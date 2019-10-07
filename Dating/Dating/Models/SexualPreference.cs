using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class SexualPreference
    {
        [Key]

        public int Id { get; set; }

        [Display(Name = "I am looking for: ")]
        public WantedGenders Gender { get; set; }

        [Display(Name = "I am looking for: ")]
        public WantedRaces Race { get; set; }

        [Display(Name = "I am looking for: ")]
        public WantedPersonalities Personality { get; set; } 

        [Display(Name = "I am looking for: ")]
        public int Age { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
    public enum WantedGenders
    {
        StraightMale,
        GayMale,
        StraightFemale,
        GayFemale
    }

    public enum WantedRaces
    {
        Asian,
        African,
        BlackAMerican,
        Caucasian,
        Hispanic
    }
    public enum WantedPersonalities
    {
        Introverted,
        Extroverted
    }
}