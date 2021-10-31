#region Using derectives

using System;

#endregion

namespace TestTask.Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Size { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
        public int Cost { get; set; }
        public int PurchasesMadeNumber { get; set; }
        public Author Author { get; set; }
    }
}