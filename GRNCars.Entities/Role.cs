﻿using System.ComponentModel.DataAnnotations;

namespace GRNCars.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Name { get; set; }

    }
}
