﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceFinder.BL.DTOs;
using PlaceFinder.BL.ServiceInterfaces;
using PlaceFinder.VMs;

namespace PlaceFinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        // GET: api/Client
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public ClientVM Get(int id)
        {
            var client = _clientService.GetClientById(id);  
            ClientVM response = _mapper.Map<ClientVM>(client);
            return response;
        }

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] ClientVM client)
        {
            ClientDTO _client = _mapper.Map<ClientDTO>(client);
            _clientService.Insert(_client);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, ClientVM client)
        {
            ClientDTO _client = _mapper.Map<ClientDTO>(client);
            _client.Id = id;
            _clientService.Update(_client);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id , [FromBody] ClientVM client)
        {
            ClientDTO _client = _mapper.Map<ClientDTO>(client);
            _client.Id = id;
            _clientService.Delete(_client);
            
        }
    }
}
