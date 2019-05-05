
import { BookingdetailsService } from 'src/service/bookingdetails/bookingdetails.service';
import { Component, OnInit, NgZone, ViewChild } from '@angular/core';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';
import { BookingService } from 'src/service/booking/booking.service';
import { jqxDateTimeInputComponent } from 'jqwidgets-scripts/jqwidgets-ts/angular_jqxdatetimeinput';

@Component({
  selector: 'app-bookingdetails',
  templateUrl: './bookingdetails.component.html',
  styleUrls: ['./bookingdetails.component.css']
})
export class BookingdetailsComponent implements OnInit {
  selectedwallet = 'SAGSDETALJER';
  @ViewChild('arrivaldate') arrivaldate: jqxDateTimeInputComponent;
  @ViewChild('departdate') departdate: jqxDateTimeInputComponent;

  constructor(private bookingdetailsService: BookingdetailsService, private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private zone: NgZone,
    private choiceService: ChoiceService, private bookingService: BookingService) {

  }

  dropdownListProvision = [];
  dropdownSettings = {};
  ddlCenterInfoReason: [];

  dropdownCampaign = [];
  Referred= [];
  ReferDDL= [];
  dropdownListLeadOrigin = [];
  dropdownListforRefreshment = [];
  dropdownListforBookingstatus = [];
  dropdownListforCauseofRemoval=[];


  ngOnInit() {
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    this.GetSProvisionType();
    this.GetCenterInfoReason();
    this.GetBookingDetails();
    this.GetAllcampaigns();
    this.GetReferredbyDDL();
    this.GetAllLeadOrigin();
    this.GetAllRefreshments();
    this.GetBookingAndStatuses();
    this.GetAllCauseOfRemoval();
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


  GetBookingDetails(): any {
    this.choiceService.GetBookingDetails().subscribe(ResponceData => {
      console.log(ResponceData);

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
    debugger
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
