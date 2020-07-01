using UnityEngine;

public class Hacker : MonoBehaviour {
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;


    private string password = null;
    private string[] easyPasswords = { "skipper", "sky", "spike", "frodo", "tippy" };
    private string[] mediumPasswords = { "meern", "sentia", "performance", "yvalidate", "ymonitor" };
    private string[] hardPasswords = { "chrono", "postmaster", "light", "tear", "pentagon" };

    private int level;

    // Start is called before the first frame update
    void Start() {
        StartMainMenu();
    }

    void StartMainMenu() {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1 Easy:   Neighbors");
        Terminal.WriteLine("2 Medium: Work");
        Terminal.WriteLine("3 Hard:   Pentagon");
        Terminal.WriteLine("Press 1,2, or 3 to continue...");
        Terminal.WriteLine("");
        currentScreen = Screen.MainMenu;
    }

    void OnUserInput(string input) {
        input = input.ToLower(); // make everything lower case before checks, this is entry point so will pass it correctly to the rest of the functions
        
        if (input == "menu") {
            StartMainMenu();
        } else if (input == "exit" || input == "quit" || input == "abort") {
            Application.Quit();
        } else if (input == "007") {
            Terminal.WriteLine("Welcome Mr.Bond! Please choose a level...");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        } else if (currentScreen == Screen.Win) {
            Terminal.WriteLine("Already won, type menu to restart!");
        } else {
            Debug.LogError("Should never come here");
        }
    }

    private void RunMainMenu(string input) {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3" );
        if (isValidLevelNumber) {
            SetRandomPassword(input);
            StartGame();
        } else {
            Terminal.WriteLine("Invalid input. Choose 1 , 2, or 3!");
        }
    }

    private void SetRandomPassword(string input) {
        level = int.Parse(input);
        switch (level) {
            case 1:
                password = easyPasswords[UnityEngine.Random.Range(0, easyPasswords.Length)];
                break;
            case 2:
                password = mediumPasswords[UnityEngine.Random.Range(0, mediumPasswords.Length)];
                break;
            case 3:
                password = hardPasswords[UnityEngine.Random.Range(0, hardPasswords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    private void CheckPassword(string input) {
        if (input == password) {
            ShowWinScreen();
        } else {
            StartGame();
        }
    }

    private void ShowWinScreen() {
        Terminal.ClearScreen();
        currentScreen = Screen.Win;
        ShowLevelReward();
    }

    private void ShowLevelReward() {

        switch (level) {
            case 1:
                Terminal.WriteLine("Welcome to the neighborhood!");
                Terminal.WriteLine(@"
           __  
      (___()'`;
      /,    /`
     \\---\\   
");
                Terminal.WriteLine("Type 'menu' to return to main menu");
                break;
            case 2:
                Terminal.WriteLine("Welcome to Ymor network!");
                Terminal.WriteLine(@"
       \\   // 
        \\_// 
         \\/   
         //
        //
");
                Terminal.WriteLine("Type 'menu' to return to main menu");
                break;
            case 3:
                Terminal.WriteLine("Welcome to the Pentagon!");
                Terminal.WriteLine(@"
    ___
 __(   )====::
/~~~~~~~~~\
\O.O.O.O.O/
");
                Terminal.WriteLine("Type 'menu' to return to main menu");
                break;
            default:
                Debug.LogError("Unknown Level Code!");
                break;
        }
    }

    private void StartGame() {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("Type menu to return to main menu");
        Terminal.WriteLine("Please enter password, hint: " + password.Anagram());
    }

}
