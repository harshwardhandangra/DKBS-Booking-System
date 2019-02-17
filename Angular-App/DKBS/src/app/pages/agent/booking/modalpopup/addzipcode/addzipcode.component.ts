import { Component, OnInit } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';


@Component({
  selector: 'app-addzipcode',
  templateUrl: './addzipcode.component.html',
  styleUrls: ['./addzipcode.component.css']
})
export class AddzipcodeComponent {
  zipitem='Folder';
  // constructor() { }

  ngOnInit() {
    
    
  }


  modelref:BsModalRef

  constructor(private modalService: BsModalService,private zipcodeService:ZipcodeService) {}

  // GetAllZipCodes(): any {
  //  this.zipcodeService.GetAllZipCodes().subscribe(res => {
  //   console.log(res);
  //   });
  // }

  open(content) {
    this.modelref = this.modalService.show(content,Object.assign({},{class:'modal-lg'}))
  }

  modalRefhide() {
    if (!this.modelref) {
      return;
    }
 
    this.modelref.hide();
    this.modelref = null;
  }

}
