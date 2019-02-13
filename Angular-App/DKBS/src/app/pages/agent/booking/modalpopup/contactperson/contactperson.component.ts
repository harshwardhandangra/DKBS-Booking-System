import { Component, OnInit } from '@angular/core';
import { BsModalService,BsModalRef } from 'ngx-bootstrap';

@Component({
  selector: 'app-contactperson',
  templateUrl: './contactperson.component.html',
  styleUrls: ['./contactperson.component.css']
})
export class ContactpersonComponent {

  selectedwallet = 'Generalkp';
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
