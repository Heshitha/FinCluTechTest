using FinCluTech.BusinessObject.Models;
using FinCluTech.Common.Models;
using FinCluTech.DataAccess.Customer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCluTech.Core.Customer
{
    public class CustomerManager : BaseManager<CustomerBo>, ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public override async Task<ResponseModel> Delete(int ID)
        {
            var res = await _customerRepository.Delete(ID);
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = 1
            };
            return resObj;
        }

        public override async Task<ResponseModel> Get(int ID)
        {
            var res = await _customerRepository.Get(ID);
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = 1
            };
            return resObj;
        }

        public override async Task<ResponseModel> GetAll()
        {
            var res = await _customerRepository.GetAll();
            var resObj = new ResponseModel()
            {
                Data = res,
                ErrorMessage = "",
                IsError = false,
                RecordCount = res.Count
            };
            return resObj;
        }

        public override async Task<ResponseModel> Save(CustomerBo item)
        {
            CustomerValidator validator = new CustomerValidator();
            var validationResult = validator.Validate(item);
            if (validationResult.IsValid)
            {
                var res = item.ID != 0 ? await _customerRepository.Update(item) : await _customerRepository.Create(item);
                var resObj = new ResponseModel()
                {
                    Data = res,
                    ErrorMessage = "",
                    IsError = false,
                    RecordCount = 1
                };
                return resObj;
            }
            else
            {
                var resObj = new ResponseModel()
                {
                    ErrorMessage = validationResult.Errors.FirstOrDefault().ErrorMessage,
                    IsError = true
                };
                return resObj;
            }
        }

        public async Task<ResponseModel> SaveBulk(List<CustomerBo> full)
        {
            foreach(var item in full)
            {
                item.CreatedDate = DateTime.Now;
            }
            var res = await _customerRepository.UploadBulk(full);
            return res;
        }
    }
}
