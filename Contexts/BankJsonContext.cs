namespace AddressServiceBFF.Contexts;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<BankInstitution>))]
internal partial class BankJsonContext : JsonSerializerContext
{
}
