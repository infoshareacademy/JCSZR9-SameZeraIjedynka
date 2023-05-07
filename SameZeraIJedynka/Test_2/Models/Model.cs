using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Test_2.Models
{
    public class Model
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public bool isActive { get; set; }
    }
}
