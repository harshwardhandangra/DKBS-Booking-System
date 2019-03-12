import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }


  columnDefs = [
    {headerName: 'Make', field: 'make',sortable: true},
    {headerName: 'Model', field: 'model',sortable: true, filter: true},
    {headerName: 'Price', field: 'price',sortable: true, filter: true},
    {headerName: 'Models', field: 'price',sortable: true, filter: true},
    {headerName: 'Prices', field: 'price',sortable: true, filter: true},
    {headerName: 'Makes', field: 'price',sortable: true, filter: true}
];

rowData = [
    {make: 'Toyota', model: 'Celica', price: 35000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Ford', model: 'Mondeo', price: 32000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Porsche', model: 'Boxter', price: 72000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Toyota', model: 'Celica', price: 35000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Ford', model: 'Mondeo', price: 32000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Porsche', model: 'Boxter', price: 72000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Toyota', model: 'Celica', price: 35000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Ford', model: 'Mondeo', price: 32000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Porsche', model: 'Boxter', price: 72000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Toyota', model: 'Celica', price: 35000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Ford', model: 'Mondeo', price: 32000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Porsche', model: 'Boxter', price: 72000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Toyota', model: 'Celica', price: 35000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Ford', model: 'Mondeo', price: 32000, Models: 'Toyota', Prices: 'Celica', Makes: 35000},
    {make: 'Porsche', model: 'Boxter', price: 72000, Models: 'Toyota', Prices: 'Celica', Makes: 35000}
];
private gridApi;
onBtExport()
{
var params={

};
this.gridApi.exportDataAsExcel(params)
}



}
