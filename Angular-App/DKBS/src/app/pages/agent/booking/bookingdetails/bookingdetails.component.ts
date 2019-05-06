
import { BookingdetailsService } from 'src/service/bookingdetails/bookingdetails.service';
import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';
import { BookingService } from 'src/service/booking/booking.service';
import { jqxDateTimeInputComponent } from 'jqwidgets-scripts/jqwidgets-ts/angular_jqxdatetimeinput';
import { ActivatedRoute, Router } from '@angular/router';
import { jqxDropDownListComponent } from 'jqwidgets-scripts/jqwidgets-ts/angular_jqxdropdownlist';

@Component({
  selector: 'app-bookingdetails',
  templateUrl: './bookingdetails.component.html',
  styleUrls: ['./bookingdetails.component.css']
})
export class BookingdetailsComponent implements OnInit {
  selectedwallet = 0;
  @ViewChild('arrivaldate') arrivaldate: jqxDateTimeInputComponent;
  @ViewChild('departdate') departdate: jqxDateTimeInputComponent;
  @ViewChild('dropdownListforCauseofRemovalddl') dropdownListforCauseofRemovalddl: jqxDropDownListComponent;
  @ViewChild('dropdownCampaignddl') dropdownCampaignddl: jqxDropDownListComponent;
  @ViewChild('dropdownListforBookingstatusddl') dropdownListforBookingstatusddl: jqxDropDownListComponent;
  @ViewChild('ddlReferred') ddlReferred: jqxDropDownListComponent;
  @ViewChild('dropdownListLeadOriginddl') dropdownListLeadOriginddl: jqxDropDownListComponent;

  updateBookingModel: any = {
    "bookingId": 0,
    "partnerDTO": {
      "partnerId": 0,
      "partnerName": "string",
      "emailId": "string",
      "centerTypeDTO": {
        "centerTypeId": 0,
        "centerTypeTitle": "string",
        "lastModified": "2019-05-06T16:05:42.255Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-05-06T16:05:42.255Z",
        "createdBy": "string"
      },
      "partnerTypeDTO": {
        "partnerTypeId": 0,
        "partnerTypeTitle": "string",
        "lastModified": "2019-05-06T16:05:42.257Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-05-06T16:05:42.257Z",
        "createdBy": "string"
      },
      "phoneNumber": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string"
    },
    "customerDTO": {
      "customerId": 0,
      "customerName": "string",
      "emailId": "string",
      "phoneNumber": "string",
      "industryCode": "string",
      "country": "string",
      "city": "string",
      "createdBy": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "lastModifiedDate": "2019-05-06T16:05:42.257Z",
      "lastModifiedBY": "string"
    },
    "tableTypeDTO": {
      "tableTypeId": 0,
      "tableTypeName": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBY": "string"
    },
    "cancellationReasonDTO": {
      "cancellationReasonId": 0,
      "cancellationReasonName": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string"
    },
    "causeOfRemovalDTO": {
      "causeOfRemovalId": 0,
      "causeOfRemovalTitle": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string"
    },
    "contactPersonDTO": {
      "contactPersonId": 0,
      "name": "string",
      "customerId": 0,
      "email": "string",
      "telephone": "string"
    },
    "bookingAndStatusDTO": {
      "bookingAndStatusId": 0,
      "bookingerIncidentTitle": "string",
      "slaCount": true,
      "closedStatus": true,
      "informUserByEmail": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBY": "string"
    },
    "flowDTO": {
      "flowId": 0,
      "flowName": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string"
    },
    "mailLanguageDTO": {
      "mailLanguageId": 0,
      "language": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string"
    },
    "participantTypeDTO": {
      "participantTypeId": 0,
      "participantTypeName": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string"
    },
    "purposeDTO": {
      "purposeId": 0,
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "purposeName": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBY": "string"
    },
    "leadOfOriginDTO": {
      "leadOfOriginId": 0,
      "name": "string",
      "createdDate": "2019-05-06T16:05:42.257Z",
      "createdBy": "string",
      "lastModified": "2019-05-06T16:05:42.257Z",
      "lastModifiedBy": "string"
    },
    "campaignDTO": {
      "campaignId": 0,
      "name": "string",
      "lastModified": "2019-05-06T16:05:42.258Z",
      "lastModifiedBy": "string",
      "createdDate": "2019-05-06T16:05:42.258Z",
      "createdBy": "string"
    },
    "arrivalDateTime": "2019-05-06T16:05:42.258Z",
    "departDateTime": "2019-05-06T16:05:42.258Z",
    "flexibleDates": true,
    "internalHistory": "string",
    "regionDTO": [
      {
        "regionId": 0,
        "name": "string"
      }
    ],
    "bookingRoomDTO": [
      {
        "bookingRoomId": 0,
        "bookingId": 0,
        "tableSetId": 0,
        "locationAttraction": "string",
        "numberOfRooms": 0,
        "perPerson": 0,
        "toDate": "2019-05-06T16:05:42.258Z",
        "fromDate": "2019-05-06T16:05:42.258Z"
      }
    ],
    "bookingArrangementTypeDTO": [
      {
        "bookingArrangementTypeId": 0,
        "bookingId": 0,
        "serviceCatalogId": 0,
        "numberOfParticipants": 0,
        "toDate": "2019-05-06T16:05:42.258Z",
        "fromDate": "2019-05-06T16:05:42.258Z"
      }
    ],
    "bookingAlternativeServiceDTO": [
      {
        "bookingAlternativeServiceId": 0,
        "bookingId": 0,
        "numberOfPieces": 0,
        "description": "string",
        "createdDate": "2019-05-06T16:05:42.258Z",
        "createdBy": "string",
        "lastModified": "2019-05-06T16:05:42.258Z",
        "lastModifieddBy": "string"
      }
    ],
    "procedureInfoDTO": [
      {
        "procedureInfoId": 0,
        "procedureDTO": {
          "procedureId": 0,
          "procedureName": "string",
          "causeOfRemovalDTO": {
            "causeOfRemovalId": 0,
            "causeOfRemovalTitle": "string",
            "lastModified": "2019-05-06T16:05:42.258Z",
            "lastModifiedBy": "string",
            "createdDate": "2019-05-06T16:05:42.258Z",
            "createdBy": "string"
          },
          "procedureReviewTypeDTO": {
            "procedureReviewTypeId": 0,
            "procedureReviewTypeTitle": "string",
            "lastModified": "2019-05-06T16:05:42.258Z",
            "lastModifiedBy": "string"
          },
          "lastModified": "2019-05-06T16:05:42.258Z",
          "lastModifiedBy": "string",
          "customerDTO": {
            "customerId": 0,
            "customerName": "string",
            "emailId": "string",
            "phoneNumber": "string",
            "industryCode": "string",
            "country": "string",
            "city": "string",
            "createdBy": "string",
            "createdDate": "2019-05-06T16:05:42.258Z",
            "lastModifiedDate": "2019-05-06T16:05:42.258Z",
            "lastModifiedBY": "string"
          }
        },
        "partnerDTO": {
          "partnerId": 0,
          "partnerName": "string",
          "emailId": "string",
          "centerTypeDTO": {
            "centerTypeId": 0,
            "centerTypeTitle": "string",
            "lastModified": "2019-05-06T16:05:42.258Z",
            "lastModifiedBy": "string",
            "createdDate": "2019-05-06T16:05:42.258Z",
            "createdBy": "string"
          },
          "partnerTypeDTO": {
            "partnerTypeId": 0,
            "partnerTypeTitle": "string",
            "lastModified": "2019-05-06T16:05:42.258Z",
            "lastModifiedBy": "string",
            "createdDate": "2019-05-06T16:05:42.258Z",
            "createdBy": "string"
          },
          "phoneNumber": "string",
          "lastModified": "2019-05-06T16:05:42.258Z",
          "lastModifiedBy": "string"
        },
        "emailOffer": "string",
        "reply": "string",
        "comment": "string",
        "price": "string",
        "chat": "string"
      }
    ]
  }
  dropdownLanguage: any;

  constructor(private bookingdetailsService: BookingdetailsService, private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private zone: NgZone,
    private choiceService: ChoiceService, private bookingService: BookingService, private route: ActivatedRoute, private router: Router) {

  }


  sendupdatebookingModel: any = {
    "bookingId": 0,
    "partnerId": 1,
    "customerId": 1,
    "tableTypeId": 1,
    "cancellationReasonId": 1,
    "causeOfRemovalId": 1,
    "contactPersonId": 1,
    "bookingAndStatusId": 3,
    "flowId": 1,
    "mailLanguageId": 1,
    "partnerTypeId": 1,
    "participantTypeId": 1,
    "purposeId": 1,
    "leadOfOriginId": 0,
    "campaignId": 0,
    "arrivalDateTime": "",
    "departDateTime": "",
    "flexibleDates": true,
    "internalHistory": "",
    "numberOfRooms": 1,
    "otherCompaignName": "string",
    "numberOfPerticipants": 1,
    "regionIds": [1, 2],
    "bookingRoomViewModel": [],
    "bookingArrangementTypeViewModel": [],
    "bookingAlternativeServiceViewModel": [],
    "partners": [{
      "partnerId": 1,
      "partnerName": "string",
      "emailId": "string",
      "centerTypeDTO": {
        "centerTypeId": 1,
        "centerTypeTitle": "string",
        "lastModified": "2019-04-29T13:28:34.024Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-04-29T13:28:34.024Z",
        "createdBy": "string"
      },
      "partnerTypeDTO": {
        "partnerTypeId": 1,
        "partnerTypeTitle": "string",
        "lastModified": "2019-04-29T13:28:34.024Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-04-29T13:28:34.024Z",
        "createdBy": "string"
      },
      "phoneNumber": "string",
      "lastModified": "2019-04-29T13:28:34.024Z",
      "lastModifiedBy": "string"
    },
    {
      "partnerId": 3,
      "partnerName": "string",
      "emailId": "string",
      "centerTypeDTO": {
        "centerTypeId": 3,
        "centerTypeTitle": "string",
        "lastModified": "2019-04-29T13:28:34.024Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-04-29T13:28:34.024Z",
        "createdBy": "string"
      },
      "partnerTypeDTO": {
        "partnerTypeId": 3,
        "partnerTypeTitle": "string",
        "lastModified": "2019-04-29T13:28:34.024Z",
        "lastModifiedBy": "string",
        "createdDate": "2019-04-29T13:28:34.024Z",
        "createdBy": "string"
      },
      "phoneNumber": "string",
      "lastModified": "2019-04-29T13:28:34.024Z",
      "lastModifiedBy": "string"
    }]
  }


  dropdownListProvision = [];
  dropdownSettings = {};
  ddlCenterInfoReason: [];

  dropdownCampaign = [];
  Referred = [];
  Company = [];
  Contact = [];
  ReferDDL = [];
  dropdownListLeadOrigin = [];
  dropdownListforRefreshment = [];
  dropdownListforBookingstatus = [];
  dropdownListforCauseofRemoval = [];
  dropdownListPurpose = [];
  dropdownListPParticipants = [];
  dropdownListTableSetting = [];
  dropdownPackageType = [];
  dropdownListforSearchType = [];
  dropdownListforCenterMatching = [];
  dropdownList = [];

  dropdownListforPartnerType = [];
  ngOnInit() {
    var bookingId = this.route.snapshot.params["id"];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    // this.GetSProvisionType();
    // this.GetCenterInfoReason();
    this.GetAllcampaigns();
    this.GetReferredbyDDL();
    this.GetAllLeadOrigin();
    this.GetAllRefreshments();
    this.GetBookingAndStatuses();
    this.GetAllCauseOfRemoval();
    this.GetAllLanguage();
    this.GetAllPurpose();
    this.GetAllTableSetting();
    this.GetAllParticipants();
    this.GetAllServiceCatalogs();
    this.GetCompany();
    this.GetAllCeterMatching();
    this.GetAllStateProvinance();
    this.GetAllPartnerType();
    this.GetSearchType();
    this.selectedwallet = 1;
    // setTimeout(function () {
    //   this.selectedwallet = 1;
    //   this.GetBookingDetails(bookingId);
    // }.bind(this), 1000)
  }

  private Arrangementtype: any = [];
  private RoomMultilstType: Array<any> = [];
  private GiveprizeMultilstType: Array<any> = [];
  private locbookingRoomViewModel: Array<any> = [];
  private locbAlternativeServiceView: Array<any> = [];
  private newAttribute: any = {};
  addFieldValue() {
    this.Arrangementtype.push(this.newAttribute);
    this.newAttribute = {};
  }
  addRoomMultilstType() {
    this.RoomMultilstType.push(this.newAttribute);
    this.newAttribute = {};
  }

  addgiveprizeMultilstType() {
    this.GiveprizeMultilstType.push(this.newAttribute);
    this.newAttribute = {};
  }
  addFieldValuebookingRoomViewModel() {
    this.locbookingRoomViewModel.push(this.newAttribute);
    this.newAttribute = {};
  }
  baddookingAlternativeServiceViewModel() {
    this.locbAlternativeServiceView.push(this.newAttribute);
    this.newAttribute = {};
  }
  deleteFieldValue(index) {
    this.Arrangementtype.splice(index, 1);
  }

  deleteFieldRoomMultilstType(index) {
    this.RoomMultilstType.splice(index, 1);
  }
  deleteFieldgiveprizeMultilstType(index) {
    this.GiveprizeMultilstType.splice(index, 1);
  }

  GetAllLanguage() {
    this.choiceService.getAllanguage().subscribe(res => {
      this.dropdownLanguage = res;
    })
  }

  updateBooking(): any {
    this.sendupdatebookingModel.bookingId = this.updateBookingModel.bookingId;
    this.sendupdatebookingModel.arrivalDateTime = this.updateBookingModel.arrivalDateTime;
    this.sendupdatebookingModel.departDateTime = this.updateBookingModel.departDateTime;
    this.sendupdatebookingModel.bookingArrangementTypeViewModel = this.updateBookingModel.bookingArrangementTypeViewModel;
    this.sendupdatebookingModel.bookingAlternativeServiceViewModel = this.updateBookingModel.bookingAlternativeServiceViewModel;
    this.sendupdatebookingModel.bookingRoomViewModel = this.updateBookingModel.bookingRoomViewModel;
    this.sendupdatebookingModel.flexibleDates = this.updateBookingModel.flexibleDates;
    this.sendupdatebookingModel.internalHistory = this.updateBookingModel.internalHistory;
    this.sendupdatebookingModel.campaignId = this.updateBookingModel.campaignDTO.campaignId;
    this.sendupdatebookingModel.mailLanguageId = this.updateBookingModel.mailLanguageDTO.mailLanguageId;
    this.sendupdatebookingModel.mailLanguageId = this.updateBookingModel.mailLanguageDTO.mailLanguageId;
    this.sendupdatebookingModel.bookingAndStatusId = this.updateBookingModel.bookingAndStatusDTO.bookingAndStatusId;
    this.sendupdatebookingModel.leadOfOriginId = this.updateBookingModel.leadOfOriginDTO.leadOfOriginId;
    this.sendupdatebookingModel.causeOfRemovalId = this.updateBookingModel.causeOfRemovalDTO.causeOfRemovalId;
    this.bookingService.updataeBooking(this.sendupdatebookingModel).subscribe(res => {
      this.router.navigate(['/allcases']);
    });
  }

  GetSProvisionType(): any {
    this.bookingdetailsService.GetSProvisionType().subscribe(state => {
      console.log(state);
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListProvision.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
      }
    });
  }

  GetCenterInfoReason(): any {
    this.bookingdetailsService.GetCenterInfoReason().subscribe(state => {
      this.ddlCenterInfoReason = state;
      console.log(state);
      // for (let i = 0; i < state.length; ++i) {
      //   this.dropdownListProvision.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
      // }
    });
  }

  //for where do you know us dropdown
  GetAllcampaigns(): any {
    this.choiceService.GetAllcampaigns().subscribe(state => {
      this.dropdownCampaign.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownCampaign.push({ item_id: state[i].campaignId, item_text: state[i].name });
      }
    });
  }


  GetBookingDetails(bookingId: any): any {
    this.choiceService.GetBookingDetails(bookingId).subscribe(ResponceData => {
      console.log(ResponceData);
      this.updateBookingModel = ResponceData;
      this.updateBookingModel.arrivalDateTime = new Date(this.updateBookingModel.arrivalDateTime)
      this.updateBookingModel.departDateTime = new Date(this.updateBookingModel.departDateTime)
      this.dropdownListforCauseofRemovalddl.selectItem(this.updateBookingModel.causeOfRemovalDTO.causeOfRemovalId)
    });
  }
  GetCompany(): any {

    this.choiceService.GetAllcustomerCompany().subscribe(res => {
      this.Company.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.Company.push({ item_id: res[i].customerId, item_text: res[i].customerName });
      }
    });
  }

  listOnSelectCompany(event: any): void {
    // debugger
    let args = event.args;
    //this.GetContactbyCompany(args.index);
    this.GetContactbyCompany(921);
  }


  GetContactbyCompany(partnerID): any {
    debugger
    this.choiceService.GetContactbyCompany(partnerID).subscribe(res => {
      this.Company.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.Company.push({ item_id: res[i].contactPersonId, item_text: res[i].name });
      }
    });
  }

  GetReferredbyDDL(): any {
    this.choiceService.GetpartnersEmployee().subscribe(res => {

      this.Referred.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.Referred.push({ item_id: res[i].partnerId, item_text: res[i].partnerName });
      }
      this.GetAllRefer('1');
    });
  }
  displayselectedwallet(step: any): any {
    this.selectedwallet = step;
    setTimeout(function () {
      if (this.selectedwallet == 3) {
        this.dropdownCampaignddl.selectItem(this.updateBookingModel.campaignDTO.campaignId)
      }
      if (this.selectedwallet == 4) {
        this.dropdownListforBookingstatusddl.selectItem(this.updateBookingModel.bookingAndStatusDTO.bookingAndStatusId)
        this.ddlReferred.selectItem(this.updateBookingModel.partnerDTO.partnerId)
        this.dropdownListLeadOriginddl.selectItem(this.updateBookingModel.leadOfOriginDTO.leadOfOriginId)
      }
    }.bind(this), 1000);
  }
  listOnSelectReferred(event: any): void {
    let args = event.args;

    this.GetAllRefer(args.index);
  };


  onSelectReferredby(event: TypeaheadMatch): void {
    // this.CreateBookingModel.partnerId = event.item.partnerEmployeeId;
    // this.LocPartnerEmpID = 1;
    this.GetAllRefer(1);
  }

  GetAllRefer(PartnerEMpID): any {

    this.choiceService.GetpartnersEmployeebyID(PartnerEMpID).subscribe(res => {
      //this.ReferDDL = res;

      this.ReferDDL.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.ReferDDL.push({ item_id: res[i].partnerEmployeeId, item_text: res[i].employeeName });
      }
    });
  }

  GetAllLeadOrigin(): any {
    this.stateprovinanceService.GetAllLeadOrigin().subscribe(state => {
      this.dropdownListLeadOrigin.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListLeadOrigin.push({ item_id: state[i].leadOfOriginId, item_text: state[i].name });
      }
    });
  }

  GetAllRefreshments(): any {
    this.choiceService.GetAllRefreshments().subscribe(res => {
      this.dropdownListforRefreshment.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.dropdownListforRefreshment.push({ item_id: res[i].refreshmentId, item_text: res[i].name });
      }
    })
  }

  GetBookingAndStatuses(): any {
    this.choiceService.GetBookingAndStatuses().subscribe(res => {
      this.dropdownListforBookingstatus.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.dropdownListforBookingstatus.push({ item_id: res[i].bookingAndStatusId, item_text: res[i].bookingerIncidentTitle });
      }
    })
  }

  GetAllCauseOfRemoval(): any {
    this.choiceService.GetAllcauseofremovals().subscribe(res => {
      this.dropdownListforCauseofRemoval.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < res.length; ++i) {
        this.dropdownListforCauseofRemoval.push({ item_id: res[i].causeOfRemovalId, item_text: res[i].causeOfRemovalTitle });
      }
    })
  }

  GetAllPurpose(): any {
    this.choiceService.GetAllpurposes().subscribe(ResponceData => {
      this.dropdownListPurpose.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListPurpose.push({ item_id: ResponceData[i].purposeId, item_text: ResponceData[i].purposeName });
      }
    });
  }
  GetAllTableSetting(): any {

    this.choiceService.GetAlltableSets().subscribe(ResponceData => {
      this.dropdownListTableSetting.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListTableSetting.push({ item_id: ResponceData[i].tableSetId, item_text: ResponceData[i].tableSetName });
      }
    });
  }
  GetAllParticipants(): any {
    this.choiceService.GetAllparticipantTypes().subscribe(ResponceData => {
      this.dropdownListPParticipants.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListPParticipants.push({ item_id: ResponceData[i].participantTypeId, item_text: ResponceData[i].participantTypeName });
      }
    });
  }

  GetAllServiceCatalogs(): any {
    this.choiceService.GetAllServiceCatalogs().subscribe(state => {
      this.dropdownPackageType.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownPackageType.push({ item_id: state[i].serviceCatalogId, item_text: state[i].coursePackage });
      }
    });
  }

  GetAllStateProvinance(): any {
    this.stateprovinanceService.GetAllStateProvinance().subscribe(state => {
      this.dropdownList.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownList.push({ item_id: state[i].regionId, item_text: state[i].name });
      }
    });
  }
  GetSearchType(): any {
    this.stateprovinanceService.GetSearchType().subscribe(state => {
      this.dropdownListforPartnerType.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListforPartnerType.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
      }
    });
  }
  GetAllPartnerType(): any {
    this.stateprovinanceService.GetAllPartnerType().subscribe(state => {
      this.dropdownListforSearchType.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListforSearchType.push({ item_id: state[i].partnerTypeId, item_text: state[i].partnerTypeTitle });
      }
    });
  }
  GetAllCeterMatching(): any {
    this.choiceService.GetAllcentermatchings().subscribe(state => {
      this.dropdownListforCenterMatching.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListforCenterMatching.push({ item_id: state[i].centerMatchingId, item_text: state[i].matchingCenter });
      }
    });
  }

}
