
# Locker (EncryptSoftware)

A school project based on Windows Forms C#


## Features

- Enigma text cryption tab
- File locker tab
- Morse converter tab


## Authors

- [@AlexNastev](https://github.com/AlexNastev)
- [@Mitko2206](https://github.com/Mitko2206)


## Documentation
### Enigma
The Enigma works with two classes the main class Enigma and the Rotor class. In the Enigma the rotors are implemented with 26 dictionaries that are reversable. These dictionaries are stored in one big dictionary with structure Dictionary<int, Dictionary<char,char>> - so that we have different dictionary for each number of the rotor. Taking that we have 3 rotors i have done that 3 times.
The plugboard implementation is similar, the letters are stored in dictionary. The reflector is also a dictionary.

 The order of the methods are:
- Plugboard letters check
- First Rotor
- Second Rotor
- Third Rotor
- Reflector
- Third Rotor
- Second Rotor
- First Rotor
- Plugboard letters check

### File Locker
Encrypts files with a password byte-by-byte using a XOR cipher.

Decryption is the same process,
only the password used to encrypt will decrypt the file.
### Morse Converter
It gathers the text from the text box and then via dictionary returns the equivalent morse string.