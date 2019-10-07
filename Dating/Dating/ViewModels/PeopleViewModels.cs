using Dating.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Dating.Models.Identify;
using static Dating.Models.SexualPreference;

namespace Dating.ViewModels
{
    public class PeopleViewModels
    {
        public Person Person { get; set; }       

        public Identify Identify { get; set; }

        public SexualPreference SexualPreference { get; set; }
        
    }
}