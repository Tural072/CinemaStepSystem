using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaStep.View_Model
{
    public class BookingsViewModel : BaseViewModel
    {
        public RelayCommand BookSeatCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand ButtonCommand { get; set; }
        public RelayCommand SelectedTimeCommand { get; set; }
        public string Time { get; set; }

        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }

        private Button button;

        public Button Button
        {
            get { return button; }
            set { button = value; OnPropertyChanged(); }
        }

        public BookingsViewModel(Bookings bookings)
        {
            Film = Helper.Film;
            BookSeatCommand = new RelayCommand((bs) =>
            {
                Helper.Bookings.Close();
                BookSucces bookSucces = new BookSucces();
                bookSucces.nameTxtb.Text = MainWindowViewModel.DateBase.Users[0].Name;
                bookSucces.filmTxtb.Text = MainWindowViewModel.DateBase.Films[0].Name;
                bookSucces.ShowDialog();
                bookings.Close();
            });

            BackCommand = new RelayCommand((b) => 
            {
                Helper.Bookings.Close();
                UserWindow userWindow = new UserWindow();
                userWindow.ShowDialog();
            });
            
            SelectedTimeCommand= new RelayCommand((s) =>
            {
                bookings.timeComboBox.ItemsSource = Helper.Film.Time;
            });


        }

    }
}
