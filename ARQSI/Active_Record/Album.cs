using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Active_Record
{
    public class Album : ActiveRecord
    {
        private string _name;
        private int _id_artist;

        public Album()
        {
        }

        public Album(int id, string name, int id_art)
        {
            this.myID = id;
            this._name = name;
            this._id_artist = id_art;
        }

        protected Album(DataRow row)
        {
            this.myID = (int)row["id_album"];
            this._name = (string)row["name"];
            this._id_artist = (int)row["id_artist"];
        }

        public string getName { get { return _name; } }
        public int getIdArtist { get { return _id_artist; } }
        /*
        public Album LoadById(int id)
        {
            DataSet ds = ExecuteQuery("Select * from album where id_album=" + id);
            if (ds.Tables[0].Rows.Count != 1)
            {
                return null;
            }
            else
            {
                return new Album(ds.Tables[0].Rows[0]);
            }
        }
        */
        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
