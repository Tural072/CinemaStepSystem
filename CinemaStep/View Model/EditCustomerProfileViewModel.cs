using CinemaStep.Command;
using CinemaStep.Extension;
using CinemaStep.Repository;
using CinemaStep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaStep.View_Model
{
    public class EditCustomerProfileViewModel : BaseViewModel
    {
        public EditCustomerProfile EditCustomerProfile { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand LogoutBtn { get; set; }
        public EditCustomerProfileViewModel(EditCustomerProfile editWindowUser)
        {
            Helper.UserWindow = new UserWindow();
            SaveCommand = new RelayCommand((s) =>
            {
                FakeRepo.User.Name = editWindowUser.firstNameTxtbox.Text;
                FakeRepo.User.Surename = editWindowUser.lastNameTxtbox.Text;
                FakeRepo.User.Email = editWindowUser.emailTxtbox.Text;
                FakeRepo.User.Password = editWindowUser.passwordTxtbox.Text;
                editWindowUser.nameTxtb.Text = FakeRepo.User.Name;
                editWindowUser.lastNameTxtb.Text = FakeRepo.User.Surename;
                editWindowUser.sendMailTxtb.Text = FakeRepo.User.Email;
                editWindowUser.oldLastNameTxtb.Text = FakeRepo.OldUser.Surename;
                editWindowUser.oldNameTxtb.Text = FakeRepo.OldUser.Name;
                editWindowUser.oldSendMailTxtb.Text = FakeRepo.OldUser.Email;
                Helper.UserWindow.nameTxtb.Text = $"{FakeRepo.User.Name}";
                Helper.UserWindow.surenameTxtb.Text = $"{FakeRepo.User.Surename}";
                editWindowUser.Close();
            });
            LogoutBtn = new RelayCommand((l) =>
            {
                editWindowUser.Close();
            });
        }
    }
}
