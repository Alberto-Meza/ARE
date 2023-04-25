using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class SubTypeOfCharge:IEntity
	{
        public int Id { get; set; }
        public int TypeOfChargeId { get; set; }

        [Display(Name = "Sub Tipo de Cobro")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Price { get; set; }


        #region Related Entities

        public TypeOfCharge? TypeOfCharge { get; set; }

        #endregion


    }
}

