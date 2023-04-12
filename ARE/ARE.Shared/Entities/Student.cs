using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class Student: IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Apellido Materno")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName1 { get; set; } = null!;

        [Display(Name = "Apellido Paterno")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName2 { get; set; } = null!;

        [Display(Name = "Genero")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Gender { get; set; } = null!;

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? BirthDate { get; set; } = null!;

        [Display(Name = "Lugar Nacimiento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string BirthPlace { get; set; } = "";

        [Display(Name = "Asma?")]
        public bool Asthma { get; set; }

        [Display(Name = "Convulsiones?")]
        public bool Convulsions { get; set; }

        [Display(Name = "Otros Padecimeintos")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string OtherConditions { get; set; } = "";

        [Display(Name = "Alergias")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Allergies { get; set; } = "";

        [Display(Name = "Enfermedades")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Diseases { get; set; } = "";

        [Display(Name = "Medicamentos")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Medicines { get; set; } = "";

        [Display(Name = "Observaciones")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Observation { get; set; } = "";

        /*[Display(Name = "Correo")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; } = null!;
        */

        [Display(Name = "Fecha de Ingreso")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? FirstDateAppointment { get; set; } = null!;

        public string? Folio { get; set; }

        public byte[]? Fingerprint1 { get; set; } 

        public byte[]? Fingerprint2 { get; set; } 

        [Display(Name = "Activo?")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool IsActive { get; set; }

        public string? PhotoPath { get; set; }

        #region Domicilio

        [Display(Name = "Calle")]
        [MaxLength(255, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Street { get; set; } = "";

        [Display(Name = "Numero")]
        public int? Number { get; set; } = null!;

        [Display(Name = "Colonia")]
        public string Suburb { get; set; } = "";

        [Display(Name = "CP.")]
        public string ZipCode { get; set; } = "";

        #endregion


        /*
        #region Info Tutor1
        [Display(Name = "Nombre")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NameTutor1 { get; set; } = null!;

        [Display(Name = "Fech Nacimiento")]
        public DateTime? BirthDateTutor1 { get; set; } = null!;

        [Display(Name = "Nro Telefono")]
        public string CelNumberTutor1 { get; set; } = null!;

        [Display(Name = "Ocupacion")]
        public string OccupationTutor1 { get; set; } = null!;

        [Display(Name = "Parentesco")]
        public string RelationshipTutor1 { get; set; } = null!;

        #endregion

        #region Info Tutor2

        [Display(Name = "Nombre")]
        [MaxLength(300, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NameTutor2 { get; set; } = null!;

        [Display(Name = "Fech Nacimiento")]
        public DateTime? BirthDateTutor2 { get; set; } = null!;

        [Display(Name = "Nro Telefono")]
        public string CelNumberTutor2 { get; set; } = null!;

        [Display(Name = "Ocupacion")]
        public string OccupationTutor2 { get; set; } = null!;

        [Display(Name = "Parentesco")]
        public string RelationshipTutor2 { get; set; } = null!;

        #endregion
        */

        public int? BloodTypeId { get; set; } = null!;

        public int? CivilStatusId { get; set; } = null!;

        public int? SchoolGradeId { get; set; } = null!;

        public int? CityId { get; set; } = null!;



        public ICollection<StudentTypeRelationship>? StudentTypeRelationships { get; set; }

        [Display(Name = "TiposEstudiante")]
        public int StudentTypeNumber => StudentTypeRelationships == null ? 0 : StudentTypeRelationships.Count;



        #region Related Entities
        public BloodType? BloodType { get; set; }

        public CivilStatus? CivilStatus { get; set; }

        public SchoolGrade? SchoolGrade { get; set; }

        public City? City { get; set; }

        #endregion


        #region Not Mappet
        
        public int Age
        {
            get { return GetAge(); }
        }

        public int GetAge()
        {
            int Age = 0;

            if (BirthDate != null)
            {
                Age = DateTime.Today.Year - BirthDate.Value.Year;

                if (DateTime.Today.Month < BirthDate.Value.Month)
                {
                    Age = Age - 1;
                }
                else if (DateTime.Today.Month == BirthDate.Value.Month)
                {
                    if (DateTime.Today.Day <= BirthDate.Value.Day)
                    {
                        Age = Age - 1;
                    }
                }
            }

            return Age;
        }

        public string FullName
        {
            get { return $"{Name} {LastName1} {LastName2}"; }
        }

        #endregion
    }
}

