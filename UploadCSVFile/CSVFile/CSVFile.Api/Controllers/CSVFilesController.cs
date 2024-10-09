using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using CSVFile.Application.CSVFiles;
using CSVFile.Application.CSVFiles.CreateCSVFile;
using CSVFile.Application.CSVFiles.GetCSVFileById;
using CSVFile.Application.CSVFiles.GetCSVFiles;
using CSVFile.Domain.Entities;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace CSVFile.Api.Controllers
{
    [ApiController]
    public class CSVFilesController : ControllerBase
    {
        private readonly ISender _mediator;

        public CSVFilesController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// </summary>
        /// <response code="201">Successfully created.</response>
        /// <response code="400">One or more validation errors have occurred.</response>
        [HttpPost("api/csvfiles")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ImportResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ImportResult>> CreateCSVFile(
            [FromBody] CreateCSVFileCommand command,
            CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, result);
        }

    }
}