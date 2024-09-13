namespace AddressServiceBFF.Interfaces.Cep;

public interface ICepService
{
    Task<(Address, HttpResponseMessage)> GetAddressByCepAsync(string cep);
}
