﻿using System;

namespace DKBS.Domain
{
    public class BookingArrangementType
    {
        public int BookingArrangementTypeId { get; set; }

        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public ServiceCatalog ServiceCatalog  { get; set; }
        public int ServiceCatalogId { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? FromDate { get; set; }

    }
}