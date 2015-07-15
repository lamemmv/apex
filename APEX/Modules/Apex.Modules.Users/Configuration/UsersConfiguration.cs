using System;
using System.Configuration;
using Apex.Framework.Core.Enums;

namespace Apex.Modules.Users.Configuration
{
	public static class UsersConfiguration
	{
		public static readonly bool UserLockoutEnabledByDefault;
		public static readonly int DefaultAccountLockoutTimeSpan;
		public static readonly int MaxFailedAccessAttemptsBeforeLockout;

		public static readonly int SaltSize;
		public static readonly HashProvider HashProvider;
		
		static UsersConfiguration()
		{
			var appSettings = ConfigurationManager.AppSettings;

			UserLockoutEnabledByDefault = ToBool(appSettings["UserLockoutEnabledByDefault"], true);
			DefaultAccountLockoutTimeSpan = ToInt(appSettings["DefaultAccountLockoutTimeSpan"], 5);
			MaxFailedAccessAttemptsBeforeLockout = ToInt(appSettings["MaxFailedAccessAttemptsBeforeLockout"], 5);

			SaltSize = ToInt(appSettings["SaltSize"], 12);
			HashProvider = ToHashProvider(appSettings["HashProvider"]);
		}

		private static bool ToBool(string value, bool defaultValue)
		{
			bool returnValue;
			if (!bool.TryParse(value, out returnValue))
			{
				returnValue = defaultValue;
			}

			return returnValue;
		}

		private static int ToInt(string value, int defaultValue)
		{
			int returnValue;
			if (!int.TryParse(value, out returnValue))
			{
				returnValue = defaultValue;
			}

			return returnValue;
		}

		private static HashProvider ToHashProvider(string value)
		{
			return (HashProvider)Enum.Parse(typeof(HashProvider), value);
		}
	}
}
