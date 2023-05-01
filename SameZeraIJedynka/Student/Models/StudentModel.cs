using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Student.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public bool isActive { get; set; }
    }
}
