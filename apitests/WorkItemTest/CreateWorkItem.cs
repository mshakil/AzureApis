using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api.ApiUtilities;
using System.Xml;
using api.Models.Request;
using api.Models.Response;
using api.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Newtonsoft.Json;

namespace apitests.WorkItemTest
{
    [TestClass]
    public class CreateWorkItem : Hooks
    {
        private CreateWorkItemRequest createWorkItemRequest;

        private RestResponse restResponse;
        private HttpStatusCode statusCode;

        [TestMethod]
        public async Task CreateNewWorkItem()
        {
            string workItemType = "Epic";
            string workItemName = "workItemType-" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-Auto";
            string workItemDescription = "Sample Description";
            string workItemTags = "Created Via Api";
            // Create the WorkItemFields array
            WorkItemFields[] fields = new WorkItemFields[]
            {
            new WorkItemFields
            {
                op = "add",
                path = "/fields/System.Title",
                from = null,
                value = workItemName
            },
            new WorkItemFields
            {
                op = "add",
                path = "/fields/System.Description",
                from = null,
                value = workItemDescription
            },
            new WorkItemFields
            {
                op = "add",
                path = "/fields/System.Tags",
                from = null,
                value = workItemTags
            }
            };

            createWorkItemRequest = new CreateWorkItemRequest
            {
                wiFields = fields
            };



            string jsonPayload = JsonConvert.SerializeObject(fields, Newtonsoft.Json.Formatting.Indented);
            var api = new ApiClient(BASE_URL, USER_NAME, USER_PAT, ORGANIZATION_NAME, PROJECT_GUID, API_VERSION);

            restResponse = await api.CreateWorkItem<WorkItemResponse>(jsonPayload, workItemType);

            statusCode = restResponse.StatusCode;
            var code = (int)statusCode;
            Assert.AreEqual(200, code, "Status Code Doesn't Match");
            

            var content = HandleContent.GetContent<WorkItemResponse>(restResponse);
            Assert.AreEqual(workItemName, content.fields["System.Title"], "Work item title is different!");
            Assert.AreEqual(workItemTags, content.fields["System.Tags"], "Work item tag is different!");
            Assert.AreEqual(workItemDescription, content.fields["System.Description"], "Work item description is different!");           

            Console.WriteLine($"Workitem Id is: {content.id}");
            Console.WriteLine($"Workitem Title is: {content.fields["System.Title"]}");
        }
    }
}
