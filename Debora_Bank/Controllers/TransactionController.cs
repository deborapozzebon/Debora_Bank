using Debora_Bank.Commands.Transaction;
using Debora_Bank.Dtos.Transaction;
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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            if (transactionRepository is null)
                throw new ArgumentNullException(nameof(transactionRepository));

            _transactionRepository = transactionRepository;
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
        public IActionResult GetTransaction(Guid guid)
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
                var command = transactionPostRequest.MapToCommand(Guid.NewGuid());

                var commandHandler = new TransactionCommandHandler(_transactionRepository);

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
        public IActionResult PutOwner([FromBody] TransactionPutRequest transactionPutRequest, [FromRoute] Guid transactionId)
        {
            if (transactionPutRequest == null || transactionId == null)
                return BadRequest();

            try
            {
                var command = transactionPutRequest.MapToCommand(transactionId);

                var commandHandler = new TransactionCommandHandler(_transactionRepository);

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
        public IActionResult DeleteOwner(Guid transactionId)
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
