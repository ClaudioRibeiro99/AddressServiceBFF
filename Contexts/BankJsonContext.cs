namespace AddressServiceBFF.Contexts;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(BankInstitution))]
internal partial class BankJsonContext : JsonSerializerContext
{
}
