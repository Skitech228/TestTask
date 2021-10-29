#region Using derectives

using System;

#endregion

namespace TestTask.Domain.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountCreationDate { get; set; }
    }
}