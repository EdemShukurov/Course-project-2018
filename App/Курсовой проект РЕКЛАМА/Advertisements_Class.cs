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
    public class Advertisements_Class
    {
        public string ad_name { get; set; }
        public string broadcast { get; set; }
        public Nullable<byte> cl_id { get; set; }
        public Nullable<byte> emp_id { get; set; }
        public Nullable<int> interval { get; set; }
        public System.TimeSpan ad_time { get; set; }
        public byte ad_id { get; set; }

        public virtual Air Air { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Employees Employees { get; set; }

        AdvertisingEntities AD = new AdvertisingEntities();

        // Обновление DGV общего
        public void Update_DGV(DataGridView DGV)
        {
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = AD.Advertisements.ToList<Advertisements>(); 
        }
        // Обновление DGV личного
        public void Update_DGV(DataGridView DGV, byte Emp_Code)
        {
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = AD.Advertisements.Where(u=>u.emp_id==Emp_Code).ToList<Advertisements>();
        }
         
        // ПРОВЕРКА НА НАЛИЧИИ РЕКЛАМЫ
        public int Check_Count(string reklama, TimeSpan time_program)
        {
            return AD.Advertisements.Where(u => u.ad_time == time_program).Where(u => u.ad_name == reklama).Count();
        }

        // МЕТОД ДЛЯ СОПОСТАВЛЕНИЯ КЛИЕНТОВ К ОПРЕДЕЛЕННОМУ СОТРУДНИКУ
        public byte[] Emp_Clients(byte emp_code)
        {
            var determine_emp=AD.Advertisements.Where(u=>u.emp_id==emp_code).Select(u=>u.cl_id);
            byte[] ArrayRows = new byte[determine_emp.Count()];
            int i = 0;
            foreach (var item in determine_emp)
            {
                ArrayRows[i] = byte.Parse(item.ToString());
                i++;
            }
            ArrayRows = ArrayRows.Distinct().ToArray();
            return ArrayRows;
        }

        //Добавление, удаление, изменение рекламы
        #region
        
            // Добавление новой рекламы 
        public void Insert_Adver(string fio_pass, string reklama, string peredacha, int sec, 
            TimeSpan time_program, DataGridView DGV, byte Emp_code)
        {
            string passport=fio_pass.Substring(fio_pass.Length-9, 9);
            var CL = AD.Clients.Where(c => c.cl_passport == passport).Single();
            
            Advertisements adv = new Advertisements();
            adv.emp_id = Emp_code;
            adv.cl_id = CL.cl_id;
            adv.FIO_Passport = fio_pass;
            adv.ad_name = reklama;
            adv.broadcast = peredacha;
            adv.interval = sec;
            adv.ad_time = time_program;

            AD.Advertisements.Add(adv);
            AD.SaveChanges();
            Update_DGV(DGV);
        }

            // Удаление рекламы      
        public void Delete_Adver(byte adv_code, string reklama, 
            TimeSpan time_programm, DataGridView DGV)
        {
           var Adv_delete = AD.Advertisements.Where(u => u.ad_id==adv_code).Single();
           AD.Advertisements.Remove(Adv_delete);
           AD.SaveChanges();
           Update_DGV(DGV);
        }

        // Изменение рекламы
        public void Update_Adver(byte adv_code,string fio_passport, string reklama, int sec, string peredacha,
            TimeSpan time_program, DataGridView DGV, byte Emp_code, TimeSpan old_reklama_time)
        {
            var adv = AD.Advertisements.Where(u => u.ad_id == adv_code).Single();
            byte? check_adv = AD.Advertisements.Where(u => u.ad_id != adv_code).Where(u => u.ad_name == reklama).
                Where(u => u.ad_time == time_program).Select(u => u.ad_id).FirstOrDefault();
            if (check_adv == 0)
            {
                adv.FIO_Passport = fio_passport;
                adv.ad_name = reklama;
                adv.interval = sec;
                adv.broadcast = peredacha;
                adv.ad_time = time_program;

                AD.SaveChanges();
                Update_DGV(DGV);
                Update_DGV(DGV, Emp_code);
                MessageBox.Show("Реклама изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else MessageBox.Show("Такая реклама уже имеется в базе! ", "Изменения отменены", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion
    }
}
