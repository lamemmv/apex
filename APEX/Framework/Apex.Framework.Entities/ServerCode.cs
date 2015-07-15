namespace Apex.Framework.Entities
{
	public class ServerCode
	{
		public int Code { get; set; }

		public string Message { get; set; }

		public ServerCode()
		{ 
		}

		public ServerCode(string message)
			: this(0, message)
		{
		}

		public ServerCode(int code, string message)
		{
			Code = code;
			Message = message;
		}
	}
}
