using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Pages.Account_Setting;
using IMS.Model.HelperModel;
using System.Xml.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IMS.Helpers
{
    public class SettingHelper
    {
        public string ImageUri;

        // This is to create web cache path
        // and will help in managing the online site and other social account associated with
        public string WebCachePath()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + Process.GetCurrentProcess().ProcessName + "/Web/cache"))
            {
                _ = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + Process.GetCurrentProcess().ProcessName + "/Web");
                _ = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + Process.GetCurrentProcess().ProcessName + "/Web/cache");
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + Process.GetCurrentProcess().ProcessName + "/Web/cache";
        }

        public void CreateRequiredFiles()
        {
            string RequiredDirectoryPath = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + @"\IMS").ToString();
            if (!Directory.Exists(RequiredDirectoryPath))
            {
                _ = Directory.CreateDirectory(RequiredDirectoryPath + "studata");
            }
        }

        public string CreateConfigutionFilePath(string FileName)
        {
            String configFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Process.GetCurrentProcess().ProcessName + @"\IMS\Configs").ToString();
            if (!Directory.Exists(configFilePath))
            {
                _ = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Process.GetCurrentProcess().ProcessName + @"\IMS");
                _ = Directory.CreateDirectory(configFilePath);
                if (!File.Exists(configFilePath + @"\" + FileName))
                {
                    _ = File.Create(configFilePath + @"\" + FileName);
                }
            }
            return configFilePath + @"\" + FileName;
        }

        public string CreateContentFilePath(string FolderName, string FileName, string Extension)
        {
            string contentFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + Process.GetCurrentProcess().ProcessName + @"\IMS\" + FolderName).ToString();
            if (!Directory.Exists(contentFilePath))
            {
                _ = Directory.CreateDirectory(contentFilePath);
                if (!File.Exists(contentFilePath + "/" + FileName + Extension))
                {
                    _ = File.Create(contentFilePath + "/" + FileName + Extension);
                }
            }
            return contentFilePath + @"\" + FileName + Extension;
        }

        public void SaveSettings(Object DATA, String FileName, Type DataType)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(DataType);
                using (TextWriter textWriter = new StreamWriter(CreateConfigutionFilePath(FileName)))
                {
                    xmlSerializer.Serialize(textWriter, DATA);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public object RetriveSettings(String FileName, Type DataType)
        {
            //TODO To Add Encryption
            // "gConfig.secure"
            Object obj = null;
            try
            {
                if (!File.Exists(CreateConfigutionFilePath(FileName)))
                {
                    _ = File.Create(CreateConfigutionFilePath(FileName));
                    return obj;
                }
                if (new FileInfo(CreateConfigutionFilePath(FileName)).Length != 0)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(DataType);
                    using (TextReader textReader = new StreamReader(CreateConfigutionFilePath(FileName)))
                    {
                        obj = xmlSerializer.Deserialize(textReader);
                        textReader.Close();
                    }
                }

            }
            catch (Exception e)
            {
                // TODO TO Add A PRompt
                Console.WriteLine(e);
            }
            return obj;
        }

        public void Save(Object DATA, String FileName, Type DataType)
        {
            try
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(CreateConfigutionFilePath(FileName)))
                {
                    JsonWriter jsonWriter = new JsonTextWriter(sw);
                    jsonSerializer.Serialize(jsonWriter, DATA);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public object Retrive(String FileName, Type DataType)
        {
            //TODO To Add Encryption
            // "gConfig.secure"
            JObject obj = new JObject();
            obj = null;
            try
            {
                if (!File.Exists(CreateConfigutionFilePath(FileName)))
                {
                    _ = File.Create(CreateConfigutionFilePath(FileName));
                    return obj;
                }
                if (new FileInfo(CreateConfigutionFilePath(FileName)).Length != 0)
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    using (StreamReader textReader = new StreamReader(CreateConfigutionFilePath(FileName)))
                    {
                        JsonReader jsonReader = new JsonTextReader(textReader);
                        obj = jsonSerializer.Deserialize(jsonReader) as JObject;
                    }
                }

            }
            catch (Exception e)
            {
                // TODO TO Add A PRompt
                Console.WriteLine(e);
            }
            object DataObject = obj.ToObject(DataType);
            return DataObject;
        }

        public String CreateFiles(String Foldername ,String Filename)
        {
            String extension = ".xlsx";
            if (!File.Exists(CreateContentFilePath(Foldername, Filename, extension)))
            {
                File.Create(CreateContentFilePath(Foldername, Filename, extension));
                try
                {
                    _ = Process.Start(CreateContentFilePath(Foldername, Filename, extension));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                try
                {
                    _ = Process.Start(CreateContentFilePath(Foldername, Filename, extension));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return CreateContentFilePath(Foldername, Filename, extension);
        }

    }
}
