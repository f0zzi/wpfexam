using System.Collections.Generic;

namespace wpfexam.DataModel
{
    public class Category
    {
        public Category()
        {
            Receipts = new List<Receipt>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}