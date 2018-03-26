using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace SDMS.Common
{
    public static class CommonHelper
    {
        public static string GetMD5(this string str)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str);
            return GetMD5(bytes);
        }
        public static string GetMD5(byte[] bytes)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(bytes);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                   computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }
        public static string GetMD5(Stream stream)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeBytes = md5.ComputeHash(stream);
                string result = "";
                for (int i = 0; i < computeBytes.Length; i++)
                {
                    result += computeBytes[i].ToString("X").Length == 1 ? "0" +
                   computeBytes[i].ToString("X") : computeBytes[i].ToString("X");
                }
                return result;
            }
        }
        public static string GetCaptcha(int length)
        {
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'g', 'k', 'm', 'p', 'r', 's', 't', 'w', 'x', 'y', '3', '4', '5', '7', '8' };
            StringBuilder sbCode = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                char ch = data[rand.Next(data.Length)];
                sbCode.Append(ch);
            }
            return sbCode.ToString();
        }

        public static void SendEmail(string[] receiveAddress, Dictionary<string, string> dicts)
        {
            using (MailMessage mailMessage = new MailMessage())
            using (SmtpClient smtpClient = new SmtpClient(dicts["SMTP"]))
            {
                for (int i = 0; i < receiveAddress.Length; i++)
                {
                    mailMessage.To.Add(receiveAddress[i]);
                }
                mailMessage.Body = dicts["MaliBody"];
                mailMessage.From = new MailAddress(dicts["SendAddress"]);
                mailMessage.Subject = dicts["MailTitle"];
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(dicts["SendAddress"], dicts["Password"]);//如果启用了“客户端授权码”，要用授权码代替密码
                smtpClient.Send(mailMessage);
            }
        }

        public static string FormatMoblie(string moblie)
        {
            StringBuilder formatMoblie = new StringBuilder();
            for(int i=0;i<moblie.Length;i++)
            {
                if(i>=3 && i<=6)
                {
                    formatMoblie.Append("*");
                }
                else
                {
                    formatMoblie.Append(moblie[i]);
                }
            }
            return formatMoblie.ToString();
        }

        public static string FormatUserName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return null;
            }
            StringBuilder formatName = new StringBuilder();
            formatName.Append(name[0]).Append("**");
            return formatName.ToString();
        }

        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                File.Copy(formFileName, toFileName);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static byte[] CaptureImage(MemoryStream ms, int offsetX, int offsetY , int width, int height)
        {
            //原图片文件
            Image fromImage = Image.FromStream(ms);
            //创建新图位图
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            MemoryStream ms1 = new MemoryStream();
            //保存图片
            saveImage.Save(ms1, ImageFormat.Jpeg);
            //释放资源   
            byte[] bytes = ms1.GetBuffer(); 
            saveImage.Dispose();
            fromImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
            ms1.Dispose();
            return bytes;
        }

        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            if(Htmlstring.Length<=30)
            {
                return Htmlstring;
            }
            return Htmlstring.Substring(0, 30);
        }
    }
}
