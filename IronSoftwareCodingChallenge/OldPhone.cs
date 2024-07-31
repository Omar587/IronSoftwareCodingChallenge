using System.Collections;
using System.Runtime.Intrinsics.X86;

class OldPhone
{


    static void Main()
    {
        string testStringOne = "33#";
        string testStringTwo = "227*#";
        string testStringThree = "4433555    555666#";
        string testStringFour = "8 88777444666*664";
        string testStringFive = "222 2 22";



        Console.WriteLine(OldPhonePad(testStringOne));
        Console.WriteLine(OldPhonePad(testStringTwo));
        Console.WriteLine(OldPhonePad(testStringThree));
        Console.WriteLine(OldPhonePad(testStringFour));
        Console.WriteLine(OldPhonePad(testStringFive));

    }



    public static string OldPhonePad(string input)
    {
        var phoneMapping = GetPhoneMapping();
        int count = 0;
        var result = new List<char>();

        char c = input[0];
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '*' || input[i] == '#')
            {
                break;
            }

            if (input[i] == c)
            {
                count++;
            }
            else
            {
                if (c != ' ')
                {
                    result.Add(GetLetterFromPresses(phoneMapping, c, count));
                }
                c = input[i];
                count = 1;
            }
        }

        // Add the last sequence of characters
        if (c != ' ')
        {
            result.Add(GetLetterFromPresses(phoneMapping, c, count));
        }

        return new string(result.ToArray());
    }



    private static char GetLetterFromPresses(Dictionary<char, List<char>> phoneMapping, char number, int presses)
    {
        //cycles through button presses
        if (phoneMapping.ContainsKey(number))
        {
            var letters = phoneMapping[number];
            int i = (presses - 1) % letters.Count;
            return letters[i];

        }
        return number;
    }



    private static Dictionary<char, List<char>> GetPhoneMapping()
    {
        return new Dictionary<char, List<char>>
        {
            { '1', new List<char> { '&', '\'', '(' } },
            { '2', new List<char> { 'A', 'B', 'C' } },
            { '3', new List<char> { 'D', 'E', 'F' } },
            { '4', new List<char> { 'G', 'H', 'I' } },
            { '5', new List<char> { 'J', 'K', 'L' } },
            { '6', new List<char> { 'M', 'N', 'O' } },
            { '7', new List<char> { 'P', 'Q', 'R', 'S' } },
            { '8', new List<char> { 'T', 'U', 'V' } },
            { '9', new List<char> { 'W', 'X', 'Y', 'Z' } },

        };
    }




}