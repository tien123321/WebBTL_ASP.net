<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignInSignUp.aspx.cs" Inherits="BTL_Final.aspx.SignInSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../styles/SignInSignUp.css" rel="stylesheet" />
</head>
<body>
    <form runat="server" >
      <div class="main">
          <div class="container">
          <div class="logo">
              <img src="../../assest/img/logo.jpg" alt="Logo"/>
          </div>
          <div class="form_action" runat="server">
              <div class="login">
                  <h2>Đăng nhập</h2>
                  <input type="text" runat="server" placeholder="Tên đăng nhập" id="login_account" class="login_account" name="login_account">
                  <input type="password" placeholder="Nhập mật khẩu" id="login_password" class="login_password" name="login_password">
                  <p class="login_password" id="p1" runat="server"></p>
                  <asp:Button runat="server" id="btnDangnhap" CssClass="Button" class="btnSign" Text="Đăng nhập"  OnClick="SignIn" />

                  <p id="KTdangnhap" runat="server"></p>
                  <div style="text-align:center">
                      <p class="password_relay"><a href="#" id="passwords_relay">Quên mật khẩu</a></p>
                      <p class="form-info">Chưa có tài khoản? <a href="#" id="switch_to_register">Đăng ký</a></p>
                      <div style="padding-top: 12px;">

                      <a style="text-decoration:none; color:red; font-size:14px;" href="HomePage.aspx">Quay về Trang Chủ!</a>
                      </div>
                  </div>
              </div>
              <div class="register">
                  <h2>Đăng ký</h2>
                  <input type="text" placeholder="Tên người sử dụng" id="register_name" class="register_name" name="register_name">
                  <input type="text" placeholder="Tên đăng nhập" id="register_account" class="register_account" name="register_account">
                  <input type="email" placeholder="Email" id="register_email" class="register_email" name="register_email">
                  <input type="password" placeholder="Mật khẩu" id="register_password" class="register_password" name="register_password">
                  <p id="p_register_password" class="register_password"></p>
                  <asp:Button runat="server" id="btnDangky" CssClass="Button" class="btnSign" Text="Đăng ký" OnClick="SignUp" />
                  <p id="KTDangky" runat="server"></p>
                  <p class="form-info">Đã có tài khoản? <a href="#" id="switch_to_login">Đăng nhập</a></p>
              </div>
              <div class="forgot_Password">
                  <h2>Quên mật khẩu</h2>
                  <input type="email" placeholder="Email" id="forgot_email" class="forgot_email" name="forgot_email">
                  <input type="text" placeholder="Tên người sử dụng" id="forgot_name" class="forgot_name" name="forgot_name">
                  <input type="text" placeholder="Tên đăng nhập" id="forgot_account" class="forgot_account" name="forgot_account">
                  <input type="password" placeholder="Mật khẩu" id="forgot_password" class="forgot_password" name="forgot_password">
                  <p id="p_forgot_password" class="forgot_pass"></p>
                  <input type="password" placeholder="Mật khẩu" id="forgot_pass_relay" class="forgot_pass_relay" name="forgot_pass_relay">
                  <p id="p_forgot_password_relay" class="forgot_pass_relay"></p>
                  <asp:Button runat="server" id="btnDoimk" CssClass="Button" class="btnSign"  Text="Đổi mật khẩu" OnClick="ForGot" />
                  <p id="ktrdoimk" runat="server"></p>
                  <p class="form-info">Quay lại đăng nhập? <a href="#" id="switchlogin">Đăng nhập</a></p>
              </div>
          </div>
      </div>
  </div>
  </form>
    <script>

        // lấy cái gom nhóm
        var login = document.getElementsByClassName("login");
        var register = document.getElementsByClassName("register");
        var forgot = document.getElementsByClassName("forgot_Password");

        // Ban đầu ẩn đăng ký và quên mật khẩu
        register[0].style.display = 'none';
        forgot[0].style.display = 'none';

        // Lấy các nút thay đổi
        var passwords_relay = document.getElementById("passwords_relay");
        var switch_to_register = document.getElementById("switch_to_register");
        var switch_to_login = document.getElementById("switch_to_login");
        var switchlogin = document.getElementById("switchlogin");


        var pRegisterPassword = document.getElementById("p_register_password")
        var pForgotPassword = document.getElementById("p_forgot_password")
        var pForgotPasswordRelay = document.getElementById("p_forgot_password_relay")

        var btnSign = document.getElementsByClassName("Button")


        for (let i = 0; i < btnSign.length; i++) {
            btnSign[i].addEventListener("click", (e) => {
                if (pRegisterPassword.innerHTML !== "" && i === 1) {
                    e.stopPropagation()
                    e.preventDefault()
                }

                if ((pForgotPassword.innerHTML !== "" || pForgotPasswordRelay.innerHTML !== "") && i === 2) {
                    e.stopPropagation()
                    e.preventDefault()
                }
            })
        }
        function noneblock(e) {
            login[0].style.display = 'none';
            register[0].style.display = 'none';
            forgot[0].style.display = 'none';

            if (e == passwords_relay) {
                forgot[0].style.display = 'block';
            } else if (e == switch_to_register) {
                register[0].style.display = 'block';
            } else if (e == switch_to_login) {
                login[0].style.display = 'block';
            } else {
                login[0].style.display = 'block';
            }
        }

        passwords_relay.addEventListener('click', function () {
            noneblock(passwords_relay);
        });
        switch_to_login.addEventListener('click', function () {
            noneblock(switch_to_login);
        });
        switch_to_register.addEventListener('click', function () {
            noneblock(switch_to_register);
        });
        switchlogin.addEventListener('click', function () {
            noneblock(switchlogin);
        });
        var input = document.getElementsByTagName('input')
                
        for (let i = 0; i < input.length; i++) {
            console.log(input[i])
            if (i != 15) {
                input[i].addEventListener("input", function () {
                    let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$/;
                    //              chữ thường   chữ hoa    số        kí tự         kết hợp  độ dài 5->?
                    let valid = regex.test(input[i].value);
                    let pvalue = document.querySelectorAll("p." + input[i].className);

                    if (valid) {
                        pvalue[0].innerHTML = "";

                    }
                    else {
                        pvalue[0].innerHTML = "Mật khẩu không hợp lệ (A-Z)(a-z)(0-9)(7 kt->)(!@#$%^&*())"
                    }
                })
            }
            else {
                input[i].addEventListener('input', function () {
                    let inputvalue = input[i - 1].value;
                    let pvalue = document.querySelectorAll("p." + input[i].className);

                    if (input[i].value == input[i - 1].value) {
                        pvalue[0].innerHTML = "";

                    }
                    else {
                        pvalue[0].innerHTML = "Mật khẩu không khớp"
                    }
                })
            }
        }
        window.onload = function () {
            var URL = window.location.href;
            var regex = /[?&]name=(\w+)/;
            var match = URL.match(regex);
            if (match) {
                if (match[1] == "DangKy") {
                    switch_to_register.click();
                }


            }
            var ktdangky = document.getElementById("KTDangky")
            var ktdoimk = document.getElementById("ktrdoimk")
            if (ktdangky.innerHTML != "") {
                switch_to_register.click();
            }
            if (ktdoimk.innerHTML != "") {
                passwords_relay.click();
            }
        }
    </script>
</body>
</html>
