using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using TestTask.Domain.Entity;
using TestTask.Shared.IEntityServices;

namespace TestTask.Application.Services
{
    public class TextService : ITextService
    {
        public void WriteCSVFile(string path, List<Text> text)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
                using (CsvWriter cw = new CsvWriter(sw,new CsvConfiguration(new CultureInfo("Text"))))
                {
                    cw.WriteHeader<Text>();
                    cw.NextRecord();

                    foreach (Text stu in text)
                    {
                        cw.WriteRecord<Text>(stu);
                        cw.NextRecord();
                    }
                }
        }  
    }
}