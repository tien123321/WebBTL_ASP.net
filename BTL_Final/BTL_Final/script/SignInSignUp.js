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
    if (i != 10) {
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
