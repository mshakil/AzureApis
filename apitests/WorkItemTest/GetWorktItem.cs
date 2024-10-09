using api.ApiUtilities;
using api.Models.Response;
using api.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apitests.WorkItemTest
{
    [TestClass]
    public class GetWorktItem : Hooks
    {
        [TestMethod]
        public async Task GetWorkItem()
        {

            int workItemId = 4;
            var api = new ApiClient(BASE_URL, USER_NAME, USER_PAT, ORGANIZATION_NAME, PROJECT_GUID, API_VERSION);

            restResponse = await api.GetWorkItem<WorkItemResponse>(workItemId);

            statusCode = restResponse.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(200, code, "Status Code is not as expected");

            var content = HandleContent.GetContent<WorkItemResponse>(restResponse);
            Console.WriteLine($"Workitem Id is: {content.id}");
            Console.WriteLine($"Workitem Title is: {content.fields["System.Title"]}");
        }
    }
}
