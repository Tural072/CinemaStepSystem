using CinemaStep.Command;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class RemoveViewModel : BaseViewModel
    {
        public RelayCommand RemoveFilmCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public ObservableCollection<Film> Films { get; set; } = new ObservableCollection<Film>();
        public RemoveViewModel(RemoveWindow removeWindow)
        {
            Films = MainWindowViewModel.DateBase.Films;
            BackCommand = new RelayCommand((b) =>
            {
                removeWindow.Close();
            });

            RemoveFilmCommand = new RelayCommand((r) =>
            {
                var film = removeWindow.mainListbox.SelectedItem as Film;
                FakeRepo.Films.Remove(film);
            });
        }
    }
}
