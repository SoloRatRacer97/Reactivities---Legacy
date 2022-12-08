using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
      // Again, we are instantiating this class from DbContext that we get from Mofcrosoft.EntityFramrworkCore to make our lives easier.
      // I'm begining to see it here.... all these NuGet packages we are getting is kind of similar to npm installing stuff for JS all the time. I think..... the using statements are just like import statements. 
      public class DataContext : DbContext
      {
            public DataContext(DbContextOptions options) : base(options)
            {
            }

            // Here we are making the DbSet from the model that we created with Acitivty so the data will have that same stucture. The title is set to activiites:
            public DbSet<Activity> Activities { get; set; }
      }
}