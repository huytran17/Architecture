using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Intefaces.Repositories
{
    public interface IBaseRepository<MISAEntity>
    {
        #region Methods
        /// <summary>
        /// Lấy tất cả các đối tượng MISAEntity
        /// </summary>
        /// <returns>Tất cả đối tượng MISAEntity</returns>
        /// Created by: TVHUY (3-6-2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy đối tượng MISAEntity theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng MISAEntity</param>
        /// <returns>1 đối tượng MISAEntity</returns>
        /// Created by: TVHUY (3-6-2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm mới một đối tượng MISAEntity
        /// </summary>
        /// <param name="entity">Đối tượng MISAEntity cần thêm</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        int? Insert(MISAEntity entity);

        /// <summary>
        /// Cập nhật một đối tượng MISAEntity theo ID
        /// </summary>
        /// <param name="entity">Đối tượng MISAEntity cần cập nhật</param>
        /// <param name="entityId">ID của đối tượng MISAEntity cần cập nhật</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        int? Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa 1 đối tượng MISAEntity theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng MISAEntity cần xóa</param>
        /// <returns>Đối tượng chứa kết quả thực thi</returns>
        /// Created by: TVHUY (3-6-2021)
        int? Delete(Guid entityId);
        #endregion
    }
}
