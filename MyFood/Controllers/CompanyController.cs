﻿using AutoMapper;
using MyFood.Framework.Contracts.DAO;
using MyFood.Framework.Utils;
using MyFood.Model;
using MyFood.ViewModel;

namespace MyFood.Controllers
{
    public class CompanyController : BaseApiController<CompanyView, Company>
    {
        public CompanyController(IRepository<Company> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
