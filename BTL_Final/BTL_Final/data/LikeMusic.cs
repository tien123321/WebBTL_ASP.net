using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Final.data
{
    public class LikeMusic
    {
        public LikeMusic()
        {
        }

        public LikeMusic(string account, string nameSong, string status)
        {
            this.account = account;
            this.nameSong = nameSong;
            this.status = status;
        }

        public string status { get; set; }
        public string account { get; set; }
        public string nameSong { get; set; }
    }
}