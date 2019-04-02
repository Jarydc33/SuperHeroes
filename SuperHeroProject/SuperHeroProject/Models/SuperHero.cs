using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperHeroProject.Models
{
    public class SuperHero
    {

        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string alterName { get; set; }
        public string ability { get; set; }
        public string secondAbility { get; set; }
        public string catchphrase { get; set; }
    }
}