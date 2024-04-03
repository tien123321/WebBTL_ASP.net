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
    public partial class SearchPage : System.Web.UI.Page
    {
        ArrayList arrMusicFrame;
        ArrayList arrayLikeMusic;
        User user;
        string searchText;
        string searchTextLowerCase;
        protected void Page_Load(object sender, EventArgs e)
        {
            arrMusicFrame = Application["LMF"] as ArrayList;
            searchText = Session["Search"] as string;
            searchTextLowerCase = searchText.ToLower();
            user = (User)Session["User"];
            arrayLikeMusic = (ArrayList)Application["LikeMusic"];

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

                
            //--------------------------
            if (searchText != null)
            {
                LoadNameSong();
                LoadNameAuthor();
                LoadNameCountry();
            }
            else
            {
                list_music.InnerText = "Thang dep trai";
            }
            }
        }

        public void LoadNameSong()
        {
            ArrayList arrMusicResult = new ArrayList();
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            string innerHTML = "";

            foreach (MusicFrame musicFrame in arrMusicFrame)
            {
                string nameMusicToLowerCase = musicFrame.nameMusic.ToLower();
                if (nameMusicToLowerCase.Contains(searchTextLowerCase.Trim()))
                {
                    arrMusicResult.Add(musicFrame);
                }

                /*string nameAuthorToLowerCase = musicFrame.nameAuthor.ToLower();
                if (nameAuthorToLowerCase.Contains(searchTextLowerCase.Trim()))
                {
                    arrMusicResult.Add(musicFrame);
                }*/
            }



            //xoa trung
            for (int i = 0; i < arrMusicResult.Count; i++)
            {
                MusicFrame currentObject = (MusicFrame)arrMusicResult[i];

                for (int j = i + 1; j < arrMusicResult.Count; j++)
                {
                    MusicFrame nextObject = (MusicFrame)arrMusicResult[j];

                    if (currentObject.nameMusic == nextObject.nameMusic)
                    {
                        arrMusicResult.RemoveAt(i);
                        i--; // Giảm chỉ số j để kiểm tra phần tử mới tại vị trí j
                    }
                }
            }

            //hien thi bai hat ra client
            if(arrMusicResult.Count == 0)
            {
                txtNotiMusic.InnerHtml = "Không có Bài Hát tương ứng!";
            }
            else
            {
                foreach (MusicFrame musicFrame in arrMusicResult)
                {

                    //Set lại giá trị isConnet (trạng thái thích hay chưa)
                    string isConnect = "0";
                    foreach (LikeMusic likeMusic in arrayLikeMusic)
                    {
                        if (likeMusic.account == user.nameAccount && likeMusic.nameSong == musicFrame.nameMusic && likeMusic.status == "1")
                        {
                            isConnect = "1";
                        }
                    }

                    string htmlContent = string.Format(@"
                        <a href=""PlayMusic.aspx?id={3}"" class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white"">
                             <div class=""music-banner"">
                                   <div class=""music-logo"">
                                       <img src=""{0}"" alt=""{1}"" class=""music-logo-img"">
                                   </div>
                                   <div class=""music-desc"">
                                        <h1 class=""music-name"" >{1}</h1>
                                        <p class=""music-author"">{2}</p>
                                   </div>

                                    <div style=""display:none"" class=""item heart-frame"">
                                        <i title=""like"" class=""ti-heart""></i>
                                    </div>
                                    <p style=""display:none;"" class=""isConnect"">{4}</p>

                             </div>    
                     </a>
                    ", "../assest/img/" + musicFrame.imgSrc, musicFrame.nameMusic, musicFrame.nameAuthor, musicFrame.idMusic, isConnect);
                    innerHTML = innerHTML + htmlContent;
                }

                txtNotiMusic.InnerHtml = "Bài Hát Tìm Kiếm :";
                parentDiv.InnerHtml = innerHTML;
                Session["PlayMusic"] = arrMusicResult;
            }
        }

        public void LoadNameAuthor()
        {

            ArrayList arrMusicResult = new ArrayList();
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music_author");
            string innerHTML = "";

            foreach (MusicFrame musicFrame in arrMusicFrame)
            {
                string musicFrameToLowerCase = musicFrame.nameAuthor.ToLower();
                if (musicFrameToLowerCase.Contains(searchTextLowerCase.Trim()))
                {
                    arrMusicResult.Add(musicFrame);
                }
            }


            //xoa trung

            List<MusicFrame> uniqueList = new List<MusicFrame>();

            for (int i = 0; i < arrMusicResult.Count; i++)
            {
                MusicFrame currentObject = (MusicFrame)arrMusicResult[i];
                bool isDuplicate = false;

                for (int j = 0; j < uniqueList.Count; j++)
                {
                    MusicFrame uniqueObject = uniqueList[j];
                    if (currentObject.nameAuthor == uniqueObject.nameAuthor)
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

            arrMusicResult.Clear();
            arrMusicResult.AddRange(uniqueList);

            //hien thi bai hat ra client
            if(arrMusicResult.Count == 0)
            {
                txtNotiAuthor.InnerHtml = "Không có Tác Giả tương ứng!";

            }
            else
            {
                foreach (MusicFrame musicFrame in arrMusicResult)
                {
                    string htmlContent = string.Format(@"
                        <a href=""PlayMusic.aspx?name={1}"" class=""author-frame"" style=""text-decoration: none;color:white"">
                             <div class=""author-banner"">
                                   <div class=""author-logo"">
                                       <img src=""{0}"" alt=""{1}"" class=""author-logo-img"">
                                   </div>
                                   <h1 class=""author-name"">{1}</h1>
                             </div>    
                     </a>
                    ", "../assest/img/author/" + musicFrame.imgAuthorSrc, musicFrame.nameAuthor);
                    innerHTML = innerHTML + htmlContent;
                }
                txtNotiAuthor.InnerHtml = "Các Tác Giả :";
                parentDiv.InnerHtml = innerHTML;
            }
        }

        public void LoadNameCountry()
        {
            ArrayList arrMusicResult = new ArrayList();
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music_country");
            string innerHTML = "";

            foreach (MusicFrame musicFrame in arrMusicFrame)
            {
                string countryToLowerCase = musicFrame.country.ToLower();
                txtNotiCountry.InnerHtml = "Không có bài hát tương ứng! ";

                if (countryToLowerCase.Contains(searchTextLowerCase.Trim()))
                {
                    arrMusicResult.Add(musicFrame);
                }
            }



            //xoa trung
            for (int i = 0; i < arrMusicResult.Count; i++)
            {
                MusicFrame currentObject = (MusicFrame)arrMusicResult[i];

                for (int j = i + 1; j < arrMusicResult.Count; j++)
                {
                    MusicFrame nextObject = (MusicFrame)arrMusicResult[j];

                    if (currentObject.nameMusic == nextObject.nameMusic)
                    {
                        arrMusicResult.RemoveAt(i);
                        i--; // Giảm chỉ số j để kiểm tra phần tử mới tại vị trí j
                    }
                }
            }

            //hien thi bai hat ra client
            if (arrMusicResult.Count == 0)
            {
            }
            else
            {
                foreach (MusicFrame musicFrame in arrMusicResult)
                {

                    //Set lại giá trị isConnet (trạng thái thích hay chưa)
                    string isConnect = "0";
                    foreach (LikeMusic likeMusic in arrayLikeMusic)
                    {
                        if (likeMusic.account == user.nameAccount && likeMusic.nameSong == musicFrame.nameMusic && likeMusic.status == "1")
                        {
                            isConnect = "1";
                        }
                    }

                    string htmlContent = string.Format(@"
                        <a href=""PlayMusic.aspx?id={3}"" class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white"">
                             <div class=""music-banner"">
                                   <div class=""music-logo"">
                                       <img src=""{0}"" alt=""{1}"" class=""music-logo-img"">
                                   </div>
                                   <div class=""music-desc"">
                                        <h1 class=""music-name"" >{1}</h1>
                                        <p class=""music-author"">{2}</p>
                                   </div>

                                    <div style=""display:none"" class=""item heart-frame"">
                                        <i title=""like"" class=""ti-heart""></i>
                                    </div>
                                    <p style=""display:none;"" class=""isConnect"">{4}</p>

                             </div>    
                     </a>
                    ", "../assest/img/" + musicFrame.imgSrc, musicFrame.nameMusic, musicFrame.nameAuthor, musicFrame.idMusic, isConnect);
                    innerHTML = innerHTML + htmlContent;
                }

                txtNotiCountry.InnerHtml = "Bài Hát Tìm Kiếm Theo Nước :";
                parentDiv.InnerHtml = innerHTML;
                Session["PlayMusic"] = arrMusicResult;
            }
        }

        //nut like dislike
        protected void btnClickNameLikeSong(object sender, EventArgs e)
        {
            string nameLikeSong = Request.Form.Get("inpNameLikeSong");
            foreach (LikeMusic likeMusic in arrayLikeMusic)
            {
                if (nameLikeSong == likeMusic.nameSong && user.nameAccount == likeMusic.account)
                {
                    if (likeMusic.status == "1")
                    {
                        likeMusic.status = "0";
                    }
                    else
                    {
                        likeMusic.status = "1";
                    }
                }
            }
            Application["LikeMusic"] = arrayLikeMusic;
            Response.Redirect("SearchPage.aspx");
        }

        //tim kiem
        protected void SearchInfor(object sender, EventArgs e)
        {
            string inputSearch = Request.Form.Get("inputSearch");
            Session["Search"] = inputSearch;
            Response.Redirect("SearchPage.aspx");
        }


        //dang nhap dang ky
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
    }
}