namespace PasswordGeneratorApi.Models
{
    public class PasswordRequest
    {
        public int Length { get; init; }
        public bool IncludeUppercase { get; init; }
        public bool IncludeLowercase { get; init; }
        public bool IncludeNumbers { get; init; }
        public bool IncludeSpecialCharacters { get; init; }
    }
}
