using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    // Createing the Activity class to define what kind of stucture we want for the activities we will be working with.
    public class Activity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}