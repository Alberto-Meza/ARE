using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class ChargeDetail:IEntity
	{
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public int MethodOfPaymentId { get; set; }


        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha de Pago")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal PaymentDate { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Comment { get; set; } = null!;


        #region Related Entities

        public Charge? Charge { get; set; }
        public MethodOfPayment? MethodOfPayment { get; set; }

        #endregion

    }
}

