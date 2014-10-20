using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        //Fält

        //GuessedNumber is used for holding guessed nr of current "game"
        private GuessedNumber[] _guessedNumbers;
        //Secret nr of current game
        private int? _number;
        //How many guessest that it's llowed for ONE game?
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess //Checks if nr of guesses has reach to nr of MaxNumberOfGuesses. If it's possible to make one more guesses...
        {
            get
            {   
                if (Count >= MaxNumberOfGuesses || Outcome == Outcome.Right)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public int Count { get; private set; } //Counts how many guessings that has been made...
        public int? Guess //Inited with null - Holds value of last guess.
        {
            get;
            set;
        }
        public GuessedNumber[] GuessedNumbers
        {
            get 
            {
                //return _guessedNumbers;
                GuessedNumber[] copyOfNumberArray = new GuessedNumber[MaxNumberOfGuesses];
                Array.Copy(_guessedNumbers, copyOfNumberArray, MaxNumberOfGuesses);
                return copyOfNumberArray;
            }
        }
        /// <summary>
        /// Property of secret nr (_number
        /// </summary>
        public int? Number 
        {
            get
            {
                if (true == CanMakeGuess)
                {
                    return null;
                }
                else return _number;
            }
            private set
            {
                _number = value;
            }
        }
        /// <summary>
        /// Holds the outcome of last guessed nr. Different outcomes in public enum Outcome
        /// </summary>
        public Outcome Outcome
        { get; private set; }
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, MaxNumberOfGuesses);
            //Rand nr
            Random rnd = new Random();
            Number = rnd.Next(1,101);
            //Init count to Zero
            Count = 0;
            //Init Guess with null
            Guess = null;
            //Init Outcome to outcome.Indefinite
            Outcome = Outcome.Indefinite;

        }
        public Outcome MakeGuess(int guess)
        {       
            foreach (GuessedNumber value in GuessedNumbers)
                if (value.Number == guess)
                {
                    Outcome = Outcome.OldGuess;
                    return Outcome.OldGuess;
                }

            if(Count >= MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
                return Outcome.NoMoreGuesses;
            }
           
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_number > guess)
            {
                Guess = guess;
                Outcome = Outcome.Low;
                _guessedNumbers[Count].Number = guess;
                _guessedNumbers[Count].Outcome = Outcome.Low;
                Count++;
                return Outcome.Low;
            }
            else if (_number < guess)
            {
                Guess = guess;
                Outcome = Outcome.High;
                _guessedNumbers[Count].Number = guess;
                _guessedNumbers[Count].Outcome = Outcome.High;
                Count++;
                return Outcome.High;
            }
            else
            {
                Guess = guess;
                Outcome = Outcome.Right;
                _guessedNumbers[Count].Number = guess;
                _guessedNumbers[Count].Outcome = Outcome.Right;
                Count++;
                return Outcome.Right;
            }
        }
        /// <summary>
        /// Create array that can cold references to object of the Type GuessedNumber
        /// </summary>
        public SecretNumber()
        {
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];

            Initialize();
        }
    }
    /// <summary>
    /// Outcome is responsible to hold the outcome of last guess/answer
    /// </summary>
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }



}
