namespace AddressServiceBFF.Interfaces
{
    public interface ICepService
    {
        Task<(Address, HttpResponseMessage)> GetAddressByCepAsync(string cep);
    }
}
