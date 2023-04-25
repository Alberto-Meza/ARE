using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class TypeOfCharge:IEntity
	{
        public int Id { get; set; }

        [Display(Name = "Tipos de Cobros")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;


        public ICollection<SubTypeOfCharge>? SubTypeOfCharges { get; set; }

        [Display(Name = "Sub Tipos de cobros")]
        public int SubTypeOfChargesNumber => SubTypeOfCharges == null ? 0 : SubTypeOfCharges.Count;

    }
}

