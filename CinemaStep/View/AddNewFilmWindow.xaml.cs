using CinemaStep.Repository;
using CinemaStep.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaStep.View
{
    /// <summary>
    /// Interaction logic for AddNewFilmWindow.xaml
    /// </summary>
    public partial class AddNewFilmWindow : Window
    {
        public AddNewFilmWindow()
        {
            InitializeComponent();
            DataContext = new AddNewFilmViewModel(this);
            FakeRepo.AddNewFilmWindow = this;
        }
    }
}
