namespace AddressServiceBFF.Interfaces.Banks;

public interface IBankService
{
    Task<(BankInstitution, HttpResponseMessage)> GetBanksByCodeAsync(string code);
    Task<(ICollection<BankInstitution>, HttpResponseMessage)> GetAllBanksAsync();
}
