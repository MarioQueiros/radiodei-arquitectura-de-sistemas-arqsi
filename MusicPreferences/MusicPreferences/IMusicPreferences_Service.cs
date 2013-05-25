using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MusicPreferences
{
    [ServiceContract]
    public interface IMusicPreferences_Service
    {
        [OperationContract]
        void getDadosiRadioDei(string namePlaylist, string[] musicas, string location);

    }
}

