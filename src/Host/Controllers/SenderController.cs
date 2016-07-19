using System.Collections.Generic;
using System.IO;
using Love.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers {
    [Route("api/[controller]")]
    public class SenderController : ControllerBase {
        [HttpPost]
        public void Post() {
            using (var reader = new BinaryReader(HttpContext.Request.Body)) {
                // app Id.
                var appId = reader.ReadString();
                // data
                var data = reader.ReadString();
                // targets
                var count = reader.ReadInt32();
                if (count > 0) {
                    var list = new List<Target>();
                    for (int index = 0; index != count; ++index) {
                        var clientId = reader.ReadString();
                        var alias = reader.ReadString();
                    }
                }
            }
        }
    }
}
