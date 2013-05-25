using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace Active_Record
{
    public class Music : ActiveRecord
    {
        private string _name;
        private int _id_playlist;

        public Music()
        {
        }

        public Music(int id, string name, int id_playlist)
        {
            this.myID = id;
            this._name = name;
            this._id_playlist = id_playlist;

        }

        protected Music(DataRow row)
        {
            this.myID = (int)row["id_music"];
            this._name = (string)row["name"];
            this._id_playlist = (int)row["id_playlist"];
        }

        public string getName { get { return _name; } }
        public int getId_playlist { get { return _id_playlist; } }

        public Music LoadById(int id)
        {
            DataSet ds = ExecuteQuery("Select * from [ARQSI36].[dbo].[MP_music] where id_music=" + id);
            if (ds.Tables[0].Rows.Count != 1)
            {
                return null;
            }
            else
            {
                return new Music(ds.Tables[0].Rows[0]);
            }
        }

        public DataSet LoadById_playlist(int id)
        {
            DataSet ds = ExecuteQuery("Select * from [ARQSI36].[dbo].[MP_music] where id_playlist=" + id);
            return ds;
        }

        public DataSet LoadAll()
        {
            DataSet ds = ExecuteQuery("select * from [ARQSI36].[dbo].[MP_music]");
            return ds;
        }


        public int Register(string name, int id_playlist)
        {
            int q = ExecuteNonQuery("Insert into [ARQSI36].[dbo].[MP_music] (name, id_playlist) values ('" + name + "', '" + id_playlist + "')");
            if (q == -1)
            {
                return q;
            }
            else
            {
                return 1;
            }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}

