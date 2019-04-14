using DKBS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Data
{
   public class DKBSDbContext :DbContext
    {
        public DKBSDbContext(DbContextOptions<DKBSDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }

        public DbSet<TableSet> TableSets { get; set; }

        public DbSet<Purpose> Purpose { get; set; }

        public DbSet<TableType> TableTypes { get; set; }

        public DbSet<PartnerType> PartnerTypes { get; set; }

        public DbSet<MailLanguage> MailLanguages { get; set; }

        public DbSet<LeadOfOrigin> LeadOfOrigins { get; set; }

        public DbSet<Land> Land { get; set; }

        public DbSet<ITProcedureStatus> ITProcedureStatuses { get; set; }

        public DbSet<IndustryCode> IndustryCodes { get; set; }

        public DbSet<Flow> Flow { get; set; }

        public DbSet<CrmStatus> CrmStatuses { get; set; }

        public DbSet<CoursePackageType> CoursePackageTypes { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<CenterType> CenterTypes { get; set; }

        public DbSet<CenterMatching> CenterMatchings { get; set; }

        public DbSet<CauseOfRemoval> CauseOfRemovals { get; set; }

        public DbSet<CancellationReason> CancellationReasons { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Partner> Partners { get; set; }

        public DbSet<PartnerEmployee> PartnerEmployees { get; set; }

        public DbSet<TownZipCode> TownZipCodes { get; set; }

        public DbSet<BookingRooms> BookingRooms { get; set; }

        public DbSet<Provision> Provisions { get; set; }

        public DbSet<ProcedureReviewType> ProcedureReviewTypes { get; set; }

        public DbSet<Procedure> Procedures { get; set; }

        public DbSet<ParticipantType> ParticipantTypes { get; set; }

        public DbSet<MailGroup> MailGroups { get; set; }

        public DbSet<ContactPerson> ContactPeople { get; set; }
        public DbSet<BookingRegion> BookingRegions { get; set; }

        public DbSet<BookingReference> BookingReferences { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingArrangementType> BookingArrangementTypes { get; set; }

        public DbSet<BookingAlternativeService> BookingAlternativeServices { get; set; }

        public DbSet<ProcedureInfo> ProcedureInfos { get; set; }

        public DbSet<BookingAndStatus> BookingAndStatuses { get; set; }

        public DbSet<ServiceCatalog> ServiceCatalogs { get; set; }
        public DbSet<ServiceRequestCommunications> ServiceRequestCommunications { get; set; }
        public DbSet<ServiceRequestNotes> ServiceRequestNotes { get; set; }
        public DbSet<SRConversationItems> SRConversationItems { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Customer>(cust =>
        //    {
        //        cust.Property(c => c.Name).HasMaxLength(200).HasColumnType("varchar"); // One example for how to define the type for db column
        //        cust.Property(c => c.Address1).HasMaxLength(500);
        //        cust.Property(c => c.Address2).HasMaxLength(500);
        //        cust.Property(c => c.ZipCode).HasMaxLength(50).IsRequired();
        //        cust.Property(c => c.Country).HasMaxLength(50);
        //        cust.Property(c => c.City).HasMaxLength(200);
        //        cust.Property(c => c.CreatedBy).HasMaxLength(100);
        //        cust.Property(c => c.ModifiedBy).HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<Booking>(booking =>
        //    {
        //        booking.Property(e => e.InternalHistory).HasMaxLength(200);
        //    });

        //    modelBuilder.Entity<Booking>().HasOne(b => b.Customer);

        //    modelBuilder.Entity<BookingRegions>(bookingRegion =>
        //    {
        //        bookingRegion.Property(br => br.BookingId).IsRequired();
        //        bookingRegion.Property(br => br.RegionId).IsRequired();
        //    });

        //    modelBuilder.Entity<BookingReference>(bookingReference =>
        //    {
        //        bookingReference.Property(br => br.BookingId).IsRequired();
        //        bookingReference.Property(br => br.CompignId).IsRequired();
        //        bookingReference.Property(br => br.LeadOrignId).IsRequired();
        //        bookingReference.Property(br => br.RefferId).IsRequired();
        //        bookingReference.Property(br => br.Other).HasMaxLength(500).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Campaign>(camp => {
        //        camp.Property(c => c.Name).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<LeadOfOrigin>(leadOrigin => {
        //        leadOrigin.Property(c => c.Name).HasMaxLength(2255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Region>(region => {
        //        region.Property(c => c.Name).HasMaxLength(2255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Room>(room => {
        //        room.Property(r => r.LocalAttraction).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<AlternativeService>(alternativeService => {
        //        alternativeService.Property(service => service.Description).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Flow>(flow => {
        //        flow.Property(f => f.FlowName).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<MailLanguage>(mailLanguage => {
        //        mailLanguage.Property(ml => ml.Language).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<CenterMatching>(centerMatching => {
        //        centerMatching.Property(cm => cm.MatchingCenter).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Purpose>(purpose => {
        //        purpose.Property(p => p.PurposeName).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<ParticipantType>(participantType => {
        //        participantType.Property(pt => pt.ParticipantTypeName).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<TableType>(tableType => {
        //        tableType.Property(t => t.TableTypeName).HasMaxLength(255).HasColumnType("varchar");
        //    });


        //    modelBuilder.Entity<Procedure>(procedure => {
        //        procedure.Property(p => p.ProcedureName).HasMaxLength(255).HasColumnType("varchar");
        //        procedure.Property(p => p.LastModifiedBy).HasMaxLength(255).HasColumnType("varchar");
        //    });

        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Customer);
        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Booking);
        //    modelBuilder.Entity<Procedure>().HasOne(p => p.Partner);

        //    modelBuilder.Entity<Partner>(partner => {
        //        partner.Property(p => p.PartnerName).HasMaxLength(255);
        //        partner.Property(p => p.EmailId).HasMaxLength(255);
        //        partner.Property(p => p.PhoneNumber).HasMaxLength(255);
        //        partner.Property(p => p.LastModifiedBy).HasMaxLength(255);
        //    });

        //    modelBuilder.Entity<Partner>().HasOne(p => p.CenterTypeId);
        //    modelBuilder.Entity<Partner>().HasOne(p => p.PartnerType);




        //}
    }
}
