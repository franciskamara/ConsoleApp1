namespace Hangman;

class Program
{
    static void Main(string[] args)
    {
        const char PLACEHOLDER = '_';
        const int PERMITTED_ATTEMPTS = 6;

        // Create list and list of words
        List<string> words = new()
            {
            "abruptly", "grogginess", "peekaboo", "whomever", "psyche",
            "strength", "zombie", "flapjack", "kiwifruit", "espionage"
            };
        Random rng = new Random();// Random draw from List

        bool playing = true; //Game play start
        while (playing)
        {
            // Game state variables 
            int attemptsMade;

            // Intro message
            Console.WriteLine("-----------------");
            Console.WriteLine(" This is Hangman ");
            Console.WriteLine("-----------------");

            int numberOfWordsInTheList = words.Count; //Words list count
            int randomNumber = rng.Next(0, numberOfWordsInTheList); //Generate random word from list

            // Chosen word
            string chosenWord = words[randomNumber]; //Store random chosen word
            Console.WriteLine(chosenWord); //Print chosen word
            Console.WriteLine($"\nWord contains {chosenWord.Length} letters");
            Console.WriteLine($"You make {PERMITTED_ATTEMPTS} incorrect guesses and you lose.");
            Console.WriteLine(" ");

            // Empty array that will contain all the letters submitted by the player.
            List<char> submittedLetters = new List<char>(); //All letters collect list

            // gamestate list
            List<char> gameState = new List<char>(); //Game position throughout the guesses
            for (int fullLengthOfWord = 0; fullLengthOfWord < chosenWord.Length; fullLengthOfWord++)
            {
                gameState.Add(PLACEHOLDER); //Add Placeholer in place for each index letter in the word 
                Console.Write($"{PLACEHOLDER} "); //Print Placeholder in place of index letter in word
            }

            // ATTEMPT COUNT
            for (attemptsMade = 0; attemptsMade < PERMITTED_ATTEMPTS; attemptsMade++)
            {

                //Collect guess letter from user
                Console.Write("\nEnter a letter: ");
                char userGuessedChar = Console.ReadKey().KeyChar; //User input

                //Letter already guessed from previous turns
                if (submittedLetters.Contains(userGuessedChar)) //Tells the user the letter has already been entered
                {
                    Console.WriteLine("\nLetter was already guessed, try another one.");
                    attemptsMade--;
                    continue;
                }
                else //Checks if letter is already included, if not add letter
                {
                    submittedLetters.Add(userGuessedChar); //Add letter to letters list, if new
                }
                
                //Print out all enters inputted by user 
                Console.Write("\nInputs: ");
                foreach (char character in submittedLetters) //Print each letter
                {
                    Console.Write(character + " ");
                }
                Console.WriteLine();

                // Loop through all the characters of the word
                bool ruleOutAttempt = false;
                for (int idx = 0; idx < chosenWord.Length; idx++)
                {
                    if (chosenWord[idx] == userGuessedChar) //Letter is in guess word
                    {
                        //Console.Clear();
                        gameState[idx] = userGuessedChar;
                        ruleOutAttempt = true;
                    }

                } //end Looping through word letters

                if (ruleOutAttempt) //Reduce the attempt if the guess is right 
                {
                    attemptsMade--;
                }

                if (!gameState.Contains(PLACEHOLDER)) //Break if all letters have been guessed
                {
                    break;
                }

                //Display game state contents to user here
                foreach (char character in gameState)
                {
                    Console.Write(character + " "); //Print all content is list
                }

                Console.WriteLine($"\nLives used: {attemptsMade +1}/{PERMITTED_ATTEMPTS}"); //Print used lives/attempts

            } //end attempts loop

            // Win and Lose situation
            if (!gameState.Contains(PLACEHOLDER)) //Win
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o-o");
                Console.WriteLine(" Congratulations, you guessed the word! Kudos.");
            } //end game loop
            else //Lose
            {
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine(" You lost this time. Try again.");
            } //end max attempts made loop

            //Prompts user to Restart or Exit game
            Console.WriteLine($"\nThe word is {chosenWord}.");
            Console.WriteLine("\nIf you would like to play again press y or any other key to exit.");
            char endGame = Console.ReadKey().KeyChar;
            if (endGame == 'y')
            {
                Console.Clear();
                playing = true;
            } //end restart game
            else return; //End game sequence
        } //end while loop
    } //end Main arg loop
} //end class Progrma loop
