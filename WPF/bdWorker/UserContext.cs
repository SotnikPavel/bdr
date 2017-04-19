using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace bdWorker
{
    public class UserContext:DbContext
    {
        public UserContext() : base("Data Source=bdrinstanse.c29uy4nro3g3.us-west-2.rds.amazonaws.com;Initial Catalog=bdr(20.04.2017);User ID=bdruser;Password=123ewqasdcxz")
        {
        }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<CellAdmission> CellAdmissions { get; set; }
        public DbSet<CellConsumption> CellConsumptions { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentClass> ComponentClasses { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Consignment> Consignments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Editing> Editings { get; set; }
        public DbSet<ExpenditureReason> ExpenditureReasons { get; set; }
        public DbSet<ImportCSV> ImportsCSV { get; set; }
        public DbSet<ImportPage> ImportPages { get; set; }
        public DbSet<ImportPageParsingOption> ImportPageParsingOptions { get; set; }
        public DbSet<ParsingPage> ParsingPages { get; set; }
        public DbSet<ParsingParameter> ParsingParameters { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_Device> Projects_Devices { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ShellType> ShellTypes { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<TechnicalDocumentation> TechnicalDocumentations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
