using System.Collections.Generic;

namespace RentAll.Domain.Models
{
    public class Category
    {
        public Category()
        {
            Activities = new List<Activity>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}