using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Final.data
{
    public class ArrayListGlobal
    {
        public ArrayListGlobal()
        {
        }

        public ArrayListGlobal(ArrayList arrayList)
        {
            this.arrayList = arrayList;
        }

        public ArrayList arrayList { get; set; }

        public void addData()
        {
            arrayList = new ArrayList();
            //Việt Nam
            arrayList.Add(new MusicFrame("Chúng ta của hiện tại", "Sơn Tùng - MTP", new TimeSpan(0, 3, 20), "Việt Nam", 0, "ChungTaCuaHienTai.png", "ChungTaCuaHienTai.mp3", "SonTungMTP.jpg"));
            arrayList.Add(new MusicFrame("Ai đợi mình được mãi", "Thanh Hưng", new TimeSpan(0, 4, 37), "Việt Nam", 0, "aidoiminhdcmai.jfif", "aidoiminhduocmai.mp3", "ThanhHung.jfif"));
            arrayList.Add(new MusicFrame("Anh Mệt Rồi", "Anh Quân Idol", new TimeSpan(0, 4, 37), "Việt Nam", 0, "Anhmetroi.jfif", "AnhMetRoi.mp3", "Anhquan.jfif"));
            arrayList.Add(new MusicFrame("Cứ Chill Thôi", "Chillies, Rhymastic,Suni Hạ Linh", new TimeSpan(0, 4, 40), "Việt Nam", 0, "Cuchillthoi.jpg", "CuChillThoi.mp3", "suniHaLinh.jfif"));
            arrayList.Add(new MusicFrame("Đừng Lo Anh Đợi Mà", "Mr Siro", new TimeSpan(0, 4, 46), "Việt Nam", 0, "Dungloanhdoima.jpg", "DungLoAnhDoiMa.mp3", "mrSiro.jfif"));
            arrayList.Add(new MusicFrame("Đường Tôi Chở Em Về", "Bùi Trường Linh", new TimeSpan(0, 4, 26), "Việt Nam", 0, "duongtoichoemve.jfif", "duongtoichoemve.mp3", "buitruonglinh.jfif"));
            arrayList.Add(new MusicFrame("Em Của Ngày Hôm Qua", "Sơn Tùng - MTP", new TimeSpan(0, 3, 46), "Việt Nam", 0, "emcuangayhomqua.jfif", "EmCuaNgayHomQua.mp3", "SonTungMTP.jpg"));
            arrayList.Add(new MusicFrame("Ghé Qua", "TaynguyenSound và tofutns", new TimeSpan(0, 4, 28), "Việt Nam", 0, "3107full.jfif", "ghequa.mp3", "TaynguyenSoundvàtofutns.jfif"));
            //Trung Quốc
            arrayList.Add(new MusicFrame("Tương tư thành họa", "Trịnh Diệc Thần", new TimeSpan(0, 4, 23), "Trung Quốc", 1, "Tuongtuthanhhoa.jfif", "TuongTuThanhTaiHoa.mp3", "Tuongtuthanhhoa.jfif"));
            arrayList.Add(new MusicFrame("Yến vô Hiết", "Tưởng Tuyết Nhi", new TimeSpan(0, 3, 03), "Trung Quốc", 1, "Yenvohiet.jfif", "yetvohiet.mp3", "Tuongtuyetnhi.jfif"));
            arrayList.Add(new MusicFrame("Phi điểu và ve sầu", "Nhậm Nhiên", new TimeSpan(0, 4, 56), "Trung Quốc", 1, "Phidieuvavesau.jfif", "Phidieuvavesau.mp3", "Nhamnhiem.jfif"));
            arrayList.Add(new MusicFrame("Cửa sổ", "Ngô Thanh Phong", new TimeSpan(0, 3, 30), "Trung Quốc", 1, "Cuaso.jfif", "Cuaso.mp3", "Ngothanhphong.jfif"));
            arrayList.Add(new MusicFrame("Tình yêu khó cầu", "Từ Giai Oách", new TimeSpan(0, 4, 22), "Trung Quốc", 1, "Tinhyeukhocau.jfif", "TinhYeuKhoCau.mp3", "Tuoachgiai.jfif"));
            arrayList.Add(new MusicFrame("Lạnh lẽo", "Dương Tông Vĩ", new TimeSpan(0, 5, 33), "Trung Quốc", 1, "Lanhleo.jfif", "Lanhleo.mp3", "Duongtongvi.jfif"));
            arrayList.Add(new MusicFrame("Thời không sai lệch", "Ngải Thần", new TimeSpan(0, 3, 24), "Trung Quốc", 1, "Thoikhongsailech.jfif", "ThoiKhongSaiLech.mp3", "NgaiThan.jfif"));
            arrayList.Add(new MusicFrame("Tay trái chỉ chăng", "Tát Đỉnh Đỉnh", new TimeSpan(0, 3, 50), "Trung Quốc", 1, "Taytraichitrang.jfif", "TayTraiChiTrang.mp3", "Tatdinhdinh.jfif"));
            //Aumi
            arrayList.Add(new MusicFrame("Jingle Bell", "Boney M", new TimeSpan(0, 3, 27), "Âu Mỹ", 2, "jinglebell.jfif", "Jingle-Bell.mp3", "jinglebell.jfif"));
            arrayList.Add(new MusicFrame("lemon Tree", "Fools Garden", new TimeSpan(0, 3, 12), "Âu Mỹ", 2, "lemontree.jfif", "Lemon.mp3", "lemontree.jfif"));
            arrayList.Add(new MusicFrame("I got money", "Tom Media", new TimeSpan(0, 4, 32), "Âu Mỹ", 2, "igotmoney.jfif", "Igotmoney.mp3", "igotmoney.jfif"));
            arrayList.Add(new MusicFrame("Legends Naver Die", "Thang media", new TimeSpan(0, 3, 55), "Âu Mỹ", 2, "lgnever.jfif", "LegendsNeverDie.mp3", "lgnever.jfif"));

        }

        public void addUsers()
        {
            arrayList = new ArrayList();
            arrayList.Add(new User("QuangThang@gmail.com", "PhamQuangThang", "Quang Thắng", "Thang1@"));
            arrayList.Add(new User("1@gmail.com", "Thang1", "Nguyễn Trần Trung Quân", "Thang1@"));

        }


        public void addLikeMusic()
        {
            arrayList = new ArrayList();
        }
    }
}