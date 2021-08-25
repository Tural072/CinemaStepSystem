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
        public RelayCommand EmailCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public BookSuccesViewModel(BookSucces bookSucces)
        {
            CloseCommand = new RelayCommand((l) => 
            {
                bookSucces.Close();
            });

            EmailCommand = new RelayCommand((b) => 
            {
               
            });
        }
    }
}
