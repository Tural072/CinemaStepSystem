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
    public class ViewFilmsViewModel : BaseViewModel
    {
        public RelayCommand BackClickCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public UserWindow UserWindow { get; set; }
        public ObservableCollection<Film> Films { get; set; }
        private Film film;

        public Film Film
        {
            get { return film; }
            set { film = value; OnPropertyChanged(); }
        }
        public ViewFilmsViewModel()
        {
            Helper.UserWindow.Close();
            Films = new ObservableCollection<Film>(FakeRepo.GetAll());
            BackClickCommand = new RelayCommand((b) =>
            {
                Helper.ViewFilms.Close();
                UserWindow = new UserWindow();
                UserWindow.ShowDialog();
            });

            SelectedItemChangedCommand = new RelayCommand((SelectedItem) => 
            {
                ViewFilmsControl viewFilmsControl = new ViewFilmsControl();
                var item = SelectedItem as Film;
                Film = item;
                viewFilmsControl.filmNameLbl.Content = Film.Name;
                viewFilmsControl.filmDescriptionLbl.Content = Film.Description;
                viewFilmsControl.imageSource.Source = new BitmapImage(new Uri(
                Film.ImagePath, UriKind.RelativeOrAbsolute));
                Helper.ViewFilms.grid.Children.Add(viewFilmsControl);
            });

        }

    }
}
