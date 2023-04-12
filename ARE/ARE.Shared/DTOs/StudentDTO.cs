using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ARE.Shared.Entities;

namespace ARE.Shared.DTOs
{
	public class StudentDTO : Student
	{
        public StudentDTO()
        {

        }
        public StudentDTO(Student student)
        {
            init(student);
            StudentTypeIds = student.StudentTypeRelationships!.Select(x => x.StudentTypeId).ToList();
        }

        public StudentDTO(Student student, List<int> Ids)
        {

            init(student);
            StudentTypeIds = Ids;
        }

        public List<int>? StudentTypeIds { get; set; }

        public void init(Student student) {
            Id = student.Id;
            Name = student.Name;
            LastName1 = student.LastName1;
            LastName2 = student.LastName2;
            Gender = student.Gender;
            BirthDate = student.BirthDate;
            BirthPlace = student.BirthPlace;
            Asthma = student.Asthma;
            Convulsions = student.Convulsions;
            OtherConditions = student.OtherConditions;
            Allergies = student.Allergies;
            Diseases = student.Diseases;
            Medicines = student.Medicines;
            Observation = student.Observation;
            FirstDateAppointment = student.FirstDateAppointment;
            Folio = student.Folio;
            Fingerprint1 = student.Fingerprint1;
            Fingerprint2 = student.Fingerprint2;
            IsActive = student.IsActive;
            PhotoPath = student.PhotoPath;

            #region Domicilio

            Street = student.Street;
            Number = student.Number;
            Suburb = student.Suburb;
            ZipCode = student.ZipCode;
            #endregion

            BloodTypeId = student.BloodTypeId;
            CivilStatusId = student.CivilStatusId;
            SchoolGradeId = student.SchoolGradeId;
            CityId = student.CityId;

            #region Related Entities
            BloodType = student.BloodType;
            CivilStatus = student.CivilStatus;
            SchoolGrade = student.SchoolGrade;
            City = student.City;
            #endregion

            this.StudentTypeRelationships = student.StudentTypeRelationships!;
        }

        public Student ToStudent() {
            return new Student()
            {
                Id = Id
            , Name = Name
            , LastName1 = LastName1
            , LastName2 = LastName2
            , Gender = Gender
            , BirthDate = BirthDate
            , BirthPlace = BirthPlace
            , Asthma = Asthma
            , Convulsions = Convulsions
            , OtherConditions = OtherConditions
            , Allergies = Allergies
            , Diseases = Diseases
            , Medicines = Medicines
            , Observation = Observation
            , FirstDateAppointment = FirstDateAppointment
            , Folio = Folio
            , Fingerprint1 = Fingerprint1
            , Fingerprint2 = Fingerprint2
            , IsActive = IsActive
            , PhotoPath = PhotoPath

                #region Domicilio

            , Street = Street
            , Number = Number
            , Suburb = Suburb
            , ZipCode = ZipCode
                #endregion

            , BloodTypeId = BloodTypeId
            , CivilStatusId = CivilStatusId
            , SchoolGradeId = SchoolGradeId
            , CityId = CityId

                #region Related Entities
            , BloodType = BloodType
            , CivilStatus = CivilStatus
            , SchoolGrade = SchoolGrade
            , City = City
                #endregion

            , StudentTypeRelationships = new List<StudentTypeRelationship>()

            };
        }
    }
}

