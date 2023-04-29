using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ARE.Shared.Entities
{
	public class Payment : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int MethodOfPaymentId { get; set; }
        public int ChargeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Amount { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime PaymentDate { get; set; }

        #region Related Entities
        public Student? Student { get; set; }
        public MethodOfPayment? MethodOfPayment { get; set; }
        public Charge? Charge { get; set; }
        #endregion

    }
}

