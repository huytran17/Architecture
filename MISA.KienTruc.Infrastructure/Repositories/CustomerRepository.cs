using Microsoft.Extensions.Configuration;
using MISA.KienTruc.Core.Entities;
using MISA.KienTruc.Core.Intefaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.KienTruc.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {

        #region Constructor
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
    }
}
