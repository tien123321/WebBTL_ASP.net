<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BTL_Final.aspx.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <link href="../assest/themify-icons/themify-icons.css" rel="stylesheet" />
    <link href="../styles/Global.css" rel="stylesheet"/>
    <link href="../styles/HomePage.css" rel="stylesheet" /> 
    <style>
        .section-type-music-item:hover{
            cursor:pointer;
        }
    </style>
</head>
<body>
    <form runat="server">
    <div class="main">
        <div class="header">
            <div class="header-logo">
                <img src="../assest/img/logo-dark.svg" alt="Logo" class="header-logo-img"/>
            </div>
            <div class="header-with-search">
                <div class="header-input-wrap" runat="server">
                    <input type="text" class="header-search-input" placeholder="Tìm kiếm" name="inputSearch" id="inputSearch" runat="server"/>
                </div>
                 <asp:Button runat="server" id="btnSeach"  class="header-search " Text="Tìm" OnClick="SearchInfor" />

            </div>
            <div class="header-sign">
                 <asp:Button runat="server" id="btnSignUp"  class="header-sign-btn header-sign-up signUp" Text="Đăng Ký" OnClick="signUp" />
                 <span class="header-sign-span"></span>
                 <asp:Button runat="server" id="btnSignIn"  class="header-sign-btn header-sign-in" Text="Đăng Nhập" OnClick="signIn" />
            </div>
        </div>

        <div class="container">
            <div class="sidebar">
                <ul class="sidebar-list">
                    <li class="sidebar-item" >
                        <a class="link" href="HomePage.aspx">
                            <i class="ti-home sidebar-item-child"></i>
                            <h2 class="sidebar-item-child text-sidebar-item">Khám phá</h2>
                        </a>
                    </li>
                    <li class="sidebar-item">
                        <a class="link" href="PlayMusic.aspx">
                            <i class="ti-control-play sidebar-item-child"></i>
                            <h2 class="sidebar-item-child text-sidebar-item">Nghe Nhạc</h2>
                        </a>
                    </li>
                    <li class="sidebar-item">
                        <a class="link" href="HistoryPage.aspx">
                            <i class="ti-music sidebar-item-child"></i>
                            <h2 class="sidebar-item-child text-sidebar-item">Đã nghe gần đây</h2>
                        </a>
                    </li>
                    <li class="sidebar-item">
                        <a class="link" href="LikePage.aspx">
                            <i class="ti-menu-alt sidebar-item-child"></i>
                            <h2 class="sidebar-item-child text-sidebar-item">Thư viện</h2>
                        </a>
                    </li>
                </ul>
            </div>
            <div class="content">
                <div class="content-bg">
                    <div class="banner-list">
                        <div class="banner-item">
                            <img src="../assest/img/banner-1.jpg" alt="Logo-Banner" class="banner-img"/>
                        </div>
                        <div class="banner-item">
                            <img src="../assest/img/banner-2.jpg" alt="Logo-Banner" class="banner-img"/>
                        </div>
                        <div class="banner-item">
                            <img src="../assest/img/banner-3.jpg" alt="Logo-Banner" class="banner-img"/>
                        </div>
                    </div>

                    <div class="content-main">
                        <div class="section">
                            <h3 class="section-header">Danh Sách Bài Hát</h3>
                            <div class="section-type-music-list">
                                <div class="section-type-music-item active">Tất Cả</div>
                                <div class="section-type-music-item">Việt Nam</div>
                                <div class="section-type-music-item">Trung Quốc</div>
                                <div class="section-type-music-item">Âu Mỹ</div>
                            </div>
                        </div>
    
                        <div id="list_music" runat="server" class="list-music"></div>
                        <!--lay ra ten bai hat khi click vao ti-heart -->
                        <div style="display:none" runat="server">
                            <input class="inpNameLikeSong" id="inpNameLikeSong" name="inpNameLikeSong" runat="server" />
                            <asp:Button class="btnNameLikeSong" id="btnNameLikeSong" name="btnNameLikeSong" runat="server" OnClick="btnClickNameLikeSong"  />
                        </div>
                        <div class="section">
                            <h3 class="section-header">Ca Sĩ</h3>
                            <div class="section-album-list">
                                <div class="section-album-item">
                                    <div class="section-album-card">
                                        <img src="../assest/img/card-1.jpg" alt="Logo-Card" class="section-item-img"/>
                                    </div>
                                    <div class="section-album-text">Người đừng lặng im đến thế</div>
                                </div>

                                <div class="section-album-item">
                                    <div class="section-album-card">
                                        <img src="../assest/img/card-2.jpg" alt="Logo-Card" class="section-item-img"/>
                                    </div>
                                    <div class="section-album-text">Tình yêu thầm lặng</div>
                                </div>

                                <div class="section-album-item">
                                    <div class="section-album-card">
                                        <img src="../assest/img/card-3.jpg" alt="Logo-Card" class="section-item-img"/>
                                    </div>
                                    <div class="section-album-text">Nỗi nhớ là một đóa hoa</div>

                                </div>

                                <div class="section-album-item">
                                    <div class="section-album-card">
                                        <img src="../assest/img/card-4.jpg" alt="Logo-Card" class="section-item-img"/>
                                    </div>
                                    <div class="section-album-text">Nơi nào bình yên</div>
                                </div>
                            </div>
                        </div>

                    </div>

                        
                <!-- <p >Hiện Có : <%=Application["Counter"] %> Người Truy Cập</p>-->
                </div>
            </div>
        </div>
    </div>
    </form>
    <script>
        var nameSong = document.getElementsByClassName("music-name")
        var heartIcon = document.getElementsByClassName("ti-heart")
        var inpNameLikeSong = document.getElementById("inpNameLikeSong")
        var btnNameLikeSong = document.getElementsByClassName("btnNameLikeSong")[0]

        window.onload = function () {
            var urlParams = new URLSearchParams(window.location.search);
            var name = urlParams.get('name');

            loadForm()
            for (let i = 0; i < country.length; i++) {
                country[i].classList.remove('active');

            }

            if (name === 'Việt Nam') {
                country[1].classList.add('active');
            } else if (name === 'Trung Quốc') {
                country[2].classList.add('active');
            } else if (name === 'Âu Mỹ') {
                country[3].classList.add('active');
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
                    window.location.href = "Homepage.aspx?name=Việt%20Nam";
                } else if (country[i].innerHTML === 'Trung Quốc') {
                    window.location.href = "Homepage.aspx?name=Trung%20Quốc";
                } else if (country[i].innerHTML === 'Âu Mỹ') {
                    window.location.href = "Homepage.aspx?name=Âu%20Mỹ";
                }
            })
        }

        var loadForm = () => {
            var isConnect = document.getElementsByClassName("isConnect")
            for (let i = 0; i < isConnect.length; i++) {
                if (isConnect[i].innerHTML == "1") {
                    heartIcon[i].style.color = "green"

                }
                else {
                    heartIcon[i].style.color = "white"
                }
            }
        }

        //click vao ti-heart lay cac bai hat yeu thich
        for (let i = 0; i < heartIcon.length; i++) {
            heartIcon[i].addEventListener("click", (e) => {
                e.stopPropagation()
                e.preventDefault()
                inpNameLikeSong.value = nameSong[i].innerHTML
                btnNameLikeSong.click()
            })
        }

        

        var link = document.getElementsByTagName('a')
        
        //ngăn chặn hành vi khi chưa đăng nhập
        var signup = document.getElementsByClassName('signUp')[0];
        for (let i = 0; i < link.length; i++) {
            link[i].addEventListener('click', function (event) {
                if (signup.value == 'Đăng Ký') {
                    event.preventDefault();
                    event.stopPropagation();
                    window.location.href = "SignIn.aspx";
                }
            });
        }
        var inputSearch = document.getElementById("inputSearch")
        var btnSearch = document.getElementsByClassName("header-search")[0]
        btnSearch.addEventListener("click", (e) => {
            if (inputSearch.value === "") {
                alert("Bạn chưa nhập thông tin!")
                e.stopPropagation()
                e.preventDefault()
            }
        })


    </script>
</body>
</html>
