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
    var hisPlaySong = hour + ":" + minute + ":" + second
    songArr.push(namePlaySong.innerHTML, hisPlaySong)

    inputName.value === ""
    inputTime.value === ""
    for (let j = 0; j < songArr.length; j++ ) {
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
    console.log(inputName.value + inputTime.value)
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