import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';


@Injectable({
  providedIn: 'root'
})
export class ChoiceService {

  constructor(private commonService:CommonService) {

  }

  GetAllStateProvinance(): any {
    var url = '/choice/regions';
    return this.commonService.get(url);
  }



  GetAllregions(): any {
    var url = '/choice/regions';
    return this.commonService.get(url);
  }


  GetAlltableSets(): any {
    var url = '/choice/tableSets';
    return this.commonService.get(url);
  }


  GetAllpurposes(): any {
    var url = '/choice/purposes';
    return this.commonService.get(url);
  }


  GetAlltabletypes(): any {
    var url = '/choice/tabletypes';
    return this.commonService.get(url);
  }

  GetAllpartnertypes(): any {
    var url = '/choice/partnertypes';
    return this.commonService.get(url);
  }
  Getmaillanguages(): any {
    var url = '/choice/maillanguages';
    return this.commonService.get(url);
  }
  GetAllleadoforigins(): any {
    var url = '/choice/leadoforigins';
    return this.commonService.get(url);
  }
  GetAlllands(): any {
    var url = '/choice/lands';
    return this.commonService.get(url);
  }
  GetAllitprocedurestatus(): any {
    var url = '/choice/itprocedurestatus';
    return this.commonService.get(url);
  }
  GetAllindustrycodes(): any {
    var url = '/choice/industrycodes';
    return this.commonService.get(url);
  }
  GetAllflow(): any {
    var url = '/choice/flow';
    return this.commonService.get(url);
  }
  GetAllcrmstatus(): any {
    var url = '/choice/crmstatus';
    return this.commonService.get(url);
  }
  GetAllcoursepackagetype(): any {
    var url = '/choice/coursepackagetype';
    return this.commonService.get(url);
  }
  GetAllcontactpersons(): any {
    var url = '/choice/contactpersons';
    return this.commonService.get(url);
  }
  GetAllcampaigns(): any {
    var url = '/choice/campaigns';
    return this.commonService.get(url);
  }
  GetAllcentertypes(): any {
    var url = '/choice/centertypes';
    return this.commonService.get(url);
  }
  GetAllcentermatchings(): any {
    var url = '/choice/centermatchings';
    return this.commonService.get(url);
  }
  GetAllcauseofremovals(): any {
    var url = '/choice/causeofremovals';
    return this.commonService.get(url);
  }
  GetAllcancellationreasons(): any {
    var url = '/choice/cancellationreasons';
    return this.commonService.get(url);
  }
  GetAllpartnerEmployees(): any {
    var url = '/choice/partnerEmployees';
    return this.commonService.get(url);
  }
  GetAllBookingAlternativeServices(): any {
    var url = '/choice/BookingAlternativeServices';
    return this.commonService.get(url);
  }

  GetAllBookingArrangementTypes(): any {
    var url = '/choice/BookingArrangementTypes';
    return this.commonService.get(url);
  }
  GetAllbookings(): any {
    var url = '/choice/bookings';
    return this.commonService.get(url);
  }
  GetAllbookingReference(): any {
    var url = '/choice/bookingReference';
    return this.commonService.get(url);
  }
  GetAllcontactPeople(): any {
    var url = '/choice/contactPeople';
    return this.commonService.get(url);
  }
  GetAllmailGroups(): any {
    var url = '/choice/mailGroups';
    return this.commonService.get(url);
  }
  GetAllparticipantTypes(): any {
    var url = '/choice/participantTypes';
    return this.commonService.get(url);
  }
  GetAllprocedures(): any {
    var url = '/choice/procedures';
    return this.commonService.get(url);
  }
  GetAllprocedureReviewTypes(): any {
    var url = '/choice/procedureReviewTypes';
    return this.commonService.get(url);
  }
  GetAllprovisions(): any {
    var url = '/choice/provisions';
    return this.commonService.get(url);
  }
  GetAllBookingRooms(): any {
    var url = '/choice/BookingRooms';
    return this.commonService.get(url);
  }
  GetAlltownZipCodes(): any {
    var url = '/choice/townZipCodes';
    return this.commonService.get(url);
  }

}
