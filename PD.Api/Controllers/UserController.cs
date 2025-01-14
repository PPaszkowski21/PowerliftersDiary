﻿using PD.Services.Contracts.Api.UserDetails.Requests;
using PD.Services.Contracts.Api.Users.Requests;
using PD.Services.Services;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace PD.Api.Controllers
{

    [RoutePrefix("user")]
    public class UserController : BaseApiController
    {
        private readonly UserService _userService;
        public UserController()
        {
            this._userService = new UserService();
        }

        
        [HttpPost]
        [Route("authorization/test")]
        public IHttpActionResult Test(AddUserRequest user)
        {
            var currentUser = _userService.GetUserModelFromRequest(Request);
            return ResponseMessage(CreateCustomResponseMessage(currentUser));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(AddUserRequest user)
        {
            if (user == null || !ModelState.IsValid) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.Add(user);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        //[HttpGet]
        //[Route("read")]
        //public IHttpActionResult Read()
        //{
        //    var result = _userService.Read();
        //    return ResponseMessage(CreateCustomResponseMessage(result));
        //}

        [HttpGet]
        [Route("get")]
        public IHttpActionResult ReadById(int id)
        {
            if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.ReadById(id);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpDelete]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.Delete(id);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(UpdateUserRequest user)
        {
            if (user.Id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.Update(user);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpPost]
        [Route("adddetails")]
        public IHttpActionResult AddDetails(AddUserDetailsRequest user)
        {
            if (user == null || !ModelState.IsValid) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var userService = _userService;
            var result = userService.AddDetails(user);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpPut]
        [Route("updatedetails")]
        public IHttpActionResult UpdateDetails(UpdateUserDetailsRequest user)
        {
            if (user == null || !ModelState.IsValid) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.UpdateDetails(user);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpPost]
        [Route("addavatar")]
        public IHttpActionResult AddAvatar(AddAvatarRequest avatar)
        {
            if (avatar == null || !ModelState.IsValid) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result =_userService.AddAvatar(avatar);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpGet]
        [Route("getavatar")]
        public IHttpActionResult GetAvatar(int id)
        {
            if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.GetAvatar(id);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpDelete]
        [Route("deleteavatar")]
        public IHttpActionResult DeleteAvatar(int id)
        {
            if (id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.DeleteAvatar(id);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }

        [HttpPost]
        [Route("savebranding")]
        public IHttpActionResult SaveBrandingSettings(SaveBrandingRequest request)
        {
            if (request.Id <= 0) return ResponseMessage(CreateCustomResponseMessage(HttpStatusCode.BadRequest));
            var result = _userService.SaveBrandingSettings(request);
            return ResponseMessage(CreateCustomResponseMessage(result));
        }
    }
}