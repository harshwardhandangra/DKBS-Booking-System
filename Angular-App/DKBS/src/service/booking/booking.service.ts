import { Injectable } from '@angular/core';
import { CommonService } from '../common/common.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  bookingAssignmentTasks = [
    {SRM_id: 1, Case: 'Booking', Queries: 'Rooms Available', Role: 'Admin'
    , Booking_Responsible: 'Mack', Assigned_to_team: 'Bravo', Contact: '+44789', Company_old_look_up: 'Previous'
    , Received_on: '23/06/19', Status: 'Available', SLA: 'NA', Active_support_time: '09:00AM',
     Time_to_Fix: '16:00PM'
    }        
  ];

  incidentAssignmentTasks: any = [
    {im_id: 1, Subject: 'Booking', Procedures: 'Rooms Available', Role: 'Admin'
    , Assigned_to_Person: 'Mack', Assigned_to_team: 'Bravo', Requester: '+44789', Customer: 'Previous'
    , Discovery_Time: '23/06/19', Status: 'Available', SLA: 'NA', Active_support_time: '09:00AM',
     Time_to_Fix: '16:00PM'
    }
  ];

  bookingUnAssignmentTasks: any = [
    {SRM_id: 1, Case: 'Booking', Queries: 'Rooms Available', Company_old_look_up: 'Previous'
    , Discovery_Time: '23/06/19', Status: 'Available', SLA: 'NA', Active_support_time: '09:00AM',
     Time_to_Fix: '16:00PM'
    }
  ];

  incidentUnAssignmentTasks: any = [
    {im_id: 1, Subject: 'Booking', Procedures: 'Rooms Available', Requester: '+44789', Customer: 'Previous'
    , Discovery_Time: '23/06/19', Status: 'Available', SLA: 'NA', Active_support_time: '09:00AM',
     Time_to_Fix: '16:00PM'
    }
  ];
  headElements = ['ID', 'First', 'Last', 'Handle', 'PrimeCustomer'];
  constructor(private commonService:CommonService) {

  }
  


  getBookingTask(): any{
    return this.bookingAssignmentTasks;
  }

  getBookingUnAssignedTask(): any{
    return this.bookingUnAssignmentTasks;
  }

  getIncidentTask(): any{
    return this.incidentAssignmentTasks;
  }

  getIncidentUnAssignedTask(): any{
    return this.incidentUnAssignmentTasks;
  }
}
