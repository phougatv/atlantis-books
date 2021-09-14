﻿namespace Atlantis.WebApi.Book.Controllers
{
    using Atlantis.WebApi.Book.Business;
    using Atlantis.WebApi.Book.Dtos;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;

        public BooksController(
            IMapper mapper,
            IBookService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Ping!!!");
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookCreateDto dto)
        {
            var domainModel = _mapper.Map<BookDomainModel>(dto);
            var isCreated = _service.Create(domainModel);

            return StatusCode(isCreated ? Status201Created : Status500InternalServerError);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Read([FromRoute] Guid id)
        {
            var domainModel = _service.Read(id);
            var bookDto = _mapper.Map<BookDto>(domainModel);

            return Ok(bookDto);
        }
    }
}
