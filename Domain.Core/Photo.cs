using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class Photo : Author
    {
        public int PhotoId { get; set; }
        public string PhotoTitle { get; set; }
        public string ContentLink { get; set; }
        public int PhotoSize { get; set; }
        public DateTime PhotoCreationDate { get; set; }
        public int PhotoAuthor { get; set; }
        public int PhotoCost { get; set; }
        public int PhotoPurchasesMadeNumber { get; set; }
        public Author Id { get; set; }

    }
}
