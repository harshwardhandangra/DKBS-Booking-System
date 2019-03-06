﻿using System;

namespace DKBS.Domain
{
    public class ArrangementType
    {
        public int ArrangementTypeId { get; set; }

        // TODO if it is a table then only need to define the navigation property
        //public int ServiceCatlogueId { get; set; }
        public int NumberOfPerticipants { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public Booking Booking { get; set; }
    }
}