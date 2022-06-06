using FinCluTech.BusinessObject.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinCluTech.Core.User
{
    public class UserValidator : AbstractValidator<UserBo>
    {
        public UserValidator()
        {

        }
    }
}
