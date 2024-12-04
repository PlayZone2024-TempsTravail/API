namespace PlayZone.BLL.Interfaces.Budget_Related;

public interface ITransactionService
{
    public Object GenerateRapport(IEnumerable<int> libeles, IEnumerable<int> projectIds, DateTime startDate,
        DateTime endDate);
}

