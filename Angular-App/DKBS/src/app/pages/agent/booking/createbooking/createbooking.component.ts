import { Component, OnInit, NgZone } from '@angular/core';
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
  CreateBookingModel: any = {};

  bookingRoomViewModel: any = {};
  bookingArrangementTypeViewModel: any = {};
  bookingAlternativeServiceViewModel: any = {};
  tableSetViewModel: any = {};
  mytime1: Date | undefined = new Date();
  mytime2: Date | undefined = new Date();
  ArrivalDate = new Date();
  DepartDate = new Date();
  selectedwallet = 'Eventdetaljer';
  dropdownList = [];
  dropdownListLeadOrigin = [];
  dropdownPackageType = [];
  dropdownCampaign = [];
  dropdownListPurpose = [];
  dropdownListPParticipants = [];
  dropdownListTableSetting = [];
  dropdownListforSearchType = [];
  dropdownListforPartnerType = [];
  selectedItems = [];
  dropdownListforCenterMatching = [];
  dropdownSettings = {};

  ngOnInit() {

    const time = new Date();
    time.setHours(9);
    time.setMinutes(0);
    const time2 = new Date();
    time2.setHours(5);
    time2.setMinutes(0);
    this.mytime1 = time;
    this.mytime2 = time2;
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
    this.GetAllPurpose();
    this.GetAllTableSetting();
    this.GetAllParticipants();
    this.GetAllRefer();
    this.GetReferredbyDDL();
    this.GetAllServiceCatalogs();
    this.GetAllcampaigns();
    this.GetAllCeterMatching();
  }

  selectedValue: string;
  selectedOption: any;
  states: any[];
  company: any[];
  ContactPerson: any[];
  Referred: any[];
  ReferDDL: any[];

  onSelectReferredby(event: TypeaheadMatch): void {
    this.CreateBookingModel.customerId = event.item.partnerId;
  }
  onSelect(event: TypeaheadMatch): void {
    this.CreateBookingModel.partnerId = event.item.partnerId;
  }
  onItemSelect(item: any) {
    console.log(item);
  }
  onSelectAll(items: any) {
    console.log(items);
  }
  private Arrangementtype: Array<any> = [];
  private locbookingRoomViewModel: Array<any> = [];
  private locbAlternativeServiceView: Array<any> = [];

  private newAttribute: any = {};

  addFieldValue() {
    this.Arrangementtype.push(this.bookingArrangementTypeViewModel)
    this.newAttribute = {};
  }

  addFieldValuebookingRoomViewModel() {
    this.locbookingRoomViewModel.push(this.bookingRoomViewModel)
    this.newAttribute = {};
  }
  baddookingAlternativeServiceViewModel() {
    this.locbAlternativeServiceView.push(this.bookingAlternativeServiceViewModel)
    this.newAttribute = {};
  }
  deleteFieldValue(index) {
    this.Arrangementtype.splice(index, 1);
  }


  constructor(private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private zone: NgZone, private choiceService: ChoiceService) {

  }

  onSubmit() {
    this.CreateBookingModel.partnerId = 1;
    this.CreateBookingModel.customerId = 1;
    this.CreateBookingModel.cancellationReasonId = 1;
    this.CreateBookingModel.causeOfRemovalId = 1;
    this.CreateBookingModel.contactPersonId = 1;
    this.CreateBookingModel.bookingAndStatusId = 3;
    this.CreateBookingModel.flowId = 1;
    this.CreateBookingModel.partnerTypeId = 1;
    this.CreateBookingModel.mailLanguageId = 1;
    this.CreateBookingModel.otherCompaignName = "Test from webapp_Vishal";
    this.CreateBookingModel.flexibleDates = true;
    this.CreateBookingModel.bookingArrangementTypeViewModel = [this.bookingArrangementTypeViewModel];
    this.CreateBookingModel.bookingRoomViewModel = [this.bookingRoomViewModel]
    this.CreateBookingModel.bookingAlternativeServiceViewModel = [this.bookingAlternativeServiceViewModel]
    this.CreateBookingModel.bookingRoomViewModel.tableSetViewModel = this.tableSetViewModel;
  }
  GetAllZipCodes(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {
      this.states = res;
    });
  }
  GetCompany(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {
      this.company = res;
    });
  }
  GetContactPerson(): any {
    this.zipcodeService.GetAllcontactpersons().subscribe(res => {
      this.ContactPerson = res;
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
  GetAllCeterMatching(): any {
    this.choiceService.GetAllcentermatchings().subscribe(state => {

      for (let i = 0; i < state.length; ++i) {
        this.dropdownListforCenterMatching.push({ item_id: state[i].centerMatchingId, item_text: state[i].matchingCenter });
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
        this.dropdownListLeadOrigin.push({ item_id: state[i].leadOfOriginId, item_text: state[i].name });
      }
    });
  }
  GetAllPurpose(): any {
    this.choiceService.GetAllpurposes().subscribe(ResponceData => {
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListPurpose.push({ item_id: ResponceData[i].purposeId, item_text: ResponceData[i].purposeName });
      }
    });
  }
  GetAllTableSetting(): any {
    this.choiceService.GetAlltableSets().subscribe(ResponceData => {
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListTableSetting.push({ item_id: ResponceData[i].tableSetId, item_text: ResponceData[i].tableSetName });
      }
    });
  }
  GetAllParticipants(): any {
    this.choiceService.GetAllparticipantTypes().subscribe(ResponceData => {
      for (let i = 0; i < ResponceData.length; ++i) {
        this.dropdownListPParticipants.push({ item_id: ResponceData[i].participantTypeId, item_text: ResponceData[i].participantTypeName });
      }
    });
  }
  GetAllRefer(): any {
    this.choiceService.Getpartners().subscribe(res => {
      this.ReferDDL = res;
    });
  }
  GetAllServiceCatalogs(): any {
    this.choiceService.GetAllServiceCatalogs().subscribe(state => {
      for (let i = 0; i < state.length; ++i) {
        this.dropdownPackageType.push({ item_id: state[i].serviceCatalogId, item_text: state[i].coursePackage });
      }
    });
  }
  GetReferredbyDDL(): any {
    this.choiceService.Getpartners().subscribe(res => {
      this.Referred = res;
    });
  }
  setAddress(addrObj) {

    //We are wrapping this in a zone method to reflect the changes
    //to the object in the DOM.
    this.zone.run(() => {
      this.addr = addrObj;
      this.addrKeys = Object.keys(addrObj);
      console.log(this.addr);
    });
  }


  GetAllcampaigns(): any {
    this.choiceService.GetAllcampaigns().subscribe(state => {
      for (let i = 0; i < state.length; ++i) {
        this.dropdownCampaign.push({ item_id: state[i].campaignId, item_text: state[i].name });
      }
    });
  }

}
