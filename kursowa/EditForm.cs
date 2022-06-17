using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kursowa
{
    public partial class EditForm : Form
    {
        private readonly Table action;
        private readonly PaymentsEntities db;
        private readonly object entity;

        private List<TextBox> boxes;
        private List<DateTimePicker> dates;
        private List<ComboBox> combos;
        private Button button;
        
        public EditForm(Table action, PaymentsEntities db, object entity)
        {
            InitializeComponent();
            this.action = action;
            this.db = db;
            this.entity = entity;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            switch (action)
            {
                case Table.Employee:
                    AddEmployeeBoxes();
                    break;
                case Table.Passport:
                    AddPassportBoxes();
                    break;
                case Table.Career:
                    AddCareerBoxes();
                    break;
                case Table.Departament:
                    AddDepartamentBoxes();
                    break;
                case Table.Position:
                    AddPositionBoxes();
                    break;
                case Table.Vacation:
                    AddVacationBoxes();
                    break;
                case Table.Salary:
                    AddSalaryBoxes();
                    break;
                default:
                    throw new InvalidOperationException("Something went wrong");
            }
        }
        private void AddSalaryBoxes()
        {
            var salary = entity as Salary;
            labelHeader.Text = "Edit Salary";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Employee ID",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Salary Date",
                    Location = new Point(350, 170)
                },
                new Label
                {
                    Text = "Suma",
                    Location = new Point(350, 270)
                },
                new Label
                {
                    Text = "Oved",
                    Location = new Point(350, 370)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Name = "emp",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = salary.employee_id.ToString(),
                },
            };
            combos[0].Items.AddRange(QueryToString<long>(db.Employee.Select(x => x.id_employee)));
            this.Controls.AddRange(combos.ToArray());
            dates = new List<DateTimePicker>
            {
                new DateTimePicker
                {
                    Name = "salarydate",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    MinDate = salary.salary_date,
                    Value = salary.salary_date
                }
            };
            this.Controls.AddRange(dates.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "sum",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    Text = salary.sum.ToString(),
                },
                new TextBox
                {
                    Name = "oved",
                    Location = new Point(290, 400),
                    Size = new Size(180, 25),
                    Text = salary.oved.ToString(),
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 500),
                Size = new Size(190, 50),
                Text = "Edit",
            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddVacationBoxes()
        {
            var vac = entity as Vacation;
            labelHeader.Text = "Edit Vacation";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Employee ID",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Start",
                    Location = new Point(350, 170)
                },
                new Label
                {
                    Text = "End",
                    Location = new Point(350, 270)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Name = "emp",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = vac.employee_id.ToString()
                },
            };
            combos[0].Items.AddRange(QueryToString<long>(db.Employee.Select(x => x.id_employee)));
            this.Controls.AddRange(combos.ToArray());
            dates = new List<DateTimePicker>
            {
                new DateTimePicker
                {
                    Name = "start_work",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    MinDate = vac.vacation_start,
                    Value = vac.vacation_start
                },
                new DateTimePicker
                {
                    Name = "end_work",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    MinDate = vac.vacation_end,
                    Value = vac.vacation_end
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 400),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddPositionBoxes()
        {
            var pos = entity as Position;
            labelHeader.Text = "Edit Postion";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Postion Name",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Salary",
                    Location = new Point(350, 170)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "name",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = pos.position_name
                },
                new TextBox
                {
                    Name = "salary",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    Text = pos.salary.ToString()
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 350),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddDepartamentBoxes()
        {
            var dep = entity as Department;
            labelHeader.Text = "Edit Departament";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Departament Name",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Departament Leader",
                    Location = new Point(350, 170)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "name",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = dep.name_abbreviation
                },
            };
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    Text = dep.department_leader.ToString()
                }
            };
            combos[0].Items.AddRange(QueryToString<long>(db.Employee.Select(x => x.id_employee)));
            this.Controls.AddRange(boxes.ToArray());
            this.Controls.AddRange(combos.ToArray());
            button = new Button
            {
                Location = new Point(290, 350),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddCareerBoxes()
        {
            var career = entity as Career;
            labelHeader.Text = "Edit Career";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Employee ID",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Position ID",
                    Location = new Point(350, 170)
                },
                new Label
                {
                    Text = "Departament name",
                    Location= new Point(350, 270)
                },
                new Label
                {
                    Text = "Start Work",
                    Location = new Point(350, 370)
                },
                new Label
                {
                    Text = "End Work",
                    Location = new Point(350, 470)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Name = "emp",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = career.employee_id.ToString()
                },
                new ComboBox
                {
                    Name = "pos",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    Text = career.position_id.ToString(),
                },
                new ComboBox
                {
                    Name = "dep",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    Text = career.department_name.ToString(),
                }

            };

            combos[0].Items.AddRange(QueryToString<long>(db.Employee.Select(x => x.id_employee)));
            combos[1].Items.AddRange(QueryToString<long>(db.Position.Select(x => x.id_position)));
            combos[2].Items.AddRange(QueryToString<long>(db.Department.Select(x => x.id_name)));
            this.Controls.AddRange(combos.ToArray());
            dates = new List<DateTimePicker>
            {
                new DateTimePicker
                {
                    Name = "start_work",
                    Location = new Point(290, 400),
                    Size = new Size(180, 25),
                    MaxDate = DateTime.Now,
                    Value = career.start_work
                },
                new DateTimePicker
                {
                    Name = "end_work",
                    Location = new Point(290, 500),
                    Size = new Size(180, 25),
                    MinDate = DateTime.Now,
                    Value = career.end_work
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 530),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddPassportBoxes()
        {
            var pas = entity as Passport_data;
            labelHeader.Text = "Edit Passport";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Full Name",
                    Location = new Point(350, 70)
                },
                new Label
                {
                    Text = "Birth Date",
                    Location = new Point(350, 170)
                },
                new Label
                {
                    Text = "Birth Place",
                    Location= new Point(350, 270)
                },
                new Label
                {
                    Text = "Address",
                    Location = new Point(350, 370)
                },
            };
            this.Controls.AddRange(labels.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "name",
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = pas.name
                },
                new TextBox
                {
                    Name = "place_of_birth",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    Text = pas.place_of_birth
                },
                new TextBox
                {
                    Name = "address",
                    Location = new Point(290, 400),
                    Size = new Size(180, 25),
                    Text = pas.address
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            dates = new List<DateTimePicker>
            {
                new DateTimePicker
                {
                    Name = "date_of_birth",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    MaxDate = DateTime.Now,
                    Value = pas.date_of_birth
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 500),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }
        private void AddEmployeeBoxes()
        {
            var emp = entity as Employee;
            labelHeader.Text = "Edit Employee";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Passport_id",
                    Location = new Point(350, 70),
                },
                new Label
                {
                    Text = "Education",
                    Location = new Point(350, 170)
                },
                new Label
                {
                    Text = "Qualification",
                    Location= new Point(350, 270)
                }
            };
            this.Controls.AddRange(labels.ToArray());
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Location = new Point(290, 100),
                    Size = new Size(180, 25),
                    Text = emp.passport_id.ToString()
                }
            };
            combos[0].Items.AddRange(QueryToString<long>(db.Passport_data.Select(x => x.id_passport)));
            this.Controls.AddRange(combos.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "education",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                    Text = emp.education
                },
                new TextBox
                {
                    Name = "qualification",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    Text = emp.qualification
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 450),
                Size = new Size(190, 50),
                Text = "Edit",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                switch (action)
                {
                    case Table.Employee:
                        UpdateEmployeeToDb();
                        break;
                    case Table.Passport:
                        UpdatePassportToDb();
                        break;
                    case Table.Career:
                        UpdateCareerToDb();
                        break;
                    case Table.Departament:
                        UpdateDepartamentToDb();
                        break;
                    case Table.Position:
                        UpdatePositionToDb();
                        break;
                    case Table.Vacation:
                        UpdateVacationToDb();
                        break;
                    case Table.Salary:
                        UpdateSalaryToDb();
                        break;
                    default:
                        throw new InvalidOperationException("Something went wrong");
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateSalaryToDb()
        {
            if (ValidateCombos()&&ValidateBoxes())
            {
                var sal = entity as Salary;
                sal.employee_id = long.Parse(combos[0].Text);
                sal.salary_date = dates[0].Value.Date;
                sal.sum = decimal.Parse(boxes[0].Text);
                sal.oved = decimal.Parse(boxes[1].Text);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdateVacationToDb()
        {
            if (ValidateCombos())
            {
                var vac = entity as Vacation;
                vac.employee_id = long.Parse(combos[0].Text);
                vac.vacation_start = dates[0].Value.Date;
                vac.vacation_end = dates[1].Value.Date;
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdatePositionToDb()
        {
            if (ValidateBoxes())
            {
                var pos = entity as Position;
                pos.position_name = boxes[0].Text;
                pos.salary = decimal.Parse(boxes[1].Text);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdateDepartamentToDb()
        {
            if (ValidateBoxes() && ValidateCombos())
            {
                var dep = entity as Department;
                dep.name_abbreviation = boxes[0].Text;
                dep.department_leader = long.Parse(combos[0].Text);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdateCareerToDb()
        {
            if (ValidateCombos())
            {
                var car = entity as Career;
                car.employee_id = long.Parse(combos[0].Text);
                car.position_id = long.Parse(combos[1].Text);
                car.department_name = long.Parse(combos[2].Text);
                car.start_work = dates[0].Value.Date;
                car.end_work = dates[1].Value.Date;
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdatePassportToDb()
        {
            if (ValidateBoxes())
            {
                var pas = entity as Passport_data;
                pas.name = boxes[0].Text;
                pas.date_of_birth = dates[0].Value.Date;
                pas.place_of_birth = boxes[1].Text;
                pas.address = boxes[2].Text;
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void UpdateEmployeeToDb()
        {
            if (ValidateBoxes() && ValidateCombos())
            {
                var emp = entity as Employee;
                emp.passport_id = long.Parse(combos[0].Text);
                emp.education = boxes[0].Text;
                emp.qualification = boxes[1].Text;
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }
        private bool ValidateBoxes()
        {
            foreach (var box in boxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                    return false;
            }
            return true;
        }
        private bool ValidateCombos()
        {
            foreach (var c in combos)
            {
                if (string.IsNullOrEmpty(c.Text))
                    return false;
            }
            return true;
        }

        private string[] QueryToString<T>(IQueryable<T> ts)
        {
            List<string> elems = new List<string>();
            foreach (var t in ts)
            {
                elems.Add(t.ToString());
            }
            return elems.ToArray();
        }
    }
}
