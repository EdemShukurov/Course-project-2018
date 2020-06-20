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
    public class Clients_Class
    {
        public Clients_Class()
        {
            this.Advertisements = new HashSet<Advertisements>();
        }
    
        public byte cl_id { get; set; }
        public string cl_surname { get; set; }
        public string cl_name { get; set; }
        public string cl_lastname { get; set; }
        public string cl_passport { get; set; }
        public string cl_tel { get; set; }
        public string cl_bankcard { get; set; }
    
        public virtual ICollection<Advertisements> Advertisements { get; set; }

        AdvertisingEntities AD = new AdvertisingEntities();

        // Обновление DGV общего
        public void Update_DGV(DataGridView DGV)
        {
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = AD.Clients.ToList<Clients>();
        }

        // Обновление DGV личного
        public void Update_DGV(DataGridView DGV, byte code)
        {
            Advertisements_Class adv = new Advertisements_Class();
            byte[] ArrayEmp_Cl = adv.Emp_Clients(code);
            List<Clients> list = new List<Clients>();
            for (int i = 0; i < ArrayEmp_Cl.Length; i++)
            {
                byte k = ArrayEmp_Cl[i];
                var cl_list = AD.Clients.Where(c => c.cl_id == k).Single();
                list.Add(cl_list);
            }
            
            DGV.AutoGenerateColumns = false;
            DGV.DataSource = list;
        }

        // Кол-во клиентов
        public int Clients_Count()
        {
            return AD.Clients.Count();
        }

        public string ChangeFIO(byte code)
        {
            var List_Client = AD.Clients.Where(u => u.cl_id == code).Single();
            if (List_Client.cl_lastname.Length > 0) return List_Client.cl_surname + " " + List_Client.cl_name.Remove(1) + "." +
                   List_Client.cl_lastname.Remove(1) + ". " + List_Client.cl_passport;
            else return List_Client.cl_surname + " " + List_Client.cl_name.Remove(1) + 
                    ". " + List_Client.cl_passport;
        }

        // Метод для проверки пасспорта
        public byte Check_Passport(string passport)
        {
             return byte.Parse(AD.Clients.Where(c => c.cl_passport == passport).Count().ToString());         
        }

        // Метод для проверки банковской карточки
        public byte Check_BankCard(string bank_card, string passport, bool k)
        {
            if (k) return byte.Parse(AD.Clients.Where(c => c.cl_passport != passport).Where(c => c.cl_bankcard == bank_card).
                Count().ToString());
            else return byte.Parse(AD.Clients.Where(c => c.cl_bankcard == bank_card).Count().ToString());
        }

        // Метод для проверки телефона
        public byte Check_Phone(string phone, string passport, bool k)
        {
            if (k) return byte.Parse(AD.Clients.Where(c => c.cl_passport != passport).Where(c => c.cl_tel == phone).
                Count().ToString());
            else return byte.Parse(AD.Clients.Where(c => c.cl_tel == phone).Count().ToString());
        }

        // Добавление, удаление и изменение клиента
        #region

        // Добавление клиента
        public void Insert_clients(string surname, string name, string lastname, string passport, string bank_card,
            string tel, DataGridView DGV_Clients, byte Emp_code)
        {
               Clients cl = new Clients();
                cl.cl_surname = surname;
                cl.cl_name = name;
                cl.cl_lastname = lastname;
                cl.cl_passport = passport;
                cl.cl_tel = tel;
                cl.cl_bankcard = bank_card;

                AD.Clients.Add(cl);
                AD.SaveChanges();
                Update_DGV(DGV_Clients);
                Update_DGV(DGV_Clients, Emp_code);
        }
        
        // Изменение данных о клиенте
        public void Update_clients(string passport, string surname, string name, string lastname, string bank_card,
            string tel, DataGridView DGV_Clients, byte client_id)
        {
            var Cl_Var = AD.Clients.Where(c => c.cl_passport == passport).Single();
            int check = Check_BankCard(bank_card, passport, true);
            if (check == 0)
            {
                check=Check_Phone(tel, passport, true);
                if (check == 0)
                {
                    Cl_Var.cl_surname = surname;
                    Cl_Var.cl_name = name;
                    Cl_Var.cl_lastname = lastname;
                    Cl_Var.cl_passport = passport;
                    Cl_Var.cl_tel = tel;
                    Cl_Var.cl_bankcard = bank_card;

                    AD.SaveChanges();

                    Update_DGV(DGV_Clients);
                    Update_DGV(DGV_Clients, client_id);
                    MessageBox.Show("Данные измененны", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("Данный номер телефона уже занят", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Данный номер банковской карточки уже занят","",MessageBoxButtons.OK, MessageBoxIcon.Warning);     
        }
        

        // Удаление клиента
        public void Delete_clients(string passport, DataGridView DGV_Clients)
        {
                var Cl_delete = AD.Clients.Where(u => u.cl_passport == passport).Single();
                AD.Clients.Remove(Cl_delete);
                AD.SaveChanges();
                DGV_Clients.AutoGenerateColumns = false;
                DGV_Clients.DataSource = AD.Clients.ToList<Clients>();
        }
        #endregion
    }
}
