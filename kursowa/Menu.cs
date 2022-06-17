using System;
using System.Linq;
using System.Windows.Forms;

namespace kursowa
{
    public partial class Menu : Form
    {
        private readonly PaymentsEntities db;

        private readonly Role role;
        public Menu(Role role)
        {
            InitializeComponent();
            db = new PaymentsEntities();
            this.role = role;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            RefreshForm();
            SetVisibility();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void RefreshForm()
        {
            dataGridView1.DataSource = db.Employee.ToList();
            dataGridView2.DataSource = db.Passport_data.ToList();
            dataGridView3.DataSource = db.Career.ToList();
            dataGridView4.DataSource = db.Department.ToList();
            dataGridView5.DataSource = db.Position.ToList();
            dataGridView6.DataSource = db.Vacation.ToList();
            dataGridView7.DataSource = db.Salary.ToList();
        }
        private void SetVisibility()
        {
            if(role == Role.User)
            {
                buttonAdd1.Visible = false;
                buttonAdd2.Visible = false;
                buttonAdd3.Visible = false;
                buttonAdd4.Visible = false;
                buttonAdd5.Visible = false;
                buttonAdd6.Visible = false;
                buttonAdd7.Visible = false;
                buttonDelete1.Visible = false;
                buttonDelete2.Visible = false;
                buttonDelete3.Visible = false;
                buttonDelete4.Visible = false;
                buttonDelete5.Visible = false;
                buttonDelete6.Visible = false;
                buttonDelete7.Visible = false;
                buttonEdit1.Visible = false;
                buttonEdit2.Visible = false;
                buttonEdit3.Visible = false;
                buttonEdit4.Visible = false;
                buttonEdit5.Visible = false;
                buttonEdit6.Visible = false;
                buttonEdit7.Visible = false;
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void buttonDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    var employee = db.Employee.FirstOrDefault(x => x.id_employee == id);
                    db.Employee.Remove(employee);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                    var passport = db.Passport_data.FirstOrDefault(x => x.id_passport == id);
                    db.Passport_data.Remove(passport);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView3.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                    var career = db.Career.FirstOrDefault(x => x.id_career == id);
                    db.Career.Remove(career);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView4.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                    var departament = db.Department.FirstOrDefault(x => x.id_name == id);
                    db.Department.Remove(departament);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView5.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView5.SelectedRows[0].Cells[0].Value.ToString());
                    var position = db.Position.FirstOrDefault(x => x.id_position == id);
                    db.Position.Remove(position);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView6.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView6.SelectedRows[0].Cells[0].Value.ToString());
                    var vacation = db.Vacation.FirstOrDefault(x => x.id_vacation == id);
                    db.Vacation.Remove(vacation);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonDelete7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView7.SelectedRows.Count > 0)
                {
                    var id = long.Parse(dataGridView7.SelectedRows[0].Cells[0].Value.ToString());
                    var salary = db.Salary.FirstOrDefault(x => x.id_salary == id);
                    db.Salary.Remove(salary);
                    db.SaveChanges();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("Please select a row");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You can't delete this cell");
            }
        }

        private void buttonAdd1_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Employee, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Passport, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd3_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Career, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd4_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Departament, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd5_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Position, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd6_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Vacation, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonAdd7_Click(object sender, EventArgs e)
        {
            try
            {
                new AddForm(Table.Salary, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                var employee = db.Employee.FirstOrDefault(x => x.id_employee == id);
                new EditForm(Table.Employee, db, employee).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                var pas = db.Passport_data.FirstOrDefault(x => x.id_passport == id);
                new EditForm(Table.Passport, db, pas).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit3_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView3.SelectedRows[0].Cells[0].Value.ToString());
                var career = db.Career.FirstOrDefault(x => x.id_career == id);
                new EditForm(Table.Career, db, career).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit4_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                var dep = db.Department.FirstOrDefault(x => x.id_name == id);
                new EditForm(Table.Departament, db, dep).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit5_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView5.SelectedRows[0].Cells[0].Value.ToString());
                var pos = db.Position.FirstOrDefault(x => x.id_position == id);
                new EditForm(Table.Position, db, pos).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit6_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView6.SelectedRows[0].Cells[0].Value.ToString());
                var vac = db.Vacation.FirstOrDefault(x => x.id_vacation == id);
                new EditForm(Table.Vacation, db, vac).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonEdit7_Click(object sender, EventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView7.SelectedRows[0].Cells[0].Value.ToString());
                var sal = db.Salary.FirstOrDefault(x => x.id_salary == id);
                new EditForm(Table.Salary, db, sal).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var id = long.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                var emp = db.Employee.FirstOrDefault(x => x.id_employee == id);
                new Info(emp, db).ShowDialog();
                RefreshForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().ShowDialog();
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new DepInfo().ShowDialog();
        }
    }
}
