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
    public partial class LikePage : System.Web.UI.Page
    {
        public User user;
        ArrayList arrLikeSong;
        ArrayList arrMusicFrame;
        ArrayList arrayLikePlayMusic;
        protected void Page_Load(object sender, EventArgs e)
        {
            arrLikeSong = Application["LikeMusic"] as ArrayList;
            arrMusicFrame = Application["LMF"] as ArrayList;
            user = (User)Session["User"];
            arrayLikePlayMusic = new ArrayList();
            loadForm();
        }

        public void loadForm()
        {
            //Hiện Người Dùng
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

            //Khai báo
            //Xóa Trùng
            List <LikeMusic> uniqueList = new List<LikeMusic>();

            for(int i=0; i<arrLikeSong.Count; i++)
            {
                LikeMusic currentObject = (LikeMusic)arrLikeSong[i];
                bool isDuplicate = false;

                for(int j=0; j<uniqueList.Count; j++)
                {
                    LikeMusic uniqueObject = uniqueList[j];
                    if (currentObject.account == uniqueObject.account && currentObject.nameSong == uniqueObject.nameSong)
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if(!isDuplicate)
                {
                    uniqueList.Add(currentObject);
                }
            }

            arrLikeSong.Clear();
            arrLikeSong.AddRange(uniqueList);

            Application["LikeMusic"] = arrLikeSong;

            HtmlGenericControl parentDiv = (HtmlGenericControl)FindControl("list_music");
            string innerHTML = "";
            
            foreach(LikeMusic likeMusic in arrLikeSong)
            {
                if (likeMusic.status == "1" && user.nameAccount == likeMusic.account) {
                    string urlImg = "";
                    string id = "";
                    string nameAuthor = "";
                    foreach(MusicFrame musicFrame in arrMusicFrame)
                    {
                        if(likeMusic.nameSong == musicFrame.nameMusic)
                        {
                            arrayLikePlayMusic.Add(musicFrame);
                            urlImg = musicFrame.imgSrc;
                            id = musicFrame.idMusic.ToString();
                            nameAuthor = musicFrame.nameAuthor;
                            break;
                        }
                    }

                    string conentHTML = string.Format(@"
                        <a href=""PlayMusic.aspx?id={3}"" class=""music-frame"" id=""{3}"" style=""text-decoration: none;color:white"">
                            <div class=""music-banner"">
                                <div class=""music-logo"">
                                    <img src=""{0}"" alt=""Thằng điên"" class=""music-logo-img"">
                                </div>
                                <div class=""music-desc"">
                                    <h1 class=""music-name"">{1}</h1>
                                    <p class=""music-author"">{2}</p>
                                </div>
                                
                                <div class=""item heart-frame"">
                                    <i title=""like"" class=""ti-heart"" style=""color: green""></i>
                                </div>
                            </div>
                        </a>
                    ", "../assest/img/" + urlImg, likeMusic.nameSong, nameAuthor, id);

                    innerHTML += conentHTML;
                }
            }

            parentDiv.InnerHtml = innerHTML;
            Session["PlayMusic"] = arrayLikePlayMusic;
        }

        protected void clickDislike(object sender, EventArgs e)
        {
            string nameDislikeSong = Request.Form.Get("nameDislikeSong");
            foreach(LikeMusic likeMusic in arrLikeSong)
            {
                if (nameDislikeSong == likeMusic.nameSong && user.nameAccount == likeMusic.account)
                {
                    likeMusic.status = "0";
                }
            }

            Application["LikeMusic"] = arrLikeSong;
            Response.Redirect("LikePage.aspx");
        }


        //Dang Nhap Dang Ky
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