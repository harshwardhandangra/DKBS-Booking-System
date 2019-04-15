using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using DKBS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DKBS.API.Controllers
{
    /// <summary>
    /// Booking
    /// </summary>
    [Route("BookingController")]
    public class BookingController : Controller
    {
        private IChoiceRepository _choiceRepoistory;
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="choiceRepoistory"></param>
        /// <param name="mapper"></param>
        public BookingController(IChoiceRepository choiceRepoistory, IMapper mapper)
        {
            _choiceRepoistory = choiceRepoistory;
            _mapper = mapper;
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingReferenceDTO> GetBookingReference(int bookingId)
        {
            return _choiceRepoistory.GetBookingReferences().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
        }


        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingAlternativeServiceDTO> GetBookingAlternativeService(int bookingId)
        {
            return _choiceRepoistory.GetBookingAlternativeServices().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingAndStatusId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingAndStatusId}")]
        public ActionResult<BookingAndStatusDTO> GetBookingAndStatusById(int bookingAndStatusId)
        {
            return _choiceRepoistory.GetBookingAndStatuses().FirstOrDefault(c => c.BookingAndStatusId == bookingAndStatusId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingArrangementTypeDTO> GetBookingArrangementType(int bookingId)
        {
            return _choiceRepoistory.GetBookingArrangementTypes().FirstOrDefault(c => c.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingRegionDTO> GetBookingRegion(int bookingId)
        {
            return _choiceRepoistory.GetBookingRegions().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
        }

        /// <summary>
        /// Get bookingReference by booking id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{bookingId}")]
        public ActionResult<BookingRoomsDTO> GetBookingRooms(int bookingId)
        {
            return _choiceRepoistory.GetBookingRooms().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
        }

        /// <summary>
        /// Get booking by id
        /// </summary>
        /// <param name="bookingId"></param>
        /// <returns></returns>
        [HttpGet("{bookingId}", Name = "GetBookingById")]
        public ActionResult<BookingDTO> GetBookingById(int bookingId)
        {
            return _choiceRepoistory.GetBookings().FirstOrDefault(c => c.BookingId == bookingId);
        }


        /// <summary>
        /// update booking
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="bookingDto"></param>
        /// <returns></returns>
        [HttpPut("{bookingId}")]
        public IActionResult UpdateBooking(int bookingId, [FromBody] BookingDTO bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingDto == null)
                return BadRequest();

            var booking = _choiceRepoistory.GetBookings().Find(c => c.BookingId == bookingId);

            if (booking == null)
            {
                return BadRequest();
            }

            booking = bookingDto;

            _choiceRepoistory.Complete();
            return NoContent();
        }

        /// <summary>
        /// Create booking
        /// </summary>
        /// <param name="bookingDto"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreateBooking([FromBody] BookingDTO bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingDto == null)
                return BadRequest();

            var bookingEntry = _choiceRepoistory.GetBookings().Find(c => c.BookingId == bookingDto.BookingId);

            if (bookingEntry != null)
            {
                return BadRequest();
            }

            IndustryCode industryCode = _mapper.Map<IndustryCodeDTO, IndustryCode>(bookingDto.CustomerDTO.IndustryCodeDTO);

            _choiceRepoistory.AttachIndustryCode(industryCode);

            TableType newlyCreatedtableType = _mapper.Map<TableTypeDTO, TableType>(bookingDto.TableTypeDTO);
            _choiceRepoistory.SetTableType(newlyCreatedtableType);


            CancellationReason newlyCreatedCancellationReason = _mapper.Map<CancellationReasonDTO, CancellationReason>(bookingDto.CancellationReasonDTO);
            _choiceRepoistory.SetCancellationReason(newlyCreatedCancellationReason);


            CauseOfRemoval newlyCreatedCauseOfRemoval = _mapper.Map<CauseOfRemovalDTO, CauseOfRemoval>(bookingDto.CauseOfRemovalDTO);
            _choiceRepoistory.SetCauseOfRemoval(newlyCreatedCauseOfRemoval);

            ContactPerson newlyCreatedContactPerson = _mapper.Map<ContactPersonDTO, ContactPerson>(bookingDto.ContactPersonDTO);
            _choiceRepoistory.SetContactPerson(newlyCreatedContactPerson);


            BookingAndStatus newlyCreatedBookingAndStatus = _mapper.Map<BookingAndStatusDTO, BookingAndStatus>(bookingDto.BookingAndStatusDTO);
            _choiceRepoistory.SetBookingAndStatus(newlyCreatedBookingAndStatus);


            Flow newlyCreatedFlow = _mapper.Map<FlowDTO, Flow>(bookingDto.FlowDTO);
            _choiceRepoistory.SetFlow(newlyCreatedFlow);


            MailLanguage newlyCreatedmailLanguage = _mapper.Map<MailLanguageDTO, MailLanguage>(bookingDto.MailLanguageDTO);
            _choiceRepoistory.SetMailLanguage(newlyCreatedmailLanguage);


            ParticipantType newlyCreatedParticipantType = _mapper.Map<ParticipantTypeDTO, ParticipantType>(bookingDto.ParticipantTypeDTO);
            _choiceRepoistory.SetParticipantType(newlyCreatedParticipantType);


            Purpose newlyCreatedPurpose = _mapper.Map<PurposeDTO, Purpose>(bookingDto.PurposeDTO);
            _choiceRepoistory.SetPurpose(newlyCreatedPurpose);


            LeadOfOrigin newlyCreatedLeadOfOrigin = _mapper.Map<LeadOfOriginDTO, LeadOfOrigin>(bookingDto.LeadOfOriginDTO);
            _choiceRepoistory.SetLeadOfOrigin(newlyCreatedLeadOfOrigin);


            Campaign newlyCreatedCampaign = _mapper.Map<CampaignDTO, Campaign>(bookingDto.CampaignDTO);
            _choiceRepoistory.SetCampaign(newlyCreatedCampaign);

            // TODO Create all the properties accordingly : Find some other good way to map

            CenterType centerTypeMapped = _mapper.Map<CenterTypeDTO, CenterType>(bookingDto.PartnerDTO.CenterTypeDTO);
            _choiceRepoistory.SetCenterType(centerTypeMapped);

            PartnerType partnerTypeMapped = _mapper.Map<PartnerTypeDTO, PartnerType>(bookingDto.PartnerDTO.PartnerTypeDTO);
            _choiceRepoistory.SetPartnerType(partnerTypeMapped);

            var newlyCreatedCustomer = new Customer()
            {
                City = bookingDto.CustomerDTO.City,
                IndustryCode = industryCode,
                CreatedBy = bookingDto.CustomerDTO.CreatedBy,
                Country = bookingDto.CustomerDTO.Country,
                CreatedDate = bookingDto.CustomerDTO.CreatedDate,
                CustomerName = bookingDto.CustomerDTO.CustomerName,
                EmailId = bookingDto.CustomerDTO.EmailId,
                LastModifiedBY = bookingDto.CustomerDTO.LastModifiedBY,
                LastModifiedDate = bookingDto.CustomerDTO.LastModifiedDate,
                PhoneNumber = bookingDto.CustomerDTO.PhoneNumber
            };

            _choiceRepoistory.SetCreatedCustomer(newlyCreatedCustomer);

            var newlyCreatedPartner = new Partner()
            {
                PartnerId = bookingDto.PartnerDTO.PartnerId,
                CenterType = centerTypeMapped,
                PartnerType = partnerTypeMapped,
                EmailId = bookingDto.PartnerDTO.EmailId,
                LastModified = bookingDto.PartnerDTO.LastModified,
                LastModifiedBy = bookingDto.PartnerDTO.LastModifiedBy,
                PartnerName = bookingDto.PartnerDTO.PartnerName,
                PhoneNumber = bookingDto.PartnerDTO.PhoneNumber
            };

            _choiceRepoistory.SetPartner(newlyCreatedPartner);

            var newlyCreatedBooking = new Booking()
            {
                Partner = newlyCreatedPartner,
                PartnerType = partnerTypeMapped,
                Customer = newlyCreatedCustomer,
                TableType = newlyCreatedtableType,
                CancellationReason = newlyCreatedCancellationReason,
                CauseOfRemoval = newlyCreatedCauseOfRemoval,
                ContactPerson = newlyCreatedContactPerson,
                BookingAndStatus = newlyCreatedBookingAndStatus,
                Flow = newlyCreatedFlow,
                MailLanguage = newlyCreatedmailLanguage,
                ParticipantType = newlyCreatedParticipantType,
                Purpose = newlyCreatedPurpose,
                LeadOfOrigin = newlyCreatedLeadOfOrigin,
                Campaign = newlyCreatedCampaign,
                ArrivalDateTime = bookingDto.ArrivalDateTime,
                DepartDateTime = bookingDto.DepartDateTime,
                FlexibleDates = bookingDto.FlexibleDates,
                InternalHistory = bookingDto.InternalHistory
            };

            _choiceRepoistory.SetBookings(newlyCreatedBooking);


            _choiceRepoistory.Complete();

            return CreatedAtRoute("GetBookingById", new { bookingId = newlyCreatedBooking.BookingId }, newlyCreatedBooking);
        }

    }
}