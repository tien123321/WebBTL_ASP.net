<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="BTL_Final.aspx.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../styles/SignInSignUp.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
          <div class="container">

        <div class="login">
            <h2>Đăng Nhập</h2>
            <input type="text" placeholder="Tên Đăng Nhập" id="login_account" class="login_account" name="login_account"/>
            <input type="password" placeholder="Nhập mật khẩu" id="login_password" class="login_password" name="login_password"/>
            
            <p class="login_password" id="login_noti" runat="server"></p>
            <asp:Button runat="server" id="btnDangnhap" CssClass="Button"  Text="Đăng nhập"  OnClick="clickSignIn" />

            <p class="test_login" id="test_login" runat="server"></p>
            <div style="text-align:center">
                <p class="forgot_form"><a href="ForGot.aspx" id="forgot_form">Quên mật khẩu</a></p>
                <p class="signup_form">Chưa có tài khoản? <a href="SignUp.aspx" id="switch_to_register">Đăng ký</a></p>
                <div style="padding-top: 12px;">
                    <a style="text-decoration:none; color:red; font-size:14px;" href="HomePage.aspx">Quay về Trang Chủ!</a>
                </div>
            </div>
        </div>
        </div>
        </div>
            
    </form>
    <script>
        var loginNoti = document.getElementById("login_noti")
        var inputPassword = document.getElementById("login_password")
        var btnDangnhap = document.getElementsByClassName("Button")[0]
        console.log(btnDangnhap)
        inputPassword.addEventListener("input", () => {
            let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$/;
            //              chữ thường   chữ hoa    số        kí tự         kết hợp  độ dài 5->?
            let valid = regex.test(inputPassword.value);
            if (valid) {
                loginNoti.innerHTML = ""
                console.log("hehe")
            } else {
                loginNoti.innerHTML = "Mật khẩu không hợp lệ (A-Z)(a-z)(0-9)(7 kt->)(!@#$%^&*())"

            }
        })

        btnDangnhap.addEventListener("click", (e) => {
            if (loginNoti.innerHTML !== "") {
                e.preventDefault()
                e.stopPropagation()
                document.getElementById("test_login").innerHTML = "Hãy nhập đúng kiểu dữ liệu"
            } else {

            }
        })
    </script>
</body>
</html>
