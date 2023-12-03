using System.ComponentModel.DataAnnotations;

namespace myweb.Models
{
    public class Student
    {
        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set;
        }
    }
}
