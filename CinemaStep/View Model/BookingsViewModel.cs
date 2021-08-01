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
    public class BookingsViewModel:BaseViewModel
    {
        public RelayCommand BookSeatCommand { get; set; }
        public BookingsViewModel(Bookings bookings)
        {
            BookSeatCommand = new RelayCommand((bs) => {
                Helper.Bookings.Close();

                BookSucces bookSucces = new BookSucces();
                //ticketWindow1.UserNametxtblock.Text = FakeRepo.User.Name;
                //ticketWindow1.FilmTxtBlock.Text = ClassHelper.Film.Name;

                bookSucces.ShowDialog();
                bookings.Close();

            });
        }
       
    }
}
