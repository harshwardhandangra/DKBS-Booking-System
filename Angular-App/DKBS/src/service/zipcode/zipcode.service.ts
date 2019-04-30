import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';


@Injectable({
  providedIn: 'root'
})
export class ZipcodeService {

  constructor(private commonService:CommonService) {

   }

   SaveCreateBooking( model: any): any {
     debugger
    var url = '/BookingController';
    return this.commonService.post(url,model);
}

   GetAllZipCodes(): any {
       var url = '/choice/regions';
    return this.commonService.get(url);
  }

  GetAllcontactpersons(): any {
      var url = '/choice/regions';
    return this.commonService.get(url);
    }
}
