import { Component, OnInit } from '@angular/core';
import { ZipcodeService } from 'src/service/zipcode/zipcode.service';
import { StateprovinanceService } from 'src/service/stateprovinance/stateprovinance.service';
import { ChoiceService } from 'src/service/Choice/Choice.service';
import { Subject } from 'rxjs';
@Component({
  selector: 'app-allcases',
  templateUrl: './allcases.component.html',
  styleUrls: ['./allcases.component.css']
})
export class AllcasesComponent implements OnInit {



  AllCasesModel: any = {
    "bookingId": 0,
    "partnerId": 0,    
  }


  constructor(private zipcodeService: ZipcodeService, private stateprovinanceService: StateprovinanceService, private choiceService: ChoiceService) {

  }
  
  Allcaseslst:any = [];

  ngOnInit() {
    this.GetAllCases();
  }

  GetAllCases(): any {
    
    this.choiceService.GetAllcases().subscribe(ResponceData => {
      this.Allcaseslst=ResponceData;     
      
    });
  }


}
