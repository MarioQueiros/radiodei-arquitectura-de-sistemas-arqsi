using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Active_Record
{
    public class Edition : ActiveRecord
    {
        private DateTime _date_edition;


        public Edition()
        {
        }

        public Edition(int id, DateTime wdt)
        {
            this.myID = id;
            this._date_edition = wdt;
        }

        protected Edition(DataRow row)
        {
            this.myID = (int)row["id_edition"];
            this._date_edition = (DateTime)row["date_edition"];
        }

        public DateTime getWeekDate { get { return _date_edition; } }

        public static int SaveEdition(DateTime dt)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_edition from edition where date_edition='" + dt.ToString() + "'");
                if (ds.Tables[0].Rows.Count != 0)
                {
                    return -2;
                }
                else
                {
                    int q = ExecuteNonQuery("insert into edition (date_edition) values ('" + dt.ToString() + "')");
                    if (q == -1)
                    {
                        return q;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return -99;
            }
        }

        public override void Save()
        {
            //throw new NotImplementedException();
        }
    }
}