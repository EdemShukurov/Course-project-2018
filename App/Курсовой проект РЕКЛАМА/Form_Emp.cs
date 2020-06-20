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
    public partial class Form_Emp : Form
    {
        AdvertisingEntities AD = new AdvertisingEntities();
        byte Check, Emp_Code, Adver_id;
        string Client_Passport, Emp_Fio_login, old_reklama_time;
        
        public Form_Emp(byte Emp_Code)
        {
            InitializeComponent();
            this.Emp_Code = Emp_Code;
            Employees_Class emp = new Employees_Class();
            ProfilLabel.Text = emp.Profil_Label(Emp_Code);
            switch (Emp_Code)
            {
                case 2:PhotoPictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.ИванВасильевич; break;
                case 3: PhotoPictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.Че_Гевара; break;
                case 4: PhotoPictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.Женщина_афро_волосы; break;
                case 5: PhotoPictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.клеопатра; break;
            }

            dgv_Advertisements.Visible = dgv_Air.Visible = dgv_Clients.Visible = dgv_Own_Statistic.Visible 
                = dgv_Own_Adver.Visible= dgv_Own_Client.Visible = groupBox_V_Reklama.Visible = groupBox_Nothing.Visible=menuStrip1.Visible
                    = groupBox_Clients.Visible = groupBox_Own_Stat.Visible = Panel_Buttons.Enabled = false;

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 120, 120);
            Region rgn = new Region(path);
            PhotoPictureBox.Region = rgn;
            PhotoPictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;

            textBoxClientLastName.MaxLength = textBoxClientName.MaxLength = textBoxClientSurname.MaxLength = 20;
            textBoxReklama.MaxLength = 25;
            textBoxInterval.MaxLength = 2;
        }

        // Методы для манипулированиями группбоксами и датагридвью:
        #region
        void DGV_V_Stat() // Видны только объекты для манипулирования статистикой
        {
            dgv_Clients.Visible = dgv_Advertisements.Visible = dgv_Air.Visible =
                dgv_Own_Adver.Visible = dgv_Own_Client.Visible = menuStrip1.Visible =
                   groupBox_Clients.Visible=groupBox_V_Reklama.Visible= false;
            dgv_Own_Statistic.Visible = groupBox_Own_Stat.Visible = true;

            Employees_Class emp = new Employees_Class();
            Emp_Fio_login = emp.ChangeFIO_Login(Emp_Code);
            V_Own_Stat_Class vs = new V_Own_Stat_Class();
            vs.Update_DGV(Emp_Fio_login, dgv_Own_Statistic);

            double sum_deals=0;
            foreach (DataGridViewRow item in dgv_Own_Statistic.Rows)
                sum_deals += double.Parse(item.Cells[5].Value.ToString());

            label_count.Text = dgv_Own_Statistic.RowCount.ToString() ;
            label_sum.Text=sum_deals.ToString();

            ClearBoxes();
        }

        void DGV_Client()// Видны только объекты для манипулирования клиентами
        {
            dgv_Own_Statistic.Visible = dgv_Advertisements.Visible = dgv_Air.Visible =
                dgv_Own_Adver.Visible = dgv_Own_Client.Visible = groupBox_Own_Stat.Visible = menuStrip1.Visible=
                    groupBox_V_Reklama.Visible = groupBox_Clients.Visible = Panel_Buttons.Enabled = false;
            dgv_Clients.Visible = groupBox_Nothing.Visible = true;
            
            Clients_Class cl = new Clients_Class();
          
            cl.Update_DGV(dgv_Clients);

            ClearBoxes();
        }

        void DGV_Own_Clients()// Видны только объекты для манипулирования своими клиентами
        {
            dgv_Own_Statistic.Visible = dgv_Advertisements.Visible = dgv_Air.Visible = 
                dgv_Own_Adver.Visible = groupBox_Own_Stat.Visible = groupBox_V_Reklama.Visible = 
                menuStrip1.Visible = Panel_Buttons.Enabled = dgv_Clients.Visible = groupBox_Nothing.Visible = false;

            dgv_Own_Client.Visible = groupBox_Clients.Visible = true;

            Clients_Class cl = new Clients_Class();
            cl.Update_DGV(dgv_Own_Client, Emp_Code);

            ClearBoxes();
        }

        void DGV_Air() // Видны только объекты для манипулирования эфиром
        {
            dgv_Own_Statistic.Visible = dgv_Advertisements.Visible = dgv_Clients.Visible = dgv_Own_Adver.Visible =
                dgv_Own_Client.Visible = groupBox_Own_Stat.Visible = groupBox_V_Reklama.Visible = menuStrip1.Visible =
                     groupBox_Clients.Visible = false;
            dgv_Air.Visible = groupBox_Nothing.Visible = true;

            Air_Class air = new Air_Class();
            air.Update_DGV(dgv_Air);

            ClearBoxes();
        }
#endregion

        // Метод для очищения группбоксов и кнопка с его вызовом:
#region
        // Метод для очищения группбоксов
        void ClearBoxes()
        {
            textBoxClientSurname.Text = textBoxClientName.Text = textBoxClientLastName.Text =
                maskedTextBoxClientPassport.Text = maskedTextBoxClientTel.Text = maskedTextBoxClientBankcard.Text =
                comboBoxBroadcast.Text = comboBoxTime.Text =  textBoxReklama.Text = textBoxInterval.Text = "";
                     comboBoxBroadcast.SelectedIndex = -1; comboBoxFIO_Passport.SelectedIndex = -1;
              maskedTextBoxClientTel.Text = "+79990000000";
              maskedTextBoxClientBankcard.Text = "0000-0000-0000-0000";
              maskedTextBoxClientPassport.Text = "000000000";
              textBoxReklama.Enabled = comboBoxBroadcast.Enabled = comboBoxFIO_Passport.Enabled =
                    comboBoxTime.Enabled = textBoxInterval.Enabled=true;
              Panel_Buttons.Enabled = but_Cancel.Enabled = but_Del.Enabled = but_Insert.Enabled = but_Update.Enabled = false;
        }

        // Кнопка с вызовом метода "Очищение группбоксов" 
        private void butCancel_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }
#endregion

        // Манипулирование рекламой
        #region
        void Reklama()
        {
            dgv_Own_Statistic.Visible = dgv_Air.Visible = dgv_Clients.Visible = dgv_Own_Client.Visible =
                groupBox_Own_Stat.Visible = groupBox_Clients.Visible = but_Update.Enabled= false;

            Clients_Class client = new Clients_Class();
            client.Update_DGV(dgv_Clients);
            Air_Class air = new Air_Class();
            air.Update_DGV(dgv_Air);

            Advertisements_Class Adver = new Advertisements_Class();
            if (dgv_Advertisements.Visible)
            {
                groupBox_Nothing.Visible = true; Panel_Buttons.Enabled = groupBox_V_Reklama.Visible = false;
                Adver.Update_DGV(dgv_Advertisements);
            }
            if (dgv_Own_Adver.Visible)
            {
                groupBox_Nothing.Visible = false; groupBox_V_Reklama.Visible = true;
                Adver.Update_DGV(dgv_Own_Adver, Emp_Code);

                //panelButtons.Enabled = false;

                if (client.Clients_Count() > comboBoxFIO_Passport.Items.Count)
                {
                    foreach (DataGridViewRow item in dgv_Clients.Rows)
                    {
                        comboBoxFIO_Passport.Items.Add(client.ChangeFIO(byte.Parse(item.Cells[0].Value.ToString().Trim())));
                    }
                }
                if (dgv_Air.RowCount > comboBoxBroadcast.Items.Count)
                foreach (DataGridViewRow item in dgv_Air.Rows)
                    comboBoxBroadcast.Items.Add(item.Cells[0].Value.ToString());               
             }
        }

        // Изменение времени в зависимости от передачи
        private void comboBoxBroadcast_TextChanged(object sender, EventArgs e)
        {
            comboBoxTime.Items.Clear();
            but_Update.Enabled = true;
            but_Del.Enabled = false;
            foreach (DataGridViewRow item in dgv_Air.Rows)
            {
                if (item.Cells[0].Value.ToString() == comboBoxBroadcast.Text)
                {
                    for (TimeSpan i = TimeSpan.Parse(item.Cells[1].Value.ToString()); i <= TimeSpan.Parse(item.Cells[2].Value.ToString()); i += TimeSpan.FromMinutes(15))
                        comboBoxTime.Items.Add(i);
                }
            }
        }
        // ИЗМЕНЕНИЕ В ТЕКСТЕ ДЛЯ РЕКЛАМЫ
        #region
        private void comboBoxFIO_Passport_TextChanged(object sender, EventArgs e)
        {
            but_Cancel.Enabled = but_Update.Enabled = true;
        }

        private void textBoxReklama_TextChanged(object sender, EventArgs e)
        {
            but_Cancel.Enabled = but_Update.Enabled = true;
        }

        private void comboBoxTime_TextChanged(object sender, EventArgs e)
        {
            but_Cancel.Enabled = but_Update.Enabled = true;
        }
        #endregion
        #endregion

        // Двойной клик по DGV
        #region
                // Двойное нажатие по клиентам с использованием переменной passport в качестве ключа:
        private void dgv_Own_Client_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Own_Client.CurrentRow.Index != -1)
            {
                Client_Passport = dgv_Own_Client.CurrentRow.Cells[4].Value.ToString();
                textBoxClientSurname.Text = dgv_Own_Client.CurrentRow.Cells[1].Value.ToString();
                textBoxClientName.Text = dgv_Own_Client.CurrentRow.Cells[2].Value.ToString();
                textBoxClientLastName.Text = dgv_Own_Client.CurrentRow.Cells[3].Value.ToString();
                maskedTextBoxClientPassport.Text = Client_Passport;
                maskedTextBoxClientTel.Text = dgv_Own_Client.CurrentRow.Cells[5].Value.ToString();
                maskedTextBoxClientBankcard.Text = dgv_Own_Client.CurrentRow.Cells[6].Value.ToString();
                Panel_Buttons.Enabled=but_Cancel.Enabled = but_Del.Enabled = true;
                maskedTextBoxClientPassport.Enabled = but_Insert.Enabled = false;
                
            }
        }
               // Двойное нажатие по рекламе:
        private void dgv_Own_Adver_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Own_Adver.CurrentRow.Index != -1)
            {
                comboBoxFIO_Passport.Text = dgv_Own_Adver.CurrentRow.Cells[0].Value.ToString();
                textBoxReklama.Text = dgv_Own_Adver.CurrentRow.Cells[1].Value.ToString();
                textBoxInterval.Text = dgv_Own_Adver.CurrentRow.Cells[2].Value.ToString();
                comboBoxBroadcast.Text = dgv_Own_Adver.CurrentRow.Cells[3].Value.ToString();
                old_reklama_time = comboBoxTime.Text = dgv_Own_Adver.CurrentRow.Cells[4].Value.ToString();
                Adver_id = byte.Parse(dgv_Own_Adver.CurrentRow.Cells[7].Value.ToString());
                //textBoxReklama.Enabled = comboBoxBroadcast.Enabled=comboBoxFIO_Passport.Enabled= comboBoxTime.Enabled=textBoxInterval.Enabled= false;
                Panel_Buttons.Enabled = but_Del.Enabled = but_Cancel.Enabled = true;
                but_Insert.Enabled = but_Update.Enabled = false;
            }
            
        }
        #endregion

        // МЕНЮ
        #region
        private void просмотрРекламыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            dgv_Own_Adver.Visible = false;
            dgv_Advertisements.Visible = true;
            Reklama();
            Panel_Buttons.Enabled = but_Cancel.Enabled = but_Del.Enabled = but_Insert.Enabled = but_Update.Enabled = false;
        }

        private void внестиИзмененияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            dgv_Own_Adver.Visible = true;
            dgv_Advertisements.Visible = false;
            Reklama();
        }
       
        private void EmpMenuItemAir_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            DGV_Air();
            Panel_Buttons.Enabled = but_Cancel.Enabled = but_Del.Enabled = but_Insert.Enabled = but_Update.Enabled = false;
        }

        private void EmpMenuItemStat_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            DGV_V_Stat();
            Panel_Buttons.Enabled = but_Cancel.Enabled = but_Del.Enabled = but_Insert.Enabled = but_Update.Enabled = false;

        }

        private void просмотретьСписокКлиентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            DGV_Client();
            Panel_Buttons.Enabled = but_Cancel.Enabled = but_Del.Enabled = but_Insert.Enabled = but_Update.Enabled = false;
        }

        private void внестиИзмененичяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV_Own_Clients();
        }
        #endregion

        #region
                   
        // ЭЛЕМЕНТ МЕНЮ ВЫХОД
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmpMenuItemClients_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }

        private void EmpMenuItemAdver_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }


        // ЗАКРЫТИЕ ФОРМЫ
        private void Form_Emp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти и открыть окно авторизации?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form_Sign_In f = new Form_Sign_In();
                f.Show();
            }
            else e.Cancel = true;
        }
        #endregion

        // КНОПКА ВЫХОДА НА ИЗОБРАЖЕНИИ
        #region
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
        #endregion

        // ДОБАВЛЕНИЕ, УДАЛЕНИЕ И ИЗМЕНЕНИЕ ДАННЫХ 
        #region
        private void butInsert_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Добавление клиентов:
                #region
                if (dgv_Own_Client.Visible)
                {
                    Clients_Class CL_Class = new Clients_Class();

                    if (textBoxClientSurname.Text.Trim() != "" && textBoxClientName.Text.Trim() != "" && maskedTextBoxClientBankcard.Text != "0000-0000-0000-0000" && maskedTextBoxClientPassport.Text != "000000000" && maskedTextBoxClientTel.Text != "+79990000000")
                    {
                        // Проверка пасспорта:
                        Check = CL_Class.Check_Passport(maskedTextBoxClientPassport.Text);
                        if (Check == 1)
                        {
                            maskedTextBoxClientPassport.Text = "";
                            MessageBox.Show("Такой паспорт уже занят, введите другой", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Проверка банковской карточки:
                            Check = CL_Class.Check_BankCard(maskedTextBoxClientBankcard.Text, maskedTextBoxClientPassport.Text, false);
                            if (Check == 1)
                            {
                                maskedTextBoxClientBankcard.Text = "";
                                MessageBox.Show("Данный номер банковской карточки уже имеется в базе, введите другой", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            else
                            {
                                // Проверка телефона:
                                Check = CL_Class.Check_Phone(maskedTextBoxClientTel.Text, maskedTextBoxClientPassport.Text, false);
                                if (Check == 1)
                                {
                                    maskedTextBoxClientTel.Text = "";
                                    MessageBox.Show("Данный номер телефона уже имеется в базе, введите другой", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    CL_Class.Insert_clients(textBoxClientSurname.Text.Trim(), 
                                        textBoxClientName.Text, textBoxClientLastName.Text.Trim(), 
                                        maskedTextBoxClientPassport.Text.Trim(), maskedTextBoxClientBankcard.Text.Trim(),
                                        maskedTextBoxClientTel.Text.Trim(), dgv_Own_Client, Emp_Code);
                                    MessageBox.Show("Новый клиент добавлен. Для того, чтобы увидеть его в списке своих клиентов необходимо добавить его рекламу", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    CL_Class.Update_DGV(dgv_Own_Client, Emp_Code);
                                    CL_Class.Update_DGV(dgv_Clients);

                                    ClearBoxes();
                                }
                            }
                        }
                    }
                    else MessageBox.Show("Не все ключевые значения были заполнены");
                }
                #endregion
                //Добавление рекламы: 
                if (dgv_Own_Adver.Visible)
                {
                    Advertisements_Class adver = new Advertisements_Class();
                    if (comboBoxFIO_Passport.Text.Trim() != "" && textBoxReklama.Text.Trim() != "" &&
                        comboBoxBroadcast.Text != "" && textBoxInterval.Text != "" && comboBoxTime.Text != "")
                    {
                        if (adver.Check_Count(textBoxReklama.Text, TimeSpan.Parse(comboBoxTime.Text)) != 1)
                        {
                            adver.Insert_Adver(comboBoxFIO_Passport.Text, textBoxReklama.Text, comboBoxBroadcast.Text,
                            int.Parse(textBoxInterval.Text), TimeSpan.Parse(comboBoxTime.Text), dgv_Advertisements, Emp_Code);
                            adver.Update_DGV(dgv_Own_Adver);
                            adver.Update_DGV(dgv_Own_Adver, Emp_Code);
                            MessageBox.Show("Реклама добавлена");
                            ClearBoxes();
                        }
                        else MessageBox.Show("Данная реклама уже имеется", "Невозможно внести изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Не все ключевые значения были заполнены", "Невозможно внести изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearBoxes();
                Panel_Buttons.Enabled = false;
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            // Удаление клиента:
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "Надо сделать выбор",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgv_Own_Client.Visible)
                {
                    if (textBoxClientSurname.Text.Trim() != "" && textBoxClientName.Text.Trim() != "" &&
                        maskedTextBoxClientBankcard.Text != "" && maskedTextBoxClientPassport.Text != "")
                    {
                        Clients_Class Cl_Class = new Clients_Class();
                        Cl_Class.Delete_clients(Client_Passport, dgv_Own_Client);

                        DGV_Client();
                        MessageBox.Show("Запись удалена");
                        ClearBoxes();
                    }
                    else MessageBox.Show("Поля не должны быть пустыми");
                }
                // Удаление рекламы:
                if (dgv_Own_Adver.Visible)
                {
                    if (comboBoxFIO_Passport.Text != "" && textBoxReklama.Text.Trim() != "" &&
                        comboBoxBroadcast.Text != "" && textBoxInterval.Text != "" && comboBoxTime.Text != "")
                    {
                        Advertisements_Class adver_del = new Advertisements_Class();
                        adver_del.Delete_Adver(Adver_id, textBoxReklama.Text, 
                                TimeSpan.Parse(comboBoxTime.Text), dgv_Own_Adver);
                        adver_del.Update_DGV(dgv_Own_Adver);
                        adver_del.Update_DGV(dgv_Own_Adver, Emp_Code);
                        MessageBox.Show("Реклама удалена");
                        ClearBoxes();
                    }
                    else MessageBox.Show("Поля не должны быть пустыми");
                }
            }
            Panel_Buttons.Enabled = false;  
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите внести изменения?!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Изменение данных о клиенте:
                #region
                if (dgv_Own_Client.Visible)
                {
                    Clients_Class CL_Class = new Clients_Class();

                    if (textBoxClientSurname.Text.Trim() != "" && textBoxClientName.Text.Trim() != "" &&
                        maskedTextBoxClientBankcard.Text != "0000-0000-0000-0000" &&
                        maskedTextBoxClientPassport.Text != "000000000" && maskedTextBoxClientTel.Text != "+79990000000")
                    {
                        Clients_Class CL_Update = new Clients_Class();
                        CL_Update.Update_clients(Client_Passport, textBoxClientSurname.Text.Trim(), textBoxClientName.Text,
                            textBoxClientLastName.Text.Trim(), maskedTextBoxClientBankcard.Text.Trim(),
                                maskedTextBoxClientTel.Text.Trim(), dgv_Own_Client, Emp_Code);
                        DGV_Own_Clients();
                        ClearBoxes();
                    }
                    else MessageBox.Show("Не все ключевые значения были заполнены", "Невозможно внести изменения",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion

                // Изменение данных о рекламе
                if (dgv_Own_Adver.Visible)
                {
                    Advertisements_Class Adv_Update = new Advertisements_Class();

                    if (comboBoxTime.SelectedIndex != -1 && comboBoxFIO_Passport.SelectedIndex != -1 && comboBoxBroadcast.SelectedIndex != -1 && textBoxInterval.Text != "")
                    {
                        Adv_Update.Update_Adver(Adver_id, comboBoxFIO_Passport.Text, textBoxReklama.Text, int.Parse(textBoxInterval.Text),
                            comboBoxBroadcast.Text, TimeSpan.Parse(comboBoxTime.Text), dgv_Own_Adver, Emp_Code, TimeSpan.Parse(old_reklama_time));

                        Adv_Update.Update_DGV(dgv_Own_Adver);
                        Adv_Update.Update_DGV(dgv_Own_Adver, Emp_Code);
                    }

                    else MessageBox.Show("Не все поля были заполнены", "Невозможно внести изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ClearBoxes();
            Panel_Buttons.Enabled = false;
        }


        #endregion

        private void textBoxClientSurname_TextChanged(object sender, EventArgs e)
        {
            Panel_Buttons.Enabled= but_Cancel.Enabled = true;
            if (maskedTextBoxClientPassport.Text == "") maskedTextBoxClientPassport.Enabled = true;
            if (maskedTextBoxClientPassport.Text != "" && maskedTextBoxClientPassport.Enabled==true) but_Insert.Enabled = true;   
        }

        private void comboBoxFIO_Passport_TextChanged_1(object sender, EventArgs e)
        {
            Panel_Buttons.Enabled = but_Cancel.Enabled = but_Insert.Enabled = but_Update.Enabled = true;
            but_Del.Enabled = false;
        }

        private void textBoxClientLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char simbol = e.KeyChar;
            if ((simbol < 'А' || simbol > 'я') && simbol != '\b' && simbol != '.')
                e.Handled = true;
        }

        private void textBoxReklama_KeyPress(object sender, KeyPressEventArgs e)
        {
            char simbol = e.KeyChar;
            if ((simbol < 'А' || simbol > 'я') && simbol != '\b' && simbol != '.')
                e.Handled = true;
        }

        private void textBoxInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & (e.KeyChar != ',') & (e.KeyChar != (char)Keys.Back))
                e.Handled = true;
        }

        private void Form_Emp_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
        }
      
    }
}
