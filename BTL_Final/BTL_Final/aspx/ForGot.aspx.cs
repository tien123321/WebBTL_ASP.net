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
    public partial class ForGot : System.Web.UI.Page
    {
        ArrayList arrUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            arrUser = (ArrayList)Application["Users"];

        }

        protected void btnForGot(object sender, EventArgs e)
        {
            arrUser = (ArrayList)Application["Users"];

            int kt = 0;
            if (IsPostBack)
            {
                foreach (User user in arrUser)
                {
                    if (user.email == Request.Form.Get("forgot_email") &&
                        user.nameAccount == Request.Form.Get("forgot_account") &&
                        user.nameUser == Request.Form.Get("forgot_name"))
                    {
                        kt = 1;
                        arrUser.Remove(user);
                        break;
                    }
                }

                if (kt == 1)
                {
                    User newUser = new User(
                    Request.Form.Get("forgot_email"),
                    Request.Form.Get("forgot_account"),
                    Request.Form.Get("forgot_name"),
                    Request.Form.Get("forgot_password"));
                    arrUser.Add(newUser);
                    Application["Users"] = arrUser;
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    kt = 0;
                    test_forgot.InnerHtml = "Đổi mật khẩu không thành công vui lòng kiểm tra lại";
                }
            }
        }
    }
}