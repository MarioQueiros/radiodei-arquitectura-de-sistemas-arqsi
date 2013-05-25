using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Active_Record
{
    public class Playlist : ActiveRecord
    {
        private string _name;
        private string _location;

        public Playlist()
        {
        }

        public Playlist(int id, string name, string location)
        {
            this.myID = id;
            this._name = name;
            this._location = location;
        }

        protected Playlist(DataRow row)
        {
            this.myID = (int)row["id_playlist"];
            this._name = (string)row["name"];
            this._location = (string)row["location"];
        }

        public string getName { get { return _name; } }
        public string getLocation { get { return _location; } }

        public Playlist LoadByIdMP(int id)
        {
            DataSet ds = ExecuteQuery("Select * from [ARQSI36].[dbo].[MP_playlist] where id_playlist=" + id);
            if (ds.Tables[0].Rows.Count != 1)
            {
                return null;
            }
            else
            {
                return new Playlist(ds.Tables[0].Rows[0]);
            }
        }

        public int getIdByNameMP(string name)
        {
            DataSet ds = ExecuteQuery("Select id_playlist from [ARQSI36].[dbo].[MP_playlist] where name=" + name);
            if (ds.Tables[0].Rows.Count != 1)
            {
                return -1;
            }
            else
            {
                string n = ds.Tables[0].Rows[0].ToString();
                int numVal = Convert.ToInt32(n);
                return numVal;
            }
        }

        public DataSet LoadAllMP()
        {
            DataSet ds = ExecuteQuery("select * from [ARQSI36].[dbo].[MP_playlist]");
            return ds;
        }


        public DataSet LoadByLocationMP(string location)
        {
            DataSet ds = ExecuteQuery("select * from [ARQSI36].[dbo].[MP_playlist] where location='" + location + "'");
            return ds;
        }

        public int RegisterMP(string name, string location)
        {
            DataSet ds = ExecuteQuery("Insert into [ARQSI36].[dbo].[MP_playlist] (name, location) values ('" + name + "', '" + location + "')SELECT id_playlist AS LastID FROM [ARQSI36].[dbo].[MP_playlist] WHERE id_playlist = @@Identity");
            int id = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                id = (int)dr["LastID"];
            }
            return id;
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
