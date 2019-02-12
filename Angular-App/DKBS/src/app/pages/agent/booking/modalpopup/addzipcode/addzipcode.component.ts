import { Component, OnInit } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-addzipcode',
  templateUrl: './addzipcode.component.html',
  styleUrls: ['./addzipcode.component.css']
})
export class AddzipcodeComponent {

  // constructor() { }

  // ngOnInit() {
  // }

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
