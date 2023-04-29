using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ARE.Shared.Entities
{
	public class PendingAssistance:IEntity
	{
        public int Id { get; set; }
        public int AssistanceId { get; set; }
        public int SubTypeOfChargeId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Total")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal Total { get; set; }

        [Display(Name = "Comentario")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Comment { get; set; } = null!;


        #region Related Entities

        public Assistance? Assistance { get; set; }

        public SubTypeOfCharge? SubTypeOfCharge { get; set; }
        #endregion

    }
}

