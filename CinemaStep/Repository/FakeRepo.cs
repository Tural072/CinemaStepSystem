using CinemaStep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.Repository
{
    public static class FakeRepo
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static User User { get; set; }
        public static User OldUser { get; set; }
        public static List<Film> GetAll() {
            return new List<Film> { 
            new Film{
            Id=1,
            Description="lksdjfh",
            Name=",jkahdf",
            Imdb=1,
            Type="sdv",
            ImagePath="../Images/bookedSuccessfully.png"
            }
            };
        }
    }
}
