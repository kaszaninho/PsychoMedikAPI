using Microsoft.EntityFrameworkCore;

namespace PsychoMedikAPI.Data
{
    public class PsychoMedikAPIContext : DbContext
    {
        public PsychoMedikAPIContext(DbContextOptions<PsychoMedikAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PsychoMedikAPI.Models.Choroba> Choroba { get; set; } = default!;

        public DbSet<PsychoMedikAPI.Models.Harmonogram>? Harmonogram { get; set; }

        public DbSet<PsychoMedikAPI.Models.HistoriaChoroby>? HistoriaChoroby { get; set; }

        public DbSet<PsychoMedikAPI.Models.Objaw>? Objaw { get; set; }

        public DbSet<PsychoMedikAPI.Models.Pacjent>? Pacjent { get; set; }

        public DbSet<PsychoMedikAPI.Models.Pokoj>? Pokoj { get; set; }

        public DbSet<PsychoMedikAPI.Models.Pracownik>? Pracownik { get; set; }

        public DbSet<PsychoMedikAPI.Models.Stanowisko>? Stanowisko { get; set; }

        public DbSet<PsychoMedikAPI.Models.Wizyta>? Wizyta { get; set; }
    }
}
