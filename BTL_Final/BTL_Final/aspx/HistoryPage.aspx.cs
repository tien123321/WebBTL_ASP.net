using BTL_Final.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_Final.aspx
{
    public partial class HistoryPage : System.Web.UI.Page
    {

        public User x;
        User user;
        ArrayList arrHistory;
        ArrayList arrPlayMusic;
        ArrayList arrMusicFrame;
        protected void Page_Load(object sender, EventArgs e)
        {
            arrHistory = Application["History"] as ArrayList;
            user = Session["User"] as User;
            if (!IsPostBack)
            {
                load();
            }

        }
        public void load()
        {
            if (user.nameUser == null)
                {
                    
                }
                else
                {
                    btnSignUp.Text = user.nameUser;
                    btnSignIn.Text = "Đăng xuất";

                }


            
            arrMusicFrame = Application["LMF"] as ArrayList;
            arrPlayMusic = new ArrayList();


            //xoa trung
            for (int i = 0; i < arrHistory.Count; i++)
            {
                HistoryMusic currentObject = (HistoryMusic)arrHistory[i];

                for (int j = i + 1; j < arrHistory.Count; j++)
                {
                    HistoryMusic nextObject = (HistoryMusic)arrHistory[j];

                    if (currentObject.song == nextObject.song && currentObject.account == nextObject.account)
                    {
                        arrHistory.RemoveAt(i);
                        i--; // Giảm chỉ số j để kiểm tra phần tử mới tại vị trí j
                    }
                }
            }

            arrHistory = SortHistoryList(arrHistory);

            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            string innerHTML = "";

            foreach(HistoryMusic history in arrHistory)
            {
                if(user.nameAccount == history.account)
                {
                    string url = "";
                    string id = "";

                    foreach (MusicFrame music in arrMusicFrame)
                    {
                        if (history.song == music.nameMusic)
                        {
                            arrPlayMusic.Add(music);
                            url = music.imgSrc;
                            id = music.idMusic.ToString();
                            break;
                        }
                    }

                    DateTime now = DateTime.Now;
                    TimeSpan time = now.TimeOfDay;
                    string x = history.time;
                    string[] timecut = x.Split(':');
                    int gio, phut, giay, ngay, thang, nam;

                    gio = int.Parse(timecut[0]);
                    phut = int.Parse(timecut[1]);
                    giay = int.Parse(timecut[2]);

                    ngay = int.Parse(timecut[3]);
                    thang = int.Parse(timecut[4]);
                    nam = int.Parse(timecut[5]);
                    TimeSpan time1 = new TimeSpan(gio, phut, giay);
                    TimeSpan timehistory = time - time1;

                    string timeFrame = GetTimeFrame(timehistory);
                    string htmlContent = string.Format(@"
                    <div class=""div-flex"">
                        <a href=""PlayMusic.aspx?id={3}"" class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white"">
                            <div class=""music-banner"">
                                <div class=""music-logo"">
                                    <img src=""{0}"" alt=""Thằng điên"" class=""music-logo-img"">
                                </div>
                                <div class=""music-desc"">
                                    <h1 class=""music-name"">{1}</h1>
                                    <p class=""music-author"">{2}</p>
                                </div>
                                <div class=""music-coundown-time"">
                                    <p>{4}</p>
                                </div>
                            </div>
                        </a>

                        <div style=""display:none"" class=""check"">
                            <input type=""checkbox"" name=""checked"" value=""{1}"" />
                         </div>
                    </div>
                     ", "../assest/img/" + url, history.song, history.author, id, timeFrame);

                    innerHTML += htmlContent;
                }
            }

            parentDiv.InnerHtml = innerHTML;
            Session["PlayMusic"] = arrPlayMusic;
        }

        protected void DeleteSong(object sender, EventArgs e)
        {

            foreach (string key in Request.Form.AllKeys)
            {
                if (key.Contains("checked")) // Kiểm tra nếu key chứa tên của input
                {
                 
                    string values = Request.Form.Get(key);
                    if (values != null)
                    {
                        string[] songCut = values.Split(',');
                        for(int i = 0;i< songCut.Length; i++)
                        {
                            for(int j=0; j<arrHistory.Count; j++)
                            {
                                HistoryMusic historyMusic = (HistoryMusic)arrHistory[j];
                                if (songCut[i].Equals(historyMusic.song))
                                {
                                    arrHistory.Remove(historyMusic);
                                }
                            }
                        }
                        
                    }
                }
            }
            load();
        }
        //Sap xep lai bai hat
        private ArrayList SortHistoryList(ArrayList arrH)
        {
            List<HistoryMusic> sortedList = arrH.Cast<HistoryMusic>().ToList();

            sortedList.Sort((x, y) =>
            {
                string[] timecutx = x.time.Split(':');
                string[] timecuty = y.time.Split(':');

                int gioX = int.Parse(timecutx[0]);
                int phutX = int.Parse(timecutx[1]);
                int giayX = int.Parse(timecutx[2]);
                int ngayX = int.Parse(timecutx[3]);
                int thangX = int.Parse(timecutx[4]);
                int namX = int.Parse(timecutx[5]);

                int gioY = int.Parse(timecuty[0]);
                int phutY = int.Parse(timecuty[1]);
                int giayY = int.Parse(timecuty[2]);
                int ngayY = int.Parse(timecuty[3]);
                int thangY = int.Parse(timecuty[4]);
                int namY = int.Parse(timecuty[5]);

                DateTime datetimeX = new DateTime(namX, thangX, ngayX, gioX, phutX, giayX);
                DateTime datetimeY = new DateTime(namY, thangY, ngayY, gioY, phutY, giayY);

                return datetimeY.CompareTo(datetimeX);
            });

            return new ArrayList(sortedList);
        }

        private string GetTimeFrame(TimeSpan time)
        {
            if (time.TotalHours < 1)
            {
                if (time.TotalMinutes < 1)
                {
                    return $"{time.Seconds} giây trước";
                }
                else
                {
                    int minutes = (int)time.TotalMinutes + 1;
                    return $"{minutes} phút trước";
                }
            }
            else if (time.TotalHours > 24)
            {
                int hours = (int)time.TotalHours + 1;
                return $"{hours} giờ trước";
            }
            else
            {
                return $"{time.Hours}:{time.Minutes}:{time.Seconds}<br>{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
            }
        }



        protected void signUp(object sender, EventArgs e)
        {
            if (btnSignUp.Text == "Đăng Ký")
            {
                Response.Redirect("SignInSignUp.aspx?name=DangKy");
            }
        }

        protected void signIn(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Đăng Nhập")
            {
                Response.Redirect("SignInSignUp.aspx");
            }
            else
            {
                //dang xuat
                Session["User"] = new User();
                Response.Redirect("HomePage.aspx");

            }
        }

        //tim kiem
        protected void SearchInfor(object sender, EventArgs e)
        {
            string inputSearch = Request.Form.Get("inputSearch");
            Session["Search"] = inputSearch;
            Response.Redirect("SearchPage.aspx");
        }
    }
}