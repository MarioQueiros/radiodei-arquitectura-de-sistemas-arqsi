using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Active_Record
{
    public class Artist : ActiveRecord
    {
        private string _name;

        public Artist()
        {
        }

        public Artist(int id, string name)
        {
            this.myID = id;
            this._name = name;
        }

        protected Artist(DataRow row)
        {
            this.myID = (int)row["id_artist"];
            this._name = (string)row["name"];
        }

        public string getName { get { return _name; } }
        /*
        public Artist LoadById(int id)
        {
            DataSet ds = ExecuteQuery("Select * from artist where id_artist=" + id);
            if (ds.Tables[0].Rows.Count != 1)
            {
                return null;
            }
            else
            {
                return new Artist(ds.Tables[0].Rows[0]);
            }
        }
        */
        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
