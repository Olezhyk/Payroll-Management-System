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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Payroll_Management_System.Cryptography;

namespace Payroll_Management_System
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonSignin_Click(object sender, RoutedEventArgs e)
        {
            MainForm mainForm = new MainForm();
            UserForm userForm = new UserForm();
            if ((Encryptor.MD5Hash(TextPassword.Text) == LoginInfo.adminPassword) && (TextUserName.Text == LoginInfo.adminLogin))
            {
                this.Close();
                mainForm.ShowDialog();
            }
            else if ((Encryptor.MD5Hash(TextPassword.Text) == LoginInfo.userPassword) && (TextUserName.Text == LoginInfo.userLogin))
            {
                this.Close();
                userForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("The user name or password is incorrect");
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
