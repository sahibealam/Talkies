using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Net.Sockets;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;



public class AllClasses : Page
{
    public AllClasses()
    {

    }
    public static void Create_Directory_Session(int _count)
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + _count.ToString() + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name" + _count.ToString()] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name" + _count.ToString()] = temp_folder;
        }
    }
    public static void Create_Directory_Session()
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name"] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name"] = temp_folder;
        }
    }
    public static void Create_Directory_Session3(int _count)
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + _count.ToString() + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name1"] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name1"] = temp_folder;
        }
    }
    public static void Create_Directory_Session1()
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name1"] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name1"] = temp_folder;
        }
    }
    public static void Create_Directory_Session1(int _count)
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + _count.ToString() + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name1" + _count.ToString()] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name1" + _count.ToString()] = temp_folder;
        }
    }
    public static void Create_Directory_Session2()
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name2"] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name2"] = temp_folder;
        }
    }
    public static void Create_Directory_Session2(int _count)
    {
        string temp_folder = DateTime.Now.Ticks.ToString("x") + _count.ToString() + "_" + HttpContext.Current.Session["Person_Id"].ToString();
        if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/"))
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/K_Log/") + temp_folder + "/");
            HttpContext.Current.Session["Folder_Name2" + _count.ToString()] = temp_folder;
        }
        else
        {
            HttpContext.Current.Session["Folder_Name2" + _count.ToString()] = temp_folder;
        }
    }
    public void Render_PDF_Document(Literal _ltEmbed, string filePath)
    {
        string embed = "<object data=\"{0}\" type=\"application/pdf\" width=\"900px\" height=\"600px\">";
        embed += "If you are unable to view file, you can download from <a href = \"{0}\">here</a>";
        embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
        embed += "</object>";
        _ltEmbed.Text = string.Format(embed, ResolveUrl(filePath.Replace("\\", "/")));
    }

    public static string ByteArr_To_ASCII(string string_ByteArr)
    {
        if (string_ByteArr == null)
        {
            return "";
        }
        else
        {
            byte[] uni = Convert.FromBase64String(string_ByteArr);
            return System.Text.UTF8Encoding.UTF8.GetString(uni);
        }
    }
    public static bool SendMail(string subject, string emailBody, string To_Email_Address, string From_Email_Address, string From_Email_Password)
    {
        bool strResult = false;
        try
        {
            var fromAddress = new MailAddress(From_Email_Address, From_Email_Address);
            var toAddress = new MailAddress(To_Email_Address, To_Email_Address);
            string fromPassword = From_Email_Password;
            string strsubject = subject;
            string body = emailBody;

            //var smtp = new SmtpClient
            //{
            //    Host = "smtp.gmail.com",
            //    Port = 587,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            //};
            var smtp = new SmtpClient
            {
                Host = "smtpout.secureserver.net",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = strsubject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
            strResult = true;
        }
        catch (Exception ee)
        {
            strResult = false;
        }
        return strResult;
    }
    public static string getIPAddress()
    {
        try
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
        catch
        {
            return "";
        }
    }
    public static string convert_To_Indian_No_Format(string data, string _DataType)
    {
        if (data == "")
        {
            return "0";
        }
        else
        {
            string retVal = "";
            retVal = String.Format(new CultureInfo("en-IN", false), "{0:n}", Convert.ToDouble(data));
            if (_DataType == "Decimal")
            {

            }
            else
            {
                retVal = retVal.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
            return retVal;
        }
    }
    public static string convert_To_Laks(string data)
    {
        if (data == "")
        {
            return "0";
        }
        if (data == "0")
        {
            return "0";
        }
        else
        {
            string retVal = "";
            retVal = decimal.Round((Convert.ToDecimal(data) / 100000), 2, MidpointRounding.AwayFromZero).ToString();
            return retVal;
        }
    }
    public static string getIPAddress2()
    {
        HttpContext context = HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }

    public static string getMACAddress()
    {
        try
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            if (macAddresses == "")
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up)
                    {
                        macAddresses += nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }
            return macAddresses;
        }
        catch
        {
            return "";
        }
    }
    public static DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
    {
        DataTable dt = new DataTable();

        PropertyInfo[] columns = null;

        if (Linqlist == null) return dt;

        foreach (T Record in Linqlist)
        {

            if (columns == null)
            {
                columns = ((Type)Record.GetType()).GetProperties();
                foreach (PropertyInfo GetProperty in columns)
                {
                    Type colType = GetProperty.PropertyType;

                    if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                    == typeof(Nullable<>)))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }

                    dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                }
            }

            DataRow dr = dt.NewRow();

            foreach (PropertyInfo pinfo in columns)
            {
                dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                (Record, null);
            }

            dt.Rows.Add(dr);
        }
        return dt;
    }

    public static string ConvertNumbertoWords(long number)
    {
        if (number == 0)
        {
            return "ZERO";
        }

        if (number < 0)
        {
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        }

        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKES ";
            number %= 1000000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "")
            {
                words += "AND ";
            }

            var unitsMap = new[]
            {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
            var tensMap = new[]
            {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
            if (number < 20)
            {
                words += unitsMap[number];
            }
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                {
                    words += " " + unitsMap[number % 10];
                }
            }
        }
        return words;
    }
    public static void SendSMS(List<SMS_Objects> obj_SMS_Objects)
    {
        for (int i = 0; i < obj_SMS_Objects.Count; i++)
        {
            string MobileNum = obj_SMS_Objects[i].MobileNum;
            string SMS_Content = obj_SMS_Objects[i].SMS_Content;
            string SMS_Response = obj_SMS_Objects[i].SMS_Response;
            string Sid = obj_SMS_Objects[i].Sid;
            string sms_URL = "";

            if (Sid == "" || string.IsNullOrEmpty(Sid))
            {
                sms_URL = "http://prioritysms.tulsitainfotech.com/api/mt/SendSMS?user=urbandevelopment&password=urban&senderid=MASTER&channel=Trans&DCS=0&flashsms=0&number=" + MobileNum + "&text=" + SMS_Content + "&route=15";
            }
            else
            {
                sms_URL = "http://prioritysms.tulsitainfotech.com/api/mt/SendSMS?user=urbandevelopment&password=urban&senderid=" + Sid + "&channel=Trans&DCS=0&flashsms=0&number=" + MobileNum + "&text=" + SMS_Content + "&route=15";
            }

            try
            {
                WebRequest request;
                string MobileNo = MobileNum.Trim();
                string sms = SMS_Content.Trim();
                request = WebRequest.Create(sms_URL);
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response1.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                SMS_Response = responseFromServer.ToString().Trim();

                tbl_SMS obj_SMS = new tbl_SMS();
                obj_SMS.SMS_Content = sms;
                obj_SMS.SMS_Mobile_No = MobileNo;
                obj_SMS.SMS_Response = SMS_Response;
                new DataLayer().Insert_tbl_SMS(obj_SMS);

                reader.Close();
                dataStream.Close();
                response1.Close();
            }
            catch
            {
                SMS_Response = "Error";
            }
        }
    }
    public static string getAddress(string lat, string lng, string responseType)
    {
        string SMS_Response = "";
        string sms_URL = "https://maps.googleapis.com/maps/api/geocode/" + responseType + "?latlng=" + lat + "," + lng + "&key=AIzaSyD6sxtv-u4NTtcNychOw123dEULAPak1Fk";
        try
        {
            WebRequest request;
            request = WebRequest.Create(sms_URL);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response1 = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response1.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            SMS_Response = responseFromServer.ToString().Trim();
            reader.Close();
            dataStream.Close();
            response1.Close();
        }
        catch
        {
            SMS_Response = "";
        }
        return SMS_Response;
    }
    public static string ConvertDTToJSONString(DataTable dt)
    {
        string[][] zaggedArray = new string[dt.Rows.Count][];
        int i = 0;
        string[] arrColVal = null;
        foreach (DataRow dr1 in dt.Rows)
        {
            arrColVal = new string[dt.Columns.Count];
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                arrColVal[j] = dr1[j].ToString().Trim();
            }
            zaggedArray[i] = arrColVal;
            i = i + 1;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(zaggedArray);
        return jsonString;
    }

    public static string ConvertListToJSONString(List<string> obj)
    {
        string[][] zaggedArray = new string[obj.Count][];
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(obj);
        return jsonString;
    }

    public static DataSet FillMonthCombo()
    {
        string Year = DateTime.Now.Year.ToString();
        string[] strText = { "---Select---", "January", "Feburary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        string[] strValue = { "0", "01-" + Year, "02-" + Year, "03-" + Year, "04-" + Year, "05-" + Year, "06-" + Year, "07-" + Year, "08-" + Year, "09-" + Year, "10-" + Year, "11-" + Year, "12-" + Year };
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn dc = new DataColumn();
        if (strText.Length == strValue.Length)
        {
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "Text";
            dt.Columns.Add(dc);
            DataColumn dc1 = new DataColumn();
            dc1.DataType = System.Type.GetType("System.String");
            dc1.ColumnName = "Value";
            dt.Columns.Add(dc1);
            for (int i = 0; i < strText.Length; i++)
            {
                DataRow dr;
                dr = dt.NewRow();
                dr["Text"] = strText[i];
                dr["Value"] = strValue[i];
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
        }
        else
        {
            ds = null;
        }
        return ds;
    }
    public static DataTable FilterDT(DataTable dt, DataTable dsAccess, string CompareField1, string CompareField2, string TextShow)
    {
        DataTable dtResult = new DataTable();
        if (dt != null && dt.Rows.Count > 0)
        {
            var result = from dataRows1 in dt.AsEnumerable()
                         join dataRows2 in dsAccess.AsEnumerable()
                         on dataRows1.Field<int>(CompareField1) equals dataRows2.Field<int>(CompareField2)
                         select new { CompareField1 = dataRows1[CompareField1], TextShow = dataRows1[TextShow] };

            dtResult = AllClasses.LINQResultToDataTable(result);
        }
        dtResult.Columns["CompareField1"].ColumnName = CompareField1;
        dtResult.Columns["TextShow"].ColumnName = TextShow;
        return dtResult;
    }

    public bool getBarCode(string strData, int imageHeight, int imageWidth, string Forecolor, string Backcolor, bool bIncludeLabel, string strImageFormat, string strAlignment, string barcodeType, ref string savedPath)
    {
        bool flag = true;
        //BarCodeLib.Barcode b = new BarCodeLib.Barcode(BarCodeLib.TYPE.UPCA, "038000356216", Color.Black, Color.White, 300, 150);
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

        switch (barcodeType)
        {
            case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
            case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
            case "UPC 2 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
            case "UPC 5 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
            case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
            case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
            case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
            case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
            case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
            case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
            case "Bookland-ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
            case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
            case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
            case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
            case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
            case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
            case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
            case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
            case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
            case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
            case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
            case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
            case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
            case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
            case "FIM (Facing Identification Mark)": type = BarcodeLib.TYPE.FIM; break;
            default: break;
        }
        System.Drawing.Image barcodeImage = null;
        try
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.IncludeLabel = bIncludeLabel;

                //alignment
                switch (strAlignment.ToLower().Trim())
                {
                    case "c":
                        b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                        break;
                    case "r":
                        b.Alignment = BarcodeLib.AlignmentPositions.RIGHT;
                        break;
                    case "l":
                        b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                        break;
                    default:
                        b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                        break;
                }//switch

                if (Forecolor.Trim() == "" && Forecolor.Trim().Length != 6)
                {
                    Forecolor = "000000";
                }

                if (Backcolor.Trim() == "" && Backcolor.Trim().Length != 6)
                {
                    Backcolor = "FFFFFF";
                }
                //Forecolor = "FF0000";
                //===== Encoding performed here =====
                barcodeImage = b.Encode(type, strData.Trim(), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), imageWidth, imageHeight);

                //===== Static Encoding performed here =====
                //barcodeImage = BarcodeLib.Barcode.DoEncode(type, this.txtData.Text.Trim(), this.chkGenerateLabel.Checked, this.btnForeColor.BackColor, this.btnBackColor.BackColor);

                MemoryStream MemStream = new System.IO.MemoryStream();

                switch (strImageFormat)
                {
                    case "gif": barcodeImage.Save(MemStream, ImageFormat.Gif); break;
                    case "jpeg": barcodeImage.Save(MemStream, ImageFormat.Jpeg); break;
                    case "png": barcodeImage.Save(MemStream, ImageFormat.Png); break;
                    case "bmp": barcodeImage.Save(MemStream, ImageFormat.Bmp); break;
                    case "tiff": barcodeImage.Save(MemStream, ImageFormat.Tiff); break;
                    default: break;
                }
                //MemStream.WriteTo(Response.OutputStream);
                File.WriteAllBytes(HttpContext.Current.Server.MapPath(".") + "\\BarCode_Data\\" + strData + ".gif", MemStream.ToArray());
                //savedPath = HttpContext.Current.Server.MapPath(".") + "\\BarCode_Data\\" + strData + ".gif";

                savedPath = "BarCode_Data\\" + strData + ".gif";
            }
        }
        catch
        {
            flag = false;
        }
        finally
        {
            //Clean up / Dispose...
            //barcodeImage.Dispose();
        }

        return flag;
    }

    public bool getBarCodeInvoice(string strData, int imageHeight, int imageWidth, string Forecolor, string Backcolor, bool bIncludeLabel, string strImageFormat, string strAlignment, string barcodeType, ref string savedPath)
    {
        try
        {
            strData = strData.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0].PadLeft(5, '0') + strData.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[1].PadLeft(5, '0');
        }
        catch
        {
            strData = strData.Replace("_", "").PadLeft(10, '0');
        }
        bool flag = true;
        //BarCodeLib.Barcode b = new BarCodeLib.Barcode(BarCodeLib.TYPE.UPCA, "038000356216", Color.Black, Color.White, 300, 150);
        BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

        switch (barcodeType)
        {
            case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
            case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
            case "UPC 2 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
            case "UPC 5 Digit Ext": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
            case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
            case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
            case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
            case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
            case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
            case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
            case "Bookland-ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
            case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
            case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
            case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
            case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
            case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
            case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
            case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
            case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
            case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
            case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
            case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
            case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
            case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
            case "FIM (Facing Identification Mark)": type = BarcodeLib.TYPE.FIM; break;
            default: break;
        }
        System.Drawing.Image barcodeImage = null;
        try
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            if (type != BarcodeLib.TYPE.UNSPECIFIED)
            {
                b.IncludeLabel = bIncludeLabel;

                //alignment
                switch (strAlignment.ToLower().Trim())
                {
                    case "c":
                        b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                        break;
                    case "r":
                        b.Alignment = BarcodeLib.AlignmentPositions.RIGHT;
                        break;
                    case "l":
                        b.Alignment = BarcodeLib.AlignmentPositions.LEFT;
                        break;
                    default:
                        b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
                        break;
                }//switch

                if (Forecolor.Trim() == "" && Forecolor.Trim().Length != 6)
                {
                    Forecolor = "000000";
                }

                if (Backcolor.Trim() == "" && Backcolor.Trim().Length != 6)
                {
                    Backcolor = "FFFFFF";
                }
                //Forecolor = "FF0000";
                //===== Encoding performed here =====
                barcodeImage = b.Encode(type, strData.Trim(), System.Drawing.ColorTranslator.FromHtml("#" + Forecolor), System.Drawing.ColorTranslator.FromHtml("#" + Backcolor), imageWidth, imageHeight);

                //===== Static Encoding performed here =====
                //barcodeImage = BarcodeLib.Barcode.DoEncode(type, this.txtData.Text.Trim(), this.chkGenerateLabel.Checked, this.btnForeColor.BackColor, this.btnBackColor.BackColor);

                MemoryStream MemStream = new System.IO.MemoryStream();

                switch (strImageFormat)
                {
                    case "gif": barcodeImage.Save(MemStream, ImageFormat.Gif); break;
                    case "jpeg": barcodeImage.Save(MemStream, ImageFormat.Jpeg); break;
                    case "png": barcodeImage.Save(MemStream, ImageFormat.Png); break;
                    case "bmp": barcodeImage.Save(MemStream, ImageFormat.Bmp); break;
                    case "tiff": barcodeImage.Save(MemStream, ImageFormat.Tiff); break;
                    default: break;
                }
                //MemStream.WriteTo(Response.OutputStream);
                File.WriteAllBytes(HttpContext.Current.Server.MapPath(".") + "\\BarCode_Invoice\\" + strData + ".gif", MemStream.ToArray());
                //savedPath = HttpContext.Current.Server.MapPath(".") + "\\BarCode_Data\\" + strData + ".gif";

                savedPath = "BarCode_Invoice\\" + strData + ".gif";
            }
        }
        catch
        {
            flag = false;
        }
        finally
        {
            //Clean up / Dispose...
            //barcodeImage.Dispose();
        }

        return flag;
    }

    public static string Get24HourTime(int hour, int minute, int seconds, string ToD, DateTime dt)
    {
        int year = dt.Year;
        int month = dt.Month;
        int day = dt.Day;
        if (ToD.ToUpper() == "PM")
        {
            hour = (hour % 12) + 12;
        }

        if (ToD.ToUpper() == "AM")
        {
            if (hour == 12)
            {
                hour = 0;
            }
        }

        return new DateTime(year, month, day, hour, minute, seconds).ToString("HH:mm:ss");
    }

    public static bool CheckDataSet(DataSet ds)
    {
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            return true;
        }
        return false;
    }

    public static void FillHour(ref DropDownList ddlHourdel)
    {
        ddlHourdel.Items.Clear();
        for (int i = 0; i < 24; i++)
        {
            ddlHourdel.Items.Add(i.ToString().PadLeft(2, '0'));
        }
    }

    public static void FillMinuteAndSecond(ref DropDownList ddlmindel)
    {
        ddlmindel.Items.Clear();
        for (int i = 0; i < 60; i++)
        {
            ddlmindel.Items.Add(i.ToString().PadLeft(2, '0'));
        }
    }

    public static void FillDropDown(DataTable dt, DropDownList ddl, string TextField, string ValueField)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            DataRow dr = dt.NewRow();

            dr[TextField] = "--Select--";
            dr[ValueField] = "0";
            dt.Rows.InsertAt(dr, 0);
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField;
            ddl.DataSource = dt;
            ddl.DataBind();

            //dt.Rows.RemoveAt(0);
        }
    }

    public static void FillDropDown_WithOutSelect(DataTable dt, DropDownList ddl, string TextField, string ValueField)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField;

            ddl.DataSource = dt;
            ddl.DataBind();
        }
    }

    public static bool CheckDt(DataTable dt)
    {
        if (dt != null && dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool chackDate(string _fromDate, string _tillDate)
    {
        DateTime dtCurrentDate = DateTime.ParseExact(HttpContext.Current.Session["ServerDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        DateTime dtFYStart = DateTime.ParseExact(HttpContext.Current.Session["FinancialYearStart"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime dtFYEnd = DateTime.ParseExact(HttpContext.Current.Session["FinancialYearEnd"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        DateTime fromDate = DateTime.ParseExact(_fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime tillDate = DateTime.ParseExact(_tillDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        TimeSpan tsFrom = fromDate - dtFYStart;
        TimeSpan tsTo = dtFYEnd - tillDate;

        TimeSpan tsCurr = dtCurrentDate - tillDate;

        if (tsCurr.TotalDays < 0)
        {
            return false;
        }
        if (tsFrom.TotalDays < 0)
        {
            return false;
        }
        if (tsTo.TotalDays < 0)
        {
            return false;
        }
        return true;
    }

    public static void Set_Dates(TextBox txtDateFrom, TextBox txtDateTill)
    {
        string[] FyEnd = HttpContext.Current.Session["FinancialYearEnd"].ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        string[] CurrDate = HttpContext.Current.Session["ServerDate"].ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
        DateTime dtFyEnd = new DateTime(int.Parse(FyEnd[2]), int.Parse(FyEnd[1]), int.Parse(FyEnd[0]));
        DateTime dtCurrDate = new DateTime(int.Parse(CurrDate[2]), int.Parse(CurrDate[1]), int.Parse(CurrDate[0]));
        if (dtCurrDate.Subtract(dtFyEnd).TotalDays > 0)
        {
            txtDateFrom.Text = HttpContext.Current.Session["FinancialYearEnd"].ToString();
            txtDateTill.Text = HttpContext.Current.Session["FinancialYearEnd"].ToString();
        }
        else
        {
            txtDateFrom.Text = HttpContext.Current.Session["ServerDate"].ToString();
            txtDateTill.Text = HttpContext.Current.Session["ServerDate"].ToString();
        }
    }

    public static string getmonth(string mnth)
    {
        switch (mnth)
        {
            case "01":
                {
                    //  Label4.Text = "जनवरी";
                    return "January";

                }
            case "02":
                {
                    return "Febuary"; //Label9.Text = "फरवरी";

                }
            case "03":
                {
                    return "March"; //Label9.Text = "मार्च";


                }
            case "04":
                {
                    return "April"; //Label9.Text = "अप्रैल";

                }
            case "05":
                {
                    return "May"; //Label9.Text = "मई";

                }
            case "06":
                {
                    return "June"; //Label9.Text = "जून";

                }
            case "07":
                {
                    return "July"; //Label9.Text = "जुलाई";

                }
            case "08":
                {
                    return "August"; //Label9.Text = "अगस्त";

                }
            case "09":
                {
                    return "September"; //Label9.Text = "सितम्बर";

                }
            case "10":
                {
                    return "October"; //Label9.Text = "अक्टूबर";

                }
            case "11":
                {
                    return "November"; //Label9.Text = "नवम्बर";

                }
            case "12":
                {
                    return "December"; //Label9.Text = "दिसम्बर";

                }

        }
        return "";
    }

    public static string getmonthval(string mnth)
    {
        mnth = mnth.Substring(0, 3);
        switch (mnth)
        {
            case "Jan":
                {
                    return "1";
                }
            case "Feb":
                {
                    return "2";
                }
            case "Mar":
                {
                    return "3";
                }
            case "Apr":
                {
                    return "4";
                }
            case "May":
                {
                    return "5";
                }
            case "Jun":
                {
                    return "6";
                }
            case "Jul":
                {
                    return "7";
                }
            case "Aug":
                {
                    return "8";
                }
            case "Sep":
                {
                    return "9";
                }
            case "Oct":
                {
                    return "10";
                }
            case "Nov":
                {
                    return "11";
                }
            case "Dec":
                {
                    return "12";
                }
        }
        return "";
    }
    public static string re_Organize_GO_No(string GO_No, bool Replace_Special_Symbols)
    {
        string retVal = GO_No;
        retVal = GO_No.Replace("०", "0").Replace("१", "1").Replace("२", "2").Replace("३", "3").Replace("४", "4").Replace("५", "5").Replace("६", "6").Replace("७", "7").Replace("८", "8").Replace("९", "9").Replace(" ", "");
        if (Replace_Special_Symbols)
            retVal = retVal.Replace("-", "").Replace("/", "").Replace("\\", "").Replace("(", "").Replace(")", "");
        return retVal;
    }
}
public class SMS_Objects
{
    public string MobileNum { get; set; }
    public string SMS_Content { get; set; }
    public string SMS_Response { get; set; }
    public string Sid { get; set; }
}
public class tbl_SMS
{
    public int SMS_Id { get; set; }
    public string SMS_Mobile_No { get; set; }
    public string SMS_Content { get; set; }
    public string SMS_Response { get; set; }
    public string SMS_AddedOn { get; set; }
}
public class tbl_UserLogin
{
    public int Login_AddedBy { get; set; }
    public string Login_Addeddatetime { get; set; }
    public int Login_Id { get; set; }
    public string Login_password { get; set; }
    public int Login_PersonId { get; set; }
    public int Login_Status { get; set; }
    public string Login_UserName { get; set; }
}
public class tbl_Category
{
    public int Category_AddedBy { get; set; }
    public string Category_AddedOn { get; set; }
    public int Category_ModifiedBy { get; set; }
    public string Category_ModifiedOn { get; set; }
    public string Category_Name { get; set; }
    public int Category_Id { get; set; }
    public int Category_Status { get; set; }
}
public class tbl_Starring
{
    public int Starring_Id { get; set; }
    public string Starring_Name { get; set; }
    public string Starring_Type { get; set; }
    public int Starring_Status { get; set; }
    public int Starring_AddedBy { get; set; }
    public DateTime Starring_AddedOn { get; set; }
    public int Starring_ModifiedBy { get; set; }
    public DateTime Starring_ModifiedOn { get; set; }

}

public class tbl_Studio
{
    public int Studio_Id { get; set; }
    public string Studio_Name { get; set; }
    public int Studio_Status { get; set; }
    public int Studio_AddedBy { get; set; }
}
public class tbl_Genere
{
    public int Genere_Id { get; set; }
    public string Genere_Name { get; set; }
    public int Genere_Status { get; set; }
    public int Genere_AddedBy { get; set; }

}

public class save_account
{
    public int save_id { get; set; }
    public string save_name { get; set; }
    public string save_Username { get; set; }
    public string save_mobile { get; set; }
    public String save_email { get; set; }
    public String save_password { get; set; }
    public String save_confirmpassword { get; set; }
    public String save_gender { get; set; }
    public String save_age { get; set; }
    public String save_AddedOn { get; set; }
    public String save_AddedBy { get; set; }
    public String save_ModifiedOn { get; set; }
    public String save_ModifiedBy { get; set; }
    public String save_status { get; set; }


}



public class tbl_Album_Save
{
    public int Album_Id { get; set; }
    public string Album_Name { get; set; }
    public string Album_Description { get; set; }
    public int Album_Rating { get; set; }
    public string Album_Mounting_Rating { get; set; }
    public int Album_Studio_Id { get; set; }
    public int Album_Category { get; set; }
    public int Album_AddedBy { get; set; }
    public string Album_AddedOn { get; set; }
    public int Album_ModifiedBy { get; set; }
    public string Album_ModifiedOn { get; set; }
    public int Album_Status { get; set; }
}
public class tbl_Album_Staff
{
    public int AlbumStaff_Id { get; set; }
    public int AlbumStaff_Album_Id { get; set; }
    public int AlbumStaff_Starring_id { get; set; }
    public int AlbumStaff_AddedBy { get; set; }
    public string AlbumStaff_AddedOn { get; set; }
    public int AlbumStaff_ModifiedBy { get; set; }
    public string AlbumStaff_ModifiedOn { get; set; }
    public int AlbumStaff_Status { get; set; }
    
}
public class tbl_Album_Genere
{
    public int AlbumGenere_Id { get; set; }
    public int AlbumGenere_Album_Id { get; set; }
    public int AlbumGenere_Genere_id { get; set; }
    public int AlbumGenere_AddedBy { get; set; }
    public string AlbumGenere_AddedOn { get; set; }
    public int AlbumGenere_ModifiedBy { get; set; }
    public string AlbumGenere_ModifiedOn { get; set; }
    public int AlbumGenere_Status { get; set; }

}

public class tbl_Upload_Banner
{
    public int AlbumUpload_Id { get; set; }
    public int AlbumUpload_Album_Id { get; set; }
    public string AlbumUpload_Path { get; set; }
    public string AlbumUpload_Type { get; set; }
    public byte[] AlbumUpload_File_Bytes { get; set; }
    public string AlbumUpload_AddedOn { get; set; }
    public int AlbumUpload_ModifiedBy { get; set; }
    public string AlbumUpload_ModifiedOn { get; set; }
    public int AlbumUpload_Status { get; set; }

}
public class tbl_Review
{
    public int tbl_Review_id { get; set; }
    public int tbl_Review_Rating { get; set; }
    public String tbl_Review_Comment { get; set; }
    public String tbl_Review_faviourate { get; set; }
    public int tbl_Review_Album_id { get; set; }
    public int tbl_Review_User_id { get; set; }
    public String tbl_Review_Status { get; set; }
    public int tbl_Review_AddedBy { get; set; }
    public DateTime tbl_Review_AddedOn { get; set; }
    public int tbl_Review_ModifiedBy { get; set; }
    public DateTime tbl_Review_ModifiedOn { get; set; }
   


}
public class tbl_Company
{
    public int tbl_Company_id { get; set; }
    public String tbl_Company_Name { get; set; }
    public String Ato_sell { get; set; }
    public String Ato_By { get; set; }
    public string Totl_sell { get; set; }
    public String Totl_Qty { get; set; }
    public String tbl_Final_Qty { get; set; }
    public String tbl_Self_result { get; set; }
    public String tbl_NSE_result { get; set; }
    public String Date { get; set; }
    public int tbl_Company_Status { get; set; }



}








