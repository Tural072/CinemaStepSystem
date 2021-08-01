using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class ViewFilmsControlViewModel : BaseViewModel
    {
        public RelayCommand BookNowCommand { get; set; }
        public ViewFilmsControlViewModel()
        {
            BookNowCommand = new RelayCommand((b) => 
            {
                Helper.ViewFilms.Close();
                Bookings bookings = new Bookings();
                bookings.ShowDialog();
            });
        }
    }
}
