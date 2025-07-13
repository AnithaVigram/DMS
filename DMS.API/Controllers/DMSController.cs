﻿using Microsoft.AspNetCore.Mvc;
using DMS.Application;
using DMS.Data.EF.Models;
using DMS.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using DMS.Data.EF.Query;

namespace DMS.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DMSController : ControllerBase
    {
        private readonly IDMSService _service;
        private readonly ILogger<DMSController> _logger;

        public DMSController(IDMSService service, ILogger<DMSController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetTreeViewManualList")]
        public async Task<ActionResult<List<DmManual_Treeview>>> GetTreeViewManualList()
        {
            _logger.LogInformation("Get Treeview Manual list");
            var manualList = await _service.GetTreeViewManualListAsync(); // Await the async method
            
            return Ok(manualList);
        }

        [HttpPost]
        public async Task<ActionResult> PostDM_Manual(DmManualDto manual) // Mark method as async
        {
            // Validation
            // Checking

            await _service.AddDmManualAsync(manual); // Await the async method

            // Retrieve all the manuals from the database
            var manualList = await _service.GetDmManualsAsync(); // Await the async method
            foreach (var s in manualList)
            {
                Console.WriteLine($"Name: {s.ManualName}, Id: {s.DmManualId}");
            }

            return Ok();
        }

        [HttpGet("GetDM_Manual")]
        public async Task<ActionResult<List<DmManual>>> GetDM_ManualList() // Mark method as async
        {
            _logger.LogInformation("Get DM_Manual List");

            var manualList = await _service.GetDmManualsAsync(); // Await the async method

            foreach (var s in manualList)
            {
                Console.WriteLine($"Name: {s.ManualName}, Id: {s.DmManualId}");
                Console.WriteLine(new string('-', 30));
            }

            return Ok(manualList);
        }
    }
}
