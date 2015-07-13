﻿using System;
using System.Security.Cryptography;
using System.Text;
using Apex.Framework.Core.Enums;

namespace Apex.Framework.Core.Securities
{
	public static class Encryption
	{
		public static string ComputeHash(HashProvider hashAlgorithm, string plainText, int saltSize = 0)
		{
			// Random salt.
			byte[] salt = saltSize > 0 ? Random.RNGCrypto(saltSize) : new byte[0];
			return ComputeHash(hashAlgorithm, plainText, salt);
		}

		public static bool CompareStringToHash(HashProvider hashAlgorithm, string plainText, string encrypt, int saltSize = 0)
		{
			byte[] encryptBuffer = Convert.FromBase64String(encrypt);
			int encryptLength = encryptBuffer.Length;

			// Pluck the salt size off of the end of the hash.
			if (saltSize < 0)
			{
				saltSize = 0;
			}

			byte[] saltBuffer = new byte[saltSize];
			Array.Copy(encryptBuffer, encryptLength - saltSize, saltBuffer, 0, saltSize);

			string hash = ComputeHash(hashAlgorithm, plainText, saltBuffer);
			return string.Equals(encrypt, hash);
		}

		private static HashAlgorithm GetHashProvider(HashProvider hashAlgorithm)
		{
			HashAlgorithm hash;
			switch (hashAlgorithm)
			{
				case HashProvider.SHA1:
					hash = new SHA1Managed();
					break;

				case HashProvider.SHA256:
					hash = new SHA256Managed();
					break;

				case HashProvider.SHA384:
					hash = new SHA384Managed();
					break;

				case HashProvider.SHA512:
					hash = new SHA512Managed();
					break;

				case HashProvider.MD5:
				default:
					hash = new MD5CryptoServiceProvider();
					break;
			}

			return hash;
		}

		private static string ComputeHash(HashProvider hashAlgorithm, string plainText, byte[] salt)
		{
			// Convert plain text into a byte array
			byte[] data = Encoding.UTF8.GetBytes(plainText);
			int dataLength = data.Length;

			// Random salt
			int saltLength = salt.Length;

			// Append the salt to the end of the plainText
			byte[] dataSalt = new byte[dataLength + saltLength];

			// Copy both the data and salt into the new array
			Array.Copy(data, dataSalt, dataLength);
			Array.Copy(salt, 0, dataSalt, dataLength, saltLength);

			// Compute hash value of our plain text with appended salt.
			byte[] encrypt = GetHashProvider(hashAlgorithm).ComputeHash(dataSalt);
			int encryptLength = encrypt.Length;

			// Append the salt to the end of the encrypt
			byte[] encryptSalt = new byte[encryptLength + saltLength];
			Array.Copy(encrypt, encryptSalt, encryptLength);
			Array.Copy(salt, 0, encryptSalt, encryptLength, saltLength);

			return Convert.ToBase64String(encryptSalt);
		}
	}
}
