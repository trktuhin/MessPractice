using System;
using System.Linq;
using AutoMapper;
using Mess.Core;
using Mess.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Mess.Controllers.Base
{
    [ApiController]
    public class BaseController<TResource, TModel, TRepository>:ControllerBase
    where TModel:class, new() where TRepository:IBaseRepository<TModel>
    {
        protected readonly TRepository _repo;
        protected readonly IUnitOfWork _work;
        protected readonly IMapper _mapper;

        protected bool _isInvalid;
        protected string _message;
        public BaseController(TRepository repo, IUnitOfWork work, IMapper mapper)
        {
            _repo=repo;
            _work=work;
            _mapper=mapper;
        }

        protected virtual TModel BeforeCreate(TModel model){
            return model;
        }

        protected virtual TModel BeforeCreate(TModel model, TResource resorce){
            return model;
        }

        [HttpPost("Create")]
        public IActionResult Create(TResource resource){
            if(!ModelState.IsValid){
                return BadRequest("Model is not valid");
            }
            try{
                var model=_mapper.Map<TResource,TModel>(resource);

                BeforeCreate(model);
                BeforeCreate(model,resource);

                if(_isInvalid){
                    return BadRequest(_message);
                }
                
                var modelInDb=_repo.Add(model);
                _work.Complete();
                return Ok(_mapper.Map<TModel,TResource>(modelInDb));
            }
            catch(Exception e){
                return BadRequest("Sorry, something went wrong");
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(){
            try{
                var models=_repo.GetAll();
                return Ok(models.Select(_mapper.Map<TModel,TResource>));
            }
            catch(Exception e){
                return BadRequest("Something went wrong");
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetSingle(int id){
            try{
                var model=_repo.Get(id);
                return Ok(_mapper.Map<TModel,TResource>(model));
            }
            catch(Exception e){
                return BadRequest("Something went wrong");
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id){
            try{
                var model=_repo.Get(id);
                _repo.Remove(model);
                _work.Complete();
                return Ok(model);
            }
            catch(Exception e){
                return BadRequest("Something went wrong");
            }
        }
    }
}