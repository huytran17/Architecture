using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Entities
{
    #region Class
    /// <summary>
    /// Bắt buộc nhập
    /// </summary>
    class Required : Attribute
    {
        #region Declare
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Msg { get; set; }
        #endregion

        #region Constructor
        public Required(string msg = "")
        {
            Msg = msg;
        }
        #endregion
    }
    #endregion

    #region Class
    /// <summary>
    /// Giới hạn ký tự tối đa
    /// </summary>
    class MaxLength : Attribute
    {
        #region Declare
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// Số lượng ký tự tối đa cho phép
        /// </summary>
        public int Max { get; set; }
        #endregion

        #region Constructor
        public MaxLength(int max, string msg = "")
        {
            Max = max;
            Msg = msg;
        }
        #endregion
    }
    #endregion

    #region Class
    /// <summary>
    /// Số không được âm
    /// </summary>
    class NotNegative : Attribute
    {
        #region Declare
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Msg { get; set; }
        #endregion
        #region Constructor
        public NotNegative(string msg = "")
        {
            Msg = msg;
        }
        #endregion
    }
    #endregion

    #region Class
    /// <summary>
    /// Giới hạn ngày trong khoảng cho phép
    /// </summary>
    class DateInRange : Attribute
    {
        #region Declare
        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string Msg { get; set; }
        #endregion

        #region Constructor
        public DateInRange(string startDate, string endDate, string msg = "")
        {
            StartDate = DateTime.Parse(startDate);
            EndDate = DateTime.Parse(endDate);
            Msg = msg;
        }
        #endregion
    }
    #endregion
}
