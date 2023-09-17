# ConsoleApp1 - Hangman sln

Hangman
Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word.
Each correct guess fills in that letter in the word. Guess too many wrong letters and the player loses.

Tips: It is all a matter of taking the letter the player guesses and looping through the word comparing it to each letter in the word character by character. If the letters match, you show that letter to the player. If you reach the end of the word and no letters have been matched, it is a wrong guess.
Remember that strings are often treated as an array of characters. Most languages have a function to fetch a single letter from a string.
Keep track of how many wrong guesses the player has done and use this number to determine if the game has been won or lost.

- Development status: Complete

If possible, include screenshots and demo videos.
- Screenshot
<img width="1164" alt="Screenshot 2023-09-17 at 17 10 30" src="https://github.com/franciskamara/ConsoleApp1/assets/53877017/af50e860-be3b-486b-ba9d-5b28769675ac">

- Video
[Hangman recording.zip](https://github.com/franciskamara/ConsoleApp1/files/12643230/Hangman.recording.zip)

Requirements
1. Fill list with possible words
2. Figure out how to get a random entry from a list
3. Write a block tht helps you figure out if a character is part of a string
4. Write a block that outputs the current state of the game. Console.Clear() can help to mae things better 
5. Look at Console.ReadKey(); to make things nicer
6. Pack all of this in a loop and keep track of tries 
