using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

namespace SameZeraIJedynka.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide Name")]
        [StringLength(25)]
        public string Name { get; set; }

        [Display(Name = "Start time")]
        [Required(ErrorMessage = "Please provide start time")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Number of participants")]
        [Required(ErrorMessage = "Please provide number of participants")]
        [Range(2, 100, ErrorMessage = "Please provide value from 2 to 100")]
        public int NumberOfParticipants { get; set; }
    }
}
