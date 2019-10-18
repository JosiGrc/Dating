using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dating.Models
{
    public class Identify
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "My age is : ")]
        public int Age { get; set; }

        [Display(Name = "My gender is : ")]
        public Genders Gender { get; set; }

        [Display(Name = "I am : ")]
        public Races Race { get; set; }

        [Display(Name = "I am : ")]
        public Personalities Personality { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
    public enum Genders
    {
        StraightMale,
        GayMale,
        StraightFemale,
        GayFemale
    }

    public enum Races
    {
        Asian,
        African,
        BlackAmerican,
        Caucasian,
        Hispanic
    }
    public enum Personalities
    {
        Introverted,
        Extroverted,
    }
}