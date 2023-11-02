using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptSoftware.EnigmaCode
{
    public class Enigma
    {
        public Rotor FirstRotor { get; set; }
        public Rotor SecondRotor { get; set; }
        public Rotor ThirdRotor { get; set; }
        public Dictionary<char, char> PlugBoard { get; set; }

        private Dictionary<int, Dictionary<char, char>> rotorRandomizerOne = new Dictionary<int, Dictionary<char, char>>()
{
    {1, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'z'}, {'c', 'x'}, {'d', 'm'}, {'e', 'i'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'j'}, {'i', 'e'}, {'j', 'h'},
            {'k', 'y'}, {'l', 'w'}, {'m', 'd'}, {'n', 'q'}, {'o', 'r'},
            {'p', 'a'}, {'q', 'n'}, {'r', 'o'}, {'s', 'u'}, {'t', 'v'},
            {'u', 's'}, {'v', 't'}, {'w', 'l'}, {'x', 'c'}, {'y', 'k'},
            {'z', 'b'}
        }
    },
    {2, new Dictionary<char, char> // copy to others, fix mistakes
        {
            {'a', 'h'}, {'b', 'l'}, {'c', 'e'}, {'d', 'j'}, {'e', 'c'},
            {'f', 's'}, {'g', 'm'}, {'h', 'a'}, {'i', 'o'}, {'j', 'd'},
            {'k', 'x'}, {'l', 'b'}, {'m', 'g'}, {'n', 'r'}, {'o', 'i'},
            {'p', 'p'}, {'q', 'u'}, {'r', 'n'}, {'s', 'f'}, {'t', 'v'},
            {'u', 'q'}, {'v', 't'}, {'w', 'y'}, {'x', 'k'}, {'y', 'w'},
            {'z', 'z'}
        }
    },
    {3, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'n'}, {'c', 'k'}, {'d', 'f'}, {'e', 't'},
            {'f', 'd'}, {'g', 'r'}, {'h', 'y'}, {'i', 'u'}, {'j', 'o'},
            {'k', 'c'}, {'l', 'z'}, {'m', 'w'}, {'n', 'b'}, {'o', 'j'},
            {'p', 'x'}, {'q', 'v'}, {'r', 'g'}, {'s', 'a'}, {'t', 'e'},
            {'u', 'i'}, {'v', 'q'}, {'w', 'm'}, {'x', 'p'}, {'y', 'h'},
            {'z', 'l'}
        }
    },
    {4, new Dictionary<char, char>
        {
           {'a', 'v'}, {'b', 'o'}, {'c', 'r'}, {'d', 'y'}, {'e', 'm'},
            {'f', 'i'}, {'g', 'q'}, {'h', 'w'}, {'i', 'f'}, {'j', 'x'},
            {'k', 'u'}, {'l', 'z'}, {'m', 'e'}, {'n', 'p'}, {'o', 'b'},
            {'p', 'n'}, {'q', 'g'}, {'r', 'c'}, {'s', 't'}, {'t', 's'},
            {'u', 'k'}, {'v', 'a'}, {'w', 'h'}, {'x', 'j'}, {'y', 'd'},
            {'z', 'l'}
        }
    },
    {5, new Dictionary<char, char>
        {//TODO
            {'a', 't'}, {'b', 'r'}, {'c', 'z'}, {'d', 'g'}, {'e', 'u'},
            {'f', 'j'}, {'g', 'd'}, {'h', 'x'}, {'i', 'q'}, {'j', 'f'},
            {'k', 'w'}, {'l', 'y'}, {'m', 'v'}, {'n', 's'}, {'o', 'p'},
            {'p', 'o'}, {'q', 'i'}, {'r', 'b'}, {'s', 'n'}, {'t', 'a'},
            {'u', 'e'}, {'v', 'm'}, {'w', 'k'}, {'x', 'h'}, {'y', 'l'},
            {'z', 'c'}
        }
    },
    {6, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'w'}, {'c', 'y'}, {'d', 'n'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'z'}, {'h', 'r'}, {'i', 'v'}, {'j', 'u'},
            {'k', 's'}, {'l', 'p'}, {'m', 't'}, {'n', 'd'}, {'o', 'f'},
            {'p', 'l'}, {'q', 'a'}, {'r', 'h'}, {'s', 'k'}, {'t', 'm'},
            {'u', 'j'}, {'v', 'i'}, {'w', 'b'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'g'}
        }
    },
    {7, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'z'}, {'c', 'v'}, {'d', 'u'}, {'e', 'q'},
            {'f', 'w'}, {'g', 't'}, {'h', 'x'}, {'i', 's'}, {'j', 'y'},
            {'k', 'p'}, {'l', 'n'}, {'m', 'o'}, {'n', 'l'}, {'o', 'm'},
            {'p', 'k'}, {'q', 'e'}, {'r', 'a'}, {'s', 'i'}, {'t', 'g'},
            {'u', 'd'}, {'v', 'c'}, {'w', 'f'}, {'x', 'h'}, {'y', 'j'},
            {'z', 'b'}
        }
    },
    {8, new Dictionary<char, char>
        {
            {'a', 'w'}, {'b', 'u'}, {'c', 'x'}, {'d', 's'}, {'e', 'y'},
            {'f', 'r'}, {'g', 'z'}, {'h', 'q'}, {'i', 'v'}, {'j', 't'},
            {'k', 'o'}, {'l', 'n'}, {'m', 'p'}, {'n', 'l'}, {'o', 'k'},
            {'p', 'm'}, {'q', 'h'}, {'r', 'f'}, {'s', 'd'}, {'t', 'j'},
            {'u', 'b'}, {'v', 'i'}, {'w', 'a'}, {'x', 'c'}, {'y', 'e'},
            {'z', 'g'}
        }
    },
    {9, new Dictionary<char, char>
        {
            {'a', 'x'}, {'b', 't'}, {'c', 'y'}, {'d', 'r'}, {'e', 'z'},
            {'f', 'q'}, {'g', 'w'}, {'h', 'p'}, {'i', 'v'}, {'j', 'o'},
            {'k', 'u'}, {'l', 'n'}, {'m', 's'}, {'n', 'l'}, {'o', 'j'},
            {'p', 'h'}, {'q', 'f'}, {'r', 'd'}, {'s', 'm'}, {'t', 'b'},
            {'u', 'k'}, {'v', 'i'}, {'w', 'g'}, {'x', 'a'}, {'y', 'c'},
            {'z', 'e'}
        }
    },
    {10, new Dictionary<char, char>
        {
            {'a', 'y'}, {'b', 's'}, {'c', 'z'}, {'d', 'q'}, {'e', 'x'},
            {'f', 'p'}, {'g', 'v'}, {'h', 'o'}, {'i', 'w'}, {'j', 'n'},
            {'k', 't'}, {'l', 'm'}, {'m', 'l'}, {'n', 'j'}, {'o', 'h'},
            {'p', 'f'}, {'q', 'd'}, {'r', 'u'}, {'s', 'b'}, {'t', 'k'}, // u-r
            {'u', 'r'}, {'v', 'g'}, {'w', 'i'}, {'x', 'e'}, {'y', 'a'},
            {'z', 'c'}
        }
    },
    {11, new Dictionary<char, char>
        {
            {'a', 'z'}, {'b', 'r'}, {'c', 'y'}, {'d', 'p'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'u'}, {'h', 'n'}, {'i', 'v'}, {'j', 'm'},
            {'k', 's'}, {'l', 'l'}, {'m', 'j'}, {'n', 'h'}, {'o', 'f'},
            {'p', 'd'}, {'q', 'q'}, {'r', 'b'}, {'s', 'k'}, {'t', 't'},
            {'u', 'g'}, {'v', 'i'}, {'w', 'w'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'a'}
        }
    },
    {12, new Dictionary<char, char>
        {
            {'a', 'u'}, {'b', 'q'}, {'c', 'x'}, {'d', 'o'}, {'e', 'w'},
            {'f', 'n'}, {'g', 't'}, {'h', 'm'}, {'i', 'v'}, {'j', 'l'},
            {'k', 'r'}, {'l', 'j'}, {'m', 'h'}, {'n', 'f'}, {'o', 'd'},
            {'p', 'p'}, {'q', 'b'}, {'r', 'k'}, {'s', 's'}, {'t', 'g'},
            {'u', 'a'}, {'v', 'i'}, {'w', 'e'}, {'x', 'c'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {13, new Dictionary<char, char>
        {
            {'a', 't'}, {'b', 'p'}, {'c', 'w'}, {'d', 'n'}, {'e', 'v'},
            {'f', 'm'}, {'g', 's'}, {'h', 'l'}, {'i', 'u'}, {'j', 'k'},
            {'k', 'j'}, {'l', 'h'}, {'m', 'f'}, {'n', 'd'}, {'o', 'o'},
            {'p', 'b'}, {'q', 'q'}, {'r', 'r'}, {'s', 'g'}, {'t', 'a'},
            {'u', 'i'}, {'v', 'e'}, {'w', 'c'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {14, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'o'}, {'c', 'v'}, {'d', 'm'}, {'e', 'u'},
            {'f', 'l'}, {'g', 'r'}, {'h', 'k'}, {'i', 't'}, {'j', 'j'},
            {'k', 'h'}, {'l', 'f'}, {'m', 'd'}, {'n', 'n'}, {'o', 'b'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'g'}, {'s', 'a'}, {'t', 'i'},
            {'u', 'e'}, {'v', 'c'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {15, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'n'}, {'c', 'u'}, {'d', 'l'}, {'e', 't'},
            {'f', 'k'}, {'g', 'q'}, {'h', 'j'}, {'i', 's'}, {'j', 'h'},
            {'k', 'f'}, {'l', 'd'}, {'m', 'm'}, {'n', 'b'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'g'}, {'r', 'a'}, {'s', 'i'}, {'t', 'e'},
            {'u', 'c'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {16, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'm'}, {'c', 't'}, {'d', 'k'}, {'e', 's'},
            {'f', 'j'}, {'g', 'p'}, {'h', 'i'}, {'i', 'h'}, {'j', 'f'},
            {'k', 'd'}, {'l', 'l'}, {'m', 'b'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'g'}, {'q', 'a'}, {'r', 'r'}, {'s', 'e'}, {'t', 'c'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {17, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'l'}, {'c', 's'}, {'d', 'j'}, {'e', 'r'},
            {'f', 'i'}, {'g', 'o'}, {'h', 'h'}, {'i', 'f'}, {'j', 'd'},
            {'k', 'k'}, {'l', 'b'}, {'m', 'm'}, {'n', 'n'}, {'o', 'g'},
            {'p', 'a'}, {'q', 'q'}, {'r', 'e'}, {'s', 'c'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {18, new Dictionary<char, char>
        {
            {'a', 'o'}, {'b', 'k'}, {'c', 'r'}, {'d', 'i'}, {'e', 'q'},
            {'f', 'h'}, {'g', 'n'}, {'h', 'f'}, {'i', 'd'}, {'j', 'j'},
            {'k', 'b'}, {'l', 'l'}, {'m', 'm'}, {'n', 'g'}, {'o', 'a'},
            {'p', 'p'}, {'q', 'e'}, {'r', 'c'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {19, new Dictionary<char, char>
        {
            {'a', 'n'}, {'b', 'j'}, {'c', 'q'}, {'d', 'h'}, {'e', 'p'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'd'}, {'i', 'i'}, {'j', 'b'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'a'}, {'o', 'o'},
            {'p', 'e'}, {'q', 'c'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {20, new Dictionary<char, char>
        {
            {'a', 'm'}, {'b', 'i'}, {'c', 'p'}, {'d', 'g'}, {'e', 'o'},
            {'f', 'f'}, {'g', 'd'}, {'h', 'h'}, {'i', 'b'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'a'}, {'n', 'n'}, {'o', 'e'},
            {'p', 'c'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {21, new Dictionary<char, char>
        {
            {'a', 'l'}, {'b', 'h'}, {'c', 'o'}, {'d', 'f'}, {'e', 'n'},
            {'f', 'd'}, {'g', 'g'}, {'h', 'b'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'a'}, {'m', 'm'}, {'n', 'e'}, {'o', 'c'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {22, new Dictionary<char, char>
        {
            {'a', 'k'}, {'b', 'g'}, {'c', 'n'}, {'d', 'e'}, {'e', 'd'},
            {'f', 'f'}, {'g', 'b'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'a'}, {'l', 'l'}, {'m', 'm'}, {'n', 'c'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {23, new Dictionary<char, char> //Fix
        {
            {'a', 'j'}, {'b', 'f'}, {'c', 'm'}, {'d', 'd'}, {'e', 'l'},
            {'f', 'b'}, {'g', 'g'}, {'h', 'h'}, {'i', 'i'}, {'j', 'a'},
            {'k', 'k'}, {'l', 'e'}, {'m', 'c'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {24, new Dictionary<char, char>
        {
            {'a', 'i'}, {'b', 'e'}, {'c', 'l'}, {'d', 'd'}, {'e', 'b'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'h'}, {'i', 'a'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'c'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {25, new Dictionary<char, char>
        {
            {'a', 'h'}, {'b', 'd'}, {'c', 'k'}, {'d', 'b'}, {'e', 'j'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'a'}, {'i', 'i'}, {'j', 'e'},
            {'k', 'c'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {26, new Dictionary<char, char>
        {
            {'a', 'g'}, {'b', 'c'}, {'c', 'b'}, {'d', 'd'}, {'e', 'f'},
            {'f', 'e'}, {'g', 'a'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
};

        private Dictionary<int, Dictionary<char, char>> rotorRandomizerTwo = new Dictionary<int, Dictionary<char, char>>()
{
    {17, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'z'}, {'c', 'x'}, {'d', 'm'}, {'e', 'i'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'j'}, {'i', 'e'}, {'j', 'h'},
            {'k', 'y'}, {'l', 'w'}, {'m', 'd'}, {'n', 'q'}, {'o', 'r'},
            {'p', 'a'}, {'q', 'n'}, {'r', 'o'}, {'s', 'u'}, {'t', 'v'},
            {'u', 's'}, {'v', 't'}, {'w', 'l'}, {'x', 'c'}, {'y', 'k'},
            {'z', 'b'}
        }
    },
    {4, new Dictionary<char, char> // copy to others, fix mistakes
        {
            {'a', 'h'}, {'b', 'l'}, {'c', 'e'}, {'d', 'j'}, {'e', 'c'},
            {'f', 's'}, {'g', 'm'}, {'h', 'a'}, {'i', 'o'}, {'j', 'd'},
            {'k', 'x'}, {'l', 'b'}, {'m', 'g'}, {'n', 'r'}, {'o', 'i'},
            {'p', 'p'}, {'q', 'u'}, {'r', 'n'}, {'s', 'f'}, {'t', 'v'},
            {'u', 'q'}, {'v', 't'}, {'w', 'y'}, {'x', 'k'}, {'y', 'w'},
            {'z', 'z'}
        }
    },
    {22, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'n'}, {'c', 'k'}, {'d', 'f'}, {'e', 't'},
            {'f', 'd'}, {'g', 'r'}, {'h', 'y'}, {'i', 'u'}, {'j', 'o'},
            {'k', 'c'}, {'l', 'z'}, {'m', 'w'}, {'n', 'b'}, {'o', 'j'},
            {'p', 'x'}, {'q', 'v'}, {'r', 'g'}, {'s', 'a'}, {'t', 'e'},
            {'u', 'i'}, {'v', 'q'}, {'w', 'm'}, {'x', 'p'}, {'y', 'h'},
            {'z', 'l'}
        }
    },
    {13, new Dictionary<char, char>
        {
           {'a', 'v'}, {'b', 'o'}, {'c', 'r'}, {'d', 'y'}, {'e', 'm'},
            {'f', 'i'}, {'g', 'q'}, {'h', 'w'}, {'i', 'f'}, {'j', 'x'},
            {'k', 'u'}, {'l', 'z'}, {'m', 'e'}, {'n', 'p'}, {'o', 'b'},
            {'p', 'n'}, {'q', 'g'}, {'r', 'c'}, {'s', 't'}, {'t', 's'},
            {'u', 'k'}, {'v', 'a'}, {'w', 'h'}, {'x', 'j'}, {'y', 'd'},
            {'z', 'l'}
        }
    },
    {9, new Dictionary<char, char>
        {//TODO
            {'a', 't'}, {'b', 'r'}, {'c', 'z'}, {'d', 'g'}, {'e', 'u'},
            {'f', 'j'}, {'g', 'd'}, {'h', 'x'}, {'i', 'q'}, {'j', 'f'},
            {'k', 'w'}, {'l', 'y'}, {'m', 'v'}, {'n', 's'}, {'o', 'p'},
            {'p', 'o'}, {'q', 'i'}, {'r', 'b'}, {'s', 'n'}, {'t', 'a'},
            {'u', 'e'}, {'v', 'm'}, {'w', 'k'}, {'x', 'h'}, {'y', 'l'},
            {'z', 'c'}
        }
    },
    {2, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'w'}, {'c', 'y'}, {'d', 'n'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'z'}, {'h', 'r'}, {'i', 'v'}, {'j', 'u'},
            {'k', 's'}, {'l', 'p'}, {'m', 't'}, {'n', 'd'}, {'o', 'f'},
            {'p', 'l'}, {'q', 'a'}, {'r', 'h'}, {'s', 'k'}, {'t', 'm'},
            {'u', 'j'}, {'v', 'i'}, {'w', 'b'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'g'}
        }
    },
    {11, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'z'}, {'c', 'v'}, {'d', 'u'}, {'e', 'q'},
            {'f', 'w'}, {'g', 't'}, {'h', 'x'}, {'i', 's'}, {'j', 'y'},
            {'k', 'p'}, {'l', 'n'}, {'m', 'o'}, {'n', 'l'}, {'o', 'm'},
            {'p', 'k'}, {'q', 'e'}, {'r', 'a'}, {'s', 'i'}, {'t', 'g'},
            {'u', 'd'}, {'v', 'c'}, {'w', 'f'}, {'x', 'h'}, {'y', 'j'},
            {'z', 'b'}
        }
    },
    {25, new Dictionary<char, char>
        {
            {'a', 'w'}, {'b', 'u'}, {'c', 'x'}, {'d', 's'}, {'e', 'y'},
            {'f', 'r'}, {'g', 'z'}, {'h', 'q'}, {'i', 'v'}, {'j', 't'},
            {'k', 'o'}, {'l', 'n'}, {'m', 'p'}, {'n', 'l'}, {'o', 'k'},
            {'p', 'm'}, {'q', 'h'}, {'r', 'f'}, {'s', 'd'}, {'t', 'j'},
            {'u', 'b'}, {'v', 'i'}, {'w', 'a'}, {'x', 'c'}, {'y', 'e'},
            {'z', 'g'}
        }
    },
    {6, new Dictionary<char, char>
        {
            {'a', 'x'}, {'b', 't'}, {'c', 'y'}, {'d', 'r'}, {'e', 'z'},
            {'f', 'q'}, {'g', 'w'}, {'h', 'p'}, {'i', 'v'}, {'j', 'o'},
            {'k', 'u'}, {'l', 'n'}, {'m', 's'}, {'n', 'l'}, {'o', 'j'},
            {'p', 'h'}, {'q', 'f'}, {'r', 'd'}, {'s', 'm'}, {'t', 'b'},
            {'u', 'k'}, {'v', 'i'}, {'w', 'g'}, {'x', 'a'}, {'y', 'c'},
            {'z', 'e'}
        }
    },
    {19, new Dictionary<char, char>
        {
            {'a', 'y'}, {'b', 's'}, {'c', 'z'}, {'d', 'q'}, {'e', 'x'},
            {'f', 'p'}, {'g', 'v'}, {'h', 'o'}, {'i', 'w'}, {'j', 'n'},
            {'k', 't'}, {'l', 'm'}, {'m', 'l'}, {'n', 'j'}, {'o', 'h'},
            {'p', 'f'}, {'q', 'd'}, {'r', 'u'}, {'s', 'b'}, {'t', 'k'}, // u-r
            {'u', 'r'}, {'v', 'g'}, {'w', 'i'}, {'x', 'e'}, {'y', 'a'},
            {'z', 'c'}
        }
    },
    {14, new Dictionary<char, char>
        {
            {'a', 'z'}, {'b', 'r'}, {'c', 'y'}, {'d', 'p'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'u'}, {'h', 'n'}, {'i', 'v'}, {'j', 'm'},
            {'k', 's'}, {'l', 'l'}, {'m', 'j'}, {'n', 'h'}, {'o', 'f'},
            {'p', 'd'}, {'q', 'q'}, {'r', 'b'}, {'s', 'k'}, {'t', 't'},
            {'u', 'g'}, {'v', 'i'}, {'w', 'w'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'a'}
        }
    },
    {8, new Dictionary<char, char>
        {
            {'a', 'u'}, {'b', 'q'}, {'c', 'x'}, {'d', 'o'}, {'e', 'w'},
            {'f', 'n'}, {'g', 't'}, {'h', 'm'}, {'i', 'v'}, {'j', 'l'},
            {'k', 'r'}, {'l', 'j'}, {'m', 'h'}, {'n', 'f'}, {'o', 'd'},
            {'p', 'p'}, {'q', 'b'}, {'r', 'k'}, {'s', 's'}, {'t', 'g'},
            {'u', 'a'}, {'v', 'i'}, {'w', 'e'}, {'x', 'c'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {24, new Dictionary<char, char>
        {
            {'a', 't'}, {'b', 'p'}, {'c', 'w'}, {'d', 'n'}, {'e', 'v'},
            {'f', 'm'}, {'g', 's'}, {'h', 'l'}, {'i', 'u'}, {'j', 'k'},
            {'k', 'j'}, {'l', 'h'}, {'m', 'f'}, {'n', 'd'}, {'o', 'o'},
            {'p', 'b'}, {'q', 'q'}, {'r', 'r'}, {'s', 'g'}, {'t', 'a'},
            {'u', 'i'}, {'v', 'e'}, {'w', 'c'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {3, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'o'}, {'c', 'v'}, {'d', 'm'}, {'e', 'u'},
            {'f', 'l'}, {'g', 'r'}, {'h', 'k'}, {'i', 't'}, {'j', 'j'},
            {'k', 'h'}, {'l', 'f'}, {'m', 'd'}, {'n', 'n'}, {'o', 'b'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'g'}, {'s', 'a'}, {'t', 'i'},
            {'u', 'e'}, {'v', 'c'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {16, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'n'}, {'c', 'u'}, {'d', 'l'}, {'e', 't'},
            {'f', 'k'}, {'g', 'q'}, {'h', 'j'}, {'i', 's'}, {'j', 'h'},
            {'k', 'f'}, {'l', 'd'}, {'m', 'm'}, {'n', 'b'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'g'}, {'r', 'a'}, {'s', 'i'}, {'t', 'e'},
            {'u', 'c'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {5, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'm'}, {'c', 't'}, {'d', 'k'}, {'e', 's'},
            {'f', 'j'}, {'g', 'p'}, {'h', 'i'}, {'i', 'h'}, {'j', 'f'},
            {'k', 'd'}, {'l', 'l'}, {'m', 'b'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'g'}, {'q', 'a'}, {'r', 'r'}, {'s', 'e'}, {'t', 'c'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {21, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'l'}, {'c', 's'}, {'d', 'j'}, {'e', 'r'},
            {'f', 'i'}, {'g', 'o'}, {'h', 'h'}, {'i', 'f'}, {'j', 'd'},
            {'k', 'k'}, {'l', 'b'}, {'m', 'm'}, {'n', 'n'}, {'o', 'g'},
            {'p', 'a'}, {'q', 'q'}, {'r', 'e'}, {'s', 'c'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {10, new Dictionary<char, char>
        {
            {'a', 'o'}, {'b', 'k'}, {'c', 'r'}, {'d', 'i'}, {'e', 'q'},
            {'f', 'h'}, {'g', 'n'}, {'h', 'f'}, {'i', 'd'}, {'j', 'j'},
            {'k', 'b'}, {'l', 'l'}, {'m', 'm'}, {'n', 'g'}, {'o', 'a'},
            {'p', 'p'}, {'q', 'e'}, {'r', 'c'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {18, new Dictionary<char, char>
        {
            {'a', 'n'}, {'b', 'j'}, {'c', 'q'}, {'d', 'h'}, {'e', 'p'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'd'}, {'i', 'i'}, {'j', 'b'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'a'}, {'o', 'o'},
            {'p', 'e'}, {'q', 'c'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {12, new Dictionary<char, char>
        {
            {'a', 'm'}, {'b', 'i'}, {'c', 'p'}, {'d', 'g'}, {'e', 'o'},
            {'f', 'f'}, {'g', 'd'}, {'h', 'h'}, {'i', 'b'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'a'}, {'n', 'n'}, {'o', 'e'},
            {'p', 'c'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {26, new Dictionary<char, char>
        {
            {'a', 'l'}, {'b', 'h'}, {'c', 'o'}, {'d', 'f'}, {'e', 'n'},
            {'f', 'd'}, {'g', 'g'}, {'h', 'b'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'a'}, {'m', 'm'}, {'n', 'e'}, {'o', 'c'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {7, new Dictionary<char, char>
        {
            {'a', 'k'}, {'b', 'g'}, {'c', 'n'}, {'d', 'e'}, {'e', 'd'},
            {'f', 'f'}, {'g', 'b'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'a'}, {'l', 'l'}, {'m', 'm'}, {'n', 'c'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {15, new Dictionary<char, char> //Fix
        {
            {'a', 'j'}, {'b', 'f'}, {'c', 'm'}, {'d', 'd'}, {'e', 'l'},
            {'f', 'b'}, {'g', 'g'}, {'h', 'h'}, {'i', 'i'}, {'j', 'a'},
            {'k', 'k'}, {'l', 'e'}, {'m', 'c'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {23, new Dictionary<char, char>
        {
            {'a', 'i'}, {'b', 'e'}, {'c', 'l'}, {'d', 'd'}, {'e', 'b'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'h'}, {'i', 'a'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'c'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {20, new Dictionary<char, char>
        {
            {'a', 'h'}, {'b', 'd'}, {'c', 'k'}, {'d', 'b'}, {'e', 'j'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'a'}, {'i', 'i'}, {'j', 'e'},
            {'k', 'c'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {1, new Dictionary<char, char>
        {
            {'a', 'g'}, {'b', 'c'}, {'c', 'b'}, {'d', 'd'}, {'e', 'f'},
            {'f', 'e'}, {'g', 'a'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
};

        private Dictionary<int, Dictionary<char, char>> rotorRandomizerThree = new Dictionary<int, Dictionary<char, char>>()
{
    {8, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'z'}, {'c', 'x'}, {'d', 'm'}, {'e', 'i'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'j'}, {'i', 'e'}, {'j', 'h'},
            {'k', 'y'}, {'l', 'w'}, {'m', 'd'}, {'n', 'q'}, {'o', 'r'},
            {'p', 'a'}, {'q', 'n'}, {'r', 'o'}, {'s', 'u'}, {'t', 'v'},
            {'u', 's'}, {'v', 't'}, {'w', 'l'}, {'x', 'c'}, {'y', 'k'},
            {'z', 'b'}
        }
    },
    {15, new Dictionary<char, char> // copy to others, fix mistakes
        {
            {'a', 'h'}, {'b', 'l'}, {'c', 'e'}, {'d', 'j'}, {'e', 'c'},
            {'f', 's'}, {'g', 'm'}, {'h', 'a'}, {'i', 'o'}, {'j', 'd'},
            {'k', 'x'}, {'l', 'b'}, {'m', 'g'}, {'n', 'r'}, {'o', 'i'},
            {'p', 'p'}, {'q', 'u'}, {'r', 'n'}, {'s', 'f'}, {'t', 'v'},
            {'u', 'q'}, {'v', 't'}, {'w', 'y'}, {'x', 'k'}, {'y', 'w'},
            {'z', 'z'}
        }
    },
    {3, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'n'}, {'c', 'k'}, {'d', 'f'}, {'e', 't'},
            {'f', 'd'}, {'g', 'r'}, {'h', 'y'}, {'i', 'u'}, {'j', 'o'},
            {'k', 'c'}, {'l', 'z'}, {'m', 'w'}, {'n', 'b'}, {'o', 'j'},
            {'p', 'x'}, {'q', 'v'}, {'r', 'g'}, {'s', 'a'}, {'t', 'e'},
            {'u', 'i'}, {'v', 'q'}, {'w', 'm'}, {'x', 'p'}, {'y', 'h'},
            {'z', 'l'}
        }
    },
    {20, new Dictionary<char, char>
        {
           {'a', 'v'}, {'b', 'o'}, {'c', 'r'}, {'d', 'y'}, {'e', 'm'},
            {'f', 'i'}, {'g', 'q'}, {'h', 'w'}, {'i', 'f'}, {'j', 'x'},
            {'k', 'u'}, {'l', 'z'}, {'m', 'e'}, {'n', 'p'}, {'o', 'b'},
            {'p', 'n'}, {'q', 'g'}, {'r', 'c'}, {'s', 't'}, {'t', 's'},
            {'u', 'k'}, {'v', 'a'}, {'w', 'h'}, {'x', 'j'}, {'y', 'd'},
            {'z', 'l'}
        }
    },
    {25, new Dictionary<char, char>
        {//TODO
            {'a', 't'}, {'b', 'r'}, {'c', 'z'}, {'d', 'g'}, {'e', 'u'},
            {'f', 'j'}, {'g', 'd'}, {'h', 'x'}, {'i', 'q'}, {'j', 'f'},
            {'k', 'w'}, {'l', 'y'}, {'m', 'v'}, {'n', 's'}, {'o', 'p'},
            {'p', 'o'}, {'q', 'i'}, {'r', 'b'}, {'s', 'n'}, {'t', 'a'},
            {'u', 'e'}, {'v', 'm'}, {'w', 'k'}, {'x', 'h'}, {'y', 'l'},
            {'z', 'c'}
        }
    },
    {10, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'w'}, {'c', 'y'}, {'d', 'n'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'z'}, {'h', 'r'}, {'i', 'v'}, {'j', 'u'},
            {'k', 's'}, {'l', 'p'}, {'m', 't'}, {'n', 'd'}, {'o', 'f'},
            {'p', 'l'}, {'q', 'a'}, {'r', 'h'}, {'s', 'k'}, {'t', 'm'},
            {'u', 'j'}, {'v', 'i'}, {'w', 'b'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'g'}
        }
    },
    {23, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'z'}, {'c', 'v'}, {'d', 'u'}, {'e', 'q'},
            {'f', 'w'}, {'g', 't'}, {'h', 'x'}, {'i', 's'}, {'j', 'y'},
            {'k', 'p'}, {'l', 'n'}, {'m', 'o'}, {'n', 'l'}, {'o', 'm'},
            {'p', 'k'}, {'q', 'e'}, {'r', 'a'}, {'s', 'i'}, {'t', 'g'},
            {'u', 'd'}, {'v', 'c'}, {'w', 'f'}, {'x', 'h'}, {'y', 'j'},
            {'z', 'b'}
        }
    },
    {5, new Dictionary<char, char>
        {
            {'a', 'w'}, {'b', 'u'}, {'c', 'x'}, {'d', 's'}, {'e', 'y'},
            {'f', 'r'}, {'g', 'z'}, {'h', 'q'}, {'i', 'v'}, {'j', 't'},
            {'k', 'o'}, {'l', 'n'}, {'m', 'p'}, {'n', 'l'}, {'o', 'k'},
            {'p', 'm'}, {'q', 'h'}, {'r', 'f'}, {'s', 'd'}, {'t', 'j'},
            {'u', 'b'}, {'v', 'i'}, {'w', 'a'}, {'x', 'c'}, {'y', 'e'},
            {'z', 'g'}
        }
    },
    {18, new Dictionary<char, char>
        {
            {'a', 'x'}, {'b', 't'}, {'c', 'y'}, {'d', 'r'}, {'e', 'z'},
            {'f', 'q'}, {'g', 'w'}, {'h', 'p'}, {'i', 'v'}, {'j', 'o'},
            {'k', 'u'}, {'l', 'n'}, {'m', 's'}, {'n', 'l'}, {'o', 'j'},
            {'p', 'h'}, {'q', 'f'}, {'r', 'd'}, {'s', 'm'}, {'t', 'b'},
            {'u', 'k'}, {'v', 'i'}, {'w', 'g'}, {'x', 'a'}, {'y', 'c'},
            {'z', 'e'}
        }
    },
    {13, new Dictionary<char, char>
        {
            {'a', 'y'}, {'b', 's'}, {'c', 'z'}, {'d', 'q'}, {'e', 'x'},
            {'f', 'p'}, {'g', 'v'}, {'h', 'o'}, {'i', 'w'}, {'j', 'n'},
            {'k', 't'}, {'l', 'm'}, {'m', 'l'}, {'n', 'j'}, {'o', 'h'},
            {'p', 'f'}, {'q', 'd'}, {'r', 'u'}, {'s', 'b'}, {'t', 'k'}, // u-r
            {'u', 'r'}, {'v', 'g'}, {'w', 'i'}, {'x', 'e'}, {'y', 'a'},
            {'z', 'c'}
        }
    },
    {26, new Dictionary<char, char>
        {
            {'a', 'z'}, {'b', 'r'}, {'c', 'y'}, {'d', 'p'}, {'e', 'x'},
            {'f', 'o'}, {'g', 'u'}, {'h', 'n'}, {'i', 'v'}, {'j', 'm'},
            {'k', 's'}, {'l', 'l'}, {'m', 'j'}, {'n', 'h'}, {'o', 'f'},
            {'p', 'd'}, {'q', 'q'}, {'r', 'b'}, {'s', 'k'}, {'t', 't'},
            {'u', 'g'}, {'v', 'i'}, {'w', 'w'}, {'x', 'e'}, {'y', 'c'},
            {'z', 'a'}
        }
    },
    {1, new Dictionary<char, char>
        {
            {'a', 'u'}, {'b', 'q'}, {'c', 'x'}, {'d', 'o'}, {'e', 'w'},
            {'f', 'n'}, {'g', 't'}, {'h', 'm'}, {'i', 'v'}, {'j', 'l'},
            {'k', 'r'}, {'l', 'j'}, {'m', 'h'}, {'n', 'f'}, {'o', 'd'},
            {'p', 'p'}, {'q', 'b'}, {'r', 'k'}, {'s', 's'}, {'t', 'g'},
            {'u', 'a'}, {'v', 'i'}, {'w', 'e'}, {'x', 'c'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {9, new Dictionary<char, char>
        {
            {'a', 't'}, {'b', 'p'}, {'c', 'w'}, {'d', 'n'}, {'e', 'v'},
            {'f', 'm'}, {'g', 's'}, {'h', 'l'}, {'i', 'u'}, {'j', 'k'},
            {'k', 'j'}, {'l', 'h'}, {'m', 'f'}, {'n', 'd'}, {'o', 'o'},
            {'p', 'b'}, {'q', 'q'}, {'r', 'r'}, {'s', 'g'}, {'t', 'a'},
            {'u', 'i'}, {'v', 'e'}, {'w', 'c'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {16, new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'o'}, {'c', 'v'}, {'d', 'm'}, {'e', 'u'},
            {'f', 'l'}, {'g', 'r'}, {'h', 'k'}, {'i', 't'}, {'j', 'j'},
            {'k', 'h'}, {'l', 'f'}, {'m', 'd'}, {'n', 'n'}, {'o', 'b'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'g'}, {'s', 'a'}, {'t', 'i'},
            {'u', 'e'}, {'v', 'c'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {21, new Dictionary<char, char>
        {
            {'a', 'r'}, {'b', 'n'}, {'c', 'u'}, {'d', 'l'}, {'e', 't'},
            {'f', 'k'}, {'g', 'q'}, {'h', 'j'}, {'i', 's'}, {'j', 'h'},
            {'k', 'f'}, {'l', 'd'}, {'m', 'm'}, {'n', 'b'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'g'}, {'r', 'a'}, {'s', 'i'}, {'t', 'e'},
            {'u', 'c'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {4, new Dictionary<char, char>
        {
            {'a', 'q'}, {'b', 'm'}, {'c', 't'}, {'d', 'k'}, {'e', 's'},
            {'f', 'j'}, {'g', 'p'}, {'h', 'i'}, {'i', 'h'}, {'j', 'f'},
            {'k', 'd'}, {'l', 'l'}, {'m', 'b'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'g'}, {'q', 'a'}, {'r', 'r'}, {'s', 'e'}, {'t', 'c'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {12, new Dictionary<char, char>
        {
            {'a', 'p'}, {'b', 'l'}, {'c', 's'}, {'d', 'j'}, {'e', 'r'},
            {'f', 'i'}, {'g', 'o'}, {'h', 'h'}, {'i', 'f'}, {'j', 'd'},
            {'k', 'k'}, {'l', 'b'}, {'m', 'm'}, {'n', 'n'}, {'o', 'g'},
            {'p', 'a'}, {'q', 'q'}, {'r', 'e'}, {'s', 'c'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {7, new Dictionary<char, char>
        {
            {'a', 'o'}, {'b', 'k'}, {'c', 'r'}, {'d', 'i'}, {'e', 'q'},
            {'f', 'h'}, {'g', 'n'}, {'h', 'f'}, {'i', 'd'}, {'j', 'j'},
            {'k', 'b'}, {'l', 'l'}, {'m', 'm'}, {'n', 'g'}, {'o', 'a'},
            {'p', 'p'}, {'q', 'e'}, {'r', 'c'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {24, new Dictionary<char, char>
        {
            {'a', 'n'}, {'b', 'j'}, {'c', 'q'}, {'d', 'h'}, {'e', 'p'},
            {'f', 'g'}, {'g', 'f'}, {'h', 'd'}, {'i', 'i'}, {'j', 'b'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'a'}, {'o', 'o'},
            {'p', 'e'}, {'q', 'c'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {6, new Dictionary<char, char>
        {
            {'a', 'm'}, {'b', 'i'}, {'c', 'p'}, {'d', 'g'}, {'e', 'o'},
            {'f', 'f'}, {'g', 'd'}, {'h', 'h'}, {'i', 'b'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'a'}, {'n', 'n'}, {'o', 'e'},
            {'p', 'c'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {14, new Dictionary<char, char>
        {
            {'a', 'l'}, {'b', 'h'}, {'c', 'o'}, {'d', 'f'}, {'e', 'n'},
            {'f', 'd'}, {'g', 'g'}, {'h', 'b'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'a'}, {'m', 'm'}, {'n', 'e'}, {'o', 'c'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {19, new Dictionary<char, char>
        {
            {'a', 'k'}, {'b', 'g'}, {'c', 'n'}, {'d', 'e'}, {'e', 'd'},
            {'f', 'f'}, {'g', 'b'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'a'}, {'l', 'l'}, {'m', 'm'}, {'n', 'c'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {2, new Dictionary<char, char> //Fix
        {
            {'a', 'j'}, {'b', 'f'}, {'c', 'm'}, {'d', 'd'}, {'e', 'l'},
            {'f', 'b'}, {'g', 'g'}, {'h', 'h'}, {'i', 'i'}, {'j', 'a'},
            {'k', 'k'}, {'l', 'e'}, {'m', 'c'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {17,new Dictionary<char, char>
        {
            {'a', 'i'}, {'b', 'e'}, {'c', 'l'}, {'d', 'd'}, {'e', 'b'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'h'}, {'i', 'a'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'c'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {11, new Dictionary<char, char>
        {
            {'a', 'h'}, {'b', 'd'}, {'c', 'k'}, {'d', 'b'}, {'e', 'j'},
            {'f', 'f'}, {'g', 'g'}, {'h', 'a'}, {'i', 'i'}, {'j', 'e'},
            {'k', 'c'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
    {22, new Dictionary<char, char>
        {
            {'a', 'g'}, {'b', 'c'}, {'c', 'b'}, {'d', 'd'}, {'e', 'f'},
            {'f', 'e'}, {'g', 'a'}, {'h', 'h'}, {'i', 'i'}, {'j', 'j'},
            {'k', 'k'}, {'l', 'l'}, {'m', 'm'}, {'n', 'n'}, {'o', 'o'},
            {'p', 'p'}, {'q', 'q'}, {'r', 'r'}, {'s', 's'}, {'t', 't'},
            {'u', 'u'}, {'v', 'v'}, {'w', 'w'}, {'x', 'x'}, {'y', 'y'},
            {'z', 'z'}
        }
    },
};
        private Dictionary<char, char> reflector = new Dictionary<char, char>
        {
            {'a', 's'}, {'b', 'n'}, {'c', 'k'}, {'d', 'f'}, {'e', 't'},
            {'f', 'd'}, {'g', 'r'}, {'h', 'y'}, {'i', 'u'}, {'j', 'o'},
            {'k', 'c'}, {'l', 'z'}, {'m', 'w'}, {'n', 'b'}, {'o', 'j'},
            {'p', 'x'}, {'q', 'v'}, {'r', 'g'}, {'s', 'a'}, {'t', 'e'},
            {'u', 'i'}, {'v', 'q'}, {'w', 'm'}, {'x', 'p'}, {'y', 'h'},
            {'z', 'l'}
        };


        public Enigma(int firstRotorValue, int secondRotorValue, int thirdRotorValue, Dictionary<char, char> plugBoard)
        {
            FirstRotor = new Rotor(firstRotorValue, rotorRandomizerOne);
            SecondRotor = new Rotor(secondRotorValue, rotorRandomizerTwo);
            ThirdRotor = new Rotor(thirdRotorValue, rotorRandomizerThree);
            PlugBoard = plugBoard;
        }

        public string Crypt(string message)
        {
            char currentLetter;
            StringBuilder cryptedMessage = new StringBuilder();
            foreach (char letter in message)
            {
                currentLetter = letter;
                if (currentLetter != ' ' && currentLetter != '.' && currentLetter != ',' && currentLetter != '!' && currentLetter != '?' && currentLetter != '(' && currentLetter != ')' && currentLetter != '\'' && currentLetter != '\n' && currentLetter != '\r' && currentLetter != '[' && currentLetter != ']' && !char.IsDigit(currentLetter) && currentLetter != '-' && currentLetter != '/' && currentLetter != ':' && currentLetter != '{' && currentLetter != '}' && currentLetter != '"')
                {
                    currentLetter = PlugBoardCheck(letter);

                    currentLetter = rotorRandomizerOne[FirstRotor.Vlaue][currentLetter];
                    currentLetter = rotorRandomizerTwo[SecondRotor.Vlaue][currentLetter];
                    currentLetter = rotorRandomizerThree[ThirdRotor.Vlaue][currentLetter];

                    currentLetter = reflector[currentLetter];

                    currentLetter = rotorRandomizerThree[ThirdRotor.Vlaue][currentLetter];
                    currentLetter = rotorRandomizerTwo[SecondRotor.Vlaue][currentLetter];
                    currentLetter = rotorRandomizerOne[FirstRotor.Vlaue][currentLetter];

                    currentLetter = PlugBoardCheck(currentLetter);
                    if (FirstRotor.Vlaue < 26)
                    {
                        FirstRotor.Vlaue++;
                    }
                    else
                    {
                        SecondRotor.Vlaue++;
                        FirstRotor.Vlaue = 1;

                        if (SecondRotor.Vlaue > 26)
                        {
                            ThirdRotor.Vlaue++;
                            SecondRotor.Vlaue = 1;

                            if (ThirdRotor.Vlaue > 26)
                            {
                                ThirdRotor.Vlaue = 1;
                            }
                        }
                    }
                }

                cryptedMessage.Append(currentLetter);

            }
            return cryptedMessage.ToString();
        }
        private char PlugBoardCheck(char letter)
        {
            if (PlugBoard.ContainsKey(letter))
            {
                return PlugBoard[letter];
            }
            else
            {
                return letter;
            }
        }
    }
}
