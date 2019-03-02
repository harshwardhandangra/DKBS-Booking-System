import { Component, OnInit } from '@angular/core';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';

@Component({
  selector: 'app-addpartner',
  templateUrl: './addpartner.component.html',
  styleUrls: ['./addpartner.component.css']
})
export class AddpartnerComponent implements OnInit {

  constructor(private stateprovinanceService:StateprovinanceService) { }
  dropdownList = [];
  dropdownSettings = {};
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

    this.GetAllPartnerType();
  }


  GetAllPartnerType(): any {
    this.stateprovinanceService.GetAllPartnerType().subscribe(state => {   
    for (let i = 0; i < state.length; ++i) {
      this.dropdownList.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
    }
    console.log(state);
     });
   }
}
