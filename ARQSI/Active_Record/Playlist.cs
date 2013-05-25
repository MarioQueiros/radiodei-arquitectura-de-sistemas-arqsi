using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Globalization;

namespace Active_Record
{
    public class Playlist : ActiveRecord
    {
        private string _name;
        private DateTime _pl_date;
        private int _id_user;

        public Playlist()
        {
        }

        public Playlist(int id, string name, DateTime date, int id_user)
        {
            this.myID = id;
            this._name = name;
            this._pl_date = date;
            this._id_user = id_user;
        }

        protected Playlist(DataRow row)
        {
            this.myID = (int)row["id_playlist"];
            this._name = (string)row["name"];
            this._pl_date = (DateTime)row["pl_date"];
            this._id_user = (int)row["id_user"];
        }

        public string getName { get { return _name; } }
        public DateTime getPlDate { get { return _pl_date; } }
        public int getIdUser { get { return _id_user; } }

        public static DataSet LoadAll()
        {
            try
            {
                DataSet ds = ExecuteQuery("select * from playlist");

                return ds;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static DataTable getTopPlaylist()
        {
            try
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(-6);
                var saturday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(-1);

                int day = monday.Day;
                int month = monday.Month;
                int year = monday.Year;

                int day2 = saturday.Day;
                int month2 = saturday.Month;
                int year2 = saturday.Year;
                DataSet ds = new DataSet();

                if (day > 12 && day2 > 12)
                {
                    ds = ExecuteQuery("select e.id_playlist, pl.name,e.n_votes from [ARQSI36].[dbo].[vote] e, [ARQSI36].[dbo].[playlist] pl where n_votes=(SELECT MAX(n_votes) FROM [ARQSI36].[dbo].[vote]) and e.id_playlist = pl.id_playlist and pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "'");
                }
                else if (day > 12)
                {
                    ds = ExecuteQuery("select e.id_playlist, pl.name,e.n_votes from [ARQSI36].[dbo].[vote] e, [ARQSI36].[dbo].[playlist] pl where n_votes=(SELECT MAX(n_votes) FROM [ARQSI36].[dbo].[vote]) and e.id_playlist = pl.id_playlist and pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "'");
                }
                else if (day2 > 12)
                {
                    ds = ExecuteQuery("select e.id_playlist, pl.name,e.n_votes from [ARQSI36].[dbo].[vote] e, [ARQSI36].[dbo].[playlist] pl where n_votes=(SELECT MAX(n_votes) FROM [ARQSI36].[dbo].[vote]) and e.id_playlist = pl.id_playlist and pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "'");
                }
                else
                {
                    ds = ExecuteQuery("select e.id_playlist, pl.name,e.n_votes from [ARQSI36].[dbo].[vote] e, [ARQSI36].[dbo].[playlist] pl where n_votes=(SELECT MAX(n_votes) FROM [ARQSI36].[dbo].[vote]) and e.id_playlist = pl.id_playlist and pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "'");
                }

                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Votes", typeof(int));

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DataRow dtr = dt.NewRow();
                    dtr["ID"] = (int)r["id_playlist"];
                    dtr["Name"] = (string)r["name"];
                    dtr["Votes"] = (int)r["n_votes"];
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

        public static DataTable getPlaystsForVotes(DateTime dt1)
        {
            try
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(1);
                var saturday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(6);

                int day = monday.Day;
                int month = monday.Month;
                int year = monday.Year;

                int day2 = saturday.Day;
                int month2 = saturday.Month;
                int year2 = saturday.Year;
                DataSet ds = new DataSet();

                if (day > 12 && day2 > 12)
                {
                    ds = ExecuteQuery("select pl.id_playlist, pl.name, n.n_votes from[ARQSI36].[dbo].[playlist] pl,[ARQSI36].[dbo].[vote] n where pl.state = 'closed' and n.id_playlist=pl.id_playlist and pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "'");
                }
                else if (day > 12)
                {
                    ds = ExecuteQuery("select pl.id_playlist, pl.name, n.n_votes from[ARQSI36].[dbo].[playlist] pl,[ARQSI36].[dbo].[vote] n where pl.state = 'closed' and n.id_playlist=pl.id_playlist and pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "'");
                }
                else if (day2 > 12)
                {
                    ds = ExecuteQuery("select pl.id_playlist, pl.name, n.n_votes from[ARQSI36].[dbo].[playlist] pl,[ARQSI36].[dbo].[vote] n where pl.state = 'closed' and n.id_playlist=pl.id_playlist and pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "'");
                }
                else
                {
                    ds = ExecuteQuery("select pl.id_playlist, pl.name, n.n_votes from[ARQSI36].[dbo].[playlist] pl,[ARQSI36].[dbo].[vote] n where pl.state = 'closed' and n.id_playlist=pl.id_playlist and pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "'");
                }

                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Votes", typeof(int));

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DataRow dtr = dt.NewRow();
                    dtr["ID"] = (int)r["id_playlist"];
                    dtr["Name"] = (string)r["name"];
                    dtr["Votes"] = (int)r["n_votes"];
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

        public static int verifyPlaylist(int id)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_vote from [ARQSI36].[dbo].[vote] where id_playlist=" + id);
                DataTable dt = new DataTable();
                dt.Columns.Add("id_vote", typeof(int));
                int index = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    index = (int)dr["id_vote"];
                }
                return index;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int DeletePlaylist(int id)
        {
            try
            {
                int q = ExecuteNonQuery("delete from vote where id_playlist=" + id);
                if (q == -1)
                {
                    return -1;
                }
                else
                {
                    int q1 = ExecuteNonQuery("delete from playlist_music where id_playlist=" + id);
                    if (q1 == -1)
                    {
                        return -1;
                    }
                    else
                    {
                        int q2 = ExecuteNonQuery("delete from playlist where id_playlist=" + id);
                        if (q2 == -1)
                        {
                            return -1;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int CheckPlaylistByUsername(string username)
        {
            try
            {
                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(1);
                var saturday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek).AddDays(6);

                int day = monday.Day;
                int month = monday.Month;
                int year = monday.Year;

                int day2 = saturday.Day;
                int month2 = saturday.Month;
                int year2 = saturday.Year;
                DataSet ds = new DataSet();

                if (day > 12 && day2 > 12)
                {
                    ds = ExecuteQuery("select id_playlist from [ARQSI36].[dbo].[playlist] where pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "' and id_user=(select id_user from [ARQSI36].[dbo].[users] where username='" + username + "') and state='closed'");
                }
                else if (day > 12)
                {
                    ds = ExecuteQuery("select id_playlist from [ARQSI36].[dbo].[playlist] where pl_date >= '" + month + "/" + day + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "' and id_user=(select id_user from [ARQSI36].[dbo].[users] where username='" + username + "') and state='closed'");
                }
                else if (day2 > 12)
                {
                    ds = ExecuteQuery("select id_playlist from [ARQSI36].[dbo].[playlist] where pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + month2 + "/" + day2 + "/" + year2 + "' and id_user=(select id_user from [ARQSI36].[dbo].[users] where username='" + username + "') and state='closed'");
                }
                else
                {
                    ds = ExecuteQuery("select id_playlist from [ARQSI36].[dbo].[playlist] where pl_date >= '" + day + "/" + month + "/" + year + "' and pl_date <= '" + day2 + "/" + month2 + "/" + year2 + "' and id_user=(select id_user from [ARQSI36].[dbo].[users] where username='" + username + "') and state='closed'");
                }

                if (ds.Tables[0].Rows.Count == 0)
                {
                    //pode guardar playlist
                    return 1;
                }
                else
                {
                    //nao pode guardar playlist
                    return -1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }



        public static int updateVote(int id_vot, int id_playlist)
        {
            try
            {
                DataSet ds = ExecuteQuery("select n_votes from [ARQSI36].[dbo].[vote] where id_vote=" + id_vot);
                DataTable dt = new DataTable();
                dt.Columns.Add("n_votes", typeof(int));
                int n = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    n = (int)dr["n_votes"];
                }
                n += 1;
                int q = ExecuteNonQuery("UPDATE [ARQSI36].[dbo].[vote] SET [n_votes] =" + n + " WHERE id_playlist=" + id_playlist + " and id_vote=" + id_vot);

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
                return -99;
            }
        }

        public static int insertVote(int id_playlist)
        {
            try
            {
                int q = ExecuteNonQuery("INSERT INTO [ARQSI36].[dbo].[vote]([id_playlist],[n_votes]) VALUES(" + id_playlist + " ,0)");
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
                return -99;
            }
        }


        public static DataTable LoadPlaylistByUsername(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_playlist, name, pl_date from playlist where id_user=(select id_user from users where username='" + username + "') and state='closed'");

                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Creation Date", typeof(DateTime));

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    DataRow dtr = dt.NewRow();
                    dtr["ID"] = (int)r["id_playlist"];
                    dtr["Name"] = (string)r["name"];
                    dtr["Creation Date"] = (DateTime)r["pl_date"];
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

        public static DataSet LoadPlaylistByUsername(string username, int x)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_playlist, name, pl_date from playlist where id_user=(select id_user from users where username='" + username + "') and state='closed'");
                return ds;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static DataTable LoadMusicByIdPlaylist(int id)
        {
            try
            {
                DataSet ds1 = ExecuteQuery("select id_music from playlist_music where id_playlist=" + id);

                DataTable dt = new DataTable();

                dt.Columns.Add("Name", typeof(string));
                /* dt.Columns.Add("Artist", typeof(string));
                 dt.Columns.Add("Album", typeof(DateTime));*/

                foreach (DataRow r1 in ds1.Tables[0].Rows)
                {
                    DataSet ds2 = ExecuteQuery("select name from music where id_music=" + (int)r1["id_music"]);

                    foreach (DataRow r2 in ds2.Tables[0].Rows)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Name"] = (string)r2["name"];
                        dt.Rows.Add(dtr);
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static int CheckOpenPlaylist(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_playlist from playlist where state='open' and id_user=(select id_user from users where username='" + username + "')");

                if (ds.Tables[0].Rows.Count == 0)
                {
                    return -1;
                }
                else
                {
                    int id = -1;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        id = (int)dr["id_playlist"];
                    }
                    return id;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int CreatePlaylist(string name, string username, DateTime dt)
        {
            try
            {
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    dt = dt.AddDays(-(int)dt.DayOfWeek).AddDays(1);
                }
                DataSet ds1 = ExecuteQuery("select id_user from [ARQSI36].[dbo].[users] where username='" + username + "'");
                int q = 0;
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    q = (int)dr["id_user"];
                }
                DataSet ds = ExecuteQuery("insert into [ARQSI36].[dbo].[playlist] (name, pl_date, id_user, state) values ('" + name + "','" + dt.ToString() + "'," + q + ", 'open')SELECT id_playlist AS LastID FROM [ARQSI36].[dbo].[playlist] WHERE id_playlist = @@Identity");
                q = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    q = (int)dr["LastID"];
                }
                return q;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int CreatePlaylist(string username, DateTime dt)
        {
            try
            {
                int q = ExecuteNonQuery("insert into [ARQSI36].[dbo].[playlist] (name, pl_date, id_user, state) values ('' ,'" + dt.ToString() + "',(select id_user from users where username='" + username + "'), 'open')");

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
                return -99;
            }
        }

        public static int UpdatePlaylistName(string name, int id_playlist)
        {
            try
            {
                int q = ExecuteNonQuery("update playlist set name='" + name + "' where id_playlist=" + id_playlist);
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
                return -99;
            }
        }

        public static int SavePlaylistMusic(int id_music, int id_playlist)
        {
            try
            {
                int q = ExecuteNonQuery("Insert into playlist_music (id_playlist, id_music) values (" + id_playlist + ", " + id_music + ")");
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
                return -99;
            }

        }

        public static int ChangePlaylistState(int id)
        {
            try
            {
                DateTime dt = DateTime.Today;
                if (dt.DayOfWeek == DayOfWeek.Sunday)
                {
                    dt = dt.AddDays(-(int)dt.DayOfWeek).AddDays(1);
                }

                int q = ExecuteNonQuery("update playlist set state='closed', pl_date='" + dt + "' where id_playlist=" + id);
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
                return -99;
            }
        }

        public static int DeleteMusicFromPlaylist(int id_music, int id_playlist)
        {
            try
            {
                int q = ExecuteNonQuery("Delete from playlist_music where id_music=" + id_music + " and id_playlist=" + id_playlist);
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
                return -99;
            }
        }

        public static List<string> GetMusicFromOpenPlaylist(int id_playlist)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_music from playlist_music where id_playlist=" + id_playlist);

                List<string> list = new List<string>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int id = (int)dr["id_music"];
                    DataSet ds1 = ExecuteQuery("select name from music where id_music=" + id);

                    foreach (DataRow dr1 in ds1.Tables[0].Rows)
                    {
                        list.Add((string)dr1["name"]);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }



        public override void Save()
        {
            //throw new NotImplementedException();
        }
    }
}