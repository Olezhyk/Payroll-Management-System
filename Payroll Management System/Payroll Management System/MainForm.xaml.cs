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
using Payroll_Management_System.Entities;
using Payroll_Management_System.Context;

namespace Payroll_Management_System
{
    public partial class MainForm : Window
    {
        private Employee _employee;
        Location _location;
        Department _department;
        SalaryInfo _salary;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                _employee = new Employee();
                _location = new Location();
                _department = new Department();
                _salary = new SalaryInfo();

                _employee.FirstName = TextFirstName.Text;
                _employee.LastName = TextLastName.Text;
                _employee.Age = Convert.ToInt32(TextAge.Text);
                _location.LocationName = TextLocation.Text;
                _employee.JobTitle = TextJobTitle.Text;
                _department.Name = TextDepartment.Text;
                _salary.Salary = Convert.ToDouble(TextSalary.Text);
                _salary.Tax = _salary.Salary - (_salary.Salary * 0.2);
                if (male.IsChecked == true)
                {
                    _employee.Gender = "Male";
                }
                if (female.IsChecked == true)
                {
                    _employee.Gender = "Female";
                }

                context.Employees.Add(_employee);
                context.Locations.Add(_location);
                context.Departments.Add(_department);
                context.Salaries.Add(_salary);

                context.SaveChanges();
                MessageBox.Show("Employee successfully added");
            }
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
                context.SaveChanges();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            using (EmployeeContext context = new EmployeeContext())
            {
                int empId = (employeesDataGrid.SelectedItem as Employee).ID;
                Employee deleteEmployee = (from employeeT2 in context.Employees
                                           where employeeT2.ID == empId
                                           select employeeT2).SingleOrDefault();
                context.Employees.Remove(deleteEmployee);
                context.SaveChanges();
                employeesDataGrid.ItemsSource = context.Employees.ToList();
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
