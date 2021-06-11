using MISA.KienTruc.Core.Entities;
using MISA.KienTruc.Core.Intefaces.Repositories;
using MISA.KienTruc.Core.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.KienTruc.API.Controllers
{
    public class CustomerGroupController : MISABaseController<CustomerGroup>
    {
        #region Declare
        ICustomerGroupService _customerGroupService;
        ICustomerGroupRepository _customerGroupRepository;
        #endregion

        #region Constructor
        public CustomerGroupController(ICustomerGroupService customerGroupService,
        ICustomerGroupRepository customerGroupRepository) : base (customerGroupService, customerGroupRepository)
        {
            _customerGroupService = customerGroupService;
            _customerGroupRepository = customerGroupRepository;
        }
        #endregion
    }
}
