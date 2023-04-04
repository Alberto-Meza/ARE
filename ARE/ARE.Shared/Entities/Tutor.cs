using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class Tutor : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Fech Nacimiento")]
        public DateTime? BirthDate { get; set; } = null!;

        [Display(Name = "Nro Telefono")]
        public string CelNumber { get; set; } = null!;

        [Display(Name = "Ocupacion")]
        public string Occupation { get; set; } = null!;

        [Display(Name = "Parentesco")]
        public string Relationship { get; set; } = null!;

        public int? StudentId { get; set; } = null!;

        #region Related Entities
        public Student? Student { get; set; }
        #endregion
    }
}

