using Debora_Bank.Commands.Account;
using Debora_Bank.Dtos.Account;
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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            if (accountRepository is null)
                throw new ArgumentNullException(nameof(accountRepository));

            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("accounts")]
        public IActionResult GetAccounts()
        {
            var accounts = _accountRepository.GetAccounts();

            if (accounts is null || !accounts.Any()) return NoContent();

            var response = accounts.MapToResponse();

            return Ok(response);
        }

        [HttpGet]
        [Route("accounts/{accountsId}")]
        public IActionResult GetAccount(Guid guid)
        {
            if (guid == null) return BadRequest();

            var account = _accountRepository.GetAccount(guid);

            if (account is null) return NoContent();

            var response = account.MapToResponse();

            return Ok(response);
        }

        [HttpPost]
        [Route("accounts")]
        public IActionResult PostAccount(AccountPostRequest accountPostRequest)
        {
            if (accountPostRequest == null) return BadRequest();

            try
            {
                var command = accountPostRequest.MapToCommand(Guid.NewGuid());

                var commandHandler = new AccountCommandHandler(_accountRepository);

                var account = commandHandler.Handle(command);

                var response = account.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eAccountError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpPut]
        [Route("accounts/{accountsId}")]
        public IActionResult PutAccount([FromBody] AccountPutRequest accountPutRequest, [FromRoute] Guid accountId)
        {
            if (accountPutRequest == null || accountId == null)
                return BadRequest();

            try
            {
                var command = accountPutRequest.MapToCommand(accountId);

                var commandHandler = new AccountCommandHandler(_accountRepository);

                var account = commandHandler.Handle(command);

                var response = account.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eAccountError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpDelete]
        [Route("accounts/{accountsId}")]
        public IActionResult DeleteAccount(Guid accountId)
        {
            if (accountId == null) return BadRequest();

            try
            {
                var command = new DeleteAccountCommand(accountId);

                var commandHandler = new AccountCommandHandler(_accountRepository);

                commandHandler.Handle(command);

                return Ok();
            }
            catch (CommandValidationException<eAccountError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }
    }
}
