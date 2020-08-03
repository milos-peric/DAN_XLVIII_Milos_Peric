using DAN_XLVIII_Milos_Peric.Command;
using DAN_XLVIII_Milos_Peric.Validation;
using DAN_XLVIII_Milos_Peric.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLVIII_Milos_Peric.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        ViewLogin view;

        public LoginViewModel(ViewLogin viewLogin)
        {
            view = viewLogin;
        }

        private string userName;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute, param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                string password = (obj as PasswordBox).Password;
                if (UserName.Equals("Zaposleni") && password.Equals("Zaposleni"))
                {
                    ViewEmployeeView employeeView = new ViewEmployeeView();
                    view.Close();
                    employeeView.Show();
                    return;
                }
                else if (EntryValidation.ValidateJmbg(UserName) && password.Equals("Gost"))
                {
                    ViewGuestView guestView = new ViewGuestView();
                    view.Close();
                    guestView.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Wrong usename or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
