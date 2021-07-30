using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinemaStep.View_Model
{
    public class MainWindowViewModel : BaseViewModel
    {
        public UserWindow UserWindow { get; set; }
        public Grid Grid { get; set; }
        public RelayCommand SignUpCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand SubmitCommand { get; set; }

        public MainWindowViewModel(Grid grid, MainWindow mainWindow)
        {
            Grid = grid;
            SignUpCommand = new RelayCommand((CC) =>
            {
                SignUpControl signUpControl = new SignUpControl();
                Grid.Children.Add(signUpControl);
                Helper.MainWindow = mainWindow;

            });

            ExitCommand = new RelayCommand((e) =>
            {
                mainWindow.Close();
            });

            SubmitCommand = new RelayCommand((b) =>
            {
                foreach (var item in FakeRepo.Users)
                {
                    if (item.Email == mainWindow.nameTxtbx.Text && item.Password == mainWindow.surenameTxtbx.Text)
                    {
                        UserWindow.nameTxtb.Text = $"{item.Name}";
                        UserWindow.surenameTxtb.Text = $"{item.Surename}";
                        UserWindow.ShowDialog();
                        mainWindow.Close();
                    }
                }
            });
        }

    }
}
