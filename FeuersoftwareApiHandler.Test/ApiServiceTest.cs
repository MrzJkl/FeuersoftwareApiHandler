using NUnit.Framework;
using FeuersoftwareApiHandler.Services;
using FeuersoftwareApiHandler.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace FeuersoftwareApiHandler.Test
{
    public class ApiServiceTest
    {
        private static readonly string apiToken = "";

        private static readonly string baseAddress = "https://connectapi.feuersoftware.com";

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
            News news = new News
            {
                Id = 0,
                Title = "Diese News wurden über die API erstellt",
                Content = "Das ist ein Test",
                Start = DateTimeOffset.Now,
                End = DateTimeOffset.Now.AddDays(10),
                MailingLists = new List<string>(),
                Groups = new List<string>(),
                CreatedBy = "User",
                Site = "FÜG"
            };

            ApiService service = new ApiService(apiToken: apiToken, baseAddress: baseAddress);
            await service.PostNews(news);
        }

        [Test]
        public async Task PostOperation_Test()
        {
            LocalOperation operation = new LocalOperation
            {
                Start = DateTimeOffset.Now,
                End = DateTimeOffset.Now.AddHours(2),
                Keyword = "PROBE",
                Facts = "Dieser Einsatz wurde über die API erstellt!",
                Address = "Johannes-Kepler-Straße 4,36119 Neuhof",
                Number = "123456",
                AlarmEnabled = true,
                Status = OperationStatus.New
            };

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