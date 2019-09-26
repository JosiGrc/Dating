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
        public bool Male { get; set; }
        public bool Female { get; set; }
        public bool GayMale { get; set; }
        public bool GayFemale { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}