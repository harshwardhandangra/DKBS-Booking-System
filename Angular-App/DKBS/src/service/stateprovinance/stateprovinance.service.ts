import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';

@Injectable({
  providedIn: 'root'
})
export class StateprovinanceService {

  constructor(private commonService:CommonService) {

  }

  
  GetAllStateProvinance(): any {
    //var url ='https://my.api.mockaroo.com/regions.json?key=60e50c10';
    var url =' https://dkbs-api-dev.azurewebsites.net/choice/regions';
    return this.commonService.get(url);
  }

  GetAllPartnerType(): any {
    var url ='https://dkbs-api-dev.azurewebsites.net/choice/partnertypes';
    return this.commonService.get(url);
  }

  GetSearchType(): any {
    var url ='https://my.api.mockaroo.com/regions.json?key=60e50c10';
    return this.commonService.get(url);
  }

  GetAllLeadOrigin(): any {
    //var url ='http://dkbs-api-dev.azurewebsites.net/choice/leadoforigins';
    var url ='https://dkbs-api-dev.azurewebsites.net/choice/regions';
    return this.commonService.get(url);
  }

}
