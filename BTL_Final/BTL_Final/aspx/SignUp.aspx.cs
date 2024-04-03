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
    public partial class SignUp : System.Web.UI.Page
    {
        ArrayList arrUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            arrUser = (ArrayList)Application["Users"];
        }

        protected void clickSignUp(object sender, EventArgs e)
        {
            int kt = 0;
            if (IsPostBack)
            {
                foreach (User user in arrUser)
                {
                    if (user.email == Request.Form.Get("register_email"))
                    {
                        kt = 1;
                        test_register.InnerHtml = "Email đã tồn tai vui lòng chọn email khác";
                    }
                    if (user.nameAccount == Request.Form.Get("register_account"))
                    {
                        kt = 1;
                        test_register.InnerHtml = "Tài khoản đã tồn tại vui lòng đăng ký lại";

                    }
                }
                if (kt == 0)
                {
                    User newUser = new User(
                    Request.Form.Get("register_email"),
                    Request.Form.Get("register_account"),
                    Request.Form.Get("register_name"),
                    Request.Form.Get("register_password"));

                    arrUser.Add(newUser);
                    Session["User"] = newUser;
                    Response.Redirect("HomePage.aspx");
                }
            }
        }
    }
}