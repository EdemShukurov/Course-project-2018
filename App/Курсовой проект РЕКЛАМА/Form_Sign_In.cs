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
    public partial class Form_Sign_In : Form
    {
        public Form_Sign_In()
        {
            InitializeComponent();
        }

        private void EyePictureBox_Click(object sender, EventArgs e)
        {
            if (PassMaskedTextBox.UseSystemPasswordChar)
            {
                PassMaskedTextBox.UseSystemPasswordChar = false;
                EyePictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.пароль_виден;
            }
            else
            {
                PassMaskedTextBox.UseSystemPasswordChar = true;
                EyePictureBox.Image = Курсовой_проект_РЕКЛАМА.Properties.Resources.пароль_скрыт;
            }    
        }

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            if (LoginTextBox.Text != "" && PassMaskedTextBox.Text != "")
                butSignIn.Enabled = true;
            else butSignIn.Enabled = false;
        }

        // Вход:
        #region
        private void butSignIn_Click(object sender, EventArgs e)
        {
            Employees_Class emp = new Employees_Class();
            byte Emp_id_Check = emp.CheckPass(LoginTextBox.Text, PassMaskedTextBox.Text);
            byte Emp_Post = emp.Post_Check(Emp_id_Check);

            if (Emp_id_Check != 0)
            {
                if (Emp_Post == 1) { Form_Boss FB = new Form_Boss(); FB.Show(); }
                else { Form_Emp FE = new Form_Emp(Emp_id_Check); FE.Show(); }
               
                this.Hide();            
            }
            else
            {
                MessageBox.Show("Неверные логин или пароль.\nПроверьте правильность введенных данных.", "", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTextBox.Text = PassMaskedTextBox.Text = "";
            }
        }
        #endregion

        private void butExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены,что хотите выйти из системы?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form_Sign_In_FormClosing(object sender, FormClosingEventArgs e)
        {
                Application.Exit();           
        }

        private void Form_Sign_In_Load(object sender, EventArgs e)
        {

        }

       

    }
}
