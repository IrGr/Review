using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
public class Helper
{
	public Helper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Bruges til at generer md5hash udfra input
    ///http://dotnet-snippets.com/snippet/generate-md5-hash/644
    /// </summary>
    /// <param name="textToHash"></param>
    /// <returns></returns>
    public static string GetMD5Hash(String textToHash)
    {
        //Check wether data was passed
        if ((textToHash == null) || (textToHash.Length == 0))
        {
            return String.Empty;
        }

        //Calculate MD5 hash. This requires that the string is splitted into a byte[].
        MD5 md5 = new MD5CryptoServiceProvider();

        byte[] hashed = Encoding.Default.GetBytes(textToHash);
        byte[] result = md5.ComputeHash(hashed);

        //Convert result back to string.
        return System.BitConverter.ToString(result);

    }

    /// <summary>
    /// Tjekker om brugeren er logget ind
    /// </summary>
    /// <returns></returns>
    public static bool ErLoggetInd()
    {
        if (HttpContext.Current.Session["brugernavn"] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    #region LogUd
    /// <summary>
    /// LogUd
    /// </summary>
    public static void LogUd()
    {
        HttpContext.Current.Session.Abandon();
        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }
    #endregion

}