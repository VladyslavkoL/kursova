using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kursowa
{
    public partial class AddForm : Form
    {
        private readonly Table action;
        private readonly PaymentsEntities db;

        private List<TextBox> boxes;
        private List<DateTimePicker> dates;
        private List<ComboBox> combos;
        private Button button;
        public AddForm(Table action, PaymentsEntities db)
        {
            InitializeComponent();
            this.action = action;
            this.db = db;
        }

        private void AddForm_Load(object sender, EventArgs e)
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
            labelHeader.Text = "Add Salary";
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
                    MinDate = DateTime.Now
                }
            };
            this.Controls.AddRange(dates.ToArray());
            boxes = new List<TextBox>
            {
                new TextBox
                {
                    Name = "sum",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25)
                },
                new TextBox
                {
                    Name = "oved",
                    Location = new Point(290, 400),
                    Size = new Size(180, 25)
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 500),
                Size = new Size(190, 50),
                Text = "Add",
            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddVacationBoxes()
        {
            labelHeader.Text = "Add Vacation";
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
                    MinDate = DateTime.Now
                },
                new DateTimePicker
                {
                    Name = "end_work",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
                    MinDate = DateTime.Now
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 400),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddPositionBoxes()
        {
            labelHeader.Text = "Add Postion";
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
                    Size = new Size(180, 25)
                },
                new TextBox
                {
                    Name = "salary",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25)
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 350),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddDepartamentBoxes()
        {
            labelHeader.Text = "Add Departament";
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
                    Size = new Size(180, 25)
                },
            };
            combos = new List<ComboBox>
            {
                new ComboBox
                {
                    Location = new Point(290, 200),
                    Size = new Size(180, 25)
                }
            };
            combos[0].Items.AddRange(QueryToString<long>(db.Employee.Select(x => x.id_employee)));
            this.Controls.AddRange(boxes.ToArray());
            this.Controls.AddRange(combos.ToArray());
            button = new Button
            {
                Location = new Point(290, 350),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }

        private void AddCareerBoxes()
        {
            labelHeader.Text = "Add Career";
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
                },
                new ComboBox
                {
                    Name = "pos",
                    Location = new Point(290, 200),
                    Size = new Size(180, 25),
                },
                new ComboBox
                {
                    Name = "dep",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25),
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
                    MaxDate = DateTime.Now
                },
                new DateTimePicker
                {
                    Name = "end_work",
                    Location = new Point(290, 500),
                    Size = new Size(180, 25),
                    MinDate = DateTime.Now
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 530),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }
        
        private void AddPassportBoxes()
        {
            labelHeader.Text = "Add Passport";
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
                    Size = new Size(180, 25)
                },
                new TextBox
                {
                    Name = "place_of_birth",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25)
                },
                new TextBox
                {
                    Name = "address",
                    Location = new Point(290, 400),
                    Size = new Size(180, 25)
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
                    MaxDate = DateTime.Now
                }
            };
            this.Controls.AddRange(dates.ToArray());
            button = new Button
            {
                Location = new Point(290, 500),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }
        private void AddEmployeeBoxes()
        {
            labelHeader.Text = "Add Employee";
            List<Label> labels = new List<Label>
            {
                new Label
                {
                    Text = "Passport_id",
                    Location = new Point(350, 70)
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
                    Size = new Size(180, 25)
                },
                new TextBox
                {
                    Name = "qualification",
                    Location = new Point(290, 300),
                    Size = new Size(180, 25)
                },
            };
            this.Controls.AddRange(boxes.ToArray());
            button = new Button
            {
                Location = new Point(290, 450),
                Size = new Size(190, 50),
                Text = "Add",

            };
            button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
        }
       
        private bool ValidateBoxes()
        {
            foreach(var box in boxes)
            {
                if (string.IsNullOrEmpty(box.Text))
                    return false;
            }
            return true;
        }
        private bool ValidateCombos()
        {
            foreach(var c in combos)
            {
                if (string.IsNullOrEmpty(c.Text))
                    return false;
            }
            return true;
        }
        
        private string[] QueryToString<T>(IQueryable<T> ts)
        {
            List<string> elems = new List<string>();
            foreach(var t in ts)
            {
                elems.Add(t.ToString());
            }
            return elems.ToArray();
        }
        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                switch (action)
                {
                    case Table.Employee:
                        AddEmployeeToDb();              
                        break;
                    case Table.Passport:
                        AddPassportToDb();
                        break;
                    case Table.Career:
                        AddCareerToDb();
                        break;
                    case Table.Departament:
                        AddDepartamentToDb();
                        break;
                    case Table.Position:
                        AddPositionToDb();
                        break;
                    case Table.Vacation:
                        AddVacationToDb();
                        break;
                    case Table.Salary:
                        AddSalaryToDb();
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

        private void AddSalaryToDb()
        {
            if (ValidateBoxes() && ValidateCombos())
            {
                var sal = new Salary
                {
                    employee_id = long.Parse(combos[0].Text),
                    salary_date = dates[0].Value.Date,
                    sum = decimal.Parse(boxes[0].Text),
                    oved = decimal.Parse(boxes[1].Text)
                };
                db.Salary.Add(sal);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void AddVacationToDb()
        {
            if (ValidateCombos())
            {
                var vac = new Vacation
                {
                    employee_id = long.Parse(combos[0].Text),
                    vacation_start = dates[0].Value.Date,
                    vacation_end = dates[1].Value.Date
                };
                db.Vacation.Add(vac);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void AddPositionToDb()
        {
            if (ValidateBoxes())
            {
                var pos = new Position
                {
                    position_name = boxes[0].Text,
                    salary = decimal.Parse(boxes[1].Text),
                };
                db.Position.Add(pos);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void AddDepartamentToDb()
        {
            if (ValidateBoxes() && ValidateCombos())
            {
                var dep = new Department
                {
                    name_abbreviation = boxes[0].Text,
                    department_leader = long.Parse(combos[0].Text)
                };
                db.Department.Add(dep);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }

        private void AddCareerToDb()
        {
            if (ValidateCombos())
            {
                var career = new Career
                {
                    employee_id = long.Parse(combos[0].Text),
                    position_id = long.Parse(combos[1].Text),
                    department_name = long.Parse(combos[2].Text),
                    start_work = dates[0].Value.Date,
                    end_work = dates[1].Value.Date,
                };
                db.Career.Add(career);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }
        private void AddEmployeeToDb()
        {
            if (ValidateBoxes() && ValidateCombos())
            {
                var employee = new Employee
                {
                    passport_id = long.Parse(combos[0].Text),
                    education = boxes[0].Text,
                    qualification = boxes[1].Text
                };
                db.Employee.Add(employee);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }
        private void AddPassportToDb()
        {
            if (ValidateBoxes())
            {
                var passport = new Passport_data
                {
                    name = boxes[0].Text,
                    date_of_birth = dates[0].Value.Date,
                    place_of_birth = boxes[1].Text,
                    address = boxes[2].Text

                };
                db.Passport_data.Add(passport);
                db.SaveChanges();
            }
            else
                throw new InvalidOperationException("Enter the all values");
        }
    }
}
