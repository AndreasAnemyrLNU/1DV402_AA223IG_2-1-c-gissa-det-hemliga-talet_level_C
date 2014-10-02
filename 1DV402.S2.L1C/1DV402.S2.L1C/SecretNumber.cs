using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    class SecretNumber
    {

        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        private const int MaxNumberOfGuesses = 7;



    }

    public enum Outcome
    {
        Indefinite,
        Low,
        Hogh,
        Right,
        NoMoreGuesses,
        OldGuess
    }



}
