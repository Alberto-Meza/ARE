using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class BranchOffice : IEntity
    {
        public int Id { get; set; }
        public int CityId { get; set; }

        [Display(Name = "Sucursal")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Name { get; set; } = null!;

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Contact { get; set; } = null!;

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Phone { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Email { get; set; } = null!;

        [Display(Name = "Colonia")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Suburb { get; set; } = null!;

        [Display(Name = "Calle")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Street { get; set; } = null!;

        [Display(Name = "Numero")]
        public int Number { get; set; }

        [Display(Name = "Codigo Postal")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(5, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string ZipCode { get; set; } = null!;


        public City? City { get; set; }
    }
}

