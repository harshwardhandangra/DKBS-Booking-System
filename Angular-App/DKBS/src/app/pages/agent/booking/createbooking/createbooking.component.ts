import { Component, OnInit ,NgZone} from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';


@Component({
  selector: 'app-createbooking',
  templateUrl: './createbooking.component.html',
  styleUrls: ['./createbooking.component.css']
})
export class CreatebookingComponent implements OnInit {
  public title = 'Places';
  public addrKeys: string[];
  public addr: object;

  selectedwallet = 'Kundeoplysniger';
  dropdownList = [];
  dropdownListforSearchType = [];
  dropdownListforPartnerType = [];
  selectedItems = [];
  dropdownSettings = {};
  ngOnInit() {
    // this.dropdownList = [
    //   { item_id: 1, item_text: 'Mumbai' },
    //   { item_id: 2, item_text: 'Bangaluru' },
    //   { item_id: 3, item_text: 'Pune' },
    //   { item_id: 4, item_text: 'Navsari' },
    //   { item_id: 5, item_text: 'New Delhi' }
    // ];
    // this.selectedItems = [
    //   { item_id: 3, item_text: 'Pune' },
    //   { item_id: 4, item_text: 'Navsari' }
    // ];
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    // this.GetAllZipCodes();
    // this.GetAllStateProvinance();
    // this.GetCompany();
    // this.GetContactPerson();
  }

  selectedValue: string;
  selectedOption: any;
  states: any[];
  company: any[];
  ContactPerson: any[];
 
  onSelect(event: TypeaheadMatch): void {
    this.selectedOption = event.item;
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  private Arrangementtype: Array<any> = [];
    private newAttribute: any = {};

    addFieldValue() {
        this.Arrangementtype.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index) {
        this.Arrangementtype.splice(index, 1);
    }
    
 
  constructor(private zipcodeService:ZipcodeService, private stateprovinanceService:StateprovinanceService,private zone: NgZone) {}
  GetAllZipCodes(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {    
     this.states=res;    
     });
   }

   GetCompany(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {    
     this.company=res;     
     });
   }
   GetContactPerson(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {    
     this.ContactPerson=res;     
     });
   }

   GetAllStateProvinance(): any {
    this.stateprovinanceService.GetAllStateProvinance().subscribe(state => {
     console.log(state);
    for (let i = 0; i < state.length; ++i) {
      this.dropdownList.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
    }
     });
   }


   GetAllPartnerType(): any {
    this.stateprovinanceService.GetAllPartnerType().subscribe(state => {   
    for (let i = 0; i < state.length; ++i) {
      this.dropdownListforSearchType.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
    }
     });
   }

   GetSearchType(): any {
    this.stateprovinanceService.GetSearchType().subscribe(state => {   
    for (let i = 0; i < state.length; ++i) {
      this.dropdownListforPartnerType.push({ item_id: state[i].Region_Id, item_text: state[i].Region_Name });
    }
     });
   }

  // ngOnInit() {
  // }

  setAddress(addrObj) {
    
    //We are wrapping this in a zone method to reflect the changes
    //to the object in the DOM.
    this.zone.run(() => {
      this.addr = addrObj;
      this.addrKeys = Object.keys(addrObj);
      console.log(this.addr );
    });
  }

}
