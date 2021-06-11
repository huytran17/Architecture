using MISA.KienTruc.Core.Entities;
using MISA.KienTruc.Core.Intefaces.Repositories;
using MISA.KienTruc.Core.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Declare
        IBaseRepository<MISAEntity> _baseRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Methods
        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            //Trả về kết quả
            return _serviceResult;
        }

        public ServiceResult Insert(MISAEntity entity)
        {
            //Validate
            var isValid = ValidateObject(entity);
            //Nếu hợp lệ
            if (isValid == true)
            {
                _serviceResult.Data = new
                {
                    rowEffected = _baseRepository.Insert(entity)
                };
            }
            //Trả về kết quả
            return _serviceResult;
        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            //Validate
            var isValid = ValidateObject(entity);
            //Nếu hợp lệ
            if (isValid == true)
            {
                _serviceResult.Data = new
                {
                    rowEffected = _baseRepository.Update(entity, entityId)
                };
            }
            //Trả về kết quả
            return _serviceResult;
        }
        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng cần kiểm tra</param>
        /// <returns>true: Thành công, false: Thất bại</returns>
        /// Crated by: TVHUY (3-6-2021)
        bool ValidateObject(MISAEntity entity)
        {
            var isValid = true;
            //Xử lý validate chung:
            //Lấy tất cả thuộc tính của đối tượng MISAEntity
            var properties = entity.GetType().GetProperties();

            foreach (var prop in properties)
            {
                //Lấy tất cả thuộc tính được đánh dấu Required (bắt buộc nhập)
                var propRequired = prop.GetCustomAttributes(typeof(Required), true);
                //Lấy tất cả thuộc tính được đánh dấu MaxLength (lượng ký tự tối đa cho phép)
                var propMaxLength = prop.GetCustomAttributes(typeof(MaxLength), true);
                //Lấy tát cả thuộc tính được đánh dấu NotNegative (không âm)
                var propNotNegative = prop.GetCustomAttributes(typeof(NotNegative), true);
                //Lấy tất cả thuộc tính được đánh dấu DateInRange (giới hạn khoảng thời gian)
                var propDateInRange = prop.GetCustomAttributes(typeof(DateInRange), true);

                //Lấy tên và giá trị của thuộc tính
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                #region Required
                //Kiểm tra các thuộc tính bắt buộc nhập
                if (propRequired.Length > 0)
                {
                    //Lấy các thuộc tính được truyền vào lớp Required
                    var msg = (propRequired[0] as Required).Msg;

                    if (propValue.ToString() == string.Empty)
                    {
                        isValid = false;
                        _serviceResult.IsValid = false;

                        if (msg == string.Empty)
                        {
                            //Build thông báo lỗi
                            _serviceResult.SetMessage(String.Format("Trường {0} không được phép để trống", propName));
                            _serviceResult.Data = new
                            {
                                errorCode = 400,
                                errorStatus = "Bad Request"
                            };
                        }
                        else
                            _serviceResult.SetMessage(msg);
                    }
                }
                #endregion

                #region MaxLength
                //Kiểm tra độ dài tối đa của ký tự
                if (propMaxLength.Length > 0)
                {
                    //Lấy các thuộc tính được truyền vào lớp Maxlength
                    var maxLength = (propMaxLength[0] as MaxLength).Max;
                    var msg = (propMaxLength[0] as MaxLength).Msg;

                    if (propValue.ToString().Length > maxLength)
                    {
                        isValid = false;
                        _serviceResult.IsValid = false;

                        if (msg == string.Empty)
                        {
                            //Build thông báo lỗi
                            _serviceResult.SetMessage(String.Format("Trường {0} không được vượt quá {1} ký tự", propName, maxLength));
                            _serviceResult.Data = new
                            {
                                errorCode = 400,
                                errorStatus = "Bad Request"
                            };
                        }
                        else
                            _serviceResult.SetMessage(msg);
                    }
                }
                #endregion

                #region NotNegative
                //Kiểm tra giá trị không được âm
                if (propNotNegative.Length > 0)
                {
                    //Lấy các thuộc tính được truyền vào lớp Maxlength
                    var msg = (propNotNegative[0] as NotNegative).Msg;

                    if (int.Parse(propValue.ToString()) < 0)
                    {
                        isValid = false;
                        _serviceResult.IsValid = false;

                        if (msg == string.Empty)
                        {
                            //Build thông báo lỗi
                            _serviceResult.SetMessage(String.Format("Giá trị {0} không được phép âm", propName));
                            _serviceResult.Data = new
                            {
                                errorCode = 400,
                                errorStatus = "Bad Request"
                            };
                        }
                        else
                            _serviceResult.SetMessage(msg);
                    }
                }
                #endregion

                #region DateInRange
                //Kiểm tra giới hạn trong khoảng ngày-tháng-năm
                if (propDateInRange.Length > 0)
                {
                    if (propValue != null)
                    {
                        DateTime dateToCheck;
                        //Lấy các thuộc tính được truyền vào lớp Maxlength
                        var startDate = (propDateInRange[0] as DateInRange).StartDate;
                        var endDate = (propDateInRange[0] as DateInRange).EndDate;
                        var msg = (propDateInRange[0] as DateInRange).Msg;
                        DateTime.TryParse(propValue.ToString(), out dateToCheck);

                        if (dateToCheck < startDate || dateToCheck > endDate)
                        {
                            isValid = false;
                            _serviceResult.IsValid = false;

                            if (msg == string.Empty)
                            {
                                _serviceResult.SetMessage(String.Format("Trường {0} giới hạn từ {1} đến {2}", propName, startDate, endDate));
                                _serviceResult.Data = new
                                {
                                    errorCode = 400,
                                    errorStatus = "Bad Request"
                                };
                            }
                            else
                                _serviceResult.SetMessage(msg);
                        }
                    }
                }
                #endregion
            }
            return isValid;
        }
        #endregion
    }
}
