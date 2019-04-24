using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KiraNodeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ipController : ControllerBase
    {
        // GET: api/ip
        [HttpGet]
        public string  Get()
        {
            WebClient myWebClient = new WebClient();

            Uri uriString = new Uri("https://api.ipify.org/");
            // Download home page data. 
            Console.WriteLine("Accessing {0} ...", uriString);
            // Open a stream to point to the data stream coming from the Web resource.
            Stream myStream = myWebClient.OpenRead(uriString);

            Console.WriteLine("\nDisplaying Data :\n");
            StreamReader sr = new StreamReader(myStream);
            string result = sr.ReadToEnd();

            // Close the stream. 
            myStream.Close();

            return result;

        }

        
    }
}
