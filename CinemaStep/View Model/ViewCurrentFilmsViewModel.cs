using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CinemaStep.View_Model
{
    public class ViewCurrentFilmsViewModel
    {
        public UserWindow UserWindow { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public ObservableCollection<Film> Films { get; set; }

        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; }
        }

        public ViewCurrentFilmsViewModel(ViewCurrentFilms viewCurrentFilms)
        {
            Films = new ObservableCollection<Film>(FakeRepo.Films);
            BackCommand = new RelayCommand((b) =>
            {
                viewCurrentFilms.Close();
            });

            SelectedItemChangedCommand = new RelayCommand((s) =>
            {
                Helper.Film.Time = new List<string>();
                ViewFilmsControl viewFilmsControl = new ViewFilmsControl();
                viewFilmsControl.Name = Helper.Film.Name;
                viewFilmsControl.filmDescriptionLbl.Content = Helper.Film.Description;
                viewFilmsControl.imageSource.Source = new BitmapImage(new Uri(
                Helper.Film.ImagePath, UriKind.RelativeOrAbsolute));
                Helper.Film = Film;
                Helper.ViewCurrentFilms.grid.Children.Add(viewFilmsControl);
            });
        }
    }
}
