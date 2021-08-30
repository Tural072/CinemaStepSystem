using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        public ObservableCollection<Admin> Admins { get; set; } = new ObservableCollection<Admin>();
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public static DateBase DateBase = new DateBase();

        public int Count { get; set; }

        public MainWindowViewModel(Grid grid, MainWindow mainWindow)
        {
            if (File.Exists(JsonHelper.fileName))
            {
                JsonHelper.JSONDeSerialization(ref DateBase);
            }
            UserWindow = new UserWindow();
            ManagementView managementView = new ManagementView();
            Admins = FakeRepo.GetAdmins();
            Grid = grid;
            Users = FakeRepo.Users;
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
                if (FakeRepo.Users != null)
                {
                    foreach (var item in DateBase.Users)
                    {
                        if (item.Email == mainWindow.nameTxtbx.Text && item.Password == mainWindow.surenameTxtbx.Text)
                        {
                            UserWindow.nameTxtb.Text = $"{item.Name}";
                            UserWindow.surenameTxtb.Text = $"{item.Surename}";
                            UserWindow.ShowDialog();
                            mainWindow.Close();
                        }
                    }
                }
                if (Admins != null)
                {
                    foreach (var item in Admins)
                    {
                        if (item.Email == mainWindow.nameTxtbx.Text && item.Password == mainWindow.surenameTxtbx.Text)
                        {
                            FakeRepo.Admin = item;
                            managementView.nameTxtb.Text = item.Name;
                            managementView.surenameTxtb.Text = item.Surename;
                            managementView.ShowDialog();
                            mainWindow.Close();
                        }
                    }
                }
            });
        }

    }
}
