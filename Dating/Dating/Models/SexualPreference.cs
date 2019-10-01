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
        [Display(Name = "A male")]
        public bool Male { get; set; }
        [Display(Name = "A Female")]
        public bool Female { get; set; }
        [Display(Name = "A gay man")]
        public bool GayMale { get; set; }
        [Display(Name = "A gay woman")]
        public bool GayFemale { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}