import { Component, OnInit, NgZone } from '@angular/core';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { TypeaheadMatch } from 'ngx-bootstrap/typeahead/typeahead-match.class';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';
import { element } from '@angular/core/src/render3';
import { BookingService } from 'src/service/booking/booking.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-createbooking',
  templateUrl: './createbooking.component.html',
  styleUrls: ['./createbooking.component.css']
})
export class CreatebookingComponent implements OnInit {
  public title = 'Places';
  public addrKeys: string[];
  public addr: object;
  public LocCompanyCustId: any;
  public LocPartnerEmpID: any;
  public LocCreateBookingCustModel: any = {};
  arrivalDate: Date = new Date();
  departDate: Date;
  DivFindCenter: boolean;
  CreateBookingModel: any = {
    "bookingId": 0,
    "partnerId": 1,
    "customerId": 1,
    "tableTypeId": 0,
    "cancellationReasonId": 1,
    "causeOfRemovalId": 1,
    "contactPersonId": 1,
    "bookingAndStatusId": 3,
    "flowId": 1,
    "mailLanguageId": 1,
    "partnerTypeId": 1,
    "participantTypeId": 0,
    "purposeId": 0,
    "leadOfOriginId": 0,
    "campaignId": 0,
    "arrivalDateTime": "",
    "departDateTime": "",
    "flexibleDates": true,
    "internalHistory": "",
    "numberOfRooms": 0,
    "otherCompaignName": "string",
    "numberOfPerticipants": 0,
    "regionIds": [],
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

  bookingRoomViewModel: any = {
    "tableSetViewModel": {
      "tableSetName": 0,
      "lastModified": new Date(),
      "lastModifiedBy": 1
    },
    "locationAttraction": "",
    "numberOfRooms": "",
    "perPerson": "",
    "toDate": "",
    "fromDate": ""
  };
  bookingArrangementTypeViewModel: any = {
    "serviceCatalogId": 0,
    "numberOfParticipants": "",
    "toDate": "",
    "fromDate": ""
  };
  bookingAlternativeServiceViewModel: any = {
    "numberOfPieces": "",
    "description": "",
    "createdDate": new Date(),
    "createdBy": 1,
    "lastModified": new Date(),
    "lastModifiedBy": 1
  };
  tableSetViewModel: any = {};
  mytime1: Date | undefined = new Date();
  mytime2: Date | undefined = new Date();
  ArrivalDate = new Date();
  DepartDate = new Date();
  selectedwallet: number;
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
  dropdownListforRefreshment = [];
  dropdownListCenter = [];
  dropdownSettings = {};
  arrivalTime: Date;
  departTime: Date;

  ngOnInit() {
    this.selectedwallet = 1;
    var departDate = new Date();
    this.departDate = new Date(departDate.setDate(departDate.getDate() + 1))
    this.arrivalTime = new Date();
    this.departTime = new Date();
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
    this.GetAllRefreshments();
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
    this.CreateBookingModel.partnerId = event.item.partnerEmployeeId;
    // this.LocPartnerEmpID = 1;
    this.GetAllRefer(event.item.partnerEmployeeId);

  }
  onSelect(event: TypeaheadMatch): void {
    this.GetContactbyCompany(event.item.partnerId);
  }
  onSelectCompany(event: TypeaheadMatch): void {
    // debugger
    this.CreateBookingModel.customerId = event.item.customerId;
    // this.CreateBookingModel.customerId = 921;
    this.GetContactbyCompany(this.CreateBookingModel.customerId);
  }

  onItemSelect(item: any) {
    this.CreateBookingModel.regionIds.push(item.item_id)
    this.CreateBookingModel.regionIds = this.CreateBookingModel.regionIds.map(item => item)
    console.log(item);
  }
  onSelectAll(items: any) {
    items.forEach(element => {
      this.CreateBookingModel.regionIds.push(element.item_id);
    });
    this.CreateBookingModel.regionIds = this.CreateBookingModel.regionIds.map(item => item)
    console.log(items);
  }
  onItemDeSelect(item: any) {
    // this.CreateBookingModel.regionIds.splice(item.item_id)
    console.log(item);
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
  constructor(private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private zone: NgZone,
    private choiceService: ChoiceService, private bookingService: BookingService, private router: Router) {

  }

  onSubmit() {
    var arrivalDateTime = (this.arrivalDate.getMonth() + 1) + "/" + this.arrivalDate.getDate() + "/" + this.arrivalDate.getFullYear() + " " + this.arrivalTime.getHours() + ":" + this.arrivalTime.getMinutes();
    this.CreateBookingModel.arrivalDateTime = new Date(arrivalDateTime);
    var departDateTime = (this.departDate.getMonth() + 1) + "/" + this.departDate.getDate() + "/" + this.departDate.getFullYear() + " " + this.departTime.getHours() + ":" + this.departTime.getMinutes();
    this.CreateBookingModel.departDateTime = new Date(departDateTime);
    var bookingArrangementTypeViewModel = [];
    var bookingArrangementTypeViewModelfromDateTime = this.bookingArrangementTypeViewModel.fromDate != "" ? (this.bookingArrangementTypeViewModel.fromDate.getMonth() + 1) + "/" + this.bookingArrangementTypeViewModel.fromDate.getDate() + "/" + this.bookingArrangementTypeViewModel.fromDate.getFullYear() + " " + this.bookingArrangementTypeViewModel.fromTime.getHours() + ":" + this.bookingArrangementTypeViewModel.fromTime.getMinutes() : "";
    var bookingArrangementTypeViewModeltoDateTime = this.bookingArrangementTypeViewModel.toDate != "" ? (this.bookingArrangementTypeViewModel.toDate.getMonth() + 1) + "/" + this.bookingArrangementTypeViewModel.toDate.getDate() + "/" + this.bookingArrangementTypeViewModel.toDate.getFullYear() + " " + this.bookingArrangementTypeViewModel.toTime.getHours() + ":" + this.bookingArrangementTypeViewModel.toTime.getMinutes() : "";
    bookingArrangementTypeViewModel.push({
      "serviceCatalogId": this.bookingArrangementTypeViewModel.serviceCatalogId,
      "numberOfParticipants": this.bookingArrangementTypeViewModel.numberOfParticipants,
      "toDateTime": new Date(bookingArrangementTypeViewModelfromDateTime),
      "fromDateTime": new Date(bookingArrangementTypeViewModeltoDateTime)
    });
    this.Arrangementtype.forEach(element => {
      var elementfromDateTime = element.fromDate != "" ? (element.fromDate.getMonth() + 1) + "/" + element.fromDate.getDate() + "/" + element.fromDate.getFullYear() + " " + element.fromTime.getHours() + ":" + element.fromTime.getMinutes() : "";
      var elementtoDateTime = element.toDate != "" ? (element.toDate.getMonth() + 1) + "/" + element.toDate.getDate() + "/" + element.toDate.getFullYear() + " " + element.toTime.getHours() + ":" + element.toTime.getMinutes() : "";
      bookingArrangementTypeViewModel.push({
        "serviceCatalogId": element.serviceCatalogId,
        "numberOfParticipants": element.numberOfParticipants,
        "toDate": new Date(elementfromDateTime),
        "fromDate": new Date(elementtoDateTime)
      });
    });
    var bookingRoomViewModel = [];
    var bookingRoomViewModelfromDateTime = this.bookingRoomViewModel.toDate != "" ? (this.bookingRoomViewModel.fromDate.getMonth() + 1) + "/" + this.bookingRoomViewModel.fromDate.getDate() + "/" + this.bookingRoomViewModel.fromDate.getFullYear() + " " + this.bookingRoomViewModel.fromTime.getHours() + ":" + this.bookingRoomViewModel.fromTime.getMinutes() : "";
    var bookingRoomViewModeltoDateTime = this.bookingRoomViewModel.toDate != "" ? (this.bookingRoomViewModel.toDate.getMonth() + 1) + "/" + this.bookingRoomViewModel.toDate.getDate() + "/" + this.bookingRoomViewModel.toDate.getFullYear() + " " + this.bookingRoomViewModel.toTime.getHours() + ":" + this.bookingRoomViewModel.toTime.getMinutes() : "";
    bookingRoomViewModel.push({
      "tableSetViewModel": {
        "tableSetName": this.bookingRoomViewModel.tableSetName,
        "lastModified": new Date(),
        "lastModifiedBy": "1"
      },
      "locationAttraction": this.bookingRoomViewModel.locationAttraction,
      "numberOfRooms": this.bookingRoomViewModel.numberOfRooms,
      "perPerson": this.bookingRoomViewModel.perPerson,
      "toDate": new Date(bookingRoomViewModeltoDateTime),
      "fromDate": new Date(bookingRoomViewModelfromDateTime)
    });

    this.RoomMultilstType.forEach(element => {
      var elementfromDateTime = element.fromDate != null ? (element.fromDate.getMonth() + 1) + "/" + element.fromDate.getDate() + "/" + element.fromDate.getFullYear() + " " + element.fromTime.getHours() + ":" + element.fromTime.getMinutes() : "";
      var elementtoDateTime = element.toDate != null ? (element.toDate.getMonth() + 1) + "/" + element.toDate.getDate() + "/" + element.toDate.getFullYear() + " " + element.toTime.getHours() + ":" + element.toTime.getMinutes() : "";
      bookingRoomViewModel.push({
        "tableSetViewModel": {
          "tableSetName": element.tableSetName,
          "lastModified": new Date(),
          "lastModifiedBy": "1"
        },
        "locationAttraction": element.locationAttraction,
        "numberOfRooms": element.numberOfRooms,
        "perPerson": element.perPerson,
        "toDate": new Date(elementtoDateTime),
        "fromDate": new Date(elementfromDateTime)
      });
    });

    var bookingAlternativeServiceViewModel = [];
    bookingAlternativeServiceViewModel.push(this.bookingAlternativeServiceViewModel)
    this.GiveprizeMultilstType.forEach(element => {
      bookingAlternativeServiceViewModel.push(element)
    })
    this.CreateBookingModel.bookingArrangementTypeViewModel = bookingArrangementTypeViewModel;
    this.CreateBookingModel.bookingRoomViewModel = bookingRoomViewModel;
    this.CreateBookingModel.partnerId = 1;
    this.CreateBookingModel.bookingAlternativeServiceViewModel = bookingAlternativeServiceViewModel;
    this.bookingService.SaveBooking(this.CreateBookingModel).subscribe(res => {
      if (res.bookingId != 0) {
        this.router.navigate(['/allcases']);
      }
    });
  }
  GetAllZipCodes(): any {
    this.zipcodeService.GetAllZipCodes().subscribe(res => {
      this.states = res;
    });
  }
  GetCompany(): any {

    this.choiceService.GetAllcustomerCompany().subscribe(res => {
      this.company = res;
    });
  }

  GetContactbyCompany(partnerID): any {
    debugger
    this.choiceService.GetContactbyCompany(partnerID).subscribe(res => {
      this.ContactPerson = res;
      // this.LocCreateBookingCustModel.Mobile=res[0].telephone;
      this.LocCreateBookingCustModel.Email = res[0].email;
      this.LocCreateBookingCustModel.Telephone = res[0].telephone;
    });
  }



  GetContactPerson(): any {
    this.zipcodeService.GetAllcontactpersons().subscribe(res => {
      this.ContactPerson = res;
    });
  }
  GetPartnerforFindCenter(): any {
    this.choiceService.GetPartnerforFindCenter().subscribe(res => {
      for (let i = 0; i < res.length; ++i) {
        this.dropdownListCenter.push({ item_id: res[i].partnerId, item_text: res[i].partnerName });
      }
    });
    setTimeout(function () {
      this.DivFindCenter = true;
    }.bind(this), 500);
  }

  // OnclickFindCenter(): void {
  //   this.CreateBookingModel.customerId;
  //   //pass ids.string to get centers
  //   this.choiceService.GetCenterbyfilter().subscribe(res => {
  //     this.ContactPerson = res;
  //     console.log(res);      
  //   });
  // }

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
      this.dropdownListLeadOrigin.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownListLeadOrigin.push({ item_id: state[i].leadOfOriginId, item_text: state[i].name });
      }
    });
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
  GetAllRefer(PartnerEMpID): any {
    this.choiceService.GetpartnersEmployeebyID(PartnerEMpID).subscribe(res => {
      this.ReferDDL = res;
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
  GetReferredbyDDL(): any {
    this.choiceService.GetpartnersEmployee().subscribe(res => {
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
      this.dropdownCampaign.push({ item_id: 0, item_text: 'Select' })
      for (let i = 0; i < state.length; ++i) {
        this.dropdownCampaign.push({ item_id: state[i].campaignId, item_text: state[i].name });
      }
    });
  }

  GetAllRefreshments(): any {
    this.choiceService.GetAllRefreshments().subscribe(res => {
      for (let i = 0; i < res.length; ++i) {
        this.dropdownListforRefreshment.push({ item_id: res[i].refreshmentId, item_text: res[i].name });
      }
    })
  }
}
