using PlayZone.API.DTOs.Budget_Related;
using Models = PlayZone.BLL.Models.Budget_Related;

namespace PlayZone.API.Mappers.Budget_Related;

public static class TransactionMapper
{
    public static TransactionResultDto ToDTO(this Models.TransactionResult transactionResult)
    {
        return new TransactionResultDto
        {
            Category = transactionResult.Category,
            Libele = transactionResult.Libele,
            Organisme = transactionResult.Organisme,
            Motif = transactionResult.Motif,
            DateFacturation = transactionResult.DateFacturation,
            Montant = transactionResult.Montant
        };
    }
}
