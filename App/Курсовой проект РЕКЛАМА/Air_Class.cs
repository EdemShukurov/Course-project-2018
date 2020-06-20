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
    public class Air_Class
    {
        public Air_Class()
        {
            this.Advertisements = new HashSet<Advertisements>();
        }
    
        public string broadcast { get; set; }
        public System.TimeSpan start_time { get; set; }
        public System.TimeSpan end_time { get; set; }
        public Nullable<decimal> price { get; set; }
    
        public virtual ICollection<Advertisements> Advertisements { get; set; }

        //
        AdvertisingEntities AD = new AdvertisingEntities();

        public void Update_DGV(DataGridView DGV)
        {
            DGV.AutoGenerateColumns = false;
            var spisok = AD.Air.ToList<Air>();
            foreach (var item in spisok)
            {
                if(item.price.ToString().Contains(","))
                item.price = decimal.Parse(item.price.ToString().Remove(item.price.ToString().Length - 2,2));
            }
            DGV.DataSource = spisok;
        }

        // ИЗМЕНЕНИЕ СТОИМОСТИ
        public void Update_Air(string BroadCast, string Price, DataGridView DGV_Air)
        {
            var Air_Var = AD.Air.Where(u => u.broadcast == BroadCast).Single();
                Air_Var.price = decimal.Parse(Price);

                AD.SaveChanges();
                Update_DGV(DGV_Air);
        }
    }
}
