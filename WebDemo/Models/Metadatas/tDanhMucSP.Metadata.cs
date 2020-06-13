using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Models
{
    [MetadataType(typeof(tDanhMucSPMetadata))]
    public partial class tDanhMucSP
    {
        internal sealed class tDanhMucSPMetadata
        {
            [Display(Name = "Mã sản phẩm:")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string MaSP { get; set; }



            [Display(Name = "Tên sản phẩm:")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenSP { get; set; }



            [Display(Name = "Mã chất liệu:")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string MaChatLieu { get; set; }



            [Display(Name = "Ngăn Laptop:")]
            public string NganLapTop { get; set; }
            public string Model { get; set; }



            [Display(Name = "Màu sắc:")]
            public string MauSac { get; set; }



            [Display(Name = "Kích thước:")]
            public string MaKichThuoc { get; set; }
            [Display(Name = "Cân nặng:")]
            public Nullable<double> CanNang { get; set; }
            [Display(Name = "Độ nới:")]
            public Nullable<double> DoNoi { get; set; }
            [Display(Name = "Mã hãng sản xuất:")]
            public string MaHangSX { get; set; }
            [Display(Name = "Mã nước sản xuất:")]
            public string MaNuocSX { get; set; }
            [Display(Name = "Mã đặc tính:")]
            public string MaDacTinh { get; set; }
            public string Website { get; set; }
            [Display(Name = "Thời gian bảo hành:")]
            public Nullable<double> ThoiGianBaoHanh { get; set; }
            [Display(Name = "Giới thiệu sản phẩm:")]
            public string GioiThieuSP { get; set; }
            public Nullable<double> Gia { get; set; }
            public Nullable<double> ChietKhau { get; set; }
            public string MaLoai { get; set; }
            public string MaDT { get; set; }
            public string Anh { get; set; }
        }
    }
}