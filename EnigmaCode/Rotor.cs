using System.Collections.Generic;

namespace EncryptSoftware.EnigmaCode
{
    public class Rotor
    {
        public int Vlaue { get; set; }
        public Dictionary<int, Dictionary<char, char>> RotorsCableManagment { get; set; }
        public Rotor(int vlaue, Dictionary<int, Dictionary<char, char>> rotorsCableManagment)
        {
            Vlaue = vlaue;
            RotorsCableManagment = rotorsCableManagment;
        }
    }
}