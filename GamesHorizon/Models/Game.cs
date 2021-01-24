using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace GamesHorizon.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Display(Name = "Created By")] 
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "not a valid date")]
        public string Year { get; set; }

        //"Xbox","PC","PS5"
        [Display(Name = "Console")]
        [Required]
        public string GameConsole { get; set; } 



    }
}