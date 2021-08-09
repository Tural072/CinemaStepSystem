using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Repository;
using CinemaStep.Service;
using CinemaStep.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CinemaStep.View_Model
{
    public class UserWindowViewModel : BaseViewModel
    {
        public EditCustomerProfile EditCustomerProfile { get; set; }
        public ViewFilms ViewFilms { get; set; }
        public UserWindow UserWindow { get; set; }
        public MainWindow MainWindow { get; set; }
        public RelayCommand LogOutCommand { get; set; }
        public RelayCommand UploadPhotoCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand SendMailCommand { get; set; }
        public RelayCommand BookingCommand { get; set; }
        public RelayCommand ViewFilmCommand { get; set; }
        public UserWindowViewModel(UserWindow userWindow)
        {
            Helper.UserWindow = userWindow;
            LogOutCommand = new RelayCommand((lB) =>
            {
                userWindow.Close();
                MainWindow mainWindow=new MainWindow();
                mainWindow.ShowDialog();
            });

            UploadPhotoCommand = new RelayCommand((u) =>
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (op.ShowDialog() == true)
                {
                    userWindow.profilePhoto.Source = new BitmapImage(new Uri(op.FileName));
                }
            });

            ViewFilmCommand = new RelayCommand((v) =>
            {
                ViewFilms = new ViewFilms();
                ViewFilms.ShowDialog();
            });

            EditCommand = new RelayCommand((e) =>
            {
                EditCustomerProfile = new EditCustomerProfile();
                FakeRepo.OldUser = FakeRepo.User;
                EditCustomerProfile.ShowDialog();
            });

            BookingCommand = new RelayCommand((b) =>
            {
                Helper.UserWindow.Close();
                Bookings bookings = new Bookings();
                bookings.ShowDialog();
            });

            SendMailCommand = new RelayCommand((s) =>
            {
                SendMailService.SendMail1(FakeRepo.User.Email);
            });
        }
    }
}
