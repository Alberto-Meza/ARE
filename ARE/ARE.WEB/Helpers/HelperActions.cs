using System;
namespace ARE.WEB.Helpers
{
	public class HelperActions
	{
		public Action Action { get; set; }
		public Action<Dictionary<string,object>> ActionByParams { get; set; }
	}
}

