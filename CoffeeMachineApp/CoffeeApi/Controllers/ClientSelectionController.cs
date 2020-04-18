using CoffeeApi.DTO;
using CoffeeApi.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientSelectionController : ControllerBase
    {
        private readonly IClientSelectionService clientSelectionService;

        public ClientSelectionController(IClientSelectionService clientSelectionService)
        {
            this.clientSelectionService = clientSelectionService;
        }

        // api/ClientSelection/GetClientSelection/BadgeNumber
        [HttpGet("GetClientSelection/{badgeNumber}")]
        public IActionResult GetClientSelection(string badgeNumber)
        {
            var clientSelection = clientSelectionService.GetClientSelection(badgeNumber);

            if (clientSelection == null)
            {
                return NotFound();
            }

            return Ok(clientSelection);
        }

        [HttpPost]
        public IActionResult AddSelection(ClientSelectionDTO clientSelectionDTO)
        {
            clientSelectionService.AddClientSelection(clientSelectionDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSelection(ClientSelectionDTO clientSelectionDTO)
        {
            clientSelectionService.UpdateClientSelection(clientSelectionDTO);
            return Ok();
        }
    }
}
