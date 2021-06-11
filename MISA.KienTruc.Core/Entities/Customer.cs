using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Entities
{
    public class Customer
    {
        #region Declare
        /// <summary>
        /// id khách hàng
        /// </summary>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// mã khach hàng
        /// </summary>
        /// 
        [Required("Mã khách hàng không được để trống")]
        [MaxLength(10, "Mã khách hàng tối đa 10 ký tự")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// họ và đệm
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// tên khách hàng
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// tên đầy đủ
        /// </summary>
        /// 
        [Required("Họ và tên không được phép để trống")]
        public string FullName { get; set; }
        /// <summary>
        /// giới tính
        /// </summary>
        /// 
        //[MISARequired]
        public int? Gender { get; set; }
        /// <summary>
        /// địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// sinh nhật
        /// </summary>
        /// 
        [DateInRange("2021-05-31 13:00:01", "2021-12-29 11:00:00")]
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// địa chỉ email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// id nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// số tiền nợ
        /// </summary>
        /// 
        [NotNegative("Số tiền nợ không thể âm")]
        public double? DebitAmout { get; set; } = 0;
        /// <summary>
        /// mã thẻ thành viên
        /// </summary>
        public string MemberCardCode { get; set; }
        /// <summary>
        /// tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// trạng thái theo dõi
        /// </summary>
        public bool? IsStopFollow { get; set; } = false;
        /// <summary>
        /// ngày tạo
        /// </summary>
        /// 
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// tạo bởi
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// ngày chỉnh sửa
        /// </summary>
        /// 
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// chỉnh sửa bởi
        /// </summary>
        public string ModifiedBy { get; set; }
        #endregion
    }
}
