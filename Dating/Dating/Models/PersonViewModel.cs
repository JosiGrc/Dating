using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Dating.Models.Identify;

namespace Dating.Models
{
    public class PersonViewModel
    {
        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Display(Name = "Age:")]
        public int Age { get; set; }

        [Display(Name = "Zipcode:")]
        public int Location { get; set; }
    }
    public class IdentityViewModel
    {
        [Required]
        [Display(Name = "I am a:")]
        public Races Race { get; set; }
        public Genders Gender { get; set; }
        public string Personality { get; set; }
    }

    public class SexualPreferenceViewModel
    {

    }
}