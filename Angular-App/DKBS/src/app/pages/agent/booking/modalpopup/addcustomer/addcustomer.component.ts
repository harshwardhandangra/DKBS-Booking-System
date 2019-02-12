import { Component, OnInit } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-addcustomer',
  templateUrl: './addcustomer.component.html',
  styleUrls: ['./addcustomer.component.css']
})
export class AddcustomerComponent {

  // constructor() { }
  modelref:BsModalRef

  constructor(private modalService: BsModalService) {}

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
