using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BaiTap5.Models
{
    public class RegistrationModel
    {
        [DisplayName("Mã nhân viên: ")]
        public string empID { get; set; }
        [DisplayName("Họ tên: ")]

        public string empName { get; set; }
        [DisplayName("Ngày sinh: ")]

        public DateTime empDateOfBirth { get; set; }
        [DisplayName("Email: ")]

        public string empEmail { get; set; }
        [DisplayName("Mật khẩu: ")]

        public string empPassword { get; set; }
        [DisplayName("Đơn vị: ")]

        public string empDivision { get; set; }
        [DisplayName("Chọn ảnh:  ")]

        public string empImg { get; set; }
        public HttpPostedFileBase imgFile { get; set; }
    }
}