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
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        #region Declare
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        #region Constructor
        public CustomerGroupService(ICustomerGroupRepository customerGroupRepository) : base (customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
        #endregion
    }
}
