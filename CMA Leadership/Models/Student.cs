using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CMA_Leadership.Models
{
    //[Table("Student")]
    public class Student
    {
        public int StudentId { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public int Years_Attended { get; set; }
        public string Division { get; set; }
        public string? Current_Position { get; set; }
        public string? Current_Rank { get; set; }
        public string Unit { get; set; }
    }
}
