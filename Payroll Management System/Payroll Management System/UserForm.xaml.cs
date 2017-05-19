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
using Payroll_Management_System.Context;
using Payroll_Management_System.Entities;

namespace Payroll_Management_System
{
    public partial class UserForm : Window
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                List<Employee> refreshInfo = (from emp in context.Employees
                                              join dep in context.Departments on emp.ID equals dep.ID
                                              join loc in context.Locations on emp.ID equals loc.ID
                                              join sal in context.Salaries on emp.ID equals sal.ID
                                              select emp).ToList();
                employeesDataGrid.ItemsSource = refreshInfo;
            }
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.ShowDialog();
        }
    }
}
