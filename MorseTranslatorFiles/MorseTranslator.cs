using EncryptSoftware.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptSoftware
{
    public class MorseTranslator
    {

        public void PlaySound(string input)
        {
            foreach (var item in input)
            {
                if (item == '-')
                {
                    Console.Beep(650, 400);
                }
                else if (item == '.')
                {
                    Console.Beep(650, 200);
                }
            }
        }
        public string ConvertToMorse(string input)
        {
            var morseAlphabet = new Dictionary<char, string>()
            {
                 {'a', ".-"},
                 {'b', "-..."},
                 {'c', "-.-."},
                 {'d', "-.."},
                 {'e', "."},
                 {'f', "..-."},
                 {'g', "--."},
                 {'h', "...."},
                 {'i', ".."},
                 {'j', ".---"},
                 {'k', "-.-"},
                 {'l', ".-.."},
                 {'m', "--"},
                 {'n', "-."},
                 {'o', "---"},
                 {'p', ".--."},
                 {'q', "--.-"},
                 {'r', ".-."},
                 {'s', "..."},
                 {'t', "-"},
                 {'u', "..-"},
                 {'v', "...-"},
                 {'w', ".--"},
                 {'x', "-..-"},
                 {'y', "-.--"},
                 {'z', "--.."},
                 {' ', "/"},
                 {'1', ".----"},
                 {'2', "..---"},
                 {'3', "...--"},
                 {'4', "....-"},
                 {'5', "....."},
                 {'6', "-...."},
                 {'7', "--..."},
                 {'8', "---.."},
                 {'9', "----."},
                 {'0', "-----"},
                 {'.', ".-.-.-"},
                 {',', "--..--"},
                 {'?', "..--.."},
             };
            string newString = "";
            input = input.ToLower();
            foreach (char letter in input)
            {
                if (morseAlphabet.ContainsKey(letter))
                    newString += morseAlphabet[letter] + " ";
            }
            return newString.ToUpper();
        }

        //Convert from morse code
        public string ConvertFromMorse(string input)
        {
            var newInput = input.Split().ToArray();
            var morseAlphabet = new Dictionary<string, char>()
            {
                {".-"  ,'a'},
                {"-...",'b'},
                {"-.-.",'c'},
                {"-.." ,'d'},
                {"."   ,'e'},
                {"..-.",'f'},
                {"--." ,'g'},
                {"....",'h'},
                {".."  ,'i'},
                {".---",'j'},
                {"-.-" ,'k'},
                {".-..",'l'},
                {"--"  ,'m'},
                {"-."  ,'n'},
                {"---" ,'o'},
                {".--.",'p'},
                {"--.-",'q'},
                {".-." ,'r'},
                {"..." ,'s'},
                {"-"   ,'t'},
                {"..-" ,'u'},
                {"...-",'v'},
                {".--" ,'w'},
                {"-..-",'x'},
                {"-.--",'y'},
                {"--..",'z'},
                {"/"   ,' '},
                {".----",'1'},
                {"..---",'2'},
                {"...--",'3'},
                {"....-",'4'},
                {".....",'5'},
                {"-....",'6'},
                {"--...",'7'},
                {"---..",'8'},
                {"----.",'9'},
                {"-----",'0'},
                {".-.-.-",'.'},
                {"--..--",','},
                {"..--..",'?'},
            };
            string newString = "";
            input = input.ToLower();
            foreach (var letter in newInput)
            {
                if (morseAlphabet.ContainsKey(letter))
                    newString += morseAlphabet[letter];
            }
            return newString.ToUpper();
        }
    }
}
