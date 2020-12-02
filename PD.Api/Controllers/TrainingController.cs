﻿using PD.Services.Contracts.Api.TrainingUnits.Requests;
using PD.Services.Services;
using System.Net;
using System.Web.Http;

namespace PD.Api.Controllers
{
    [RoutePrefix("training")]
    public class TrainingController : BaseApiController
    {
        private readonly TrainingService _trainingService;

        public TrainingController()
        {
            this._trainingService = new TrainingService();
        }
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(AddTrainingUnitRequest trainingUnitRequest)
        {
            if (trainingUnitRequest == null || !ModelState.IsValid) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _trainingService.Add(trainingUnitRequest);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        //[HttpGet]
        //[Route("read")]
        //public IHttpActionResult Read()
        //{
        //    var result = _trainingService.Read();
        //    return ResponseMessage(CreateCustomResponseMessage(result));
        //}

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadById(int id)
        {
            if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _trainingService.ReadById(id);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        //[HttpDelete]
        //[Route("delete")]
        //public IHttpActionResult Delete(int id)
        //{
        //    if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
        //    var result = _trainingService.Delete(id);
        //    return ResponseMessage(CreateCustomResponseMessage(result));
        //}
    }
}