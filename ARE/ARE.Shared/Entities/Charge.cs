using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using ARE.Shared.Enums;

namespace ARE.Shared.Entities
{
	public class Charge:IEntity
	{
        public int Id { get; set; }
        public int StudentId { get; set; }

        [Display(Name = "Fecha de Cobro")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime ChargeDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Total { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Comment { get; set; } = null!;

        [Display(Name = "Status")]
        public ChargeStatusType Status { get; set; }

        #region Related Entities

        public Student? Student { get; set; }

        
        #endregion
    }
}

