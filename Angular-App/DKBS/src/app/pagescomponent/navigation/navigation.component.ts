import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  selectedwallet = 'Kundeoplysniger';
  submenu1: boolean;
  submenu2: boolean;
  submenu3: boolean;
  submenu4: boolean;
  submenu5: boolean;
  constructor() { }

  ngOnInit() {
  }

}
