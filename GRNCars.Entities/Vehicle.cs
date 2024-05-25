using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Marka Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int BrandId { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Renk")]
        public string Color { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal Price { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Model { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Kasa Tipi")]
        public string CaseType { get; set; }
        [Display(Name = "Model Yılı")]
        public int ModelYear { get; set; }
        [Display(Name = "Satışta Mı ?")]
        public bool IsSale { get; set; }
        [Display(Name = "Anasayfa ?")]
        public bool Anasayfa { get; set; }
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        [Display(Name = "Notlar")]
        public string Notes { get; set; }
        [StringLength(100)]
        [Display(Name = "Resim1")]
        public string? Image { get; set; }
        [StringLength(100)]
        [Display(Name = "Resim2")]
        public string? Image2 { get; set; }
        [StringLength(100)]
        [Display(Name = "Resim3")]
        public string? Image3 { get; set; }

        public virtual Brand? Brand { get; set; }


    }
}
