using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Araç Sorunu"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string VehicleProblem { get; set; }
        [Display(Name = "Servis Ücreti")]
        public decimal ServicePrice { get; set; }
        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Yapılan İşlemler")]
        public string? Transactions { get; set; }
        [StringLength(15)]
        [Display(Name = "Araç Plaka"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string NumberPlate { get; set; }
        [StringLength(50)]
        [Display(Name = "Marka"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Brand { get; set; }
        [StringLength(50)]
        public string? Model { get; set; }
        [StringLength(50)]
        [Display(Name = "Kasa Tipi")]
        public string? CaseType { get; set; }
        [StringLength(50)]
        [Display(Name = "Şase Numarası")]
        public string? ChassisNumber { get; set; }
        public string Notes { get; set; }
    }
}
