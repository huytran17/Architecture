using MISA.KienTruc.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Intefaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        #region Methods
        /// <summary>
        /// Thêm mới một đối tượng MISAEntity
        /// </summary>
        /// <param name="entity">Đối tượng MISAEntity cần thêm</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        ServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật một đối tượng MISAEntity theo ID
        /// </summary>
        /// <param name="entity">Đối tượng MISAEntity cần cập nhật</param>
        /// <param name="entityId">ID của đối tượng MISAEntity cần cập nhật</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        ServiceResult Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa 1 đối tượng MISAEntity theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng MISAEntity cần xóa</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        ServiceResult Delete(Guid entityId);
        #endregion
    }
}
