using System.Collections.Generic;

namespace RentAll.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}