using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BuyPowerApiNew.LogService;
using BuyPowerApiNew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace BuyPowerApiNew.Controllers
{
    [ApiController]
    public class BuyPowerApiController : ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly ILogWriter _logger;
        private readonly RepositoryContext _db;


        public BuyPowerApiController(IHttpClientFactory clientFactory, IConfiguration config, ILogWriter logger, RepositoryContext db)
        {
            _clientFactory = clientFactory;
            _config = config;
            _logger = logger;
            _db = db;
        }

        [Authorize]
        [HttpGet]
        [Route("api/BuyPowerApi/GetAddressLookup")]
        public async Task<object> GetAddressLookup(AddressLookup al)
        {

            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var addLook = _config.GetSection("GetAddressLookupUrl").Value.ToString();
            var Auth = _config.GetSection("token").Value;

            object lookupInfo = new object();

            using (var addlook = new HttpClient())
            {
                addlook.BaseAddress = new Uri(baseurl);
                addlook.DefaultRequestHeaders.Accept.Clear();
                addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                addlook.Timeout = new System.TimeSpan(0, 0, 1, 0);
                addlook.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = await addlook.GetAsync(addLook);
                var lookupResponse = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {

                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "GetAddressLookup", RequestPayload = JsonConvert.SerializeObject(al), Response = JsonConvert.SerializeObject(lookupResponse), RequestId = al.RequestId, Client = al.Client, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseurl };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                            "REQUEST :" + ("Method Call: api/BuyPower/GetAddressLookup") + Environment.NewLine +
                             addlook.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BuyPower/GetAddressLookup") + Environment.NewLine +
                              "RESPONSE :" + lookupResponse + Environment.NewLine + addlook.Timeout + DateTime.Now + al.RequestId, "Response");
                    }

                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(lookupResponse), RequestId = al.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();


                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BuyPower/GetAddressLookup") + Environment.NewLine +
                              "RESPONSE :" + lookupResponse + Environment.NewLine + addlook.Timeout + al.RequestId + DateTime.Now, "Error");
                        return lookupResponse;
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
                return lookupResponse;
            }

        }

        [Authorize]
        [HttpGet]
        [Route("api/BuyPowerApi/GetFacilityLookup")]
        public async Task<object> GetFacilityLookup(FacilityLookup fl)
        {
            var reference = _config.GetSection("FacilityRefrenceNo").Value;
            var Auth = _config.GetSection("token").Value;
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var facLook = _config.GetSection("GetFacilityLookupUrl").Value.ToString();
            object lookupInfo = new object();

            using (var addlook = new HttpClient())
            {
                addlook.BaseAddress = new Uri(baseurl);
                addlook.DefaultRequestHeaders.Accept.Clear();
                addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                addlook.Timeout = new System.TimeSpan(0, 0, 1, 0);
                addlook.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = await addlook.GetAsync(facLook);
                var FacilitylookupResponse = await resp.Content.ReadAsStringAsync();
                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {

                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "GetFacilityLookup", RequestPayload = JsonConvert.SerializeObject(fl), Response = JsonConvert.SerializeObject(FacilitylookupResponse), RequestId = fl.RequestId, Client = fl.Client, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseurl };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        lookupInfo = JsonConvert.DeserializeObject<object>(FacilitylookupResponse);
                        _logger.LogWrite(baseurl + Environment.NewLine +
                        "REQUEST URL ENDPOINT :" + (facLook) + Environment.NewLine +
                        "REQUEST :" + ("Method Call: api/BuyPower/GetFacilityLookup")
                        + Environment.NewLine + fl.RequestId + Environment.NewLine + addlook.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                        "REQUEST URL ENDPOINT : " + (facLook) + Environment.NewLine +
                         "REQUEST : " + ("Method Call: api/BuyPower/GetFacilityLookup") + Environment.NewLine +
                         "RESPONSE : " + FacilitylookupResponse + Environment.NewLine + fl.RequestId + Environment.NewLine + addlook.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(FacilitylookupResponse), RequestId = fl.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                        "REQUEST URL ENDPOINT :" + (facLook) + Environment.NewLine +
                        "REQUEST : " + ("Method Call: api/BuyPower/GetFacilityLookup") + Environment.NewLine +
                         "RESPONSE : " + FacilitylookupResponse + Environment.NewLine + addlook.Timeout + DateTime.Now, "Error");
                        return FacilitylookupResponse;
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

                return FacilitylookupResponse;
            }
        }


        [Authorize]
        [HttpGet]
        [Route("api/BuyPowerApi/GetAccounntBalance")]
        public async Task<object> GetAccountBalance(Balance bl)
        {
            var Auth = _config.GetSection("token").Value;
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var GetBal = _config.GetSection("GetAccountBalanceUrl").Value.ToString();
            object lookupInfo = new object();

            using (var addlook = new HttpClient())
            {
                addlook.BaseAddress = new Uri(baseurl);
                addlook.DefaultRequestHeaders.Accept.Clear();
                addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                addlook.Timeout = new System.TimeSpan(0, 0, 1, 0);
                addlook.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var resp = await addlook.GetAsync(GetBal);
                var BalancelookupResponse = await resp.Content.ReadAsStringAsync();
                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();

                    if (resp.IsSuccessStatusCode)
                    {

                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "GetAccountBalance", RequestPayload = JsonConvert.SerializeObject(bl), Response = JsonConvert.SerializeObject(BalancelookupResponse), RequestId = bl.RequestId, Client = bl.Client, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestUrl = baseurl };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        lookupInfo = JsonConvert.DeserializeObject<object>(BalancelookupResponse);
                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (GetBal) + Environment.NewLine +
                             ("Method Call: api/BuyPower/GetAccounntBalance") + Environment.NewLine + bl.RequestId + Environment.NewLine +
                            addlook.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (GetBal) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BuyPower/GetAccounntBalance") + Environment.NewLine +
                           "RESPONSE :" + BalancelookupResponse + Environment.NewLine + bl.RequestId + Environment.NewLine + addlook.Timeout + DateTime.Now, "Response");
                    }

                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(BalancelookupResponse), RequestId = bl.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                             "REQUEST URL ENDPOINT :" + (GetBal) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BuyPower/GetAccounntBalance") + Environment.NewLine +
                             "RESPONSE :" + BalancelookupResponse + Environment.NewLine + bl.RequestId + Environment.NewLine + addlook.Timeout + DateTime.Now, "Error");
                        return BalancelookupResponse;
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
                return BalancelookupResponse;

            }
        }






    }
}
