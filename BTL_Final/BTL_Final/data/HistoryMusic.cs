using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Final.data
{
    public class HistoryMusic
    {
        public string account;
        public string song;
        public string author;
        public string time;
        public HistoryMusic()
        {
        }

        public HistoryMusic(string account, string song, string author, string time)
        {
            this.account = account;
            this.song = song;
            this.author = author;
            this.time = time;
        }

    }
}