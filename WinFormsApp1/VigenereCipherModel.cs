namespace WinFormsApp1;

internal static class VigenereCipherModel
{
    private static readonly char[] s_alphabet = new char[]
    {
        'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
        'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я',
        'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р',
        'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ', 'э', 'ю', 'я',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
        'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
        'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
        ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
    };
    private static readonly int s_alphabetPower = s_alphabet.Length;

    public static string Encrypt(string plaintext, string key)
    {
        string result = "";
        int key_index = 0;

        foreach (char symbol in plaintext)
        {
            if (s_alphabet.Contains(symbol))
            {
                int encodedSymbol = (Array.IndexOf(s_alphabet, symbol) + Array.IndexOf(s_alphabet, key[key_index])) % s_alphabetPower;
                result += s_alphabet[encodedSymbol];
            }
            else
            {
                result += symbol;
            }
            key_index++;
            if ((key_index + 1) == key.Length)
            {
                key_index = 0;
            }
        }
        return result;
    }

    public static string Decrypt(string ciphertext, string key)
    {
        string result = "";
        int keyword_index = 0;

        foreach (char symbol in ciphertext)
        {
            if (s_alphabet.Contains(symbol))
            {
                int decodedSymbol = (Array.IndexOf(s_alphabet, symbol) + s_alphabetPower - Array.IndexOf(s_alphabet, key[keyword_index])) % s_alphabetPower;
                result += s_alphabet[decodedSymbol];
            }
            else
            {
                result += symbol;
            }
            keyword_index++;
            if ((keyword_index + 1) == key.Length)
            {
                keyword_index = 0;
            }
        }
        return result;
    }
}
