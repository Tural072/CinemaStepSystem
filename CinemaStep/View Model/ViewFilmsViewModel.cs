using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CinemaStep.View_Model
{
    public class ViewFilmsViewModel : BaseViewModel
    {
        public RelayCommand BackClickCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand MoreInformationCommand { get; set; }
        public UserWindow UserWindow { get; set; }
        public ObservableCollection<Film> Films { get; set; }

        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }

        HttpClient http = new HttpClient();

        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }
        public string ImagePath { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }
        public ViewFilmsViewModel(ViewFilms viewFilms)
        {
            Helper.UserWindow.Visibility=System.Windows.Visibility.Hidden;
            Films = new ObservableCollection<Film>(FakeRepo.GetAll());
            Films = MainWindowViewModel.DateBase.Films;
            BackClickCommand = new RelayCommand((b) =>
            {
                Helper.ViewFilms.Close();
                Helper.UserWindow.Visibility = System.Windows.Visibility.Visible;
            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) => 
            {
                var film = SelectedItem as Film;
                ViewFilmsControl viewFilmsControl = new ViewFilmsControl();
                viewFilmsControl.filmNameLbl.Content = film.Name;
                viewFilmsControl.filmDescriptionLbl.Content = film.Description;
                viewFilmsControl.imageSource.Source = new BitmapImage(new Uri(
                film.ImagePath, UriKind.RelativeOrAbsolute));
                Helper.ViewFilms.grid.Children.Add(viewFilmsControl);
            });

            

         
        }

    }
}
