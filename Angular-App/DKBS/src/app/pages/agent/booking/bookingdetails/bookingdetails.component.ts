
import { BookingdetailsService } from 'src/service/bookingdetails/bookingdetails.service';
import { Component, OnInit, NgZone } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';
import { element } from '@angular/core/src/render3';
import { BookingService } from 'src/service/booking/booking.service';

@Component({
  selector: 'app-bookingdetails',
  templateUrl: './bookingdetails.component.html',
  styleUrls: ['./bookingdetails.component.css']
})
export class BookingdetailsComponent implements OnInit {
  selectedwallet = 'SAGSDETALJER';
  //constructor(private bookingdetailsService:BookingdetailsService) { }

  constructor(private bookingdetailsService:BookingdetailsService, private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private zone: NgZone,
    private choiceService: ChoiceService, private bookingService: BookingService) {

  }

  dropdownListProvision = [];
  dropdownSettings = {};
  ddlCenterInfoReason: [];

  dropdownCampaign = [];
  
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
      this.ddlCenterInfoReason=state;
        console.log(state);
    // for (let i = 0; i < state.length; ++i) {
    //   this.dropdownListProvision.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
    // }
     });
   }

   GetAllcampaigns(): any {
    this.choiceService.GetAllcampaigns().subscribe(state => {
      this.dropdownCampaign.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownCampaign.push({ item_id: state[i].campaignId, item_text: state[i].name });
      }
    });
  }
}
