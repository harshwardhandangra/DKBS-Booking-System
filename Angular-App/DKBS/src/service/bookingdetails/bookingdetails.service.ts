import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';

@Injectable({
  providedIn: 'root'
})
export class BookingdetailsService {

  constructor(private commonService:CommonService) { }

  GetSProvisionType(): any {
    var url ='https://my.api.mockaroo.com/regions.json?key=60e50c10';
    return this.commonService.get(url);
  }

  GetCenterInfoReason(): any {
    var url ='https://my.api.mockaroo.com/regions.json?key=60e50c10';
    return this.commonService.get(url);
  }
}
