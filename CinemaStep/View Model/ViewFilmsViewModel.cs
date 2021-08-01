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
            BackClickCommand = new RelayCommand((b) =>
            {
                Helper.ViewFilms.Close();
                Helper.UserWindow.Visibility = System.Windows.Visibility.Visible;
            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) => 
            {
                ViewFilmsControl viewFilmsControl = new ViewFilmsControl();
                viewFilmsControl.filmNameLbl.Content = Helper.Film.Name;
                viewFilmsControl.filmDescriptionLbl.Content = Helper.Film.Description;
                viewFilmsControl.imageSource.Source = new BitmapImage(new Uri(
                Helper.Film.ImagePath, UriKind.RelativeOrAbsolute));
                Helper.ViewFilms.grid.Children.Add(viewFilmsControl);
            });

            SearchCommand = new RelayCommand((sc) =>
            {
                Helper.Film = new Film();
                try
                {
                    Film = new Film();
                    Films = new ObservableCollection<Film>();
                    HttpResponseMessage response = new HttpResponseMessage();
                    response =
                    http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={viewFilms.searchTxtbox.Text}&plot=full").Result;
                    var str = response.Content.ReadAsStringAsync().Result;
                    Data = JsonConvert.DeserializeObject(str);
                    response =
                    http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[0].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);



                    ImagePath = SingleData.Poster;
                    Minute = SingleData.Runtime;
                    Description = SingleData.Genre;



                    viewFilms.mainImg.Source = new BitmapImage(new Uri(
                    ImagePath, UriKind.RelativeOrAbsolute));
                    viewFilms.filmNameTxtb.Text = SingleData.Title;
                    Helper.Film.Name = SingleData.Title;
                    Helper.Film.ImagePath = SingleData.Poster;
                    Helper.Film.Description = SingleData.Genre;
                }
                catch (Exception)
                {
                }
            });

         
        }

    }
}
