using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstWebSite.Data
{
    public class HangHoa
    {
        public Guid MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public DateTime NgaySx { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public double GiaBan { get; set; }
        public string Mota { get; set; }
        public string ChiTiet { get; set; }
        public double GiamGia { get; set; }
        public Loai Loai { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ReviewHangHoa> ReviewHangHoas { get; set; }
        public ICollection<HinhPhu> HinhPhus { get; set; }
        public ICollection<HangHoaTag> HangHoaTags { get; set; }
        
        public double? DiemReview { get; set; }
        public int MaLoai { get; set; }
    }

    public class Review
    {
        public int IdR { get; set; }
        public string Criteria { get; set; }
        public bool Active { get; set; }
        public ICollection<ReviewHangHoa> ReviewHangHoas { get; set; }
    }

    public class ReviewHangHoa
    {
        public Guid Id { get; set; }
        public DateTime NgayReview { get; set; }
        public byte DiemReview { get; set; }
        public int TieuChi { get; set; }
        public Guid MaHangHoa { get; set; }
        [ForeignKey("TieuChi")]
        public Review Review { get; set; }
        [ForeignKey("MaHangHoa")]
        public HangHoa HangHoa { get; set; }
    }

    public class HinhPhu
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool Active { get; set; }
        public Guid? MaHangHoa { get; set; }
        public HangHoa HangHoa { get; set; }
    }

    public class HangHoaTag
    {
        public string TagKey { get; set; }
        public Guid MaHangHoa { get; set; }
        public HangHoa HangHoa { get; set; }
        public Tag Tag { get; set; }
    }
    public class Tag
    {
        public virtual ICollection<HangHoaTag> HangHoaTags { get; set; }
        public string TagKey { get; set; }
        public string TagValue { get; set; }
    }
}
