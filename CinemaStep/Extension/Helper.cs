using CinemaStep.Model;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.Extension
{
    public static class Helper
    {
        public static MainWindow MainWindow { get; set; }
        public static UserWindow UserWindow { get; set; }
        public static ViewFilms ViewFilms { get; set; }
        public static ViewFilmsControl ViewFilmsControl { get; set; }
        public static ViewCurrentFilms ViewCurrentFilms { get; set; }
        public static ManagementView managementView { get; set; }
        public static Bookings Bookings { get; set; }
        public static Film Film { get; set; }

    }
}
