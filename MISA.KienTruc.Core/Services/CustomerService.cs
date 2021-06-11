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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Declare
        ICustomerRepository _customerRepository;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
    }
}
