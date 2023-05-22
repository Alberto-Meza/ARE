using System;
using ARE.Shared.Entities;

namespace ARE.Shared.DTOs
{
	public class PendingAssistanceDTO : PendingAssistance
	{
		public PendingAssistanceDTO()
		{
		}

		public bool IsSelected { get; set; }
	}
}

