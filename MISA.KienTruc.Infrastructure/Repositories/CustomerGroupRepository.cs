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
    public class CustomerGroupRepository : BaseRepository<CustomerGroup>, ICustomerGroupRepository
    {
        #region Constructor
        public CustomerGroupRepository(IConfiguration configuration) : base (configuration)
        {

        }
        #endregion
    }
}
