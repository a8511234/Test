using ForTest.Models;
using ForTest.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ForTest.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class BackendExamController : ControllerBase
    {


        [HttpGet("Select")]
        public ActionResult Select(string Sid)
        {
            SQLUtility sQLUtility = new SQLUtility("Server=localhost;Database=ForTest;TrustServerCertificate=true;User Id=sa;Password=00000000");
            string res = sQLUtility.QuerySP("[dbo].[ACPD_Read]", Sid);
            return Ok(res);
        }

        [HttpPost("Create")]
        public ActionResult Create(Data data)
        {
            try
            {
                SQLUtility sQLUtility = new SQLUtility("Server=localhost;Database=ForTest;TrustServerCertificate=true;User Id=sa;Password=00000000");
                string jsonString = JsonSerializer.Serialize(data);
                string res = sQLUtility.CreateQuerySP("[dbo].[ACPD_Create]", jsonString);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("Update")]
        public ActionResult Update(string Sid,Data data)
        {
            try
            {
                SQLUtility sQLUtility = new SQLUtility("Server=localhost;Database=ForTest;TrustServerCertificate=true;User Id=sa;Password=00000000");
                string jsonString = JsonSerializer.Serialize(data);
                string res = sQLUtility.UpdateQuerySP("[dbo].[ACPD_Update]", Sid, jsonString);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Delete")]
        public ActionResult Delete(string Sid)
        {
            try
            {
                SQLUtility sQLUtility = new SQLUtility("Server=localhost;Database=ForTest;TrustServerCertificate=true;User Id=sa;Password=00000000");
                string res = sQLUtility.QuerySP("[dbo].[ACPD_Delete]", Sid);
                return Ok(res);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
