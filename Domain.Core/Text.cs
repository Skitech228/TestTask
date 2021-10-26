using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class Text : Author
    {
        public int TextId { get; set; }
        public string TextTitle { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public DateTime TextCreationDate { get; set; }
        public int TextAuthor { get; set; }
        public int TextCost { get; set; }
        public int TextPurchasesMadeNumber { get; set; }
        public Author Id { get; set; }
    }
}
