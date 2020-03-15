using Debora_Bank.Commands.Owner;
using Debora_Bank.Dtos.Owner;
using Debora_Bank.Exceptions;
using Debora_Bank.Exceptions.Error;
using Debora_Bank.Extensions.CommandMappings;
using Debora_Bank.Extensions.ResponseMappings;
using Debora_Bank.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Debora_Bank.Controllers
{
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            if (ownerRepository is null)
                throw new ArgumentNullException(nameof(ownerRepository));

            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        [Route("owners")]
        public IActionResult GetOwners()
        {
            var owners = _ownerRepository.GetOwners();

            if (owners is null || !owners.Any()) return NoContent();

            var response = owners.MapToResponse();

            return Ok(response);
        }

        [HttpGet]
        [Route("owners/{ownerId}")]
        public IActionResult GetOwner(int guid)
        {
            if (guid == null) return BadRequest();

            var owner = _ownerRepository.GetOwner(guid);

            if (owner is null) return NoContent();

            var response = owner.MapToResponse();

            return Ok(response);
        }

        [HttpPost]
        [Route("owners")]
        public IActionResult PostOwner(OwnerPostRequest ownerPostRequest)
        {
            if (ownerPostRequest == null) return BadRequest();

            try
            {
                //colocar o id correto
                var command = ownerPostRequest.MapToCommand(0);

                var commandHandler = new OwnerCommandHandler(_ownerRepository);

                var owner = commandHandler.Handle(command);

                var response = owner.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eOwnerError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpPut]
        [Route("owners/{ownerId}")]
        public IActionResult PutOwner([FromBody] OwnerPutResquest ownerPutRequest, [FromRoute] int ownerId)
        {
            if (ownerPutRequest == null || ownerId == null)
                return BadRequest();

            try
            {
                var command = ownerPutRequest.MapToCommand(ownerId);

                var commandHandler = new OwnerCommandHandler(_ownerRepository);

                var owner = commandHandler.Handle(command);

                var response = owner.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eOwnerError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpDelete]
        [Route("owners/{ownerId}")]
        public IActionResult DeleteOwner(int ownerId)
        {
            if (ownerId == null) return BadRequest();

            try
            {
                var command = new DeleteOwnerCommand(ownerId);

                var commandHandler = new OwnerCommandHandler(_ownerRepository);

                commandHandler.Handle(command);

                return Ok();
            }
            catch (CommandValidationException<eOwnerError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }
    }
}
