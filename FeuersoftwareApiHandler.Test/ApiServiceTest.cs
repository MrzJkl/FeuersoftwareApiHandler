namespace FeuersoftwareApiHandler.Test
{
    using NUnit.Framework;
    using FeuersoftwareApiHandler.Services;
    using FeuersoftwareApiHandler.Models;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;

    public class ApiServiceTest
    {
        private static readonly string baseAddress = "https://connectapi.feuersoftware.com";

        private static readonly string apiToken = "";

        [Test]
        public async Task GetOperation_Test()
        {
            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            IEnumerable<Operation> operations = await service.GetOperations();

            Assert.NotNull(operations);
        }

        [Test]
        public async Task GetNews_Test()
        {
            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            IEnumerable<News> news = await service.GetNews();

            Assert.NotNull(news);
        }

        [Test]
        public async Task PostNews_Test()
        {
            News news = new News(
                title: "Diese News wurden über die API erstellt",
                content: "Das ist ein Test",
                start: DateTimeOffset.Now,
                end: DateTimeOffset.Now.AddDays(1));

            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            await service.PostNews(news);
        }

        [Test]
        public async Task PostOperation_Test()
        {
            LocalOperation operation = new LocalOperation(
                start: DateTimeOffset.Now,
                keyword: "PROBE",
                facts: "Das ist ein Test",
                ric: "Schleife1",
                address: "Karlsbader Str. 16, 65760 Eschborn");


            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            await service.PostOperation(operation);
        }

        [Test]
        public async Task DeleteNews_Test()
        {
            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            await service.DeleteNews(14645);
        }
    }
}