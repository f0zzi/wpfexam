using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfexam.DataModel
{
    public class Receipt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Cooking { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual Category Category { get; set; }
    }
}
