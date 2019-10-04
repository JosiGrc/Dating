using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Dating.Models
{
    public class Identify
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }

        public Genders Gender { get; set; }
        public Races Race { get; set; }
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