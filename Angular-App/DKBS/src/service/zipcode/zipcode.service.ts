import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';


@Injectable({
  providedIn: 'root'
})
export class ZipcodeService {

  constructor(private commonService:CommonService) {

   }

   GetAllZipCodes(): any {
  //  var url ='https://my.api.mockaroo.com/ZipCode.json?key=60e50c10';
      var url = '/choice/regions';
    // var url =' http://dkbs-api-dev.azurewebsites.net/choice/regions';
   
    return this.commonService.get(url);
  }

  GetAllcontactpersons(): any {
    //  var url ='https://my.api.mockaroo.com/ZipCode.json?key=60e50c10';
      //var url =' http://dkbs-api-dev.azurewebsites.net/choice/regions';
      var url = '/choice/regions';
      return this.commonService.get(url);
    }
}
