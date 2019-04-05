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
  dropdownListLeadOrigin = [];
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
    this.GetAllZipCodes();
    this.GetAllStateProvinance();
    this.GetAllPartnerType();
    this.GetCompany();
    this.GetContactPerson();
    this.GetAllLeadOrigin();
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
     console.log(this.company);   
     });
   }
   GetContactPerson(): any {
    this.zipcodeService.GetAllcontactpersons().subscribe(res => {    
     this.ContactPerson=res;   
     console.log("vsd");   
     console.log(this.ContactPerson);   

     });
   }

   GetAllStateProvinance(): any {
    this.stateprovinanceService.GetAllStateProvinance().subscribe(state => {
     console.log(state);
    for (let i = 0; i < state.length; ++i) {
      this.dropdownList.push({ item_id: state[i].regionId, item_text: state[i].name });
    }
     });
   }


   GetAllPartnerType(): any {
    this.stateprovinanceService.GetAllPartnerType().subscribe(state => {   
    for (let i = 0; i < state.length; ++i) {
      this.dropdownListforSearchType.push({ item_id: state[i].partnerTypeId, item_text: state[i].partnerTypeTitle });
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


   GetAllLeadOrigin(): any {
    this.stateprovinanceService.GetAllLeadOrigin().subscribe(state => {
      console.log("sonar");   
     console.log(state);
    for (let i = 0; i < state.length; ++i) {
      this.dropdownListLeadOrigin.push({ item_id: state[i].regionId, item_text: state[i].name });
      console.log(this.dropdownListLeadOrigin);   
      console.log("sonar");  
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
