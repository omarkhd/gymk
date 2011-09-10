using System;
using System.Security.Cryptography;
using System.Text;

namespace omarkhd.Gymk
{
	public static class HashHelper
	{
		public static string GetMd5Of(string source)
		{
			MD5 md5 = MD5.Create();
			byte[] source_bytes = Encoding.UTF8.GetBytes(source);
			byte[] hashed = md5.ComputeHash(source_bytes);
			string hash_string = string.Empty;
			foreach(byte b in hashed)
				hash_string += b.ToString("x2");
			return hash_string;
		}
	}
}

