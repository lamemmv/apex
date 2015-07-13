using System.Security.Cryptography;

namespace Apex.Framework.Core.Securities
{
	public static class Random
	{
		// Define supported password characters divided into groups.
		// You can add (or remove) characters to (from) these groups.
		private const string PASSWORD_CHARS_LCASE = "abcdefghijkmnopqrstwxyz";
		private const string PASSWORD_CHARS_UCASE = "ABCDEFGHIJKLMNPQRSTWXYZ";
		private const string PASSWORD_CHARS_NUMERIC = "0123456789";

		#region Numeric

		public static string Numberic(int size)
		{
			return RandomString(PASSWORD_CHARS_NUMERIC, size);
		}

		#endregion

		#region Alphabet

		public static string Alphabet(int size)
		{
			string alphabet = PASSWORD_CHARS_LCASE + PASSWORD_CHARS_UCASE;
			return RandomString(alphabet, size);
		}

		public static string LowerAlphabet(int size)
		{
			return RandomString(PASSWORD_CHARS_LCASE, size);
		}

		public static string UpperAlphabet(int size)
		{
			return RandomString(PASSWORD_CHARS_UCASE, size);
		}

		public static string AlphabetAndNumberic(int size)
		{
			string alphabet = PASSWORD_CHARS_LCASE + PASSWORD_CHARS_UCASE + PASSWORD_CHARS_NUMERIC;
			return RandomString(alphabet, size);
		}

		#endregion

		#region RNGCrypRandom

		public static byte[] RNGCrypto(int size)
		{
			byte[] valueArray = new byte[size];
			new RNGCryptoServiceProvider().GetBytes(valueArray);

			return valueArray;
		}

		#endregion

		private static string RandomString(string allowChars, int size)
		{
			int length = allowChars.Length;
			char[] valueArray = new char[size];

			System.Random rd = new System.Random();
			for (int i = 0; i < size; i++)
			{
				valueArray[i] = allowChars[rd.Next(length)];
			}

			return new string(valueArray);
		}
	}
}
