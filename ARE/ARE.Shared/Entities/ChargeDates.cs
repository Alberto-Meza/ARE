﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class ChargeDates:IEntity
	{
        public int Id { get; set; }
        public int ChargeId { get; set; }

        [Display(Name = "Fecha Inicio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Fecha Fin")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Pendiente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool IsPending { get; set; }

        #region Related Entities

        public Charge? Charge { get; set; }

        #endregion

    }
}
