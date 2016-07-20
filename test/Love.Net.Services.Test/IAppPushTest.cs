using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Host;

namespace Love.Net.Services.Test {
    public class User {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class IAppPushTest {
        private const string _appId = "CEKPXdNm3o7PvtKyQ19uL5";
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly IAppPush _appPush;

        public IAppPushTest() {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
            _appPush = _server.Host.Services.GetService<IAppPush>();
        }

        [Fact]
        public async Task Push_Message_To_List_Alias_Test() {
            await _appPush.PushMessageToListAsync(_appId, "{ \"UserName\": \"rigofunc\"}", Target.FromAlias("rigofunc"));
        }

        [Fact]
        public async Task Push_Message_To_List_ClientId_Test() {
            await _appPush.PushMessageToListAsync(_appId, "{ \"UserName\": \"rigofunc\"}", new Target { ClientId = "857061aec1f8d9a0bce554e0bb2e63d4" });
        }

        [Fact]
        public async Task Push_Message_To_App_Test() {
            await _appPush.PushMessageToAppAsync(_appId, "{ \"UserName\": \"rigofunc\"}");
        }

        [Fact]
        public async Task Push_Message_To_List_Invalide_List_Test() {
            await _appPush.PushMessageToListAsync(_appId, "{ \"UserName\": \"rigofunc\"}", new Target());
        }

        [Fact]
        public async Task Push_Generic_AppMessage_To_List_Test() {
            var message = new AppMessage<User> {
                Title = "xUnit test",
                Content = new User {
                    UserName = "rigofunc",
                    Password = "P@ssword"
                },
                Kind = "1"
            };

            await _appPush.PushMessageToListAsync(_appId, message, Target.FromAlias("rigofunc"));
        }
    }
}
