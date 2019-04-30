import { Injectable,Inject } from '@angular/core';
import { Router } from '@angular/router';
import { Http,Response, RequestOptions,Headers, ResponseContentType } from '@angular/http';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
// import { AppUser } from 'src/model/app-user';
import { GlobalConfig } from 'src/global-config';
import { DOCUMENT } from '@angular/platform-browser';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

  // constructor() { }

  public baseUrl: string = "";
  public accessToken: string = '';

  constructor(private _http: Http,private router: Router,@Inject(DOCUMENT) private document: any) {
      if(document.location.hostname=="localhost"){
        this.baseUrl = GlobalConfig.ApiUrl + '/';
      }else{
        this.baseUrl = GlobalConfig.ApiUrl + '/';
      }
  }

  public getHeader(): RequestOptions {
    var item = localStorage.getItem('loggedInUser');
    // var jsonObject: AppUser = JSON.parse(item);
    // if (jsonObject != null && jsonObject.user_token != null) {
    //   this.accessToken = jsonObject.user_token as string;
    //}
    let cpHeaders = new Headers({ 'Content-Type': 'application/json' });
    // cpHeaders.append('Authorization', 'Bearer ' + this.accessToken);
    let options = new RequestOptions({ headers: cpHeaders });
    return options;
  }


  getToken(): string {
    var item = localStorage.getItem('loggedInUser');
  // //  var jsonObject: AppUser = JSON.parse(item);
  //   if (jsonObject != null && jsonObject.user_token != null) {
  //     return jsonObject.user_token as string;
  //   }
    return '';
  }

  
  getuserRole(): string {
    var item = localStorage.getItem('loggedInUser');
    // var jsonObject: AppUser = JSON.parse(item);
    // if (jsonObject != null && jsonObject.user_token != null) {
    //   return jsonObject.user_role_id as string;
    // }
    return '';
  }

  

  post(url: string, model: any): Observable<any> {
    debugger
    var response = this._http.post(this.baseUrl + url, model, this.getHeader())
    .pipe(map((response: any) => response.json()),
    catchError(this.handleError('getData')));
    return response;
  }


  get(url: string): Observable<any> {    
    
   var response = this._http.get(this.baseUrl + url, this.getHeader()).pipe(map(data => <any>data.json()),
   //var response = this._http.get( url, this.getHeader()).pipe(map(data => <any>data.json()),
    catchError(this.handleError('getData')));  
    return response;
  }

  downloadFile(url:string): Observable<Blob> {
    let options = this.getHeader();
    options.responseType= ResponseContentType.Blob;
    var response = this._http.get(this.baseUrl + url, options).pipe(map(res => res.blob()),
    catchError(this.handleError('getData')));  
    return response;
  }

  getwithParams(url: string,model:any): Observable<any> {
    var response = this._http.get(this.baseUrl + url, this.getHeader()).pipe(map(data => <any>data.json()),
    catchError(this.handleError('getData')));
    return response;
  }

  delete(url: string): Observable<boolean> {
    var response = this._http.delete(this.baseUrl + url, this.getHeader()).pipe(map((response:Response) => response.json()),
    catchError(this.handleError('getData')));
    return response;
  }

  buildQueryString = function ($params) {


    var queryParams = [];
  
    for (var k in $params) {
        if ($params.hasOwnProperty(k)) {
            queryParams.push(encodeURIComponent(k) + "=" + encodeURIComponent($params[k]));
            //queryParams.push(k + "=" + $params[k]);
        }
    }
  
    return queryParams.join("&");
  }


  private handleError(operation: String) {
    return (err: any) => {
        let errMsg = `error in`;       
        if(err.status==401){
            this.router.navigate(['/']);
        }
        if(err.status==400){
          alert('User name or password is incorrect, please enter valid credentials!');
      }
        return Observable.throw(errMsg);
    }
  }

}
