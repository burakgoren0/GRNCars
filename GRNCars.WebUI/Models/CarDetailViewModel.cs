using GRNCars.Entities;

namespace GRNCars.WebUI.Models
{
    public class CarDetailViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Customer? Customer { get; set; }
    }
}
