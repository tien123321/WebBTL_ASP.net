using BTL_Final.data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Final.aspx
{
    public partial class SignInSignUp : System.Web.UI.Page
    {
        ArrayList arrayList;

        protected void Page_Load(object sender, EventArgs e)
        {
            arrayList = (ArrayList)Application["Users"];
            //dem =Convert.ToInt32( Session["Dem"]);
        }

        protected void SignIn(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                    foreach (User user in arrayList)
                    {
                        if(user.nameAccount != Request.Form.Get("login_account"))
                        {
                            KTdangnhap.InnerHtml = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác";

                        }
                        else
                        {
                            if (user.password != Request.Form.Get("login_password"))
                            {
                                KTdangnhap.InnerHtml = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác";


                            }
                            else
                            {
                                    Session["User"] = user;
                                    KTdangnhap.InnerHtml = "";
                                    Response.Redirect("HomePage.aspx");
                                    break;
                            }
                        }    
                    }

            }
        }

        protected void SignUp(object sender, EventArgs e)
        {
            int kt = 0;
            if (IsPostBack)
            {
                foreach (User user in arrayList)
                {
                    if (user.email == Request.Form.Get("register_email"))
                    {
                        kt = 1;
                        KTDangky.InnerHtml = "Email đã tồn tai vui lòng chọn email khác";
                    }
                    if(user.nameAccount == Request.Form.Get("register_account"))
                    {
                        kt = 1;
                        KTDangky.InnerHtml = "Tài khoản đã tồn tại vui lòng đăng ký lại";

                    }
                }
                if(kt == 0)
                {
                    User newUser = new User(
                    Request.Form.Get("register_email"),
                    Request.Form.Get("register_account"),
                    Request.Form.Get("register_name"),
                    Request.Form.Get("register_password"));
                    arrayList.Add(newUser);
                    Session["User"] = newUser;
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void ForGot(object sender, EventArgs e)
        {
            arrayList = (ArrayList)Application["Users"];

            int kt = 0;
            if (IsPostBack)
            {
                foreach (User user in arrayList)
                {
                    if (user.email == Request.Form.Get("forgot_email") &&
                        user.nameAccount == Request.Form.Get("forgot_account") &&
                        user.nameUser == Request.Form.Get("forgot_name"))
                    {
                        kt = 1; 
                        arrayList.Remove(user);
                        break;
                    }
                }

                if (kt == 1) {
                    User newUser = new User(
                    Request.Form.Get("forgot_email"),
                    Request.Form.Get("forgot_account"),
                    Request.Form.Get("forgot_name"),
                    Request.Form.Get("forgot_password"));
                    arrayList.Add(newUser);
                    Application["Users"] = arrayList;
                }
                    else
                    {
                        kt = 0;
                        ktrdoimk.InnerHtml = "Đổi mật khẩu không thành công vui lòng kiểm tra lại";
                    }
            }
        }
    }
}