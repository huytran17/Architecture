using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Entities
{
    public class ServiceResult
    {
        #region Declare
        /// <summary>
        /// Có hợp lệ hay không
        /// </summary>
        public bool IsValid { get; set; } = true;
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public List<string> Messages { get; set; } = new List<string>();
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
        #endregion

        #region Methods
        public void SetMessage(string msg)
        {
            Messages.Add(msg);
        }
        #endregion
    }
}
