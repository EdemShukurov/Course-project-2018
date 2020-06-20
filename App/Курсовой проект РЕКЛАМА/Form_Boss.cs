using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовой_проект_РЕКЛАМА
{
    public partial class Form_Boss : Form
    {
        string Log_In;
        int Check=1;

        public Form_Boss()
        {
            InitializeComponent();
            groupBox_Air.Visible= groupBox_Emp.Visible=groupBoxV_Stat_FIO.Visible= textBox_Reklama.Enabled=
                dgv_Advertisements.Visible=dgv_Emp.Visible=dgv_Own_Statistic.Visible = menuStrip1.Visible= panelButtons.Enabled= false;

            ProfilLabel.Text = "Начальника";
         
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 120, 120);
            Region rgn = new Region(path);
            PhotoPictureBox.Region = rgn;
            PhotoPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;

            textBox_Surname.MaxLength = textBox_Name.MaxLength = textBox_Lastname.MaxLength = 20;
            textBox_Reklama.MaxLength = 7;
        }

        bool IsNum(string text)
        {
            double num;
            return double.TryParse(textBox_Reklama.Text, out num);
        }

        void ClearBoxes()
        {
            textBox_Surname.Text = textBox_Name.Text = textBox_Lastname.Text = maskedTextBox_Percent.Text =
                comboBox_Broadcast.Text = textBox_Reklama.Text =comboBoxV_StatFIO.Text= "";
            comboBoxV_StatFIO.SelectedIndex = -1;
            dateTimePicker_Hire.Value = DateTime.Today;
            panelButtons.Enabled = textBox_Reklama.Enabled = false;
        }

        void DGV_Adver()
        {
            dgv_Air.Visible = dgv_Emp.Visible = dgv_Own_Statistic.Visible = panelButtons.Enabled=
                 groupBox_Air.Visible = groupBox_Emp.Visible = groupBoxV_Stat_FIO.Visible = menuStrip1.Visible = false;
            dgv_Advertisements.Visible = groupBox_Nothing.Visible = true;
            Advertisements_Class adv = new Advertisements_Class();
            adv.Update_DGV(dgv_Advertisements);

        }

        void DGV_V_Stat() // Видны только объекты для манипулирования статистикой
        {
            V_Own_Stat_Class VS = new V_Own_Stat_Class();
            Employees_Class emp = new Employees_Class();

            dgv_Air.Visible = dgv_Emp.Visible =
                 groupBox_Air.Visible = groupBox_Emp.Visible = panelButtons.Enabled =
                     dgv_Advertisements.Visible = groupBox_Nothing.Visible = menuStrip1.Visible = false;
            dgv_Own_Statistic.Visible = groupBoxV_Stat_FIO.Visible = true;
            VS.Update_DGV(dgv_Own_Statistic);

            emp.Update_DGV(dgv_Emp);
            panelButtons.Enabled  = true;

            ClearBoxes();
        }

        void DGV_Employees()
        {
            dgv_Air.Visible = groupBox_Air.Visible =
                   panelButtons.Enabled = dgv_Own_Statistic.Visible = groupBoxV_Stat_FIO.Visible =
                        dgv_Advertisements.Visible = groupBox_Nothing.Visible = menuStrip1.Visible = false;
            dgv_Emp.Visible = groupBox_Emp.Visible = true;

            Employees_Class emp = new Employees_Class();
            emp.Update_DGV(dgv_Emp);          
        }

        void DGV_Air() // Видны только объекты для манипулирования эфиром
        {
            //dgv_Own_Statistic.Visible = dgv_Advertisements.Visible = dgv_Clients.Visible = dgv_Own_Adver.Visible =
            dgv_Emp.Visible = groupBox_Emp.Visible = menuStrip1.Visible =
                groupBox_Nothing.Visible = dgv_Own_Statistic.Visible = groupBoxV_Stat_FIO.Visible =
                    dgv_Advertisements.Visible = false;
           dgv_Air.Visible = groupBox_Air.Visible = true;
            
            Air_Class air = new Air_Class();
            air.Update_DGV(dgv_Air);

            if(dgv_Air.RowCount>comboBox_Broadcast.Items.Count)
            foreach (DataGridViewRow item in dgv_Air.Rows)
                comboBox_Broadcast.Items.Add(item.Cells[0].Value.ToString());
            //ClearBoxes();
        }

       
        // Метод для генерация случайных чисел:
        #region
        public string RandomMethod()
        {
            Random rand = new Random();
            char[] RandomCharArr = new char[5];
            string textRandom = "";
            for (int i = 0; i < RandomCharArr.Length; i++)
            {
                RandomCharArr[i] = (char)rand.Next(0x0030, 0x007A);
            }
            foreach (char c in RandomCharArr) textRandom += c;

            return textRandom;
        }
        #endregion

        // Двойное нажатие по сотрудникам с использованием переменной Log_In в качестве ключа:

        private void dgv_Emp_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Emp.CurrentRow.Index != -1)
            {
                textBox_Surname.Text = dgv_Emp.CurrentRow.Cells[0].Value.ToString();
                textBox_Name.Text = dgv_Emp.CurrentRow.Cells[1].Value.ToString();
                textBox_Lastname.Text = dgv_Emp.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox_Percent.Text = dgv_Emp.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker_Hire.Text = dgv_Emp.CurrentRow.Cells[4].Value.ToString().Remove(10, 8);
                Log_In = dgv_Emp.CurrentRow.Cells[5].Value.ToString();

                butInsert.Enabled = butUpdate.Enabled = false;
                butDel.Enabled = butCancel.Enabled = true;
            }
        }


        private void BossMenuItemAir_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            DGV_Air();// Видны только объекты для манипулирования эфиром 
        }

        private void BossMenuItemEmp_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            DGV_Employees();
        }

        // Добавить сотрудника
        private void butInsert_Click(object sender, EventArgs e)
        {
            #region
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgv_Emp.Visible)
                {
                    Employees_Class Emp_Class = new Employees_Class();
                    if (textBox_Surname.Text.Trim() != "" && textBox_Name.Text.Trim() != "" && maskedTextBox_Percent.Text != "**" && dateTimePicker_Hire.Value <= DateTime.Today)
                    {
                        // Генерация и проверка случайных симоволов для логина и пароля
                        #region
                        string LoginRandom = "";
                        while (Check != 0)
                        {
                            LoginRandom = RandomMethod();
                            Check = Emp_Class.CheckRandomMethod(LoginRandom);
                        }
                        Check = 1;

                        string PasswordRandom = "";
                        PasswordRandom = RandomMethod();

                        #endregion
                        

                        //bool check_text = IsNum(textBox_Surname.Text);
                        //if (!check_text)
                        //{
                        //    check_text = IsNum(textBox_Name.Text);
                        //    if(!check_text)
                        //        check_text = IsNum(maskedTextBox_Percent.Text);
                        //}

                        //if (check_text)
                        //{
                        Emp_Class.Insert_employees(2, textBox_Surname.Text.Trim(), textBox_Name.Text.Trim(), 
                            textBox_Lastname.Text.Trim(), byte.Parse(maskedTextBox_Percent.Text.Trim()),
                                dateTimePicker_Hire.Text, LoginRandom, PasswordRandom, dgv_Emp);
                            MessageBox.Show("Новый сотрудник добавлен", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else MessageBox.Show("Данные имели неверный формат");
                        ClearBoxes();
                    }
                    else MessageBox.Show("Не все ключевые значения были заполнены или введены правильно","",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            #endregion
        }

        private void textBox_Surname_TextChanged(object sender, EventArgs e)
        {
            panelButtons.Enabled = butCancel.Enabled = butInsert.Enabled = butUpdate.Enabled = true;
            butDel.Enabled = false;
        }

        // УДАЛЕНИЕ СОТРУДНИКА
        private void butDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgv_Emp.Visible)
                {
                    Employees_Class Emp_Class = new Employees_Class();
                    Emp_Class.Delete_employee(Log_In, dgv_Emp);

                    DGV_Employees();
                    ClearBoxes();
                }
            }
        }

        // ИЗМЕНИТЬ ДАННЫЕ
        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "Надо сделать выбор", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ИЗМЕНЕНИЕ СОТРУДНИКА
                if (dgv_Emp.Visible)
                {
                    Employees_Class Emp_Class = new Employees_Class();
                    if (textBox_Surname.Text != "" && textBox_Name.Text != "" && maskedTextBox_Percent.Text != "**")
                    {
                        if (dateTimePicker_Hire.Value <= DateTime.Today)
                        {
                            Emp_Class.Update_employees(Log_In, textBox_Surname.Text.Trim(), textBox_Name.Text.Trim(), 
                                textBox_Lastname.Text.Trim(), byte.Parse(maskedTextBox_Percent.Text),
                                dateTimePicker_Hire.Text, dgv_Emp);
                            MessageBox.Show("Данные измененны", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else MessageBox.Show("Введена неверная дата", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else MessageBox.Show("Не все ключевые значения были заполнены", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                // Изменение стоимости минуты эфира:
                #region
                if (dgv_Air.Visible)
                {
                    Air_Class air = new Air_Class();
                    
                    double num;
                    bool isNum = double.TryParse(textBox_Reklama.Text, out num);
                    
                    if (isNum)
                    {
                        air.Update_Air(comboBox_Broadcast.Text, textBox_Reklama.Text.Trim(), dgv_Air); 
                        MessageBox.Show("Данные измененны");
                    }
                    else
                        MessageBox.Show("Введен неверный формат записи", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                #endregion

                
            }
            ClearBoxes(); 
        }

        private void рекламаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV_Adver();
            ClearBoxes();
        }

        private void BossMenuItemStat_Click(object sender, EventArgs e)
        {
            ClearBoxes();

            // Заполнение combobox ФИО_ЛОГИН
            Employees_Class emp = new Employees_Class();
            panelButtons.Enabled = false;
            int EmpCount = emp.EmpCount();
            DGV_V_Stat();
            if (EmpCount > comboBoxV_StatFIO.Items.Count)
            {
                foreach (DataGridViewRow row in dgv_Emp.Rows)
                {
                    comboBoxV_StatFIO.Items.Add(row.Cells[0].Value.ToString().Trim() + " " +
                    row.Cells[1].Value.ToString().Remove(1).Trim() + "." + row.Cells[2].Value.ToString().Remove(1).Trim() + ". " +
                    row.Cells[5].Value.ToString().Trim());
                }
            }
        }

        private void comboBox_Broadcast_TextChanged(object sender, EventArgs e)
        {
            panelButtons.Enabled = butCancel.Enabled = butUpdate.Enabled =textBox_Reklama.Enabled= true;
            butDel.Enabled = butInsert.Enabled = false;
        }

        private void butSearchV_StatFIO_Click(object sender, EventArgs e)
        {
            V_Own_Stat_Class vs = new V_Own_Stat_Class();
            string count = vs.SumIncome(comboBoxV_StatFIO.Text, dgv_Own_Statistic);
            if (count == null || count=="0") labelCount.Text = "0";
            else labelCount.Text = count.ToString();
            labelItog.Visible = labelCount.Visible = true;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhotoPictureBox_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void PhotoPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menuStrip1.Visible = true;
            }
        }

        // ЗАКРЫТИЕ ФОРМЫ
        private void Form_Boss_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти и открыть окно авторизации?", "", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form_Sign_In f = new Form_Sign_In();
                f.Show();
            }
            else e.Cancel = true;
        }

        private void Form_Boss_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void textBox_Lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            char  simbol = e.KeyChar;
            if ((simbol < 'А' || simbol > 'я') && simbol != '\b' && simbol != '.')
                e.Handled = true; 
        }

        private void textBox_Reklama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))
                e.Handled = true;
        }

             
    }
}
