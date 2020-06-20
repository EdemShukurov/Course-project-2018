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
    public class Employees_Class
    {
        public Employees_Class()
        {
            this.Advertisements = new HashSet<Advertisements>();
        }

        public byte emp_id { get; set; }
        public Nullable<byte> post_id { get; set; }
        public string emp_surname { get; set; }
        public string emp_name { get; set; }
        public string emp_lastname { get; set; }
        public Nullable<byte> emp_percent { get; set; }
        public System.DateTime date_hire { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string image_trip { get; set; }

        public virtual ICollection<Advertisements> Advertisements { get; set; }
        public virtual Posts Posts { get; set; }


        AdvertisingEntities AD = new AdvertisingEntities();
        byte code, post;
        string log, image;

        // Обновление dataGridViewEmp
        #region
        public void Update_DGV(DataGridView DGV_Emp)
        {
            DGV_Emp.AutoGenerateColumns = false;
            DGV_Emp.DataSource = AD.Employees.Where(u => u.post_id == 2).Select(u => u).ToList();
        }
        #endregion

        // ФИО_Логин
        public string ChangeFIO_Login(byte id)
        {
            var fio_login = AD.Employees.Where(u => u.emp_id == id).Single();
            return fio_login.emp_surname + " " + fio_login.emp_name.Remove(1) + "." + fio_login.emp_lastname.Remove(1) + 
                ". " + fio_login.login;
        }

        
        // Присваивание переменной code значение emp_id по логину и паролю:
        #region
        public byte CheckPass(string LOG, string PASS)
        {
            var Check = AD.Employees.Where(u => u.login == LOG).Where(u => u.password == PASS).Select(u => u.emp_id);
            foreach (var item in Check) code = item;

            return code;

        }
        #endregion

        // Присваивание переменной post значение post_id по входному параметру id:
        #region
        public byte Post_Check(byte id)
        {
            var Post_Check = AD.Employees.Where(u => u.emp_id == id).Select(u => u.post_id);
            foreach (var item in Post_Check) post = byte.Parse(item.ToString());

            return post;
        }
        #endregion

        // Присваивание переменной image значение image_trip по входному параметру id:
        #region
        public string Image_Check(byte id)
        {
            var Post_Check = AD.Employees.Where(u => u.emp_id == id).Select(u => u.image_trip);
            foreach (var item in Post_Check) image = item.ToString();

            return image;
        }
        #endregion

        // Изменение логина и пароля
        public void Log_Pass_Changed(byte id, string log_in, string pass_word)
        {
            var emp_log_pass = AD.Employees.Where(u => u.emp_id == id).Single();
            emp_log_pass.login = log_in;
            emp_log_pass.password = pass_word;

            AD.SaveChanges();
        }

        // Логин для вызова рекламы:
        #region
        public string Log_Reklama(int id)
        {
            var Log_In = AD.Employees.Where(u => u.emp_id == id).Select(u => u.login);
            foreach (var item in Log_In) log = item;

            return log;
        }
        #endregion

        // Метод для проверки логина, сгенерированного случайным образом
        #region
        public int CheckRandomMethod(string textRandom)
        {
            return AD.Employees.Where(u => u.login == textRandom).Where(u => u.login == "").Count();
        }
        #endregion

        // Метод для отображения имени в меню
        #region
        public string Profil_Label(int id)
        {
            var PrL = AD.Employees.Where(u => u.emp_id == id).Single();
            return PrL.emp_name;
        }
        #endregion

        // Число сотрудников для статистики --> комбобокс
        #region
        public int EmpCount()
        {
            return AD.Employees.Where(u => u.post_id == 2).Count();
        }
        #endregion

        // Добавление, Изменение и Удаление сотрудника
        #region
                 // Добавление сотрудника
        public void Insert_employees(byte PostId, string surname, string name, 
            string lastname, byte Percent, string Date_Hire, string Log_In,
            string PassWord, DataGridView DGV)
        {
            Employees emp = new Employees();
            emp.post_id = PostId;
            emp.emp_surname = surname;
            emp.emp_name = name;
            emp.emp_lastname = lastname;
            emp.emp_percent = Percent;
            emp.date_hire = DateTime.Parse(Date_Hire);
            emp.login = Log_In;
            emp.password = PassWord;

            AD.Employees.Add(emp);
            AD.SaveChanges();
            Update_DGV(DGV);

        }

                 // Изменение данных о сотруднике
        public void Update_employees(string Log_In, string surname, string name, string lastname, 
            byte PerCent, string Date_Hire, DataGridView DGV)
        {
            var Emp_Var = AD.Employees.Where(u => u.login == Log_In).Single();
            Emp_Var.emp_surname = surname;
            Emp_Var.emp_name = name;
            Emp_Var.emp_lastname = lastname;
            Emp_Var.emp_percent = PerCent;
            Emp_Var.date_hire = DateTime.Parse(Date_Hire);

            AD.SaveChanges();
            Update_DGV(DGV);
        }

                 // Удаление сотрудника
        public void Delete_employee(string Log_In, DataGridView DGV)
        {
            var Emp_delete = AD.Employees.Where(u => u.login == Log_In).Single();
            AD.Employees.Remove(Emp_delete);
            AD.SaveChanges();
            Update_DGV(DGV);
        }
        #endregion
    }
}
