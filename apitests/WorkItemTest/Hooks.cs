﻿using api.Models.Request;
using DotNetEnv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace apitests.WorkItemTest
{
    [TestClass]
    public class Hooks
    {
        protected string BASE_URL { get; set; }
        protected string USER_NAME { get; set; }
        protected string USER_PAT { get; set; }
        protected string ORGANIZATION_NAME { get; set; }
        protected string PROJECT_GUID { get; set; }
        protected string API_VERSION { get; set; }

        protected CreateWorkItemRequest createWorkItemRequest;

        protected RestResponse restResponse;
        protected HttpStatusCode statusCode;

        [TestInitialize]
        public void LoadEnvironmentVariables()
        {
            try
            {
                Env.Load();

                BASE_URL = Environment.GetEnvironmentVariable("BASE_URL");
                USER_NAME = Environment.GetEnvironmentVariable("USER_NAME");
                USER_PAT = Environment.GetEnvironmentVariable("USER_PAT");
                ORGANIZATION_NAME = Environment.GetEnvironmentVariable("ORGANIZATION_NAME");
                PROJECT_GUID = Environment.GetEnvironmentVariable("PROJECT_GUID");
                API_VERSION = Environment.GetEnvironmentVariable("API_VERSION");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
