namespace AddressServiceBFF.Contexts;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<BankInstitution>))]
[JsonSerializable(typeof(List<ParticipantsPix>))]
internal partial class BankJsonContext : JsonSerializerContext
{
}
