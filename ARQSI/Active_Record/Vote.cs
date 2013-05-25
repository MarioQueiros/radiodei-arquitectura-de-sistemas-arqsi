using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Web;

namespace Active_Record
{
    public class Vote : ActiveRecord
    {
        private int _id_playlist;
        private int _n_votes;
        private int _id_edition;

        public Vote()
        {
        }

        public Vote(int id, int idpl, int votes, int ide)
        {
            this.myID = id;
            this._id_playlist = idpl;
            this._n_votes = votes;
            this._id_edition = ide;
        }

        protected Vote(DataRow row)
        {
            this.myID = (int)row["id_vot"];
            this._id_playlist = (int)row["id_playlist"];
            this._n_votes = (int)row["n_votes"];
            this._id_edition = (int)row["id_edition"];
        }

        public int getIdPlaylist { get { return _id_playlist; } }
        public int getNVotes { get { return _n_votes; } }
        public int getIdEdition { get { return _id_edition; } }

        public override void Save()
        {
            //throw new NotImplementedException();
        }
    }
}