using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;
using System.Drawing;
using Microsoft.VisualBasic;


public class clsTool_2
{
    public enum eumTransType
    {
        New,
        UPDATE,
        Deleted,
        Enabled
    };

    private static Dictionary<string, string> pdicUsedFieldLimit = new Dictionary<string, string>();
    private static string pstrDeleteSign = "19110101";



    /// <summary>
    /// 計算字串長度(長度計算:一中文:2,一英文:1)
    /// </summary>
    /// <param name="sValue"></param>
    /// <returns></returns>
    public static int funGetLenCE(string sValue)
    {
        try
        {
            return Encoding.GetEncoding("big5").GetBytes(sValue).Length;
        }
        catch
        {
            return 0;
        }
    }

    /// <summary>
    /// 取字串 (Null -> Empty String)
    /// </summary>
    /// <param name="sValue"></param>
    /// <returns></returns>
    public static string funGetStr(object sValue)
    {
        try
        {
            if (sValue == null)
                throw new Exception();

            if (string.IsNullOrWhiteSpace(Convert.ToString(sValue)))
                throw new Exception();
            else
                return Convert.ToString(sValue);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// 取Combox的值(去除描述)
    /// Input : Combox.Text
    /// </summary>
    /// <param name="sValue"></param>
    /// <returns></returns>
    public static string funGetComboxValue(string sValue)
    {
        try
        {
            int i = sValue.IndexOf(":");

            if (i >= 0)
                return sValue.Substring(0, i).Trim();
            else
                return sValue.Trim();
        }
        catch (Exception)
        {
            return "";
        }
    }









    /// <summary>
    /// 將輸入字串轉換為有效格式化日期字串(yyyy-MM-dd hh:mm:ss)
    /// </summary>
    /// <param name="日期字串"></param>
    /// <returns></returns>
    public static string funGetValidDate(string sDateTime)
    {
        try
        {
            if (sDateTime == "")
                throw new Exception();

            string sNewFormat = "yyyy-MM-dd";

            if (sDateTime.Length > 8 && sDateTime.Length <= 12)
                sNewFormat = "yyyy-MM-dd HH:mm:ss";
            if (sDateTime.Length > 12)
                sNewFormat = "yyyy-MM-dd HH:mm:ss";

            string[] DataFormats = new string[] { "yyyyMMdd", "yyyyMd", "yyMMdd", "yyyMMdd", "yMd", "yyyy/MMdd", "yyyy/M/d", "yy/MM/dd", "yyy/MM/dd", "y/M/d", "yyyy-MM-dd", "yyyy/M/d", "yy-MM-dd", "yyy-MM-dd", "y-M-d", "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss" };

            DateTime dtTmp = DateTime.ParseExact(sDateTime, DataFormats, null, DateTimeStyles.AllowWhiteSpaces);

            if (dtTmp.ToString("yyyyMMdd", new System.Globalization.CultureInfo("en-US")) == pstrDeleteSign)
                throw new Exception();

            return dtTmp.ToString(sNewFormat);
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// 將輸入字串轉換為有效格式化時間字串(HH:mm:ss/HH:mm)
    /// </summary>
    /// <param name="sTime"></param>
    /// <returns></returns>
    public static string funGetValidTime(string sTime)
    {
        try
        {
            string sNewFormat = "HH:mm:ss";

            if (sTime.Length <= 4)
                sNewFormat = "HH:mm";

            string[] DataFormats = new string[] { "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyy-MM-dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm", "HHmmss", "HHmm", "HHms", "HH:m:s", "H:m:s" };

            DateTime dtTmp = DateTime.ParseExact(sTime, DataFormats, null, DateTimeStyles.AllowWhiteSpaces);
            return dtTmp.ToString(sNewFormat);
        }
        catch
        {
            return "";
        }
    }

    public static byte Asc(string character)
    {
        if (character.Length == 1)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            byte intAsciiCode = (byte)asciiEncoding.GetBytes(character)[0];
            return (intAsciiCode);
        }
        else
        {
            throw new Exception("Character is not valid.");
        }

    }

    public static string Chr(byte asciiCode)
    {
        if (asciiCode >= 0 && asciiCode <= 255)
        {
            System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
            byte[] byteArray = new byte[] { (byte)asciiCode };
            string strCharacter = asciiEncoding.GetString(byteArray);
            return (strCharacter);
        }
        else
        {
            throw new Exception("ASCII Code is not valid.");
        }
    }

    public static string funEncrypt(string strEncrypt, string PWSkey) 
    {
        short MIN_ASC = 32;
        short MAX_ASC = 126;
        short NUM_ASC = (short)(MAX_ASC - MIN_ASC + 1);

        int offset;
        int intPWSstringLen;
        short intCH;
        string strDecode="";


        offset = funNumericPassword(PWSkey);
        //Rnd -1
        //Randomize offset
        VBMath.Rnd(-1);
        VBMath.Randomize(offset);

        strEncrypt = strEncrypt.Replace(Chr(8), "'");
    
        intPWSstringLen = strEncrypt.Length ;
        for (int i = 0; i < intPWSstringLen; i++)
        {
            intCH = (short)(Strings.Asc(strEncrypt.Substring(i, 1)));
            if ((intCH >= MIN_ASC) && (intCH <= MAX_ASC))
            {
                intCH = (short)(intCH - MIN_ASC);

                offset = (short)((NUM_ASC + 1) * VBMath.Rnd());
                intCH = (short)((intCH - offset) % NUM_ASC);
                if (intCH < 0) intCH = (short)(intCH + NUM_ASC);
                intCH = (short)(intCH + MIN_ASC);
                strDecode = strDecode + System.Convert.ToString(Strings.Chr(intCH));
            }
        }

        return strDecode;
    }

    public static string funDecrypt(string strEncrypt, string PWSkey )
    {
        short MIN_ASC = 32;
        short MAX_ASC = 126;
        short NUM_ASC = (short)(MAX_ASC - MIN_ASC + 1);

        int offset;
        int intPWSstringLen;

        short intCH;
        string strEncry=string.Empty ;

        offset = funNumericPassword(PWSkey);
        //Rnd -1
        //Randomize offset
        VBMath.Rnd(-1);
        VBMath.Randomize(offset);

        intPWSstringLen = strEncrypt.Length ;
        for (int i = 0; i < intPWSstringLen; i++)
        {
            intCH = (short)(Strings.Asc(strEncrypt.Substring(i, 1)));
            if ((intCH >= MIN_ASC) && (intCH <= MAX_ASC)) intCH = (short)(intCH - MIN_ASC);
            offset = (short)((NUM_ASC + 1) * VBMath.Rnd());
            intCH = (short)((intCH + offset) % NUM_ASC);
            intCH = (short)(intCH + MIN_ASC);
            strEncry = strEncry + System.Convert.ToString(Strings.Chr(intCH));
        }
        strEncry = strEncry.Replace("'", Chr(8));
        return strEncry;
    }

    public static int funNumericPassword(string Password)
    {
        int value=0;
        int ch=0;
        int shift1=0;
        int shift2=0;
        int str_len= Password.Length ;

        for (int i = 0; i < str_len; i++)
        {
                ch = Asc(Password.Substring(i, 1));
                value = value ^ (ch * Convert.ToInt32(Math.Pow(2, shift1)));
                value = value ^ (ch * Convert.ToInt32(Math.Pow(2, shift2)));
                shift1 = (shift1 + 7) % 19;
                shift2 = (shift2 + 13) % 23;
        }
            return value;
    }

    #region  加密
    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="encryptString"></param>
    /// <param name="encryptKey"></param>
    /// <returns></returns>
    public static string EncryptDES(string encryptString, string Keys, string IVs)
    {
        try
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(Keys);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IVs);
            byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
        catch
        {
            return encryptString;
        }
    }

    //private static byte[] Keys = { 0x14, 0x35, 0x52, 0x75, 0x91, 0xAB, 0xCD, 0xEF };
    //private static byte[] Keys = { 51, 53, 55, 56, 51, 50, 56, 48 }; //"35783280"
    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="decryptString"></param>
    /// <param name="decryptKey"></param>
    /// <returns></returns>
    public static string DecryptDES(string decryptString, string Keys, string IVs)
    {
        try
        {
            byte[] rgbKey = Encoding.UTF8.GetBytes(Keys);
            byte[] rgbIV = Encoding.UTF8.GetBytes(IVs);
            byte[] inputByteArray = Convert.FromBase64String(decryptString);
            DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray());
        }
        catch
        {
            return decryptString;
        }
    }

    #endregion


    /// <summary>
    /// 字串加密
    /// </summary>
    /// <param name="_strQ"></param>
    /// <returns></returns>
    //static string sKey = "M i r le";
    //static string sIV = "35783280";
    static string sKey = "22099478";
    static string sIV = "35783280";
    public static string funStrEncrypt(string _strQ)
    {


        try
        {
            byte[] buffer = Encoding.UTF8.GetBytes(_strQ);

            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, tdes.CreateEncryptor(Encoding.UTF8.GetBytes(sKey), Encoding.UTF8.GetBytes(sIV)), CryptoStreamMode.Write);

            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }
        catch (ApplicationException Ex)
        {
            return Ex.Message;
        }
    }

    /// <summary>
    /// 字串解密
    /// </summary>
    /// <param name="_strQ"></param>
    /// <returns></returns>
    public static string funStrDecrypt(string _strQ)
    {
        try
        {
            byte[] buffer = Convert.FromBase64String(_strQ);

            MemoryStream ms = new MemoryStream();
            DESCryptoServiceProvider tdes = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(ms, tdes.CreateDecryptor(Encoding.UTF8.GetBytes(sKey), Encoding.UTF8.GetBytes(sIV)), CryptoStreamMode.Write);

            encStream.Write(buffer, 0, buffer.Length);
            encStream.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }
        catch
        {
            return "";
        }
    }
}

       

