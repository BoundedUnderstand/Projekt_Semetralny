using System;
using System.Collections.Generic;

namespace GravityBookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public int NumPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public int SoldCopies { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}