using System.Security.Cryptography;
using System.Text;

namespace PwpClientLib.Hash
{
  public class HashMaker
  {
    //public static string Hash(string input)
    //{
    //  byte[] buffer = Encoding.UTF8.GetBytes(input);
    //  return Hash(buffer);
    //}
    public static string MakeSha1(byte[] buffer)
    {
      using (SHA1Managed sha1 = new SHA1Managed())
      {
        var hash = sha1.ComputeHash(buffer);
        var sb = new StringBuilder(hash.Length * 2);

        foreach (byte b in hash)
        {
          // can be "x2" if you want lowercase
          sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
      }
    }
  }
}
