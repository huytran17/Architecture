using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.KienTruc.Core.Entities;
using MISA.KienTruc.Core.Intefaces.Repositories;
using MISA.KienTruc.Core.Intefaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.KienTruc.API.Controllers
{
    public class CustomerController : MISABaseController<Customer>
    {
        #region Declare
        ICustomerService _customerService;
        ICustomerRepository _customerRepository;
        #endregion

        #region Constructor
        public CustomerController(ICustomerService customerService,
        ICustomerRepository customerRepository) : base(customerService, customerRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
        }
        #endregion
    }
}
