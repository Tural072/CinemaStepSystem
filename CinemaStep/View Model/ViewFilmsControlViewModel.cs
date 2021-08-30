using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.View;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
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
        public RelayCommand ShowTrailerCommand { get; set; }
        public ViewFilmsControlViewModel()
        {
            BookNowCommand = new RelayCommand((b) => 
            {
                Bookings bookings = new Bookings();
                bookings.ShowDialog();
            });

            ShowTrailerCommand = new RelayCommand(async (b) =>
            {
                Helper.ViewFilmsControl.showTrailerBtn.Visibility = System.Windows.Visibility.Hidden;
                Helper.ViewFilmsControl.filmImg.Visibility = System.Windows.Visibility.Hidden;
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

                if (Helper.ViewFilmsControl.ChromiumBrowser.Address == null)
                {
                    Helper.ViewFilmsControl.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                    if (Helper.ViewFilmsControl.ChromiumBrowser.Address != null)
                        Helper.ViewFilmsControl.ChromiumBrowser.Address = string.Empty;
                    Helper.ViewFilmsControl.ChromiumBrowser.Address = $@"https://www.youtube.com/embed/{v}";
                }
            });
        }
    }
}
