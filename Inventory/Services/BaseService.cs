using AutoMapper;
using Inventory.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public class BaseService 
    {
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected internal IUnitOfWork UnitOfWork { get; set; }
        protected internal IMapper Mapper { get; set; }
    }
}
