namespace AddressServiceBFF.Contexts;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<ParticipantsPix>))]
internal partial class ParticipantsPixJsonContext : JsonSerializerContext
{
}