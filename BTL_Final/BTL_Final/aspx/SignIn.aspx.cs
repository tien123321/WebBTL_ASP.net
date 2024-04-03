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
    public partial class SignIn : System.Web.UI.Page
    {
        ArrayList arrUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            arrUser = (ArrayList)Application["Users"];
        }

        protected void clickSignIn(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                foreach(User user in arrUser)
                {
                    if(user.nameAccount == Request.Form.Get("login_account") && user.password == Request.Form.Get("login_password"))
                    {
                        test_login.InnerHtml = "";
                        Session["User"] = user;
                        Response.Redirect("HomePage.aspx");
                        break;
                    }
                    else
                    {
                        test_login.InnerHtml = "Tài Khoản Hoặc Mật Khẩu Không Chính Xác";
                    }
                }
            }
        }
    }
}