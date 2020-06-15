using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class Game
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public int ReleaseYear { get; set; }

        public string Image { get; set; }
    }
}