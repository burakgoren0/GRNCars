using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }
        [StringLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Surname { get; set; }
        [StringLength(50), Display(Name = "E-mail"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [StringLength(50), Display(Name = "Telefon")]
        public string? PhoneNumber { get; set; }
        [StringLength(50), Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [StringLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Password { get; set; }
        [Display(Name = "Aktif Mi ?")]
        public bool IsActive { get; set; }
        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? UploadDate { get; set; } = DateTime.Now;
        [Display(Name = "Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int RoleId { get; set; }
        [Display(Name = "Kullanıcı Rolü")]
        public virtual Role? Role { get; set; }
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}
