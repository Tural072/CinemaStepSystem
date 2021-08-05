using CinemaStep.Command;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.Service;
using CinemaStep.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CinemaStep.View_Model
{
    public class ManagementWindowViewModel : BaseViewModel
    {
        public RelayCommand AddCommand { get; set; }
        public RelayCommand UploadPhotoCommand { get; set; }
        public RelayCommand LogOutCommand { get; set; }
        public RelayCommand SendMailCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public ManagementWindowViewModel(ManagementView managementView)
        {
            AddCommand = new RelayCommand((a) =>
            {
                managementView.Close();
                AddNewFilmWindow addNewFilmWindow = new AddNewFilmWindow();
                addNewFilmWindow.ShowDialog();
            });

            UploadPhotoCommand = new RelayCommand((u) =>
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (op.ShowDialog() == true)
                {
                    managementView.profilePhoto.Source = new BitmapImage(new Uri(op.FileName));
                }
            });

            SendMailCommand = new RelayCommand((s) =>
            {
                SendMailService.SendMail1(FakeRepo.Admin.Email);
            });

            RemoveCommand = new RelayCommand((s) =>
            {
                RemoveWindow removeWindow = new RemoveWindow();
                removeWindow.ShowDialog();
            });

            LogOutCommand = new RelayCommand((s) =>
            {
                managementView.Close();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            });

            EditCommand = new RelayCommand((s) =>
            {
                EditAdminProfile editAdminProfile = new EditAdminProfile();
                FakeRepo.OldAdmin = FakeRepo.Admin;
                editAdminProfile.ShowDialog();
            });
        }
    }
}
