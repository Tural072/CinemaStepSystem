using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
            SearchCommand = new RelayCommand(async (sc) =>
            {
                FakeRepo.AddNewFilmWindow.filmAddedLbl.Visibility = Visibility.Hidden;
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

                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyB2hJQYD-AuCQXJoHBt7XCUFz_mYCC12nU",
                    ApplicationName = this.GetType().ToString()
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = $"{Helper.Film.Name}  Official Trailer"; // Replace with your search term.
                searchListRequest.MaxResults = 1;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                List<string> videos = new List<string>();
                List<string> channels = new List<string>();
                List<string> playlists = new List<string>();

                string v = "";

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            //   videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                            videos.Add(searchResult.Id.VideoId);
                            break;
                        case "youtube#channel":
                            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                            break;
                        case "youtube#playlist":
                            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                            break;
                    }
                }

                v = videos[0];

                if (Helper.AddNewFilmWindow.ChromiumBrowser.Address == null)
                {
                    Helper.AddNewFilmWindow.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                }

                if (Helper.AddNewFilmWindow.ChromiumBrowser.Address != null)
                {
                   Helper.AddNewFilmWindow.ChromiumBrowser.Address = string.Empty;
                   Helper.AddNewFilmWindow.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                }
            });

            AddCommand = new RelayCommand((a) => 
            {
                MainWindowViewModel.DateBase.Users = FakeRepo.Users;
                MainWindowViewModel.DateBase.Films.Add(Helper.Film);
                JsonHelper.JSONSerialization(MainWindowViewModel.DateBase);
                FakeRepo.Films.Add(Helper.Film);
                FakeRepo.AddNewFilmWindow.filmAddedLbl.Visibility = Visibility.Visible;
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
