using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Model;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class SignUpControlViewModel : BaseViewModel
    {
        public SignUpControl SignUpControl { get; set; }
        public MainWindow MainWindow { get; set; }
        public UserWindow userWindow { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(); }
        }

        public SignUpControlViewModel(SignUpControl signUp)
        {
            UserWindow userWindow = new UserWindow();
            Helper.UserWindow = userWindow;
            SignUpControl = signUp;
            SubmitCommand = new RelayCommand((sC) =>
            {
                FakeRepo.User = new User();
                User user = new User();
                user.Id = 1;
                user.Name = SignUpControl.nameTxtbx.Text;
                user.Surename = SignUpControl.surenameTxtbx.Text;
                user.Email = SignUpControl.emailTxtbx.Text;
                user.Password = SignUpControl.passwordTxtbx.Text;
                userWindow.nameTxtb.Text = user.Name;
                userWindow.surenameTxtb.Text = user.Surename;
                FakeRepo.User = user;
                FakeRepo.Users.Add(user);
                userWindow.ShowDialog();

            });



        }
    }
}
