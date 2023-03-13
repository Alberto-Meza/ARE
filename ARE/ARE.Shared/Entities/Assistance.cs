using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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


        #region Related Entities

        public Student? Student { get; set; }

        #endregion
    }
}

