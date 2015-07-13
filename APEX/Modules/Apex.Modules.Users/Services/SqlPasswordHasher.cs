using Apex.Framework.Core.Enums;
using Apex.Framework.Core.Securities;
using Microsoft.AspNet.Identity;

namespace Apex.Modules.Users.Services
{
	public class SqlPasswordHasher : IPasswordHasher
	{
		private readonly int _saltLength;
		private readonly HashProvider _hashProvider;

		public SqlPasswordHasher(int saltLength, HashProvider hashProvider)
		{
			_saltLength = saltLength;
			_hashProvider = hashProvider;
		}

		public string HashPassword(string password)
		{
			return Encryption.ComputeHash(_hashProvider, password, _saltLength);
		}

		public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
		{
			bool valid = Encryption.CompareStringToHash(_hashProvider, providedPassword, hashedPassword, _saltLength);
			return valid ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
		}
	}
}
