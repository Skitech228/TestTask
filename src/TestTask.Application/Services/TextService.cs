#region Using derectives

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Application.Services
{
    public class TextService
    {
        public void WriteCSVFile(string path, List<Text> text)
        {
            using (var sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            {
                using (var cw = new CsvWriter(sw, new CsvConfiguration(new CultureInfo("US"))))
                {
                    cw.WriteHeader<Text>();
                    cw.NextRecord();

                    foreach (var stu in text)
                    {
                        cw.WriteRecord(stu);
                        cw.NextRecord();
                    }
                }
            }
        }
    }
}