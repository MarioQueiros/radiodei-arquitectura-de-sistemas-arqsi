using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Active_Record;

namespace MusicPreferences
{
    public class MusicPreferences_Service : IMusicPreferences_Service
    {
        public void getDadosiRadioDei(string namePlaylist, string[] musics, string location)
        {
            Playlist pl = new Playlist();
            int reg1 = pl.RegisterMP(namePlaylist, location);

            Music mus = new Music();

            for (int i = 0; i < musics.Length; i++)
            {
                int reg2 = mus.Register(musics[i], reg1);
            }
        }
    }
}