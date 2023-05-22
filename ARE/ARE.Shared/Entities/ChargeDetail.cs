using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ARE.Shared.Entities
{
	public class ChargeDetail:IEntity
	{
        public int Id { get; set; }
        public int ChargeId { get; set; }
        public int SubTypeOfChargeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha de Pago")]
        [Column(TypeName = "datetime")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Comment { get; set; } = null!;


        #region Related Entities

        public Charge? Charge { get; set; }
        public SubTypeOfCharge? SubTypeOfCharge { get; set; }

        #endregion

    }
}

