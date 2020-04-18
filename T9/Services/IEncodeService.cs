namespace T9.Services
{
    public interface IEncodeService
    {
        /// <summary>
        /// Encode text to T9 according to the requirements https://code.google.com/codejam/contest/dashboard?c=351101#s=p2
        /// </summary>
        /// <returns>
        /// Encoded version of any text which contains letters [a-b] and the space symbol.
        /// Any other letters in the input parameters will throw the exception.
        /// </returns>
        string Encode(string text);
    }
}
