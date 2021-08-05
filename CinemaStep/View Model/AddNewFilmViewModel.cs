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
    public class AddNewFilmViewModel:BaseViewModel
    {
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        private Film film;
        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }
        public string ImagePath { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }
        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }


        HttpClient http = new HttpClient();
        public AddNewFilmViewModel(AddNewFilmWindow addNewFilmWindow)
        {
            SearchCommand = new RelayCommand((sc) =>
            {
                Helper.Film = new Film();
                try
                {
                    Film = new Film();
                    HttpResponseMessage response = new HttpResponseMessage();
                    response =
                    http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={addNewFilmWindow.searchTxtbox.Text}&plot=full").Result;
                    var str = response.Content.ReadAsStringAsync().Result;
                    Data = JsonConvert.DeserializeObject(str);
                    response =
                    http.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[0].Title}&plot=full").Result;
                    str = response.Content.ReadAsStringAsync().Result;
                    SingleData = JsonConvert.DeserializeObject(str);

                    ImagePath = SingleData.Poster;
                    Minute = SingleData.Runtime;
                    Description = SingleData.Genre;

                    addNewFilmWindow.mainImg.Source = new BitmapImage(new Uri(
                    ImagePath, UriKind.RelativeOrAbsolute));
                    addNewFilmWindow.filmNameTxtb.Text = SingleData.Title;
                    Helper.Film.Name = SingleData.Title;
                    Helper.Film.ImagePath = SingleData.Poster;
                    Helper.Film.Description = SingleData.Genre;
                }
                catch (Exception)
                {
                }
            });

            AddCommand = new RelayCommand((a) => 
            {
                FakeRepo.Films.Add(Helper.Film);
            });

            BackCommand = new RelayCommand((b) =>
            {
                ManagementView managementView = new ManagementView();
                addNewFilmWindow.Close();
                managementView.nameTxtb.Text = $"{FakeRepo.Admin.Name}";
                managementView.surenameTxtb.Text = $"{FakeRepo.Admin.Surename}";
                managementView.ShowDialog();
            });
        }
    }
}
