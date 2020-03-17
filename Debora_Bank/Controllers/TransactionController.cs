using Debora_Bank.Domain.Commands.Transaction;
using Debora_Bank.Domain.Exceptions;
using Debora_Bank.Domain.Exceptions.Error;
using Debora_Bank.Domain.Repository.Interfaces;
using Debora_Bank.Dtos.Transaction;
using Debora_Bank.Extensions.CommandMappings;
using Debora_Bank.Extensions.ResponseMappings;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Debora_Bank.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public TransactionController(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            if (transactionRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("transactions")]
        public IActionResult GetTransactions()
        {
            var transactions = _transactionRepository.GetTransactions();

            if (transactions is null || !transactions.Any()) return NoContent();

            var response = transactions.MapToResponse();

            return Ok(response);
        }

        [HttpGet]
        [Route("transactions/{transactionId}")]
        public IActionResult GetTransaction(int guid)
        {
            if (guid == null) return BadRequest();

            var transaction = _transactionRepository.GetTransaction(guid);

            if (transaction is null)
                return NoContent();

            var response = transaction.MapToResponse();

            return Ok(response);
        }

        [HttpPost]
        [Route("transactions")]
        public IActionResult PostTransaction(TransactionPostRequest transactionPostRequest)
         {
            if (transactionPostRequest == null) return BadRequest();

            try
            {
                var command = transactionPostRequest.MapToCommand();

                var commandHandler = new TransactionCommandHandler(_transactionRepository, _accountRepository);

                var transaction = commandHandler.Handle(command);

                var response = transaction.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eTransactionsError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpPut]
        [Route("transactions/{transactionId}")]
        public IActionResult PutTransaction([FromBody] TransactionPutRequest transactionPutRequest, [FromRoute] int transactionId)
        {
            if (transactionPutRequest == null || transactionId == null)
                return BadRequest();

            try
            {
                var command = transactionPutRequest.MapToCommand(transactionId);

                var commandHandler = new TransactionCommandHandler(_transactionRepository, _accountRepository);

                var transaction = commandHandler.Handle(command);

                var response = transaction.MapToResponse();

                return Ok(response);
            }
            catch (CommandValidationException<eTransactionsError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }

        [HttpDelete]
        [Route("transactions/{transactionId}")]
        public IActionResult DeleteTransaction(int transactionId)
        {
            if (transactionId == null) return BadRequest();

            try
            {
                var command = new DeleteTransactionCommand(transactionId);

                var commandHandler = new TransactionCommandHandler(_transactionRepository);

                commandHandler.Handle(command);

                return Ok();
            }
            catch (CommandValidationException<eTransactionsError> ex)
            {
                return BadRequest(ex.Error.ToString());
            }
        }
    }
}
