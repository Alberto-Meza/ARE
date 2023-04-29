using System;
using ARE.Shared.Entities;

namespace ARE.Shared.DTOs
{
	public class ChargeDTO
	{
		public ChargeDTO()
		{
			Charge = new Charge();
			chargeDetails = new List<ChargeDetail>();
		}

		public Charge Charge { get; set; }

		public List<ChargeDetail> chargeDetails { get; set; }

	}
}

