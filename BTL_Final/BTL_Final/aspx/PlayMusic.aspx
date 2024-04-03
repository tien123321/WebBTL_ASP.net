<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayMusic.aspx.cs" Inherits="BTL_Final.aspx.PlayMusic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Play Music</title>
    <link href="../assest/themify-icons/themify-icons.css" rel="stylesheet" />
    <link href="../styles/Global.css" rel="stylesheet" />
    <link href="../styles/PlayMusic.css" rel="stylesheet" />
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
                            <div class="content-music">
                                <div class="music-section">
                                    <div class="music-section-infor">
                                        <div class="music-section-now">Bài hát đang phát :</div>
                                        <div class="music-section-song" id="nameSong" runat="server">Thằng điên</div>
                                        <div class="music-section-author" id="nameAuthor" runat="server">Justatee x Phương Ly</div>
                                    </div>
                                    <div class="music-section-frame-img">
                                        <img src="<%#URLimg%>" alt="Thằng điên" class="music-section-img" id="urlImg" runat="server"/>
                                        <img src="<%#URLimg%>" alt="Thằng điên" class="music-section-img-drop" id="urlImgDrop" runat="server"/>
                                    </div>
                                </div>
    
                                <div class="music-track">
                                    <input type="range" name="playing" id="progress" class="music-track-progress" value="0" min="0" step="1" max="100"/>
                                    <div class="music-loader" id="loadprogress" style="height:9px;"></div>
                                </div>
            
                                <div class="music-time" style="display:flex; justify-content:space-between;">
                                    <span class="music-curtime" id="musicCurtime" runat="server"></span>
                                    <span class="music-sumtime" id="musicSumtime" runat="server"></span>
                                </div>
    
                                <div class="music-control">
                                    <div class="music-control-menu">
                                    <div class="item music-control-add" id="repeat">
                                        <i title="repeat" class="ti-reload"></i>
                                    </div>
                                    <div class="item music-control-shuffle" id="shuffle">
                                        <i title="shuffle" class="ti-control-shuffle"></i>
                                    </div>
                                    </div>
                                    <div class="music-control-menu">
                                        <div class="item music-control-back-btn" id="back">
                                            <i class="ti-control-skip-backward"></i>
                                        </div>
        
                                        <div class="item music-control-play-pause" id="pause_play">
                                            <i class="ti-control-play" id="play"></i>
                                            <!-- <i class="ti-control-pause"></i> -->
                                        </div>
        
                                        <div class="item music-control-next-btn" id="next">
                                            <i class="ti-control-skip-forward"></i>
                                        </div>
                                    </div>
    


                                    <div class="item heart" id="heart" style="color:white;border:1px solid white">
                                        <i title="like" class="ti-heart"></i>
                                        <p id="countHeart" runat="server" style="margin-top:-10px; display:none;">0</p>
                                    </div>
                                </div>
                            </div>
                            <!-- list-music -->

                            <div id="list_music" class="list-music" runat="server"></div>
                            <!-- lay ra danh sach bai hat -->
                            <div style="display:none;" runat="server">
                                <input id="arrNameSong"  name="arrNameSong" type="text" runat="server"/>
                                <input id="arrTimeSong"  name="arrTimeSong" type="text" runat="server"/>
                                <input id="likeSong" name="likeSong" type="text" runat="server" />
                               <asp:ScriptManager runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel runat="server" id="UpdatePanel1">
                                <ContentTemplate>
                                    <asp:Button runat="server" id="SaveHisSong" Text="Lưu" OnClick="btnSaveSongData" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            </div>
                   
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <audio src="<%#URLaudio%>" id="urlAudio" runat="server"></audio>
        
    </form>
    <script>

        var likeArr = []
        var heart = document.getElementsByClassName("heart")[0]
        var countHeart = document.getElementById("countHeart")
        var likeSong = document.getElementById("likeSong")
        var isConnect = document.getElementsByClassName("isConnect")
        var countHeartFrame = document.getElementsByClassName("countHeartFrame")
        var heartFrame = document.getElementsByClassName("heart-frame")

        heart.addEventListener("click", () => {
            //TH chua thich
            if (heart.style.color === "white") {
                likeArr.length = 0
                for (let i = 0; i < musicFrame.length; i++) {
                    if (namePlaySong.innerHTML === musicName[i].innerHTML) {
                        heartFrame[i].style.color = "green"
                        isConnect[i].innerHTML = "1"
                        countHeartFrame[i].innerHTML = (parseInt(countHeartFrame[i].innerHTML) + 1).toString();

                        break;
                    }
                }

                var heartTemp = parseInt(countHeart.innerHTML)
                heartTemp++
                countHeart.innerHTML = heartTemp + ""
                heart.style.border = "1px solid green"
                heart.style.color = "green"
                setSongArr()
            }

            //TH da thich
            else {
                likeArr.length = 0

                for (let i = 0; i < musicFrame.length; i++) {
                    console.log(namePlaySong.innerHTML)
                    console.log(musicFrame[i].innerHTML)
                    if (namePlaySong.innerHTML === musicName[i].innerHTML) {
                        heartFrame[i].style.color = "white"
                        isConnect[i].innerHTML = "0"
                        countHeartFrame[i].innerHTML = (parseInt(countHeartFrame[i].innerHTML) - 1).toString();
                        break;
                    }
                }
                var heartTemp = parseInt(countHeart.innerHTML)
                heartTemp--
                countHeart.innerHTML = heartTemp + ""
                heart.style.border = "1px solid white"
                heart.style.color = "white"
                setSongArr()
            }
        })

        for (let i = 0; i < heartFrame.length; i++) {
            heartFrame[i].addEventListener("click", (e) => {
                e.stopPropagation()
                likeArr.length = 0
                if (musicName[i].innerHTML === namePlaySong.innerHTML) {
                    heart.click()
                }
                else {
                    if (heartFrame[i].style.color == "" || heartFrame[i].style.color == "white") {
                        heartFrame[i].style.color = "green"
                        isConnect[i].innerHTML = "1"
                        countHeartFrame[i].innerHTML = (parseInt(countHeartFrame[i].innerHTML) + 1).toString();
                        setSongArr()
                    }
                    else {
                        heartFrame[i].style.color = "white"
                        isConnect[i].innerHTML = "0"
                        countHeartFrame[i].innerHTML = (parseInt(countHeartFrame[i].innerHTML) - 1).toString();
                        setSongArr()
                    }
                }
            })
        }



        var songArr = []
        var fullSongArr = []
        var countDown
        var seconds = 0
        var minutes = 0
        var progress = document.getElementById("progress")
        var timeStart = document.getElementById("musicCurtime")
        var timeEnd = document.getElementById("musicSumtime")
        var audio = document.getElementById("urlAudio")
        var pause_play = document.getElementById("pause_play")
        var play = document.getElementById("play")
        var musicLoader = document.getElementById("loadprogress")
        var startDate = new Date()

        var musicFrame = document.getElementsByClassName("music-frame");
        var img = document.getElementsByClassName("music-logo-img");
        var musicName = document.getElementsByClassName("music-name");
        var musicAuthor = document.getElementsByClassName("music-author");
        var audioFrame = document.getElementsByClassName("audio-none");
        var timeFrame = document.getElementsByClassName("time-none")


        var imgPlay = document.getElementById('urlImg');
        var imgPlayDrop = document.getElementById('urlImgDrop');
        var namePlaySong = document.getElementById('nameSong');
        var namePlayAuthor = document.getElementById('nameAuthor');

        var inputName = document.getElementById("arrNameSong")
        var inputTime = document.getElementById("arrTimeSong")

        var btnSearch = document.getElementsByClassName("header-search")
        var btnSignIn = document.getElementsByClassName("header-sign-in")
        var btnSignUp = document.getElementsByClassName("header-sign-up")


        var like
        function playAudio(seconds) {
            audio.currentTime = seconds
            audio.play()
        }

        function setStartDate() {
            startDate = new Date()
            startDate.setMinutes(startDate.getMinutes() - minutes);
            startDate.setSeconds(startDate.getSeconds() - seconds);
            return startDate
        }

        function setProgress() {
            var timeMax = timeEnd.innerHTML
            var splitTimeMax = timeMax.split(":")
            var progressMinutes = splitTimeMax[0]
            var progressSeconds = splitTimeMax[1]
            var times = parseInt(progressMinutes) * 60 + parseInt(progressSeconds)
            progress.max = times
        }

        function setSongArr() {

            for (let i = 0; i < isConnect.length; i++) {
                if (isConnect[i].innerHTML == "1")
                    heartFrame[i].style.color = "green"
                else
                    heartFrame[i].style.color = "white"

            }

            likeSong.value = ""

            //push du lieu ban dau len web
            for (let i = 0; i < musicFrame.length; i++) {
                likeArr.push(musicName[i].innerHTML, isConnect[i].innerHTML)
            }
            for (let i = 0; i < likeArr.length; i++) {
                if (likeSong.value === "") {
                    likeSong.value = likeArr[i]
                } else {
                    likeSong.value = likeSong.value + "," + likeArr[i]
                }
            }

            //load len web
            for (let i = 0; i < isConnect.length; i++) {
                if (musicName[i].innerHTML === namePlaySong.innerHTML) {
                    if (isConnect[i].innerHTML == "1") {
                        heart.style.border = "1px solid green"
                        heart.style.color = "green"
                        countHeart.innerHTML = countHeartFrame[i].innerHTML
                        heartFrame[i].style.color = "green"
                    } else {
                        heart.style.border = "1px solid white"
                        heart.style.color = "white"
                        countHeart.innerHTML = countHeartFrame[i].innerHTML
                        heartFrame[i].style.color = "white"
                    }
                }
            }


            for (let j = 0; j < songArr.length; j += 2) {
                if (namePlaySong.innerHTML === songArr[j]) {
                    songArr.splice(j, 2); // Xoá tên bài hát và thời gian cũ
                    break; // Thoát khỏi vòng lặp
                }
            }

            var date = new Date();
            var hour = date.getHours();
            var minute = date.getMinutes();
            var second = date.getSeconds();

            const day = date.getDate();
            const month = date.getMonth() + 1;
            const year = date.getFullYear();

            var hisPlaySong = hour + ":" + minute + ":" + second + ":" + day + ":" + month + ":" + year
            songArr.push(namePlaySong.innerHTML, hisPlaySong)

            inputName.value = ""
            inputTime.value = ""
            for (let j = 0; j < songArr.length; j++) {
                if (j % 2 == 0) {
                    if (inputName.value === "") {
                        inputName.value = songArr[j]
                    }
                    else {
                        inputName.value = inputName.value + "," + songArr[j]
                    }
                }
                else {
                    if (inputTime.value === "") {
                        inputTime.value = songArr[j]
                    }
                    else {
                        inputTime.value = inputTime.value + "," + songArr[j]
                    }
                }
            }
        }


        function resetCountDown() {
            audio.pause()
            clearInterval(countDown)

            minutes = 0
            seconds = 0

            timeStart.innerHTML = `${minutes.toString().padStart(2, "0")}:${seconds.toString().padStart(2, "0")}`
            progress.value = seconds;
            musicLoader.style.width = `${(progress.value / progress.max) * 100}%`
        }

        function runCountDown() {
            var now = new Date()

            //thời gian đã phát
            var elapsedTime = now - startDate
            //tổng sô giây đã phát
            var totalSeconds = Math.floor(elapsedTime / 1000)

            minutes = Math.floor(totalSeconds / 60);
            seconds = totalSeconds % 60;

            timeStart.innerHTML = `${minutes.toString().padStart(2, "0")}:${seconds.toString().padStart(2, "0")}`
            progress.value = totalSeconds
            musicLoader.style.width = `${(progress.value / progress.max) * 100}%`

            if (timeStart.innerHTML === timeEnd.innerHTML) {
                clearInterval(countdown);
                next.click();
            }
        }

        window.onload = function () {
                setProgress()
                play.classList.remove("ti-control-play");
                play.classList.add("ti-control-pause");
                var timeaudio = minutes * 60 + seconds;
                playAudio(timeaudio);
                countDown = setInterval(runCountDown, 1000);

                setSongArr()

        }

        pause_play.addEventListener("click", function () {
            if (play.classList.contains("ti-control-play")) {
                play.classList.add("ti-control-pause")
                play.classList.remove("ti-control-play")
                setStartDate()
                var timeAudio = minutes * 60 + seconds
                audio.currentTime = timeAudio
                audio.play()
                countDown = setInterval(runCountDown, 1000);

            }
            else {
                audio.pause();
                play.classList.add("ti-control-play");
                play.classList.remove("ti-control-pause");
                clearInterval(countDown);
            }

        });


        //tua progress
        function handleProgressInput() {
            clearInterval(countDown);

            seconds = parseInt(progress.value)
            minutes = Math.floor(seconds / 60)
            seconds = seconds % 60

            timeStart.innerHTML = `${minutes.toString().padStart(2, "0")}:${seconds.toString().padStart(2, "0")}`
            musicLoader.style.width = `${(progress.value / progress.max) * 100}%`
        }
        function updateTime() {
            handleProgressInput
            if (play.classList.contains("ti-control-pause")) {
                audio.currentTime = seconds
                audio.play()
                let startDate = setStartDate()

                countDown = setInterval(() => {
                    var now = new Date()
                    var timePassed = now.getTime() - startDate.getTime()
                    var minutesCount = Math.floor(timePassed / (1000 * 60));
                    var secondsCount = Math.floor((timePassed % (1000 * 60)) / 1000)
                    minutes = minutesCount
                    seconds = secondsCount
                    timeStart.innerHTML = `${minutes.toString().padStart(2, "0")}:${seconds.toString().padStart(2, "0")}`
                    var totalSeconds = minutes * 60 + seconds
                    progress.value = totalSeconds
                    musicLoader.style.width = `${(progress.value / progress.max) * 100}%`

                    if (timeStart.innerHTML === timeEnd.innerHTML) {
                        next.click();
                    }
                }, 1000)
            } else {
                clearInterval(countDown);
                audio.pause();
            }
        }

        progress.addEventListener("input", handleProgressInput);
        progress.addEventListener("change", updateTime);

        //click
        for (let i = 0; i < musicFrame.length; i++) {
            musicFrame[i].addEventListener("click", () => {
                fullSongArr.push(namePlaySong.innerHTML)

                resetCountDown()
                imgPlay.src = img[i].src
                imgPlayDrop.src = img[i].src
                namePlaySong.innerHTML = musicName[i].innerHTML
                namePlayAuthor.innerHTML = musicAuthor[i].innerHTML
                audio.src = audioFrame[i].src
                timeEnd.innerHTML = timeFrame[i].innerHTML

                play.classList.add("ti-control-pause")
                play.classList.remove("ti-control-play")

                playAudio(0)
                setProgress()
                setStartDate()
                countDown = setInterval(runCountDown, 1000);

                setSongArr() //Set bài hát vào trong mảng songArr


            })
        }

        //xử lý lặp và ngẫu nhiên
        var repeat = document.getElementById('repeat')
        var shuffe = document.getElementById('shuffle')

        let isRepeat = false;
        let isShuffle = false;

        repeat.addEventListener("click", () => {
            if (isRepeat) {
                repeat.style.border = '1px solid white'
                repeat.style.color = 'white';
                isRepeat = false

            } else {
                repeat.style.border = '1px solid #8628c5'
                repeat.style.color = '#8628c5';
                isRepeat = true
            }
        })

        shuffe.addEventListener('click', function () {
            if (isShuffle) {
                shuffe.style.border = '1px solid #fff'
                shuffe.style.color = '#fff';
                isShuffle = false;
            }
            else {
                shuffe.style.border = '1px solid #8628c5'
                shuffe.style.color = '#8628c5';
                isShuffle = true;

            }
        })

        //next
        var next = document.getElementById("next")
        next.addEventListener("click", () => {
            let currentIndex = -1
            if (!isRepeat && !isShuffle) {
                fullSongArr.push(namePlaySong.innerHTML)
                for (let i = 0; i < musicName.length; i++) {
                    if (musicName[i].innerHTML === namePlaySong.innerHTML) {
                        currentIndex = i
                        break
                    }
                }

                if (currentIndex !== -1) {
                    const nextIndex = (currentIndex + 1) % musicName.length // Chỉ số của bài hát tiếp theo (vòng quay lại đầu nếu cần)
                    resetCountDown()
                    imgPlay.src = img[nextIndex].src
                    imgPlayDrop.src = img[nextIndex].src
                    namePlaySong.innerHTML = musicName[nextIndex].innerHTML
                    namePlayAuthor.innerHTML = musicAuthor[nextIndex].innerHTML
                    audio.src = audioFrame[nextIndex].src
                    timeEnd.innerHTML = timeFrame[nextIndex].innerHTML

                    play.classList.add("ti-control-pause")
                    play.classList.remove("ti-control-play")

                    playAudio(0)
                    setProgress()
                    setStartDate()
                    countDown = setInterval(runCountDown, 1000);

                    setSongArr() //Set bài hát vào trong mảng songArr
                }
            }
            // lặp lại bài hát trong TH next
            else if ((isRepeat && !isShuffle) || (isRepeat && isShuffle)) {
                resetCountDown()
                play.classList.add("ti-control-pause")
                play.classList.remove("ti-control-play")

                playAudio(0)
                setProgress()
                setStartDate()
                countDown = setInterval(runCountDown, 1000);

                setSongArr()
            }
            //ngẫu nhiên
            else if (!isRepeat && isShuffle) {
                fullSongArr.push(namePlaySong.innerHTML)

                for (let i = 0; i < musicName.length; i++) {
                    if (musicName[i].innerHTML === namePlaySong.innerHTML) {
                        currentIndex = i
                        break
                    }
                }

                if (currentIndex !== -1) {
                    let x = currentIndex;
                    while (x === currentIndex) {
                        x = Math.floor(Math.random() * musicName.length);
                    }
                    currentIndex = x

                    resetCountDown()
                    imgPlay.src = img[currentIndex].src
                    imgPlayDrop.src = img[currentIndex].src
                    namePlaySong.innerHTML = musicName[currentIndex].innerHTML
                    namePlayAuthor.innerHTML = musicAuthor[currentIndex].innerHTML
                    audio.src = audioFrame[currentIndex].src
                    timeEnd.innerHTML = timeFrame[currentIndex].innerHTML

                    play.classList.add("ti-control-pause")
                    play.classList.remove("ti-control-play")

                    playAudio(0)
                    setProgress()
                    setStartDate()
                    countDown = setInterval(runCountDown, 1000);

                    setSongArr() //Set bài hát vào trong mảng songArr
                }
            }
        })

        //back
        var back = document.getElementById("back")
        back.addEventListener('click', () => {
            let preIndex = -1;
            if (fullSongArr == 0) {
                resetCountDown()
                play.classList.add("ti-control-pause")
                play.classList.remove("ti-control-play")

                playAudio(0)
                setProgress()
                setStartDate()
                countDown = setInterval(runCountDown, 1000);

                setSongArr() //Set bài hát vào trong mảng songArr
            }
            else {
                for (let i = 0; i < musicName.length; i++) {
                    if (musicName[i].innerHTML === fullSongArr[fullSongArr.length - 1]) {
                        preIndex = i
                        break
                    }
                }

                fullSongArr.pop(fullSongArr.length - 1)
                resetCountDown()
                imgPlay.src = img[preIndex].src
                imgPlayDrop.src = img[preIndex].src
                namePlaySong.innerHTML = musicName[preIndex].innerHTML
                namePlayAuthor.innerHTML = musicAuthor[preIndex].innerHTML
                audio.src = audioFrame[preIndex].src
                timeEnd.innerHTML = timeFrame[preIndex].innerHTML

                play.classList.add("ti-control-pause")
                play.classList.remove("ti-control-play")

                playAudio(0)
                setProgress()
                setStartDate()
                countDown = setInterval(runCountDown, 1000);

                setSongArr() //Set bài hát vào trong mảng songArr
            }
        })

        document.addEventListener('DOMContentLoaded', function () {
            let links = document.querySelectorAll('a'); // Giả sử 'links' là một NodeList của các thẻ <a>

            links.forEach(function (link) {
                link.addEventListener('click', function (e) {
                    e.preventDefault();
                    if (btnSignUp.innerText === "Đăng Ký") {
                        // Xử lý cho trường hợp này
                    } else {
                        e.preventDefault();

                        __doPostBack('<%= SaveHisSong.UniqueID %>', '');
                            window.location.href = link.href;
                    }
                });
            });
        });

    </script>
</body>
</html>
