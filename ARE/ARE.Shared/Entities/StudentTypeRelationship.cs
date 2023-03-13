using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class StudentTypeRelationship:IEntity
	{
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int StudentTypeId { get; set; }

        #region Related Entities

        public Student? Student { get; set; }

        public StudentType? StudentType { get; set; }

        #endregion
    }
}

