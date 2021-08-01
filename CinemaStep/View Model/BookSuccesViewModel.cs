using CinemaStep.Command;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class BookSuccesViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }
        public BookSuccesViewModel(BookSucces bookSucces)
        {
            LogOutCommand = new RelayCommand((l) => 
            {
                bookSucces.Close();
            });

            BackCommand = new RelayCommand((b) => 
            {
                bookSucces.Close();
                Bookings bookings = new Bookings();
                bookings.ShowDialog();
            });
        }
    }
}
