using FinCluTech.BusinessObject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinCluTech.Core.Customer
{
    public class CustomerValidator : AbstractValidator<CustomerBo>
    {
        public CustomerValidator()
        {

        }
    }
}
