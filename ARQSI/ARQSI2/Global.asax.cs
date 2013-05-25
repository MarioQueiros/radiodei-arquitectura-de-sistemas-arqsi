using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Active_Record;

namespace ARQSI2
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            try
            {
                if (Request.IsAuthenticated)
                {
                    int idpl = Active_Record.Playlist.CheckOpenPlaylist(User.Identity.Name);
                    if (idpl == -1)
                    {
                        Session["playlist_music"] = null;
                        Session["username"] = User.Identity.Name;
                    }
                    else
                    {
                        List<string> l = Active_Record.Playlist.GetMusicFromOpenPlaylist(idpl);

                        if (l.Count == 0)
                        {
                            Session["playlist_music"] = null;
                            Session["username"] = User.Identity.Name;
                        }
                        else
                        {
                            Session["playlist_music"] = l;
                            Session["username"] = User.Identity.Name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }

        void Session_End(object sender, EventArgs e)
        {
            try
            {
                if ((List<string>)Session["playlist_music"] != null)
                {
                    List<string> list = (List<string>)Session["playlist_music"];
                    string aux = (string)Session["username"];
                    foreach (string s in list)
                    {
                        int id_music = Active_Record.Music.GetIdMusicByName(s);

                        int idpl = Active_Record.Playlist.CheckOpenPlaylist((string)Session["username"]);

                        if (idpl == -1)
                        {
                            Active_Record.Playlist.CreatePlaylist((string)Session["username"], DateTime.Today);
                            idpl = Active_Record.Playlist.CheckOpenPlaylist((string)Session["username"]);
                        }

                        int q = Active_Record.Playlist.SavePlaylistMusic(id_music, idpl);
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
    }
}
