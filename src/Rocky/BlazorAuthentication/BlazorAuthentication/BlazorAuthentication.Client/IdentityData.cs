namespace BlazorAuthentication
{
    public class IdentityData
    {
        public string? AuthenticationType { get; set; }
        public List<ClaimData>? Claims { get; set; }
    }

    public class ClaimData
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string? ValueType { get; set; }
    }
}
