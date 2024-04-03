using BTL_Final.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_Final.aspx
{
    public partial class HomePage : System.Web.UI.Page
    {
        ArrayList array;
        ArrayList arrayPlayMusic;
        ArrayList arrayLikeMusic;
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            array = (ArrayList) Application["LMF"];
            user = (User) Session["User"];
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

                foreach(MusicFrame muicFrame in array)
                {
                    int ktr = 1;
                    foreach (LikeMusic likeMusic in arrayLikeMusic)
                    {
                        if (likeMusic.account == user.nameAccount && likeMusic.nameSong == muicFrame.nameMusic)
                        {
                            ktr = 0;
                        }
                    }
                    if (ktr == 1)
                    {
                        arrayLikeMusic.Add(new LikeMusic(user.nameAccount, muicFrame.nameMusic, "0"));
                    }
                }
                loadForm();
            }
        }

        protected void loadForm()
        {
            
            string country = "";
            if (string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                int dem = 0;
                HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
                string innerHTML = "";
                arrayPlayMusic = new ArrayList();
                foreach (MusicFrame musicFrame in array)
                {
                    //Set lại giá trị isConnet (trạng thái thích hay chưa)
                    string isConnect = "0";
                    foreach(LikeMusic likeMusic in arrayLikeMusic)
                    {
                        if (likeMusic.account == user.nameAccount && likeMusic.nameSong == musicFrame.nameMusic && likeMusic.status == "1")
                        {
                            isConnect = "1";
                        }
                    }

                    //Hiện bài hát lên trang chủ
                    arrayPlayMusic.Add(musicFrame);

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

                                    <div style=""display:none;"" class=""item heart-frame"">
                                        <i title=""like"" class=""ti-heart""></i>
                                    </div>
                                    <p style=""display:none;"" class=""isConnect"">{4}</p>
                             </div>    
                            </a>
                            ", "../assest/img/" + musicFrame.imgSrc, musicFrame.nameMusic, musicFrame.nameAuthor, musicFrame.idMusic, isConnect);
                        innerHTML = innerHTML + htmlContent;
                    dem++;
                }


                parentDiv.InnerHtml = innerHTML;
                Session["PlayMusic"] = arrayPlayMusic;
            }
            else
            {
                country = Request.QueryString["name"];
                loadMusicFrame(country);
            }
        }

        protected void loadMusicFrame(string country)
        {
            int dem = 0;
            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            string innerHTML = "";
            arrayPlayMusic = new ArrayList();
            foreach (MusicFrame musicFrame in array)
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

                if (musicFrame.country == country) { 
                    arrayPlayMusic.Add(musicFrame);
                    if (dem < 10)
                    {

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

                                    <div style=""display:none;""  class=""item heart-frame"">
                                        <i title=""like"" class=""ti-heart""></i>
                                    </div>

                                    <p style=""display:none;"" class=""isConnect"">{4}</p>

                             </div>    
                     </a>
                    ", "../assest/img/" + musicFrame.imgSrc, musicFrame.nameMusic, musicFrame.nameAuthor, musicFrame.idMusic , isConnect);
                        innerHTML = innerHTML + htmlContent;
                    }
                    dem++;
                }
            }
            parentDiv.InnerHtml = innerHTML;
            Session["PlayMusic"] = arrayPlayMusic;
        }


        //truyen gia tri ten bai hat yeu thich
        protected void btnClickNameLikeSong(object sender, EventArgs e)
        {
            string nameLikeSong = Request.Form.Get("inpNameLikeSong");
            foreach(LikeMusic likeMusic in arrayLikeMusic)
            {
                if(nameLikeSong == likeMusic.nameSong && user.nameAccount == likeMusic.account)
                {
                    if(likeMusic.status == "1")
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
            Response.Redirect("HomePage.aspx");
        }


        //tim kiem
        protected void SearchInfor(object sender, EventArgs e)
        {
           if(btnSignIn.Text == "Đăng Nhập")
            {
                Response.Redirect("SignIn.aspx");

            }
            else
            {
                string inputSearch = Request.Form.Get("inputSearch");
                Session["Search"] = inputSearch;
                Response.Redirect("SearchPage.aspx");
            }
        }

        //dang nhap dang ky
        protected void signUp(object sender, EventArgs e)
        {
            if(btnSignUp.Text == "Đăng Ký")
            {
                Response.Redirect("SignUp.aspx");
            }
            //chuyen sang list nguoi dung
            else
            {
                Response.Redirect("WebForm1.aspx");
            }
        }

        protected void signIn(object sender, EventArgs e)
        {
            if (btnSignIn.Text == "Đăng Nhập")
            {
                Response.Redirect("SignIn.aspx");
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