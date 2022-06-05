﻿using CourseWork2AspNetServer.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;

namespace CourseWork2AspNetServer.Controllers;

[ApiController]
[Route("[controller]")]
public class OAuthController : ControllerBase
{
    private readonly ILogger<OAuthController> _logger;

    public OAuthController(ILogger<OAuthController> logger)
    {
        _logger = logger;
    }

    public static OAuth? GenerateOAuth(string eMail, string md5Password, string deviceInformation)
    {
        Patient? patient = Program.Db.Patients.FirstOrDefault(p => p.Email == eMail);
        if (patient == null)
            return null;
        if (patient.Password != md5Password)
            return null;
        OAuth? oAuth = patient.Tokens.FirstOrDefault(t => t.DeviceInformation == deviceInformation);
        if (oAuth == null)
        {
            oAuth = new OAuth()
            {
                CreateTime = DateTime.Now,
                DeviceInformation = deviceInformation,
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            };
            while (Program.Db.OAuths.Count(o => oAuth.Token == o.Token) != 0)
            {
                oAuth = new OAuth()
                {
                    CreateTime = DateTime.Now,
                    DeviceInformation = deviceInformation,
                    Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                };
            }
            patient.Tokens.Add(oAuth);
            Program.Db.SaveChangesTask.Start();
        }
        return oAuth;
    }

    public class TokenClass
    {
        public string Token { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
    }

    // [HttpGet]
    // public TokenClass? Get(string eMail, string md5Password, string deviceInformation)
    // {
    //     OAuth? oAuth = GenerateOAuth(eMail, md5Password, deviceInformation);
    //     // _logger.Log(LogLevel.Information, "Response.Body");
    //     // _logger.Log(LogLevel.Information, HttpContext.Response.Body.ToString());
    //     // _logger.Log(LogLevel.Information, "Response.Headers1");
    //     // _logger.Log(LogLevel.Information, HttpContext.Response.Headers.AccessControlAllowHeaders);
    //     // HttpContext.Response.Headers.AccessControlAllowHeaders = "http://localhost:52392/";
    //     // // Response.Headers.Add("access-control-allow-headers", "*");
    //     // _logger.Log(LogLevel.Information, "Response.Headers2");
    //     // _logger.Log(LogLevel.Information, HttpContext.Response.Headers.AccessControlAllowHeaders);
    //     // _logger.Log(LogLevel.Information, "Request.Headers1");
    //     // _logger.Log(LogLevel.Information, HttpContext.Request.Headers.AccessControlAllowHeaders);
    //     // HttpContext.Request.Headers.AccessControlAllowHeaders = "http://localhost:62522/";
    //     // Request.Headers.Add("access-control-allow-headers", "*");
    //     // _logger.Log(LogLevel.Information, "Request.Headers2");
    //     // _logger.Log(LogLevel.Information, HttpContext.Request.Headers.AccessControlAllowHeaders);
    //     // Response.Headers.Add("X-Developed-By", "Your Name");
    //     // Response.Headers.Add("access-control-allow-credentials", "true");
    //     // Response.Headers.Add("access-control-allow-headers", Request.Headers.Origin);
    //     if (oAuth == null)
    //     {
    //         Response.StatusCode = 200;
    //         //return null;
    //         return new TokenClass()
    //         {
    //             Token = "123",
    //             Name = "Name",
    //             Surname = "Surname"
    //         };
    //     }
    //     return new TokenClass()
    //     {
    //         Token = oAuth.Token,
    //         Name = oAuth.Patient.Name,
    //         Surname = oAuth.Patient.Surname,
    //         MiddleName = oAuth.Patient.MiddleName,
    //     };
    // }

    [HttpGet]
    public TokenClass? Get()
    {
    //     access - control - allow - credentials: true
    //     access - control - allow - origin: https://yandex.ru
    //     cache - control: private, no-cache, no-store, must-revalidate, max-age=0
    // content-length: 351
    // content-type: application/json; charset=utf-8
    // date: Sun, 05 Jun 2022 11:23:06 GMT
    //     expires: Sun, 05-Jun-2022 11:23:06 GMT
    //     last-modified: Sun, 05-Jun-2022 11:23:06 GMT
    //     pragma: no-cache
    //     strict-transport-security: max-age=31536000
    // x-content-type-options: nosniff
    //     x-xss-protection: 1; mode=block
        Response.Headers.Add("X-Developed-By", "Your Name");
        Response.Headers.Add("access-control-allow-credentials", "true");
        Response.Headers.Add("access-control-allow-headers", Request.Headers.Origin);
        Response.Headers.Add("cache-control", "private, no-cache, no-store, must-revalidate, max-age=0");
        Response.Headers.Add("strict-transport-security", "max-age=31536000");
        return new TokenClass()
        {
            Token = "123",
            Name = "Name",
            Surname = "Surname"
        };
    }
}