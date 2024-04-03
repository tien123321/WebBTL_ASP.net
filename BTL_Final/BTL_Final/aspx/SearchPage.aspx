<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BTL_Final.aspx.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assest/themify-icons/themify-icons.css" rel="stylesheet" />
    <link href="../styles/Global.css" rel="stylesheet" />
    <link href="../styles/PlayMusic.css" rel="stylesheet" />
    <style>
        .author-frame{
            padding: 0 16px;
            margin: 4px 0;
            width: 33.333%;
            max-width: 400px;
        }

        .author-banner{
            display: flex;
            border-radius: 12px;
            padding: 8px;
            align-items: center;
            background-image: linear-gradient(to right, rgba(202, 13, 202, 0.4), rgba(81, 22, 158, 0.2) , rgba(10, 17, 112, 0.2));
        }

        .author-logo{
            width: 60px;
            height: 60px;
        }

        .author-logo-img{
            width: 100%;
            height: 100%;
            object-fit: cover;
            border-radius: 50%;
        }


        .author-name{
            font-size: 18px;
            margin-left: 12px;
            font-weight: 600;
        }

        .content-decs {
            display: flex;
            padding: 16px 0 12px 16px;
            justify-content: space-between;
            font-size: 20px;
        }

        .content-noti {
            font-weight: 600;
        }
    </style>
</head>
<body>
        <form id="form1" runat="server">
        <div class="main">
            <div class="header">
            <div class="header-logo">
                <img src="../assest/img/logo-dark.svg" alt="Logo" class="header-logo-img"/>
            </div>
            <div class="header-with-search">
                <div class="header-input-wrap" runat="server">
                    <input type="text" class="header-search-input" placeholder="Tìm kiếm" name="inputSearch" id="inputSearch" runat="server"/>
                </div>
                 <asp:Button runat="server" id="btnSeach"  class="header-search" Text="Tìm" OnClick="SearchInfor" />

            </div>
            <div class="header-sign">
                 <asp:Button runat="server" id="btnSignUp"  class="header-sign-btn header-sign-up" Text="Đăng Ký" OnClick="signUp" />
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
                <div class="content-main">
                    <div class="content-decs">
                        <p class="content-noti" runat="server" id="txtNotiMusic"  name="txtNotiMusic"></p>
                    </div>
                     <div class="list-music" runat="server" id ="list_music">
                     </div>
                    <!--lay ra ten bai hat khi click vao ti-heart -->
                    <div style="display:none" runat="server">
                        <input class="inpNameLikeSong" id="inpNameLikeSong" name="inpNameLikeSong" runat="server" />
                        <asp:Button class="btnNameLikeSong" id="btnNameLikeSong" name="btnNameLikeSong" runat="server" OnClick="btnClickNameLikeSong"  />
                    </div>

                        <div class="content-decs" style="display:none">
                            <p class="content-noti" runat="server" id="txtNotiAuthor"  name="txtNotiAuthor"></p>
                        </div>
                    <div style="display:none" class="list-music" runat="server" id="list_music_author">
                    </div>

                        <div style="display:none" class="content-decs">
                            <p class="content-noti" runat="server" id="txtNotiCountry"  name="txtNotiCountry"></p>
                        </div>
                    <div style="display:none" class="list-music" runat="server" id="list_music_country">
                    </div>
                </div>
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

        window.onload = () => {
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
    </script>
</body>
</html>
