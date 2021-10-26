using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string PhotoTitle { get; set; }
        public string ContentLink { get; set; }
        public int PhotoSize { get; set; }
        public DateTime PhotoCreationDate { get; set; }
        public int PhotoAuthor { get; set; }
        public int PhotoCost { get; set; }
        public int PhotoPurchasesMadeNumber { get; set; }

        [ForeignKey(nameof(PhotoAuthor))]
        public Author AuthorID { get; set; }

    }
}
