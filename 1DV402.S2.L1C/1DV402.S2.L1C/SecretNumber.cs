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

        //Klar, känns bra!
        private GuessedNumber[] _guessedNumbers;
        //Klar känns bra!
        private int? _number;
        //Klar - känns bra!
        public const int MaxNumberOfGuesses = 7;
        //Egenskaper

        public bool CanMakeGuess //Klar - Se över hur värdet true tilkommer och ändras!!!!
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
        public int Count { get; private set; } //Klar- känns helt ok. Init 0 någonstans?
        public int? Guess //Klar -känns ok!
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
        }//Klar, känns bra!
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
        }//Klar, känns bra!
        public Outcome Outcome
        { get; private set; }
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, MaxNumberOfGuesses);
            //Slumptalet
            Random rnd = new Random();
            Number = rnd.Next(1,100);
            //Sätter Count till 0. Kanske det räcker ?
            Count = 0;
            //Guess ska tilldelas värdet nu
            Guess = null;
            //Outcome ska tilldelas värdet outcome.Indefinite
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

        public SecretNumber()
        {
            //Skapar instanser av Arrayen _guessedNumbers.
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];

            Initialize();
        }
    }

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
