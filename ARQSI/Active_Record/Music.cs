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
        private DateTime _launch_year;
        private int _id_album;

        public Music()
        {
        }

        public Music(int id, string name, DateTime date, int id_alb)
        {
            this.myID = id;
            this._name = name;
            this._launch_year = date;
            this._id_album = id_alb;
        }

        protected Music(DataRow row)
        {
            this.myID = (int)row["id_music"];
            this._name = (string)row["name"];
            this._launch_year = (DateTime)row["launch_year"];
            this._id_album = (int)row["id_album"];
        }

        public string getName { get { return _name; } }
        public DateTime getLaunchYear { get { return _launch_year; } }
        public int getIdAlbum { get { return _id_album; } }

        public static Music LoadById(int id)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select * from music where id_music=" + id);
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return null;
                }
                else
                {
                    return new Music(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static DataSet LoadAll()
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_music,name,launch_year from music where state=1");

                return ds;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static DataTable LoadMusics()
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_music,name,launch_year from music where state=1");


                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Launch Year", typeof(int));

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DataRow dtr = dt.NewRow();
                    dtr["ID"] = (int)r["id_music"];
                    dtr["Name"] = (string)r["name"];
                    dtr["Launch Year"] = (int)r["launch_year"];
                    dt.Rows.Add(dtr);
                }
                return dt;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static int DeleteMusic(int id)
        {
            try
            {
                int q = ExecuteNonQuery("update music set state=0 where id_music=" + id);
                if (q == -1)
                {
                    return q;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -1;
            }
        }

        public static int UpdateMusicInfo(int id, string name, string year)
        {
            try
            {
                int q = ExecuteNonQuery("update music set name='" + name + "', launch_year='" + year + "' where id_music=" + id);
                if (q == -1)
                {
                    return q;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -1;
            }
        }

        public static int InsertMusic(string name, int year)
        {
            try
            {
                int q = ExecuteNonQuery("insert into music (name, launch_year, state) values ('" + name + "', " + year + ", 1)");
                if (q == -1)
                {
                    return q;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -1;
            }
        }

        public static int GetIdMusicByName(string name)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select id_music from music where name='" + name + "'");

                int id = -1;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    id = (int)dr["id_music"];
                }
                return id;
            }

            catch (Exception e)
            {
                string s = e.ToString();
                return -1;
            }
        }
        public override void Save()
        {
            //throw new NotImplementedException();
        }
    }
}