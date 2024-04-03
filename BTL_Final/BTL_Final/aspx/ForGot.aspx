<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForGot.aspx.cs" Inherits="BTL_Final.aspx.ForGot" %>

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
            <div class="forgot_Password">
                    <h2>Quên mật khẩu</h2>
                    <input type="email" placeholder="Email" id="forgot_email" class="forgot_email" name="forgot_email"/>
                    <input type="text" placeholder="Tên người sử dụng" id="forgot_name" class="forgot_name" name="forgot_name"/>
                    <input type="text" placeholder="Tên đăng nhập" id="forgot_account" class="forgot_account" name="forgot_account"/>
                    <input type="password" placeholder="Mật khẩu" id="forgot_password" class="forgot_password" name="forgot_password"/>
                    <p id="check_password" class="forgot_password"></p>
                    <input type="password" placeholder="Nhập lại mật khẩu" id="forgot_password_relay" class="forgot_password_relay" name="forgot_password_relay"/>
                    <p id="check_password_relay" class="forgot_password_relay"></p>
                    <asp:Button runat="server" id="btnDoimk" CssClass="Button" class="btnSign"  Text="Quên Mật Khẩu" OnClick="btnForGot" />
                    <p id="test_forgot" runat="server"></p>
                    <p class="form-info">Quay lại đăng nhập? <a href="#" id="switchlogin">Đăng nhập</a></p>
    </div>
    </div>
    </div>
</form>
    <script>
        var inputPassword = document.getElementById("forgot_password")
        var inputPasswordRelay = document.getElementById("forgot_password_relay")
        var checkPassword = document.getElementById("check_password")
        var checkPasswordRelay = document.getElementById("check_password_relay")
        var passwordNoti = document.getElementById("test_forgot")
        var btnForGot = document.getElementsByClassName("Button")[0]

        inputPassword.addEventListener("input", () => {
            let regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{5,}$/;
            //              chữ thường   chữ hoa    số        kí tự         kết hợp  độ dài 5->?
            let valid = regex.test(inputPassword.value);
            if (valid) {
                checkPassword.innerHTML = ""
            } else {
                checkPassword.innerHTML = "Mật khẩu không hợp lệ (A-Z)(a-z)(0-9)(7 kt->)(!@#$%^&*())"

            }
                if (inputPassword.value === inputPasswordRelay.value) {
                    checkPasswordRelay.innerHTML = ""

                } else {
                    checkPasswordRelay.innerHTML = "Nhập Mật khẩu không khớp!"
                }
        })

        inputPasswordRelay.addEventListener("input", () => {

            if (inputPassword.value === inputPasswordRelay.value) {
                checkPasswordRelay.innerHTML = ""

            } else {
                checkPasswordRelay.innerHTML = "Nhập Mật khẩu không khớp!"
            }
        })

        btnForGot.addEventListener('click', (e) => {
            if (checkPassword.innerHTML !== "" || checkPasswordRelay.innerHTML !== "") {
                e.stopPropagation()
                e.preventDefault()
                passwordNoti.innerHTML = "Nhập sai định dạng"
            }
            else {

            }
        })
    </script>
</body>
</html>
