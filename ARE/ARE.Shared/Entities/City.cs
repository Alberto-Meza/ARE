﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
    public class City :IEntity
	{
        public int Id { get; set; }
        public int StateId { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;


        public State? State { get; set; }

    }
}

