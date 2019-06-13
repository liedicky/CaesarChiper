using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CaesarChiper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variable
            Regex inputReg = new Regex("[^a-zA-Z]");
            Regex keyReg = new Regex("[^0-9]");
            string encodeInput, encodeKey;
            string decodeInput, decodeKey;



            // For encoding message
            Console.WriteLine("Please input the message you need to encode:");

            // Read the input
            encodeInput = Console.ReadLine();

            // Ask to re-input it does not only consist of alphabetical characters ot it is not blank
            while (inputReg.IsMatch(encodeInput) || encodeInput == "")
            {
                Console.WriteLine("Message can only consist of alaphabetical characters");
                Console.Write("Re-input: ");
                // If there is a non-alphabetical characters, ask user to re-input
                encodeInput = Console.ReadLine();
            }

            Console.WriteLine("Please input your key:");

            // Do the same process with input key
            encodeKey = Console.ReadLine();

            while (keyReg.IsMatch(encodeKey) || encodeKey == "")
            {
                Console.WriteLine("Key can only be numbers");
                Console.Write("Re-input: ");
                encodeKey = Console.ReadLine();
            }

            // Output call encode method
            Console.WriteLine("Your encoded message is: {0}\n", encode(encodeInput, Convert.ToInt32(encodeKey)));



            // For decoding message
            // Do the same process as encoding
            Console.WriteLine("Please input the message you need to decode:");

            decodeInput = Console.ReadLine();

            while (inputReg.IsMatch(decodeInput) || decodeInput == "")
            {
                Console.WriteLine("Message can only consist of alaphabetical characters");
                decodeInput = Console.ReadLine();
            }

            Console.WriteLine("Please input your key:");

            decodeKey = Console.ReadLine();

            while (keyReg.IsMatch(decodeKey) || decodeKey == "")
            {
                Console.WriteLine("Key can only be numbers");
                decodeKey = Console.ReadLine();
            }

            // Output call decode method
            Console.WriteLine("Your decoded message is: {0}\n", decode(decodeInput, Convert.ToInt32(decodeKey)));
        }

        // Functions

        // ASCII for a - z is 97 - 122
        // ASCII for A - Z is 65 - 90
        public static string encode(string input, int key)
        {
            // Variable
            string output = "";
            int newAscii, temp;

            // Make sure the key does not loop the character
            key = key % 25;

            for (int i = 0; i < input.Length; i++)
            {
                temp = Convert.ToInt32(input[i]);
                newAscii = temp + key;

                // Check if the newAscii is higher than the range of z or Z
                // In case it is higher than the range of Z, do additional check if temp is on range of A - Z
                if (newAscii > 90 && temp < 91 || newAscii > 122)
                {
                    // Decrease newAscii value
                    newAscii -= 26;
                }

                // Join the output
                output += Convert.ToChar(newAscii);
            }
            return output;
        }

        public static string decode(string input, int key)
        {
            // Variable
            string output = "";
            int newAscii, temp;

            // Make sure the key does not loop the character
            key = key % 25;

            for (int i = 0; i < input.Length; i++)
            {
                temp = Convert.ToInt32(input[i]);
                newAscii = temp - key;

                // Check if the newAscii is below than the range of a or A
                // In case it is below than the range of a, do additional check if temp is on range of a - z
                if (newAscii < 65 || (newAscii < 97 && temp > 96))
                {
                    // Increase newAscii value
                    newAscii += 26;
                }

                // Join the output
                output += Convert.ToChar(newAscii);
            }
            return output;
        }
    }
}
