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
    public class V_Own_Stat_Class
    {
        public string FIO_Login { get; set; }
        public string cl_surname { get; set; }
        public string cl_name { get; set; }
        public string cl_passport { get; set; }
        public string ad_name { get; set; }
        public Nullable<decimal> Income { get; set; }
        public Nullable<System.TimeSpan> ad_time { get; set; }
        public byte ad_id { get; set; }

        AdvertisingEntities AD = new AdvertisingEntities();

        public void Update_DGV(string fio_log ,DataGridView DGV)
        {
            DGV.AutoGenerateColumns = false;
            var spisok = AD.V_StatisticsFIO.Where(s => s.FIO_Login == fio_log).ToList<V_StatisticsFIO>();
            foreach (var item in spisok)
            {
                item.Income = decimal.Parse(item.Income.ToString().Remove(item.Income.ToString().Length - 2, 2));
            }
            DGV.DataSource = spisok;
        }

        // Обновление dataGridViewClients
        #region
        public void Update_DGV(DataGridView DGV_V_StatisticsFIO)
        {
            DGV_V_StatisticsFIO.AutoGenerateColumns = false;
            var spisok = AD.V_StatisticsFIO.ToList<V_StatisticsFIO>();
            foreach (var item in spisok)
            {
                item.Income = decimal.Parse(item.Income.ToString().Remove(item.Income.ToString().Length - 2, 2));
            }
            DGV_V_StatisticsFIO.DataSource = spisok;
        }
        #endregion

        // СУММА
        public string SumIncome(string FIO, DataGridView DGV_V_StatisticsFIO)
        {
            DGV_V_StatisticsFIO.AutoGenerateColumns = false;
            var spisok = AD.V_StatisticsFIO.Where(N => N.FIO_Login == FIO).Select(N => N).ToList();
            foreach (var item in spisok)
            {
                item.Income = decimal.Parse(item.Income.ToString().Remove(item.Income.ToString().Length - 2, 2));
            }
            DGV_V_StatisticsFIO.DataSource = spisok;
            decimal? sum=AD.V_StatisticsFIO.Where(N => N.FIO_Login == FIO).Sum(N => N.Income);
            if (sum.ToString().Contains(",")) return sum.ToString().Remove(sum.ToString().Length - 2, 2);
            else return sum.ToString();
        }
  
    }
}
