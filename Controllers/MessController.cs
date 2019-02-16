using AutoMapper;
using Mess.Controllers.Base;
using Mess.Core;
using Mess.Core.Repositories;
using Mess.Models;
using Mess.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Mess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessController:BaseController<MessResource, SmartMess, IMessRepository>
    {
        public MessController(IMessRepository repository, IUnitOfWork work,IMapper mapper)
        :base(repository,work,mapper)
        {}
    }
}