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
            var temp = _choiceRepoistory.GetBookingReferences().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
            return temp;
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
            return _choiceRepoistory.GetBookingArrangementTypes().FirstOrDefault(c => c.BookingDTO.BookingId == bookingId);
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
        public ActionResult<BookingRoomDTO> GetBookingRooms(int bookingId)
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
            return _choiceRepoistory.GetAllBookings().FirstOrDefault(c => c.BookingId == bookingId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingId"></param>
        /// <param name="bookingViewModel"></param>
        /// <returns></returns>
        [HttpPut("{bookingId}")]
        public IActionResult UpdateBooking(int bookingId, [FromBody] BookingDTO bookingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingDTO == null)
                return BadRequest();

            var booking = _choiceRepoistory.GetById<Booking>(bookingId);

            if (booking == null)
            {
                return BadRequest();
            }

            booking.PartnerId = bookingDTO.PartnerDTO.PartnerId;
            booking.ArrivalDateTime = bookingDTO.ArrivalDateTime;
            booking.BookingAndStatusId = bookingDTO.BookingAndStatusDTO.BookingAndStatusId;
            booking.CampaignId = bookingDTO.CampaignDTO.CampaignId;
            booking.CancellationReasonId = bookingDTO.CancellationReasonDTO.CancellationReasonId;
            booking.CauseOfRemovalId = bookingDTO.CauseOfRemovalDTO.CauseOfRemovalId;
            booking.ContactPersonId = bookingDTO.ContactPersonDTO.ContactPersonId;
            booking.CustomerId = bookingDTO.CustomerDTO.CustomerId;
            booking.DepartDateTime = bookingDTO.DepartDateTime;
            booking.FlexibleDates = bookingDTO.FlexibleDates;
            booking.FlowId = bookingDTO.FlowDTO.FlowId;
            booking.InternalHistory = bookingDTO.InternalHistory;
            booking.LeadOfOriginId = bookingDTO.LeadOfOriginDTO.LeadOfOriginId;
            booking.MailLanguageId = bookingDTO.MailLanguageDTO.MailLanguageId;
            booking.ParticipantTypeId = bookingDTO.ParticipantTypeDTO.ParticipantTypeId;
            booking.PartnerTypeId = bookingDTO.PartnerTypeDTO.PartnerTypeId;
            booking.PurposeId = bookingDTO.PurposeDTO.PurposeId;
            booking.TableTypeId = bookingDTO.TableTypeDTO.TableTypeId;


            foreach (var item in bookingDTO.BookingArrangementTypeDTO)
            {
                //CoursePackage
               // var coursePackageType = _choiceRepoistory.GetById<CoursePackageType>(item.ServiceCatalogDTO.CoursePackageTypeDTO.CoursePackageTypeId);
                var serviceCatalog = _choiceRepoistory.GetById<CoursePackageType>(item.ServiceCatalogDTO.ServiceCatalogId);
                var arrangementType = _choiceRepoistory.GetById<BookingArrangementType>(item.BookingArrangementTypeId);



                //    BookingArrangementType bookingArrangementType = new BookingArrangementType()
                //    {
                //        BookingId = booking.BookingId,
                //        FromDate = item.FromDate,
                //        NumberOfParticipants = item.NumberOfParticipants,
                //        ServiceCatalog = serviceCatalog,
                //        ToDate = item.ToDate
                //    };

                //    _choiceRepoistory.Set(bookingArrangementType);
                //}

                //foreach (var item in bookingViewModel.BookingAlternativeServiceViewModel)
                //{
                //    BookingAlternativeService bookingAlternativeService = new BookingAlternativeService()
                //    {
                //        CreatedBy = item.CreatedBy,
                //        CreatedDate = item.CreatedDate,
                //        Description = item.Description,
                //        LastModifiedBy = item.LastModifiedBy,
                //        NumberOfPieces = item.NumberOfPieces,
                //        BookingId = booking.BookingId
                //    };

                //    _choiceRepoistory.Set(bookingAlternativeService);
                //}

                //_choiceRepoistory.Complete();

                //foreach (var item in bookingViewModel.RegionIds)
                //{
                //    BookingRegion bookingRegion = new BookingRegion();
                //    var region = _choiceRepoistory.GetById<Region>(item);
                //    bookingRegion.BookingId = booking.BookingId;
                //    bookingRegion.RegionId = region.RegionId;
                //    _choiceRepoistory.Set(bookingRegion);
                //}
            }
                //_choiceRepoistory.Complete();

                //_choiceRepoistory.Complete();
                return NoContent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookingViewModel"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreateBooking([FromBody] BookingViewModel bookingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (bookingViewModel == null)
                return BadRequest();

            Booking newlyCreatedBooking = _mapper.Map<BookingViewModel, Booking>(bookingViewModel);
            _choiceRepoistory.SetBookings(newlyCreatedBooking);
            _choiceRepoistory.Complete();

            foreach (var item in bookingViewModel.BookingRoomViewModel)
            {
                TableSet tableSet = new TableSet()
                {
                    LastModified = item.TableSetViewModel.LastModified,
                    LastModifiedBy = item.TableSetViewModel.LastModifiedBy,
                    TableSetName = item.TableSetViewModel.TableSetName,
                };

                BookingRoom bookingRoom = new BookingRoom()
                {
                    FromDate = item.FromDate,
                    LocationAttraction = item.LocationAttraction,
                    NumberOfRooms = item.NumberOfRooms,
                    PerPerson = item.PerPerson,
                    TableSet = tableSet,
                    ToDate = item.ToDate,
                    BookingId = newlyCreatedBooking.BookingId
                };

                _choiceRepoistory.Set(bookingRoom);
            }

            //foreach (var item in bookingViewModel.BookingArrangementTypeViewModel)
            //{
            //    //CoursePackage
            //    CoursePackageType coursePackageType = new CoursePackageType()
            //    {
            //        CoursePackageTypeTitle = item.ServiceCatalogViewModel.CoursePackageTypeViewModel.CoursePackageTypeTitle,
            //        CreatedBy = item.ServiceCatalogViewModel.CoursePackageTypeViewModel.CreatedBy,
            //        CreatedDate = item.ServiceCatalogViewModel.CoursePackageTypeViewModel.CreatedDate,
            //        LastModified = item.ServiceCatalogViewModel.CoursePackageTypeViewModel.LastModified,
            //        LastModifiedBy = item.ServiceCatalogViewModel.CoursePackageTypeViewModel.LastModifiedBy
            //    };

            //    //ServiceCatalog
            //    ServiceCatalog serviceCatalog = new ServiceCatalog()
            //    {
            //        CoursePackage = item.ServiceCatalogViewModel.CoursePackage,
            //        //CoursePackageType = coursePackageType,
            //        LastModifiedBY = item.ServiceCatalogViewModel.LastModifiedBY,
            //        Offered = item.ServiceCatalogViewModel.Offered,
            //        Price = item.ServiceCatalogViewModel.Price,
            //        LastModified = item.ServiceCatalogViewModel.LastModified
            //    };
            //    _choiceRepoistory.Complete();
            //    BookingArrangementType bookingArrangementType = new BookingArrangementType()
            //    {
            //        BookingId = newlyCreatedBooking.BookingId,
            //        FromDate = item.FromDate,
            //        NumberOfParticipants = item.NumberOfParticipants,
            //        ServiceCatalog = serviceCatalog,
            //        ToDate = item.ToDate
            //    };

            //    _choiceRepoistory.Set(bookingArrangementType);
            //    _choiceRepoistory.Complete();

            //}

            //foreach (var item in bookingViewModel.BookingAlternativeServiceViewModel)
            //{
            //    BookingAlternativeService bookingAlternativeService = new BookingAlternativeService()
            //    {
            //        CreatedBy = item.CreatedBy,
            //        CreatedDate = DateTime.Now,// item.CreatedDate,
            //        Description = item.Description,
            //        LastModifiedBy = item.LastModifiedBy,
            //        NumberOfPieces = item.NumberOfPieces,
            //        BookingId = newlyCreatedBooking.BookingId,
            //        LastModified = DateTime.Now// item.CreatedDate
            //    };

            //    _choiceRepoistory.Set(bookingAlternativeService);
            //    _choiceRepoistory.Complete();
            //}

           

            //foreach (var item in bookingViewModel.RegionIds)
            //{
            //    BookingRegion bookingRegion = new BookingRegion();
            //    var region = _choiceRepoistory.GetById<Region>(item);
            //    bookingRegion.BookingId = newlyCreatedBooking.BookingId;
            //    bookingRegion.RegionId = region.RegionId;
            //    _choiceRepoistory.Set(bookingRegion);
            //}

            //_choiceRepoistory.Complete();

            return CreatedAtRoute("GetBookingById", new { bookingId = newlyCreatedBooking.BookingId }, newlyCreatedBooking);
        }

    }
}