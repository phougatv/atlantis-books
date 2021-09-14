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
            var bookDto = _mapper.Map<BookReadDto>(domainModel);

            return Ok(bookDto);
        }

        [HttpPut]
        public IActionResult Update([FromBody]BookUpdateDto dto)
        {
            var domainModel = _mapper.Map<BookDomainModel>(dto);
            var isUpdated = _service.Updated(domainModel);

            return StatusCode(isUpdated ? Status204NoContent : Status304NotModified);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var isDeleted = _service.Delete(id);

            return StatusCode(isDeleted ? Status204NoContent : Status304NotModified);
        }
    }
}
