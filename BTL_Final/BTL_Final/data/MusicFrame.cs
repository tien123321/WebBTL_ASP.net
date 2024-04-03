using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Final.data
{
    public class MusicFrame
    {
        public static int idUpTo = 0;

        public MusicFrame()
        {
        }

        public MusicFrame(string nameMusic, string nameAuthor, TimeSpan time, string country, int groupSong, string imgSrc, string audioSrc, string imgAuthorSrc)
        {
            idMusic = idUpTo++;
            this.nameMusic = nameMusic;
            this.nameAuthor = nameAuthor;
            this.time = time;
            this.country = country;
            this.groupSong = groupSong;
            this.imgSrc = imgSrc;
            this.audioSrc = audioSrc;
            this.imgAuthorSrc = imgAuthorSrc;
        }

        public int idMusic { get; set; }
        public string nameMusic { get; set; }
        public string nameAuthor { get; set; }
        public TimeSpan time { get; set; }
        public string country { get; set; }
        public int groupSong { get; set; }
        public string imgSrc { get; set; }
        public string audioSrc { get; set; }
        public string imgAuthorSrc { get; set; }
    }
}