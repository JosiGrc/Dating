using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class Identify
    {
        [Key]
        public int Id { get; set; }
        public Genders Gender { get; set; }
        public Races Race { get; set; }
        public string Personality { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public enum Genders
        {
            StraightMale,
            GayMale,
            StraightFemale,
            GayFemale,
        }

        public enum Races
        {
            Asian, 
            African,
            BlackAMerican,
            Caucasian,
            Hispanic
            
        }

    }
}