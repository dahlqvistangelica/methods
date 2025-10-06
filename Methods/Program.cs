namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static int GetUserIntInput(string textInput, int min, int max, string invalidText)
        {
            /// Method for receiving input from the user and converting it to an int.
            /// To allow reuse, the prompt message is passed as a parameter so it can be customized.
            /// The method also checks whether the input is within the specified range; otherwise, an error message taken as a parameter is displayed.
            while (true)
            {
                Console.Write(textInput);
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    if (input >= min && input <= max)
                    { return input; }
                }
                Console.WriteLine(invalidText);
            }
        }
        static string GetValidUserStringInput(string text, string validInput, string invalidText)
        {
            /// Method for receiving input from the user as a string and validating it. 
            /// If the input is invalid, the user is prompted to try again.
            /// This method also takes two messages as parameter to allow customization of the prompt and error-message.

            while (true)
            {
                Console.Write(text);
                string? input = Console.ReadLine();
                if (input == validInput)
                {
                    return input;
                }
                Console.WriteLine(invalidText);
            }
        }

        static string GetArrayInput(string[] arrayName, int arrayPosition, string message, string errorMsg)
        { /// This method simplifies the process of adding user input to an array.
          /// It displays a custom message (message) based on the array element at the given position,
          /// prompts the user for input, and ensures the input is not empty or whitespace.
          /// If the input is invalid, an error message (errorMsg) is shown and the user is asked to try again.
          /// The method returns the validated input string.

            { 
                Console.Write($"{message} {arrayName[arrayPosition].ToLower()}: ");
                string userInput = "empty";
                do
                {
                    userInput = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(userInput)) 
                    {
                        Console.WriteLine(errorMsg);
                    }

                } while (string.IsNullOrWhiteSpace(userInput));
                return userInput;
            }
        }

        static void AddActivity(string[] weekdays, string[] activities)
        { /// This method allows the user to add activities to specific weekdays.
          /// It prompts the user to select a day (1–7), checks if an activity already exists for that day,
          /// and optionally asks whether to overwrite it.
          /// Once an activity is added, the user is asked if they want to add another one.
          /// The process repeats until the user chooses not to continue.
            bool addAnother; // Boolean flag to control the loop.
            Console.WriteLine(" ----- ADD ACTIVITY -----");

            do
            {
                int dayChoice = GetUserIntInput("Choose a day (1 - 7): ", 1, 7, "Invalid choice, try again.");
                dayChoice--;

                // If an activity already exists for the selected day, ask the user if they want to overwrite it.
                if (activities[dayChoice] != "")
                {
                    Console.WriteLine("An activity is already scheduled for this day.");
                    string overwriteActivity = GetValidUserStringInput("Do you want to overwrite it? (y/n) ", "y", "n");
                    if (overwriteActivity != "y")
                    {
                        // If the user chooses not to overwrite, return to the main menu.
                        break;
                    }
                }

                string activity = GetArrayInput(weekdays, dayChoice, "Add activity for ", "Invalid input, try again");
                activities[dayChoice] = activity;
                Console.WriteLine();

                // Ask the user if they want to add another activity.
                string addAnotherInput = GetValidUserStringInput("Do you want to add another activity? (y/n) ", "y", "n");
                addAnother = addAnotherInput == "y"; // Continue the loop if the user answers yes.
                Console.WriteLine();

            } while (addAnother == true);
        }
    }
}
