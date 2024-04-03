using BTL_Final.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_Final.aspx
{
    public partial class PlayMusic : System.Web.UI.Page
    {
        protected string URLimg { get; set; }
        protected string URLaudio { get; set; }
        public ArrayList array;
        public ArrayList arrLikeMusic;
        public string id;
        public string nameAuthorSeachResult;

        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["User"];
            if (!IsPostBack)
            {
                if (user.nameUser == null)
                {

                }
                else
                {
                    btnSignUp.Text = user.nameUser;
                    btnSignIn.Text = "Đăng xuất";

                }
            }

            array = (ArrayList)Session["PlayMusic"];
            arrLikeMusic = (ArrayList)Application["LikeMusic"];
            if (string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                if (string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    // Thực hiện hành động mặc định nếu id không tồn tại
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    id = Request.QueryString["id"];
                    loadData();
                }

            }
            else
            {
                nameAuthorSeachResult = Request.QueryString["name"];
                loadDataAuthorSearchesult();
            }
        }

        protected void loadDataAuthorSearchesult()
        {
            string innerHTML = "";
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            ArrayList arrMusicFrameAuthorSearchResult = new ArrayList();
            MusicFrame musicFrameAuthorSearchResult = new MusicFrame();
            
            foreach (MusicFrame musicFrame in array)
            {
                
                if (musicFrame.nameAuthor == nameAuthorSeachResult)
                {
                    arrMusicFrameAuthorSearchResult.Add(musicFrame);
                    if(musicFrameAuthorSearchResult.nameAuthor == null)
                    {
                        musicFrameAuthorSearchResult = musicFrame;
                        nameSong.InnerText = musicFrame.nameMusic;
                        nameAuthor.InnerText = musicFrame.nameAuthor;
                        URLimg = "../assest/img/" + musicFrame.imgSrc;
                        urlImg.DataBind();
                        urlImgDrop.DataBind();
                        URLaudio = "../assest/audio/" + musicFrame.audioSrc;
                        urlAudio.DataBind();
                        musicCurtime.InnerText = "00:00";
                        musicSumtime.InnerText = musicFrame.time.ToString("mm':'ss");
                    }

                }
            }

            

            foreach (MusicFrame musicFrame in array)
            {
                if(musicFrame.nameAuthor == musicFrameAuthorSearchResult.nameAuthor) {
                
                    int quantity = 0;
                    int isConnect = 0;
                
                    //xoa trung
                    List<LikeMusic> uniqueList = new List<LikeMusic>();
                    for(int i=0; i<arrLikeMusic.Count; i++)
                    {
                        LikeMusic currentObject = (LikeMusic)arrLikeMusic[i];
                        bool isDuplicate = false;

                        for (int j = 0; j < uniqueList.Count; j++)
                        {
                            LikeMusic uniqueObject = uniqueList[j];

                            if (currentObject.account == uniqueObject.account && currentObject.nameSong == uniqueObject.nameSong)
                            {
                                isDuplicate = true;
                                break;
                            }
                        }

                        if (!isDuplicate)
                        {
                            uniqueList.Add(currentObject);
                        }
                    }

                    arrLikeMusic.Clear();
                    arrLikeMusic.AddRange(uniqueList);


                    foreach (LikeMusic likeMusic in arrLikeMusic)
                    {

                        if (likeMusic.nameSong == musicFrame.nameMusic && likeMusic.status == "1")
                        {
                            if (likeMusic.account == user.nameAccount)
                            {

                                isConnect = 1;
                            }
                            quantity++;
                        }
                    }

                    string htmlContent = string.Format(@"
                        <div class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white;"">
                    <div class=""music-banner"">
                          <div class=""music-logo"">
                              <img src=""{0}"" alt=""{1}"" class=""music-logo-img"">
                          </div>
                          <div class=""music-desc"">
                               <h1 class=""music-name"" >{1}</h1>
                               <p class=""music-author"">{2}</p>
                          </div>
                            <div class=""item heart-frame"">
                                <i title=""like"" class=""ti-heart""></i>
                            </div>
                    </div>    
                    <div style=""display: none; "" class=""div-none"">
                           <audio class=""audio-none"" src=""{4}""></audio>
                        <p class=""time-none"">{5}</p>
                        <p class=""countHeartFrame"">{6}</p>
                        <p class=""isConnect"">{7}</p>
                    </div>
                </div>
                    
                    ", "../assest/img/" + musicFrame.imgSrc, musicFrame.nameMusic, musicFrame.nameAuthor, musicFrame.idMusic, "../assest/audio/" + musicFrame.audioSrc, musicFrame.time.ToString("mm':'ss")
                    ,quantity,isConnect);
                     innerHTML = innerHTML + htmlContent;
                }
                parentDiv.InnerHtml = innerHTML;
            }

        }

        protected void btnSaveSongData(object sender, EventArgs e)
        {
            saveFavoriteSong();
            saveHistorySong();
        }

        public void saveFavoriteSong()
        {
            ArrayList arr = new ArrayList();
            if(btnSignUp.Text == "Đăng Ký")
            {

            }
            else
            {
                string inpLikeSong = Request.Form.Get("likeSong");
                string[] arrLikeSong = inpLikeSong.Split(',');
                List<string> nameLikeSong = new List<string>();
                List<string> statusLikeSong = new List<string>();

                for(int i=0; i<arrLikeSong.Length; i++) {
                    if (i % 2 == 0)
                    {
                        nameLikeSong.Add(arrLikeSong[i]);
                    }
                    else
                    {
                        statusLikeSong.Add(arrLikeSong[i]);
                    }
                }

                for(int i=0; i<statusLikeSong.Count; i++)
                {
                    int index = i;
                    for(int j = i; j < nameLikeSong.Count; j++)
                    {
                        if(j == index)
                        {
                            arr.Add(new LikeMusic(user.nameAccount, nameLikeSong[j], statusLikeSong[i] ));
                        }
                    }
                }

                //set gia tri arrLikeSong = arr (SET cái cũ bằng mới)
                foreach(LikeMusic oldSong in arrLikeMusic)
                {
                    foreach(LikeMusic newSong in arr)
                    {
                        if(oldSong.account == newSong.account && oldSong.nameSong == newSong.nameSong)
                        {
                            oldSong.status = newSong.status;
                        }
                    }
                }

                Application["LikeMusic"] = arrLikeMusic;
            }

        }
        public void saveHistorySong()
        {
            ArrayList arrayHistory = new ArrayList();
            ArrayList arrayFullMusicFrame = (ArrayList)Application["LMF"];

            arrayHistory = (ArrayList)Application["History"];
            if (btnSignUp.Text == "Đăng Ký")
            {

            }
            else
            {
                string inputNameSong = Request.Form.Get("arrNameSong");
                string inputTimeSong = Request.Form.Get("arrTimeSong");
                btnSignIn.Text = inputNameSong;
                string[] arrNameSong = inputNameSong.Split(',');
                string[] arrTimeSong = inputTimeSong.Split(',');

                for (int i = 0; i < arrNameSong.Length; i++)
                {
                    for (int j = 0; j < arrTimeSong.Length; j++)
                    {
                        if (i == j)
                        {
                            string s = "";
                            foreach (MusicFrame musicFrame in arrayFullMusicFrame)
                            {
                                if (musicFrame.nameMusic == arrNameSong[i])
                                {
                                    s = musicFrame.nameAuthor;
                                }
                            }
                            arrayHistory.Add(new HistoryMusic(user.nameAccount, arrNameSong[i], s, arrTimeSong[j]));
                        }
                    }
                }

                Application["History"] = arrayHistory;
            }
        }


        public void loadData()
        {
            string innerHTML = "";
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            foreach (MusicFrame x in array)
            {
                if (x.idMusic == int.Parse(id))
                {
                    nameSong.InnerText = x.nameMusic;
                    nameAuthor.InnerText = x.nameAuthor;
                    URLimg = "../assest/img/" + x.imgSrc;
                    urlImg.DataBind();
                    urlImgDrop.DataBind();
                    URLaudio = "../assest/audio/" + x.audioSrc;
                    urlAudio.DataBind();
                    musicCurtime.InnerText = "00:00";
                    musicSumtime.InnerText = x.time.ToString("mm':'ss");
                }
            }

            foreach (MusicFrame x in array)
            {
                int quantity = 0;
                int isConnect = 0;

                //xoa trung
                List<LikeMusic> uniqueList = new List<LikeMusic>();
                for (int i = 0; i < arrLikeMusic.Count; i++)
                {
                    LikeMusic currentObject = (LikeMusic)arrLikeMusic[i];
                    bool isDuplicate = false;

                    for (int j = 0; j < uniqueList.Count; j++)
                    {
                        LikeMusic uniqueObject = uniqueList[j];

                        if (currentObject.account == uniqueObject.account && currentObject.nameSong == uniqueObject.nameSong)
                        {
                            isDuplicate = true;
                            break;
                        }
                    }

                    if (!isDuplicate)
                    {
                        uniqueList.Add(currentObject);
                    }
                }

                arrLikeMusic.Clear();
                arrLikeMusic.AddRange(uniqueList);


                foreach (LikeMusic likeMusic in arrLikeMusic)
                {

                    if (likeMusic.nameSong == x.nameMusic && likeMusic.status == "1")
                    {
                        if (likeMusic.account == user.nameAccount)
                        {

                            isConnect = 1;
                        }
                        quantity++;
                    }
                }

                string htmlContent = string.Format(@"
                    <div class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white;"">
                <div class=""music-banner"">
                      <div class=""music-logo"">
                          <img src=""{0}"" alt=""{1}"" class=""music-logo-img"">
                      </div>
                      <div class=""music-desc"">
                           <h1 class=""music-name"" >{1}</h1>
                           <p class=""music-author"">{2}</p>
                      </div>
                        <div class=""item heart-frame"">
                            <i title=""like"" class=""ti-heart""></i>
                        </div>
                </div>    
                <div style=""display: none; "" class=""div-none"">
                       <audio class=""audio-none"" src=""{4}""></audio>
                    <p class=""time-none"">{5}</p>
                    <p class=""countHeartFrame"">{6}</p>
                    <p class=""isConnect"">{7}</p>
                </div>
            </div>
                    
                ", "../assest/img/" + x.imgSrc, x.nameMusic, x.nameAuthor, x.idMusic, "../assest/audio/" + x.audioSrc, x.time.ToString("mm':'ss")
                , quantity, isConnect);
                innerHTML = innerHTML + htmlContent;
            }
            parentDiv.InnerHtml = innerHTML;

        }

        //tim kiem
        protected void SearchInfor(object sender, EventArgs e)
        {
            string inputSearch = Request.Form.Get("inputSearch");
            Session["Search"] = inputSearch;
            saveFavoriteSong();
            saveHistorySong();
            Response.Redirect("SearchPage.aspx");
        }

        //dang nhap dang ky
        protected void signUp(object sender, EventArgs e)
        {
            if (btnSignUp.Text == "Đăng Ký")
            {
                saveFavoriteSong();
                saveHistorySong();
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
                saveFavoriteSong();
                saveHistorySong();
                Session["User"] = new User();
                Response.Redirect("HomePage.aspx");
            }
        }
    }
}