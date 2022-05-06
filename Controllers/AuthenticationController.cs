using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyPowerApiNew.LogService;
using BuyPowerApiNew.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BuyPowerApiNew.DataTransferObjects;
using BuyPowerApiNew.Authentication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace BuyPowerApiNew.Controllers
{
  
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogWriter _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        private readonly RepositoryContext _db;

        public AuthenticationController(ILogWriter logger, IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager, RepositoryContext db)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _db = db;

        }


        [HttpPost]
        [Route("api/Authentication")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<User>(userForRegistration);

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogWrite($"{nameof(RegisterUser)}: Registration Failed. Invalid Email or Invalid Username or Pssword." + Environment.NewLine + DateTime.Now, "Error");
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            _logger.LogWrite($"{nameof(RegisterUser)}: StatusCode201. Created." + Environment.NewLine + DateTime.Now, "Response");
            // await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }


        [HttpPost]
        [Route("api/Login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            int respCode;
            string responseString = "";
            AuthLoginResponse resp;
            DateTime requestTime;
            DateTime responseTime;
            tblAuthRequestAndResponseLog requestForDb = new tblAuthRequestAndResponseLog();
            UserForAuthenticationDto _user = new UserForAuthenticationDto();
            HttpResponseMessage httpResponseMsg;
            AuthLoginResponse myOwnResp;
            if (string.IsNullOrEmpty(user.RequestId) || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("ErrorMessage : Username,Password,RequsetId is required");
            }
              

            if (!await _authManager.ValidateUser(user))
            {
                requestTime = DateTime.Now;
                responseTime = DateTime.Now;
                requestForDb = new tblAuthRequestAndResponseLog() { RequestType = "Login", RequestPayload = JsonConvert.SerializeObject(user), RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestId = user.RequestId };


                httpResponseMsg = new HttpResponseMessage();
                respCode = (int)httpResponseMsg.StatusCode;

                httpResponseMsg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "401 - Unauthorized, Invalid Username or Password!!!" };
                responseString = httpResponseMsg.ReasonPhrase.ToString();

                responseTime = DateTime.Now;
                requestForDb.ResponseTimestamp = responseTime;


                myOwnResp = new AuthLoginResponse();
                myOwnResp.authenticated = false;
                myOwnResp.message = responseString;
                myOwnResp.name = "";
                resp = myOwnResp;

                requestForDb.Response = responseString;
                _db.tblAuthRequestAndResponseLog.Add(requestForDb);
                await _db.SaveChangesAsync();

                _logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong user name or password." + Environment.NewLine + DateTime.Now, "Error");
                return Unauthorized();
            }
            else
            {
    
                try
                {
                    if (await _authManager.ValidateUser(user))
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblAuthRequestAndResponseLog() { RequestType = "Login", RequestPayload = JsonConvert.SerializeObject(user), RequestTimestamp = DateTime.Now, RequestId = user.RequestId };


                        httpResponseMsg = new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Login Successful!!!" };
                        respCode = (int)httpResponseMsg.StatusCode;
                        responseString = httpResponseMsg.ReasonPhrase.ToString();

                        responseTime = DateTime.Now;
                        requestForDb.ResponseTimestamp = responseTime;

                        myOwnResp = new AuthLoginResponse();
                        myOwnResp.authenticated = false;
                        myOwnResp.message = responseString;
                        myOwnResp.name = "";
                        resp = myOwnResp;


                        requestForDb.Response = responseString;
                        _db.tblAuthRequestAndResponseLog.Add(requestForDb);
                        await _db.SaveChangesAsync();
                    }
                    
                }
                catch (WebException e)
                {

                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return Ok(new { Token = await _authManager.CreateToken() });
            }
           
        }

    }
}
