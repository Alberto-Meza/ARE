using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ARE.Shared.Enums;

namespace ARE.Shared.Entities
{
	public class Assistance:IEntity
	{
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Display(Name = "FechaEntrada")]
        public DateTime? EntryDate { get; set; } = null!;

        [Display(Name = "FechaSalida")]
        public DateTime? ExitDate { get; set; } = null!;

        public int? ChargeId { get; set; }

        [Display(Name = "Status")]
        public AssistsStatusType Status { get; set; }


        #region Related Entities

        public Student? Student { get; set; }

        public Charge? Charge { get; set; }

        #endregion
    }
}

