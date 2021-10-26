using System;

namespace Domain.Core
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }
}
