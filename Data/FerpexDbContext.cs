using Microsoft.EntityFrameworkCore;
using MultiDbWebApi.Models;

namespace MultiDbWebApi.Data
{
    public class FerpexDbContext : DbContext
    {
        public FerpexDbContext(DbContextOptions<FerpexDbContext> options)
            : base(options) { }

        // DbSet'ler tanımlandı
        public DbSet<TBLUSERS> Users { get; set; }
        public DbSet<TBLCARISB> Carisb { get; set; }
        public DbSet<TBLCARIHR> Carihr { get; set; }
        public DbSet<TBLSTOKSB> Stoksb { get; set; }
        public DbSet<TBLSTOKSB2> Stoksb2 { get; set; }
        public DbSet<TBLSTOKHR> Stokhr { get; set; }
        public DbSet<TBLKASASB> Kasasb { get; set; }
        public DbSet<TBLKASAHR> Kasahr { get; set; }
        public DbSet<TBLBANKASB> Bankasb { get; set; }
        public DbSet<TBLBANKAHR> Bankahr { get; set; }
        public DbSet<TBLCEKSENET> Ceksenet { get; set; }
        public DbSet<TBLRECETESB> Recetesb { get; set; }
        public DbSet<TBLRECETEHR> Recetehr { get; set; }
        public DbSet<TBLISEMRISB> Isemrisb { get; set; }
        public DbSet<TBLISEMRIHR> Isemrihr { get; set; }
        public DbSet<TBLURETIM> Uretim { get; set; }
        public DbSet<TBLURETIM2> Uretim2 { get; set; }
        public DbSet<TBLDEPOSB> Deposb { get; set; }
        public DbSet<TBLKALITEKONTROL> Panelkalitekontrol { get; set; }
        public DbSet<TBLCEKSENETwithSERIAL> Ceksenetwithserial { get; set; }


        // rehber Dbler
        public DbSet<TBLSTOKREHBER> Stokrehber { get; set; }
        public DbSet<TBLCARIREHBER> Carirehber { get; set; }
        public DbSet<TBLDEPOSAYIMREHBER> Deposayimrehber { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TBL'ler için Keyless Entity Type tanımlıyoruz
            modelBuilder.Entity<TBLUSERS>().HasNoKey();
            modelBuilder.Entity<TBLCARISB>().HasNoKey();
            modelBuilder.Entity<TBLCARIHR>().HasNoKey();
            modelBuilder.Entity<TBLSTOKSB>().HasNoKey();
            modelBuilder.Entity<TBLSTOKSB2>().HasNoKey();
            modelBuilder.Entity<TBLSTOKHR>().HasNoKey();
            modelBuilder.Entity<TBLKASASB>().HasNoKey();
            modelBuilder.Entity<TBLKASAHR>().HasNoKey();
            modelBuilder.Entity<TBLBANKASB>().HasNoKey();
            modelBuilder.Entity<TBLBANKAHR>().HasNoKey();
            modelBuilder.Entity<TBLCEKSENET>().HasNoKey();
            modelBuilder.Entity<TBLRECETESB>().HasNoKey();
            modelBuilder.Entity<TBLRECETEHR>().HasNoKey();
            modelBuilder.Entity<TBLISEMRISB>().HasNoKey();
            modelBuilder.Entity<TBLISEMRIHR>().HasNoKey();
            modelBuilder.Entity<TBLURETIM>().HasNoKey();
            modelBuilder.Entity<TBLURETIM2>().HasNoKey();
            modelBuilder.Entity<TBLDEPOSB>().HasNoKey();
            modelBuilder.Entity<TBLKALITEKONTROL>().HasNoKey();


            modelBuilder.Entity<TBLSTOKREHBER>().HasNoKey();
            modelBuilder.Entity<TBLCARIREHBER>().HasNoKey();
            modelBuilder.Entity<TBLDEPOSAYIMREHBER>().HasNoKey();
        }
    }
}
