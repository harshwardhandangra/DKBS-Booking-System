import { Component, OnInit ,NgZone} from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';


@Component({
  selector: 'app-createbooking',
  templateUrl: './createbooking.component.html',
  styleUrls: ['./createbooking.component.css']
})
export class CreatebookingComponent implements OnInit {
  public title = 'Places';
  public addrKeys: string[];
  public addr: object;
  
  mytime1: Date | undefined = new Date();
  mytime2: Date | undefined = new Date();
  ArrivalDate = new Date();
  DepartDate = new Date();

  selectedwallet = 'Eventdetaljer';
  dropdownList = [];
  dropdownListLeadOrigin = [];
  dropdownListforSearchType = [];
  dropdownListforPartnerType = [];
  selectedItems = [];
  dropdownSettings = {};

  

  ngOnInit() {

    const time = new Date();
    time.setHours(9);
    time.setMinutes(0);

    const time2 = new Date();
    time2.setHours(5);
    time2.setMinutes(0);

    this.mytime1 = time;
    this.mytime2= time2;

    this.ArrivalDate.setDate(this.ArrivalDate.getDate() + 1);
    this.DepartDate.setDate(this.DepartDate.getDate() + 2);

  
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
    
 
  constructor(private zipcodeService:ZipcodeService, private stateprovinanceService:StateprovinanceService,private zone: NgZone,private choiceService:ChoiceService) {}
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
    this.zipcodeService.GetAllcontactpersons().subscribe(res => {    
     this.ContactPerson=res;   
    

     });
   }

   GetAllStateProvinance(): any {
    this.stateprovinanceService.GetAllStateProvinance().subscribe(state => {
    
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
    
    for (let i = 0; i < state.length; ++i) {
      this.dropdownListLeadOrigin.push({ item_id: state[i].regionId, item_text: state[i].name });
      
    }
     });
   }
  // ngOnInit() {
  // }

  GetReferredbyDDL(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {    
     this.states=res;    
     });
   }
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
