using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Araç Numarası")]
        public int VehicleId { get; set; }
        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [StringLength(50)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [StringLength(11)]
        [Display(Name = "Tc Kimlik Numarası")]
        public string? IdentificationNumber { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [StringLength(500)]
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        [StringLength(20)]
        [Display(Name = "Telefon Numarası")]
        public string? PhoneNumber { get; set; }
        public string? Notes { get; set; }
        public virtual Vehicle? Vehicle { get; set; }

    }
}
