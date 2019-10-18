using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Looking for people within : ")]
        public Distance Miles { get; set; }


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
    public enum Distance
    {
        [Description("5 miles")]
        miles5,
        [Description("10 miles")]
        miles10,
        [Description("15 miles")]
        miles15,
        [Description("20 miles")]
        miles20
    }
}