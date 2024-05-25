using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Araç")]
        public int VehicleId { get; set; }
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Satış Tarihi")]
        public DateTime SellBy { get; set; }
        [Display(Name = "Araç")]
        public virtual Vehicle? Vehicle { get; set; }
        [Display(Name = "Müşteri")]
        public virtual Customer? Customer { get; set; }
    }
}
