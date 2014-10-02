using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    class SecretNumber
    {
        //Fields - Fält
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        //Properties - Egenskaper
        public bool CanMakeGuess { public get; private set; }

        public int Count { public get; private set; }

        public int? Guess { public get; private set; }

        public GuessedNumber[] GuessedNumbers { get; }

        public int? Number { public get; private set; }

        public Outcome Outcome { public get; private set; }
        
        /// <summary>
        /// Publik metod som initierar klassens fält och egenskaper
        /// </summary>
        public void Initialize()
        {
        }

        public Outcome MakeGuess(int guess)
        {
        }

        public SecretNumber()
        {
            //Initiera SecretNumber-Objektet korrekt
            Initialize();
        }

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
