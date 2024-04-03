window.onload = function () {
    var URL = window.location.href;
    var regex = /[?&]name=(\w+)/;
    var match = URL.match(regex);

    if (match) {
        var name = match[1];

        for (let i = 0; i < country.length; i++) {
            country[i].classList.remove('active');
        }

        if (name === 'VietNam') {
            country[1].classList.add('active');
        } else if (name === 'TrungQuoc') {
            country[2].classList.add('active');
        } else if (name === 'AuMy') {
            country[3].classList.add('active');
        } else {
            country[0].classList.add('active');
        }
    } else {

        country[0].classList.add('active');
    }
}

var country = document.getElementsByClassName('section-type-music-item');
for (let i = 0; i < country.length; i++) {
    country[i].addEventListener('click', function () {
        for (let j = 0; j < country.length; j++) {
            country[j].classList.remove('active');
        }

        country[i].classList.add('active');

        if (country[i].innerHTML === 'Tất Cả') {
            window.location.href = "Homepage.aspx";
        } else if (country[i].innerHTML === 'Việt Nam') {
            window.location.href = "Homepage.aspx?name=VietNam";
        } else if (country[i].innerHTML === 'Trung Quốc') {
            window.location.href = "Homepage.aspx?name=TrungQuoc";
        } else if (country[i].innerHTML === 'Âu Mỹ'){
            window.location.href = "Homepage.aspx?name=AuMy";
        }
       

    })
}

var link = document.getElementsByTagName('a')
//ngăn chặn hành vi khi chưa đăng nhập