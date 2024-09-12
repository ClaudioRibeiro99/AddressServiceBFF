using System.Text.Json.Serialization;
using AddressServiceBFF.Models;

namespace AddressServiceBFF.Contexts
{
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    [JsonSerializable(typeof(Address))]
    [JsonSerializable(typeof(Location))]
    [JsonSerializable(typeof(Coordinates))]
    internal partial class AddressJsonContext : JsonSerializerContext
    {
    }
}