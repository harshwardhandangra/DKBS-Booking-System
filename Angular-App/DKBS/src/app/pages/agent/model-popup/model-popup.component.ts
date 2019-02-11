import { Component } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap';


@Component({
  selector: 'app-model-popup',
  templateUrl: './model-popup.component.html',
  styleUrls: ['./model-popup.component.css']
})
export class ModelPopupComponent {

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
