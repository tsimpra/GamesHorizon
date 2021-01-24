using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesHorizon.Models
{
    public class GameUser
    {
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }
        [RegularExpression("^[0-9]{1,2}$", ErrorMessage = "not a valid age")]
        [Required]
        public int Age { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,9}$", ErrorMessage = "not a valid value")]      
        public float Balance { get; set; }

        public List<string> GamesBought { get; set; }
        public List<string> GamesSold { get; set; }
        public List<Game> GamesOnSale { get; set; }
    }
}