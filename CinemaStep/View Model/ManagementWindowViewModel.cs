using CinemaStep.Command;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class ManagementWindowViewModel : BaseViewModel
    {
        public RelayCommand AddCommand { get; set; }
        public ManagementWindowViewModel(ManagementView managementView)
        {
            AddCommand = new RelayCommand((a) =>
            {
                managementView.Close();
                AddNewFilmWindow addNewFilmWindow = new AddNewFilmWindow();
                addNewFilmWindow.ShowDialog();
            });
        }
    }
}
