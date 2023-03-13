using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class Employee:IEntity
	{
        public int Id { get; set; }
        public int PaymentPeriodId { get; set; }
        public int JobId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int ShiftId { get; set; }
        public int CivilStatusID { get; set; }


        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Apellido Paterno")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName1 { get; set; } = null!;

        [Display(Name = "Apellido Materno")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName2 { get; set; } = null!;

        [Display(Name = "Fecha de alta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime DischargeDate { get; set; }

        [Display(Name = "Salario Diario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public decimal DailySalary { get; set; }

        [Display(Name = "Correo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; } = null!;

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Sex { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Foto")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string PhotoPath { get; set; } = null!;

        [Display(Name = "Huella1")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public byte[] FingertPrint1 { get; set; } = null!;

        [Display(Name = "Huella2")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public byte[] FingertPrint2 { get; set; } = null!;


        [Display(Name = "Activo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool IsActive { get; set; }

        #region Related Entities

        public PaymentPeriod? PaymentPeriod { get; set; }
        public Job? Job { get; set; }
        public EmployeeType? EmployeeType { get; set; }
        public Shift? Shift { get; set; }
        public CivilStatus? CivilStatus { get; set; }
        #endregion




    }
}

