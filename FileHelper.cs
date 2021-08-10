using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MailAgent
{
    public static class FileHelper
    {
        public static List<string> ReadEmailsFromExcel(string path)
        {
            List<string> lst = new List<string>();

            if(File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lst.Add(line);
                    }
                }
            }

            return lst;
        }
    }
}
