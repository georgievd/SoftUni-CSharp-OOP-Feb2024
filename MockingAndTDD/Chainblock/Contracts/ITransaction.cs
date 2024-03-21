using Chainblock.Models.Enumerations;

namespace Chainblock.Contracts
{
    public interface ITransaction
    {
        int Id { get; init; }

        TransactionStatus Status { get; set; }

        string Sender { get; set; }

        string Receiver { get; set; }

        decimal Amount { get; set; }
    }
}
