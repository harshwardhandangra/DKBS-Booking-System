
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

  updateBookingModel: any;
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
  ReferDDL = [];
  dropdownListLeadOrigin = [];
  dropdownListforRefreshment = [];
  dropdownListforBookingstatus = [];
  dropdownListforCauseofRemoval = [];


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
    setTimeout(function () {
      this.selectedwallet = 1;
      this.GetBookingDetails(bookingId);
    }.bind(this), 1000)
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
}
