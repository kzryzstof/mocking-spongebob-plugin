using System.Text;

namespace ReSharperPlugin.MockingSpongebob.Text
{
    #region Classes

    public static class StringExtensions
    {
        #region Public Methods

        public static string AsSpongeBob(this string sarcasticText)
        {
            var stringBuilder = new StringBuilder();

            var mustLowerCase = true;

            foreach (char character in sarcasticText)
            {
                if (!char.IsLetter(character))
                {
                    stringBuilder.Append(character);
                    continue;
                }

                stringBuilder.Append(mustLowerCase ? char.ToLower(character) : char.ToUpper(character));
                mustLowerCase = !mustLowerCase;
            }

            return stringBuilder.ToString();
        }

        #endregion
    }

    #endregion
}