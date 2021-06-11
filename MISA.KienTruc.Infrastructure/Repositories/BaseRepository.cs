using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.KienTruc.Core.Entities;
using MISA.KienTruc.Core.Intefaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Infrastructure.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Declare
        protected IDbConnection DbConneciton;
        protected string ClassName;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {
            DbConneciton = new MySqlConnection(configuration.GetConnectionString("CukCuk"));
            ClassName = typeof(MISAEntity).Name;
        }
        #endregion

        #region Methods
        public int? Delete(Guid entityId)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Build câu truy vấn
            var sqlCommand = $"DELETE FROM {ClassName} WHERE {ClassName}Id = @{ClassName}Id";
            parameters.Add($"@{ClassName}Id", entityId);
            //Thực thi câu truy vấn
            var rowEffected = DbConneciton.Execute(sqlCommand, parameters);
            //Trả về kết quả
            return rowEffected;
        }

        public List<MISAEntity> GetAll()
        {
            //Câu truy vấn
            var sqlCommand = $"SELECT * FROM {ClassName}";
            //Thực thi câu truy vấn
            var customers = DbConneciton.Query<MISAEntity>(sqlCommand).ToList();
            //Trả về kết quả
            return customers;
        }

        public MISAEntity GetById(Guid entityId)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Build câu truy vấn
            var sqlCommand = $"SELECT * FROM {ClassName} WHERE {ClassName}Id = @{ClassName}Id";
            //Gán giá trị động trong câu truy vấn
            parameters.Add($"@{ClassName}Id", entityId);
            //Thực thi câu truy vấn
            var customer = DbConneciton.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
            //Trả về kết quả
            return customer;
        }

        public int? Insert(MISAEntity entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Lấy tất cả thuộc tính của đối tượng MISAEntity
            var properties = entity.GetType().GetProperties();
            //Chuỗi key-value tương ứng
            var paramFields = string.Empty;
            var paramValues = string.Empty;

            foreach (var prop in properties)
            {
                //Láy ra thuộc tính và giá trị của thuộc tính
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                //Tạo 1 id mới
                if (propName == $"{ClassName}Id")
                {
                    propValue = Guid.NewGuid();
                }

                //Tạo chuỗi key-value
                paramFields += $"{propName},";
                paramValues += $"@{propName},";

                parameters.Add($"@{propName}", propValue);
            }

            //Build câu truy vấn
            var sqlCommand = $"INSERT INTO {ClassName} ({paramFields.Substring(0, paramFields.Length - 1)}) " +
                $"VALUES ({paramValues.Substring(0, paramValues.Length - 1)})";
            //Thực thi câu truy vấn
            var rowEffected = DbConneciton.Execute(sqlCommand, param: parameters);
            //Trả về kết quả
            return rowEffected;
        }

        public int? Update(MISAEntity entity, Guid entityId)
        {
            DynamicParameters parameters = new DynamicParameters();
            //Lấy tất cả thuộc tính của đối tượng MISAEntity
            var properties = entity.GetType().GetProperties();
            //Các cặp key-value
            var paramKeyValues = string.Empty;

            foreach (var prop in properties)
            {
                //Lấy tên và giá trị của thuộc tính
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                //Không cập nhật lại ID
                if (propName != $"{ClassName}Id")
                {
                    paramKeyValues += $"{propName} = @{propName},";
                }
                parameters.Add($"@{propName}", propValue);
            }

            //Build câu truy vấn
            var sqlCommand = $"UPDATE {ClassName} SET " +
                $"{paramKeyValues.Substring(0, paramKeyValues.Length - 1)} WHERE {ClassName}Id = @{ClassName}Id";
            parameters.Add($"@{ClassName}Id", entityId);

            //Thực thi câu truy vấn
            var rowEffected = DbConneciton.Execute(sqlCommand, param: parameters);
            //Trả về kết quả
            return rowEffected;
        }
        #endregion
    }
}
