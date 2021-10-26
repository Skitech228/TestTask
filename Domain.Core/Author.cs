using System;
using System.Collections.Generic;

namespace TestTask.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Text> Text { get; set; }
    }
}
