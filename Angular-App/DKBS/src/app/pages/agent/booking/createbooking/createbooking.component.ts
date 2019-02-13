import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-createbooking',
  templateUrl: './createbooking.component.html',
  styleUrls: ['./createbooking.component.css']
})
export class CreatebookingComponent implements OnInit {

  selectedwallet = 'Kundeoplysniger';

  private Arrangementtype: Array<any> = [];
    private newAttribute: any = {};

    addFieldValue() {
        this.Arrangementtype.push(this.newAttribute)
        this.newAttribute = {};
    }

    deleteFieldValue(index) {
        this.Arrangementtype.splice(index, 1);
    }
    
  constructor() { }

  ngOnInit() {
  }

}
