using CMA_Leadership.Models;
using System;
using System.Collections.Generic;   
using System.Linq;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
    


namespace CMA_Leadership.Data
{
    public class DbInitializer
    {
        public static void Initialize(dbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }



            var students = new Student[]
            {
            new Student{StudentId = 603458, Last_Name="Miller",First_Name="Hunter", Years_Attended=3, Division="1st Classman", Current_Position="Platoon Commader", Current_Rank="2nd LT", Unit="BD"}
            };

            foreach (Student s in students)
            { 
                context.Students.Add(s);
            }
            context.SaveChanges();

        }
    }
}
