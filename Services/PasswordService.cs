namespace PasswordGeneratorApi.Services
{
    public class PasswordService
    {

        private static readonly string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string Numbers = "0123456789";
        private static readonly string SpecialCharacters = "!@#$%^&*()_-+=<>?";

        public string GeneratePassword(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecialCharacters)
        {
            var charPool = string.Empty;

            if (includeUppercase)
                charPool += Uppercase;
            if (includeLowercase)
                charPool += Lowercase;
            if (includeNumbers)
                charPool += Numbers;
            if (includeSpecialCharacters)
                charPool += SpecialCharacters;

            if (string.IsNullOrEmpty(charPool))
                throw new ArgumentException("No character sets selected.");

            var password = new char[length];
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                password[i] = charPool[random.Next(charPool.Length)];
            }

            return new string(password);
        }
    }
}
