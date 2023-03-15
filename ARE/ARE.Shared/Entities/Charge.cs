using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class Charge:IEntity
	{
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubTypeOfChargeId { get; set; }

        [Display(Name = "Fecha de Cobro")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ChargeDate { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Total { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Comment { get; set; } = null!;



        #region Related Entities

        public Student? Student { get; set; }

        public SubTypeOfCharge? SubTypeOfCharge { get; set; }
        #endregion
    }
}

