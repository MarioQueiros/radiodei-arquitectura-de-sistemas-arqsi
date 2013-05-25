using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iRadioDei_WindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bindGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label8.Text = "";
            label4.Text = "";
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                label4.Text = listBox1.Items.Count.ToString() + " of 12 maximum musics.";
                if (listBox1.Items.Count == 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                label4.Text = "Select a music!";
            }
        }

        public void bindGridView()
        {
            try
            {
                Music m = new Music();
                DataTable table = m.LoadMusics();
                if (table.Rows.Count > 0)
                {
                    dataGridView1.DataSource = table;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    /*Auto Resize*/
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    label8.Text = "";
                }
                else
                {
                    label8.Text = "No data found!";
                }
            }
            catch (Exception ex)
            {
                this.button2.Enabled = false;
                this.button1.Enabled = false;
                this.button4.Enabled = false;
                label8.Text = "The Server it's down. Try again later!";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            if (dataGridView1.Rows.Count > 0)
            {
                if (listBox1.Items.Count > 11)
                {
                    label4.Text = "Limit of musics reached!";
                    label4.Visible = true;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    var cell = this.dataGridView1.SelectedCells[0];
                    var row = this.dataGridView1.Rows[cell.RowIndex];
                    string value = row.Cells[1].Value.ToString();

                    if (listBox1.Items.Contains(value))
                    {
                        label4.Text = "Already exists '" + value + "' in the List!";
                        label4.Visible = true;
                    }
                    else
                    {
                        listBox1.Items.Add(value);
                        label4.Text = listBox1.Items.Count.ToString() + " of 12 maximum musics.";
                        label4.Visible = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label4.Text = "";
            if (listBox1.Items.Count > 0)
            {
                button2.Enabled = true;
                if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
                {
                    label5.Text = "Insert the playlist name!";
                    label5.Visible = true;
                    label6.Text = "Insert the user name!";
                    label6.Visible = true;
                    label7.Text = "Insert the location of user!";
                    label7.Visible = true;
                }
                else if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
                {
                    label5.Text = "Insert the playlist name!";
                    label5.Visible = true;
                    label6.Text = "Insert the user name!";
                    label6.Visible = true;
                    label7.Visible = false;
                }
                else if (textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
                {
                    label6.Text = "Insert the user name!";
                    label6.Visible = true;
                    label7.Text = "Insert the location of user!";
                    label7.Visible = true;
                    label5.Visible = false;
                }
                else if (textBox1.Text.Trim() == "" && textBox3.Text.Trim() == "")
                {
                    label5.Text = "Insert the playlist name!";
                    label5.Visible = true;
                    label7.Text = "Insert the location of user!";
                    label7.Visible = true;
                    label6.Visible = false;
                }
                else if (textBox1.Text.Trim() == "")
                {
                    label5.Text = "Insert the playlist name!";
                    label5.Visible = true;
                    label7.Visible = false;
                    label6.Visible = false;

                }
                else if (textBox2.Text.Trim() == "")
                {
                    label6.Text = "Insert the user name!";
                    label6.Visible = true;
                    label7.Visible = false;
                    label5.Visible = false;
                }
                else if (textBox3.Text.Trim() == "")
                {
                    label7.Text = "Insert the location of user!";
                    label7.Visible = true;
                    label6.Visible = false;
                    label5.Visible = false;
                }
                else
                {
                    int g = iRadioDei_WindowsApp.Playlist.CheckPlaylistByUsername(textBox2.Text);
                    if (g == -99)
                    {
                        label8.Text = "An error occurred while inserting the playlist. Try again later!";
                        label8.Visible = true;
                    }
                    else if (g == -1)
                    {
                        label4.Text = "You already have a playlist created this week!";
                        label4.Visible = true;
                    }
                    else
                    {
                        label7.Visible = false;
                        label6.Visible = false;
                        label5.Visible = false;
                        Users usr = new Users();
                        string iduser = usr.checkUser(textBox2.Text, textBox3.Text);

                        iRadioDei_WindowsApp.pt.ipp.isep.dei.wvm036.MusicPreferences_Service proxy = new
                            iRadioDei_WindowsApp.pt.ipp.isep.dei.wvm036.MusicPreferences_Service();
                        string location = iRadioDei_WindowsApp.Users.GetLocationByUsername(textBox2.Text);

                        if (iduser != "")
                        {
                            Playlist pl = new Playlist();
                            int idpl = pl.CreatePlaylist(textBox1.Text, textBox2.Text);
                            if (idpl == -99)
                            {
                                label8.Text = "An error occurred while inserting the playlist. Try again later!";
                                label8.Visible = true;
                            }
                            else
                            {
                                Music m = new Music();
                                string[] mus = new string[listBox1.Items.Count];
                                for (int i = 0; i < listBox1.Items.Count; i++)
                                {
                                    mus[i] = listBox1.Items[i].ToString();
                                    int id_music = m.GetIdMusicByName(listBox1.Items[i].ToString());
                                    if (id_music == -99)
                                    {
                                        label8.Text = "An error occurred while inserting the playlist. Try again later!";
                                        label8.Visible = true;
                                    }
                                    else
                                    {
                                        int q = pl.SavePlaylistMusic(id_music, idpl);
                                        if (q == -99)
                                        {
                                            label8.Text = "An error occurred while inserting the playlist. Try again later!";
                                            label8.Visible = true;
                                        }
                                    }
                                }
                                int f1 = iRadioDei_WindowsApp.Playlist.insertVote(idpl);
                                if (f1 == -99)
                                {
                                    label8.Text = "An error occurred while inserting the playlist. Try again later.";
                                    label8.Visible = true;
                                }

                                if (location != null)
                                {
                                    proxy.getDadosiRadioDei(textBox1.Text, mus, location);
                                }

                                label8.Text = "Playlist created successfully!";
                                listBox1.Items.Clear();
                                textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                                label4.Text = "";
                            }
                        }
                        else
                        {
                            label8.Text = "Doesn't exist a user with this name and location!";
                        }
                    }
                }
            }
            else
            {
                label8.Text = "You need to add at least one music!";
            }
        }
    }
}