using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Active_Record;

public class iRadioDeiService : IiRadioDeiService
{
    public void getMusics(string data)
    {
        //guardar na base de dados
        int i = 0;
        string[] data1 = data.Split('|');
        string musics = data1[0];
        string years = data1[1];
        string[] musicsName = musics.Split(';');
        string[] musicsYears = years.Split(';');

        foreach (string music in musicsName)
        {
            string musicAux = music.Replace("@", "&");
            musicsName[i] = musicAux;
            int year = Convert.ToInt32(musicsYears[i]);
            Active_Record.Music.InsertMusic(musicsName[i], year);
            i++;
        }
    }
}