using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ARE.Shared.Entities
{
	public class PendingCharges:IEntity
	{
        public int Id { get; set; }

        public int AssistanceId { get; set; }


        #region Related Entities

        public Assistance? Assistance { get; set; }

        #endregion

    }
}

