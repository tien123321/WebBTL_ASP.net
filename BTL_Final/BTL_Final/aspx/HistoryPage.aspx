<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryPage.aspx.cs" Inherits="BTL_Final.aspx.HistoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../assest/themify-icons/themify-icons.css" rel="stylesheet" />
    <link href="../styles/Global.css" rel="stylesheet" />
    <link href="../styles/HistoryPage.css" rel="stylesheet" />
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
                        <p class="content-noti"">Lịch Sử Bài Hát</p>
                        <asp:Button runat="server" id="del"  class="btn-del" Text="Xóa" OnClick="DeleteSong" Visible="false"/>
                    </div>
                        <div class="list-music" runat="server" id ="list_music">
                        </div>
                </div>
            </div>
        </div>
    </div>
</div>
    </form>
    <script>

    </script>
</body>
</html>
