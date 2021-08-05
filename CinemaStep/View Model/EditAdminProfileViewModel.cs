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
    public class EditAdminProfileViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public EditAdminProfileViewModel(EditAdminProfile editAdminProfile)
        {
            BackCommand = new RelayCommand((l) => 
            {
                editAdminProfile.Close();
            });

            SaveCommand = new RelayCommand((s) =>
            {
                FakeRepo.Admin.Name = editAdminProfile.firstNameTxtbox.Text;
                FakeRepo.Admin.Surename = editAdminProfile.lastNameTxtbox.Text;
                FakeRepo.Admin.Email = editAdminProfile.emailTxtbox.Text;
                FakeRepo.Admin.Password = editAdminProfile.passwordTxtbox.Text;
                editAdminProfile.nameTxtb.Text = FakeRepo.Admin.Name;
                editAdminProfile.lastNameTxtb.Text = FakeRepo.Admin.Surename;
                editAdminProfile.sendMailTxtb.Text = FakeRepo.Admin.Email;
                editAdminProfile.oldLastNameTxtb.Text = FakeRepo.OldAdmin.Surename;
                editAdminProfile.oldNameTxtb.Text = FakeRepo.OldAdmin.Name;
                editAdminProfile.oldSendMailTxtb.Text = FakeRepo.OldAdmin.Email;
                Helper.managementView.nameTxtb.Text = $"{FakeRepo.Admin.Name}";
                Helper.managementView.surenameTxtb.Text = $"{FakeRepo.Admin.Surename}";
                editAdminProfile.Close();
            });
        }
    }
}
