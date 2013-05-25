using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARQSI2
{
    public partial class CreatePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    List<string> list = Active_Record.Playlist.GetMusicFromOpenPlaylist(Active_Record.Playlist.CheckOpenPlaylist(User.Identity.Name));

                    foreach (string s in list)
                    {
                        ListBox1.Items.Add(s);
                    }
                    if (ListBox1.Items.Count == 0)
                        if (Session["playlist_music"] != null)
                            foreach (string s in ((List<string>)Session["playlist_music"]))
                            {
                                ListBox1.Items.Add(s);
                            }
                }
                else
                {
                    if (ListBox1.Items.Count == 0)
                    {
                        if (Session["playlist_music"] != null)
                        {
                            List<string> l = Active_Record.Playlist.GetMusicFromOpenPlaylist(Active_Record.Playlist.CheckOpenPlaylist(User.Identity.Name));
                            foreach (string s in l)
                            {
                                ListBox1.Items.Add(s);
                            }
                            if (ListBox1.Items.Count == 0)
                                if (Session["playlist_music"] != null)
                                    foreach (string s in ((List<string>)Session["playlist_music"]))
                                    {
                                        ListBox1.Items.Add(s);
                                    }
                        }

                    }
                }


                gdvMusicas.DataSource = Active_Record.Music.LoadMusics();
                gdvMusicas.DataBind();

                gdvMusicas.Columns[1].Visible = false;

                Label6.Text = ListBox1.Items.Count.ToString() + " of 12 maximum musics.";
                if (ListBox1.Items.Count == 0)
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
                else
                {
                    Button1.Enabled = true;
                    Button2.Enabled = true;
                }
            }
        }

        protected void gdvMusicas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count > 11)
            {
                Label5.Text = "Limit of musics reached.";
                Label5.Visible = true;
            }
            else
            {
                DataSet ds = Active_Record.Music.LoadAll();

                int currentPage = gdvMusicas.PageIndex;
                int pos = currentPage * 10;

                DataRow dr = ds.Tables[0].Rows[gdvMusicas.SelectedIndex + pos];
                int index = (int)dr["id_music"];

                Button1.Enabled = true;
                Button2.Enabled = true;
                Label6.Visible = true;

                ListItem lt = ListBox1.Items.FindByValue((string)dr["name"]);

                try
                {
                    string aux = lt.Text;
                    Label5.Text = "Already exists '" + (string)dr["name"] + "' in the List";
                    Label5.Visible = true;
                }
                catch
                {
                    List<string> list = (List<string>)Session["playlist_music"];
                    if (list == null)
                    {
                        list = new List<string>();
                    }
                    list.Add((string)dr["name"]);
                    Session["playlist_music"] = list;

                    ListBox1.Items.Add((string)dr["name"]);
                    Label5.Text = "";

                    Label6.Text = ListBox1.Items.Count.ToString() + " of 12 maximum musics.";
                }
            }
        }

        protected void gdvMusicas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gdvMusicas.PageIndex = e.NewPageIndex;
            bindGridView();
        }

        public void bindGridView()
        {
            DataTable ds = Active_Record.Music.LoadMusics();

            gdvMusicas.DataSource = ds;
            gdvMusicas.DataBind();
            Label5.Text = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label5.Visible = false;
            if (ListBox1.SelectedIndex != -1)
            {
                List<string> l = (List<string>)Session["playlist_music"];
                l.Remove(ListBox1.SelectedValue);
                Session["playlist_music"] = l;

                ListBox1.Items.Remove(ListBox1.SelectedItem);

                Label6.Text = ListBox1.Items.Count.ToString() + " of 12 maximum musics.";

                if (ListBox1.Items.Count == 0)
                {
                    Button1.Enabled = false;
                    Button2.Enabled = false;
                }
                else
                {
                    Button1.Enabled = true;
                    Button2.Enabled = true;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label8.Text = "";
            int g = Active_Record.Playlist.CheckPlaylistByUsername(User.Identity.Name);
            if (g == -99)
            {
                Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                Label5.Visible = true;
            }
            else if (g == -1)
            {
                Label5.Text = "You already have a playlist created this week.";
                Label5.Visible = true;
            }
            else
            {
                if (TextBox1.Text.Trim() == "")
                {
                    Label5.Text = "Insert the playlist name.";
                    Label5.Visible = true;
                }
                else
                {
                    Label5.Text = "";
                    Label5.Visible = true;

                    int idpl = Active_Record.Playlist.CheckOpenPlaylist(User.Identity.Name);
                    if (idpl == -99)
                    {
                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                        Label5.Visible = true;
                    }
                    else
                    {
                        if (idpl != -1)
                        {
                            List<string> list = (List<string>)Session["playlist_music"];
                            int q = -99, id_music = -99;
                            int f = -99;
                            foreach (ListItem aux in ListBox1.Items)
                            {
                                id_music = Active_Record.Music.GetIdMusicByName(aux.ToString());
                                if (id_music == -99)
                                {
                                    Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                    Label5.Visible = true;
                                }
                                else
                                {
                                    f = Active_Record.Playlist.DeleteMusicFromPlaylist(id_music, idpl);
                                    if (f == -99)
                                    {
                                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                        Label5.Visible = true;
                                    }
                                }
                            }

                            if (f == -99)
                            {
                                Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                Label5.Visible = true;
                            }
                            else
                            {
                                foreach (ListItem s in ListBox1.Items)
                                {
                                    id_music = Active_Record.Music.GetIdMusicByName(s.ToString());
                                    if (id_music == -99)
                                    {
                                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                        Label5.Visible = true;
                                    }
                                    else
                                    {
                                        q = Active_Record.Playlist.SavePlaylistMusic(id_music, idpl);
                                        if (q == -99)
                                        {
                                            Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                            Label5.Visible = true;
                                        }
                                        else
                                        {
                                        }
                                    }
                                }
                                if (q == -99 || id_music == -99)
                                {
                                    Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                    Label5.Visible = true;
                                }
                                else
                                {

                                    Session["playlist_music"] = null;
                                    int q1 = Active_Record.Playlist.ChangePlaylistState(idpl);
                                    if (q1 == -99)
                                    {
                                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                        Label5.Visible = true;
                                    }
                                    else
                                    {

                                        int q2 = Active_Record.Playlist.UpdatePlaylistName(TextBox1.Text, idpl);
                                        if (q2 == -99)
                                        {
                                            Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                            Label5.Visible = true;
                                        }
                                        else
                                        {
                                            int f1 = Active_Record.Playlist.insertVote(idpl);
                                            if (f1 == -99)
                                            {
                                                Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                                Label5.Visible = true;
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    MailMessage mail = new MailMessage();
                                                    mail.To.Add(Active_Record.Users.getUserEmail(User.Identity.Name));
                                                    mail.From = new MailAddress("iradio@dei.pt", "iRadioDei");
                                                    mail.Subject = "Playlist confirm publication";
                                                    mail.Body = "You had inserted a new playlist to vote.\n\nThose are the music that you selected:\n";
                                                    foreach (ListItem li in ListBox1.Items)
                                                    {
                                                        mail.Body += "   - " + li.Text;
                                                    }
                                                    mail.Body += "\n\nThank you for create a playlist.\n\niRadioDEI";

                                                    SmtpClient mSmtpClient = new SmtpClient();
                                                    mSmtpClient.Send(mail);
                                                }
                                                catch (Exception ex)
                                                {
                                                    ex.ToString();

                                                }

                                                string[] mus = new string[ListBox1.Items.Count];
                                                int i = 0;
                                                foreach (ListItem lt in ListBox1.Items)
                                                {
                                                    mus[i] = lt.Text;
                                                    i++;
                                                }


                                                MusicPreferences_ServiceReference.MusicPreferences_ServiceClient proxy = new MusicPreferences_ServiceReference.MusicPreferences_ServiceClient();
                                                string location = Active_Record.Users.GetLocationByUsername(User.Identity.Name);
                                                if (location != null)
                                                {
                                                    proxy.getDadosiRadioDei(TextBox1.Text, mus, location);
                                                }

                                                Session["playlist_music"] = null;
                                                ListBox1.Items.Clear();
                                                TextBox1.Text = "";
                                                Label8.Text = "Playlist inserted successfully.";
                                                Label8.Visible = true;
                                                Label6.Text = ListBox1.Items.Count.ToString() + " of 12 maximum musics.";
                                                Label5.Visible = false;
                                                Label5.Text = "";

                                                Button1.Enabled = false;
                                                Button2.Enabled = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Active_Record.Playlist.CreatePlaylist(TextBox1.Text, User.Identity.Name, DateTime.Today);
                            int id_pl = Active_Record.Playlist.CheckOpenPlaylist(User.Identity.Name);
                            if (id_pl == -99)
                            {

                                Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                Label5.Visible = true;
                            }
                            else
                            {
                                List<string> list = (List<string>)Session["playlist_music"];
                                int id_music = -99, q = -99;
                                foreach (string s in list)
                                {
                                    id_music = Active_Record.Music.GetIdMusicByName(s);
                                    if (id_music == -99)
                                    {
                                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                        Label5.Visible = true;
                                    }
                                    else
                                    {
                                        q = Active_Record.Playlist.SavePlaylistMusic(id_music, id_pl);
                                        if (q == -99)
                                        {
                                            Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                            Label5.Visible = true;
                                        }
                                    }
                                }
                                if (q == -99 || id_music == -99)
                                {
                                    Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                    Label5.Visible = true;
                                }
                                else
                                {
                                    int q1 = Active_Record.Playlist.ChangePlaylistState(id_pl);
                                    if (q1 == -99)
                                    {
                                        Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                        Label5.Visible = true;
                                    }
                                    else
                                    {
                                        int f1 = Active_Record.Playlist.insertVote(id_pl);
                                        if (f1 == -99)
                                        {
                                            Label5.Text = "An error occurred while inserting the playlist. Try again later.";
                                            Label5.Visible = true;
                                        }
                                        else
                                        {
                                            try
                                            {
                                                MailMessage mail = new MailMessage();
                                                mail.To.Add(Active_Record.Users.getUserEmail(User.Identity.Name));
                                                mail.From = new MailAddress("iradio@dei.pt", "iRadioDei");
                                                mail.Subject = "Playlist confirm publication";
                                                mail.Body = "You had inserted a new playlist to vote.\n\nThose are the music that you selected:\n";
                                                foreach (ListItem li in ListBox1.Items)
                                                {
                                                    mail.Body += "   - " + li.Text;
                                                }
                                                mail.Body += "\n\nThank you for create a playlist.\n\niRadioDEI";

                                                SmtpClient mSmtpClient = new SmtpClient();
                                                mSmtpClient.Send(mail);
                                            }
                                            catch (Exception ex)
                                            {
                                                ex.ToString();

                                            }
                                            string[] mus = new string[ListBox1.Items.Count];
                                            int i = 0;
                                            foreach (ListItem lt in ListBox1.Items)
                                            {
                                                mus[i] = lt.Text;
                                                i++;
                                            }


                                            MusicPreferences_ServiceReference.MusicPreferences_ServiceClient proxy = new MusicPreferences_ServiceReference.MusicPreferences_ServiceClient();
                                            string location = Active_Record.Users.GetLocationByUsername(User.Identity.Name);
                                            if (location != null)
                                            {
                                                proxy.getDadosiRadioDei(TextBox1.Text, mus, location);
                                            }

                                            Session["playlist_music"] = null;
                                            ListBox1.Items.Clear();
                                            TextBox1.Text = "";
                                            Label8.Text = "Playlist inserted successfully.";
                                            Label8.Visible = true;
                                            Label6.Text = ListBox1.Items.Count.ToString() + " of 12 maximum musics.";
                                            Label5.Visible = false;
                                            Label5.Text = "";

                                            Button1.Enabled = false;
                                            Button2.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
