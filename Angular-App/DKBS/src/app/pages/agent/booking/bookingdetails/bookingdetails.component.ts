import { Component, OnInit } from '@angular/core';
import { BookingdetailsService } from 'src/service/bookingdetails/bookingdetails.service';

@Component({
  selector: 'app-bookingdetails',
  templateUrl: './bookingdetails.component.html',
  styleUrls: ['./bookingdetails.component.css']
})
export class BookingdetailsComponent implements OnInit {
  selectedwallet = 'SAGSDETALJER';
  constructor(private bookingdetailsService:BookingdetailsService) { }
  dropdownListProvision = [];
  dropdownSettings = {};
  ddlCenterInfoReason: [];
  
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


}
