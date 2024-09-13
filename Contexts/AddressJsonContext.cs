namespace AddressServiceBFF.Contexts
{
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(Address))]
    internal partial class AddressJsonContext : JsonSerializerContext
    {
    }
}