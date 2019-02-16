import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/service/booking/booking.service';

@Component({
  selector: 'app-bookinglist',
  templateUrl: './bookinglist.component.html',
  styleUrls: ['./bookinglist.component.css']
})
export class BookinglistComponent implements OnInit {
  title = 'DKBS booking Info';
  bookingAssignedTiltle;
  IncidentAssignedTiltle;
  bookingUnAssignedTiltle;
  IncidentUnAssignedTiltle;
  bookingAssignedElements = [];
  incidentElements = [];
  bookingUnAssignedElements = [];
  IncidentUnAssignedElements = [];

  bookingTask = [
    'SRM ID',
    'Case',
    'Queries',
    'Role',
    'Booking Responsible',
    'Assigned to team',
    'Contact',
    'Company old look up',
    'Received on',
    'Status',
    'SLA',
    'Active support time',
    'Time to Fix'
  ];

  incidentTask = [
    'IM ID',
    'Subject',
    'Procedures',
    'Role',
    'Assigned to person',
    'Assigned to team',
    'Requester',
    'Customer',
    'Discovery Time',
    'Status',
    'SLA',
    'Active support time',
    'Time to Fix'
  ];

  bookingUnassignedTask = [
    'SRM ID',
    'Case',
    'Queries',
    'Company old look up',
    'Discovery Time',
    'Status',
    'SLA',
    'Active support time',
    'Time to Fix'
  ];


  incidentUnassignedTask = [
    'IM ID',
    'Subject',
    'Procedures',
    'Requester',
    'Customer',
    'Discovery Time',
    'Status',
    'SLA',
    'Active support time',
    'Time to Fix'
  ];
  constructor(private bookingService: BookingService) {
    this.bookingAssignedElements = bookingService.getBookingTask();
    this.incidentElements = bookingService.getIncidentTask();
    this.bookingUnAssignedElements = bookingService.getBookingUnAssignedTask();
    this.IncidentUnAssignedElements = bookingService.getIncidentUnAssignedTask();
    this.bookingAssignedTiltle = 'Bookings: My tasks (' + this.bookingAssignedElements.length + ')';
    this.IncidentAssignedTiltle = 'Incident: My tasks (' + this.IncidentUnAssignedElements.length + ')';
    this.bookingUnAssignedTiltle = 'Bookings: Unassigned tasks  (' + this.bookingUnAssignedElements.length + ')';
    this.IncidentUnAssignedTiltle = 'Incident: Unassigned tasks  (' + this.IncidentUnAssignedElements.length + ')';
   }

  ngOnInit() {
  }

}
