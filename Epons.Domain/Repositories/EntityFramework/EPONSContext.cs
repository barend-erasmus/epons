namespace Epons.Domain.Repositories.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EPONSContext : DbContext
    {
        public EPONSContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Details1> Details1 { get; set; }
        public virtual DbSet<Details2> Details2 { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<EpisodesOfCare> EpisodesOfCares { get; set; }
        public virtual DbSet<Details3> Details3 { get; set; }
        public virtual DbSet<Option> Options { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Details4> Details4 { get; set; }
        public virtual DbSet<AdmissionType> AdmissionTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DischargeType> DischargeTypes { get; set; }
        public virtual DbSet<Frequency> Frequencies { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<ICD10Codes> ICD10Codes { get; set; }
        public virtual DbSet<ImpairmentGroup> ImpairmentGroups { get; set; }
        public virtual DbSet<MeasurementTools2> MeasurementTools2 { get; set; }
        public virtual DbSet<MedicalScheme> MedicalSchemes { get; set; }
        public virtual DbSet<Permissions1> Permissions1 { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<ProfessionalBody> ProfessionalBodies { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<ResidentialEnvironment> ResidentialEnvironments { get; set; }
        public virtual DbSet<ScoreItem> ScoreItems { get; set; }
        public virtual DbSet<ScoreValue> ScoreValues { get; set; }
        public virtual DbSet<SupportServices1> SupportServices1 { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Details5> Details5 { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<SavedQuery> SavedQueries { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientImpairmentGroup> PatientImpairmentGroups { get; set; }
        public virtual DbSet<MessageRecipient> MessageRecipients { get; set; }
        public virtual DbSet<MeasurementTools1> MeasurementTools1 { get; set; }
        public virtual DbSet<SupportService> SupportServices { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }
        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<MeasurementToolScore> MeasurementToolScores { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ICD10CodeToIGMap> ICD10CodeToIGMap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .HasMany(e => e.Details4)
                .WithOptional(e => e.Detail)
                .HasForeignKey(e => e.CurrentFacilityId);

            modelBuilder.Entity<Detail>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Detail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detail>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.Detail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detail>()
                .HasMany(e => e.MeasurementTools2)
                .WithMany(e => e.Details)
                .Map(m => m.ToTable("MeasurementTools").MapLeftKey("FacilityId").MapRightKey("MeasurementToolId"));

            modelBuilder.Entity<Details1>()
                .HasMany(e => e.MessageRecipients)
                .WithRequired(e => e.Details1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.IdentificationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.NameOfNextOfKin)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.ContactNumberOfNextOfKin)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.MedicalSchemeMembershipNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.EmailAddressOfNextOfKin)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .Property(e => e.RelationshipOfNextOfKin)
                .IsUnicode(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.Details1)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.Details5)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.EpisodesOfCares)
                .WithRequired(e => e.Details2)
                .HasForeignKey(e => e.PatientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.EpisodesOfCares1)
                .WithRequired(e => e.Details21)
                .HasForeignKey(e => e.PatientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.MeasurementTools1)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.PatientImpairmentGroups)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.SupportServices)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details2>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.Details2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.PracticeName)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.HPCSANumber)
                .IsUnicode(false);

            modelBuilder.Entity<EpisodesOfCare>()
                .Property(e => e.AllocationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details3>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Details3>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Details3)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Option>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Option>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Option)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Options)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.IdentificationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.PracticeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .Property(e => e.RegistrationNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.Details1)
                .WithRequired(e => e.Details4)
                .HasForeignKey(e => e.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.Credentials)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.MeasurementToolScores)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.MessageRecipients)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details4>()
                .HasMany(e => e.TeamMembers)
                .WithRequired(e => e.Details4)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdmissionType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AdmissionType>()
                .HasMany(e => e.EpisodesOfCares)
                .WithOptional(e => e.AdmissionType)
                .HasForeignKey(e => e.AdmissionTypeId);

            modelBuilder.Entity<AdmissionType>()
                .HasMany(e => e.EpisodesOfCares1)
                .WithOptional(e => e.AdmissionType1)
                .HasForeignKey(e => e.AdmissionTypeId);

            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Provinces)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DischargeType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DischargeType>()
                .HasMany(e => e.EpisodesOfCares)
                .WithOptional(e => e.DischargeType)
                .HasForeignKey(e => e.DischargeTypeId);

            modelBuilder.Entity<DischargeType>()
                .HasMany(e => e.EpisodesOfCares1)
                .WithOptional(e => e.DischargeType1)
                .HasForeignKey(e => e.DischargeTypeId);

            modelBuilder.Entity<Frequency>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Frequency>()
                .HasMany(e => e.MeasurementTools1)
                .WithRequired(e => e.Frequency)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10Codes>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10Codes>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ICD10Codes>()
                .HasMany(e => e.EpisodesOfCares)
                .WithOptional(e => e.ICD10Codes)
                .HasForeignKey(e => e.ReasonForAdmissionId);

            modelBuilder.Entity<ICD10Codes>()
                .HasMany(e => e.EpisodesOfCares1)
                .WithOptional(e => e.ICD10Codes1)
                .HasForeignKey(e => e.ReasonForAdmissionId);

            modelBuilder.Entity<ImpairmentGroup>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ImpairmentGroup>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MeasurementTools2>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MeasurementTools2>()
                .HasMany(e => e.MeasurementToolScores)
                .WithRequired(e => e.MeasurementTools2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MeasurementTools2>()
                .HasMany(e => e.MeasurementTools1)
                .WithRequired(e => e.MeasurementTools2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MeasurementTools2>()
                .HasMany(e => e.ScoreItems)
                .WithRequired(e => e.MeasurementTools2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MedicalScheme>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Permissions1>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Permissions1>()
                .HasMany(e => e.Permissions)
                .WithRequired(e => e.Permissions1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalBody>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Race>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ResidentialEnvironment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreItem>()
                .HasMany(e => e.ScoreItems1)
                .WithOptional(e => e.ScoreItem1)
                .HasForeignKey(e => e.ParentScoreItemId);

            modelBuilder.Entity<ScoreItem>()
                .HasMany(e => e.ScoreValues)
                .WithRequired(e => e.ScoreItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScoreValue>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreValue>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ScoreValue>()
                .HasMany(e => e.Details5)
                .WithMany(e => e.ScoreValues)
                .Map(m => m.ToTable("ScoreValues", "Visit").MapLeftKey("ScoreValueId").MapRightKey("VisitId"));

            modelBuilder.Entity<SupportServices1>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SupportServices1>()
                .HasMany(e => e.SupportServices)
                .WithRequired(e => e.SupportServices1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Title>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Details5>()
                .Property(e => e.DailyNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Details5>()
                .Property(e => e.ProgressNotes)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsUnicode(false);

            modelBuilder.Entity<SavedQuery>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SavedQuery>()
                .Property(e => e.Query)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.AuditType)
                .IsUnicode(false);

            modelBuilder.Entity<PatientImpairmentGroup>()
                .Property(e => e.AuditType)
                .IsUnicode(false);

            modelBuilder.Entity<SupportService>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Credential>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
