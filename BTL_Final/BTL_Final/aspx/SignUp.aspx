<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="BTL_Final.aspx.SignUp" %>

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
            <h2>Đăng Ký</h2>
                    <input type="text" placeholder="Họ và Tên" id="register_name" class="register_name" name="register_name"/>
                    <input type="text" placeholder="Tên tài khoản" id="register_account" class="register_account" name="register_account"/>
                    <input type="email" placeholder="Email" id="register_email" class="register_email" name="register_email"/>
                    <input type="password" placeholder="Mật khẩu" id="register_password" class="register_password" name="register_password"/>
                    <p id="password_noti" class="register_password"></p>
                    <asp:Button runat="server" id="btnDangky" CssClass="Button" class="btnSign" Text="Đăng ký" OnClick="clickSignUp" />
                    <p id="test_register" runat="server"></p>
                    <p class="form-info">Đã có tài khoản? <a href="SignIn.aspx" id="switch_to_login">Đăng nhập</a></p>
        </div>
        </div>
        </div>
    </form>

    <script>
        var passwordNoti = document.getElementById("password_noti")
        var testRegister = document.getElementById("test_register")
        var inputPassword = document.getElementById("register_password")

        var btnDangKy = document.getElementsByClassName("Button")[0]

        /*inputPassword.addEventListener("input", () => {
            let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$/;
            //              chữ thường   chữ hoa    số        kí tự         kết hợp  độ dài 5->?
            let valid = regex.test(inputPassword.value);
            if (valid) {
                passwordNoti.innerHTML = ""
            } else {
                passwordNoti.innerHTML = "Mật khẩu không hợp lệ (A-Z)(a-z)(0-9)(7 kt->)(!@#$%^&*())"

            }
        })*/


        //email
        /*function validateEmail() {
          var emailInput = document.getElementById("emailInput").value;
          var emailRegex = /^[A-Za-z0-9._%+-]+@gmail\.com$/;

          if (emailRegex.test(emailInput)) {
            // Email hợp lệ
            // Thực hiện các xử lý khác tại đây
          } else {
            // Email không hợp lệ
            alert("Email phải có định dạng example@gmail.com");
          }
        }*/

        btnDangKy.addEventListener("click", (e) => {
            if (passwordNoti.innerHTML !== "") {
                e.preventDefault()
                e.stopPropagation()
                document.getElementById("test_register").innerHTML = "Hãy nhập đúng kiểu dữ liệu"
            } else {

            }
        })
    </script>
</body>
</html>
