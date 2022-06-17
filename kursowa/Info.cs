using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace kursowa
{
    public partial class Info : Form
    {
        private readonly Employee emp;
        private readonly PaymentsEntities db;
        public Info(Employee employee, PaymentsEntities db)
        {
            InitializeComponent();
            emp = employee;
            this.db = db;
        }

        private void Info_Load(object sender, EventArgs e)
        {
            try
            {
                GetInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void GetInfo()
        {
            labelId.Text = emp.id_employee.ToString();
            labelName.Text = db.Passport_data.Where(x=>emp.passport_id==x.id_passport).Select(c=>c.name).FirstOrDefault();
            labelDate.Text = db.Passport_data.Where(x => emp.passport_id == x.id_passport).Select(c => c.date_of_birth).FirstOrDefault().ToShortDateString();
            labelAddress.Text = $"{db.Passport_data.Where(x => emp.passport_id == x.id_passport).Select(c => c.place_of_birth).FirstOrDefault()}  {db.Passport_data.Where(x => emp.passport_id == x.id_passport).Select(c => c.address).FirstOrDefault()}";
            labelDep.Text = db.Department.Where(x => x.department_leader == emp.id_employee).Select(c => c.name_abbreviation).FirstOrDefault();
            labelPos.Text = db.Career.Where(x => x.employee_id == emp.id_employee).Select(p => p.Position.position_name).FirstOrDefault();
            labelWork.Text = db.Career.Where(x => x.employee_id == emp.id_employee).Select(d => d.start_work).FirstOrDefault().Date.ToString();
            labelSalary.Text = db.Salary.Where(x=> x.employee_id == emp.id_employee).Sum(s => s.sum + s.oved).ToString();
        }
    }
}
