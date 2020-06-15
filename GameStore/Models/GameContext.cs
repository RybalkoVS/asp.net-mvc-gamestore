using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class GameContext : DbContext
    {
        public GameContext() : base("DBconnection")
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}