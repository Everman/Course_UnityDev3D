using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;
    private enum DifficultyLevel { Easy, Medium, Hard };
    private DifficultyLevel difficulty;
    
    private enum EasyPasswords { skipper, sky, spike, frodo, tippy };
    private enum MediumPasswords { meern, sentia, performance, yvalidate, ymonitor };
    private enum HardPasswords { chronometer, postmaster, deadlight, teardrop, diplomat };

    // Start is called before the first frame update
    void Start()
    {
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
        } else if (input == "exit" || input == "quit") {
            UnityEditor.EditorApplication.isPlaying = false;
        } else if (input == "007") {
            Terminal.WriteLine("Welcome Mr.Bond! Please choose a level...");
        } else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        } else if ( currentScreen == Screen.Win ) {
            Terminal.WriteLine("Already won, type menu to restart!");
        } else {

        }
    }

    private void RunMainMenu(string input) {
        if (input == "menu") { // We can always go back to main menu
            StartMainMenu();
        } else if (input == "1") {
            difficulty = DifficultyLevel.Easy;
            StartGame();
        } else if (input == "2") {
            difficulty = DifficultyLevel.Medium;
            StartGame();
        } else if (input == "3") {
            difficulty = DifficultyLevel.Hard;
            StartGame();
        } else {
            Terminal.WriteLine("Invalid input. Choose 1 , 2, or 3!");
        }
    }

    private void CheckPassword(string input) {
        bool passwordCorrect = false;
        string[] passwords = null;

        if (difficulty == DifficultyLevel.Easy) {
            passwords = System.Enum.GetNames(typeof(EasyPasswords));
        } else if (difficulty == DifficultyLevel.Medium) {
            passwords = System.Enum.GetNames(typeof(MediumPasswords));
        } else if (difficulty == DifficultyLevel.Hard) {
            passwords = System.Enum.GetNames(typeof(HardPasswords));
        } else {
            Debug.LogError("Unknown difficulty level!");
        }

        if(passwords != null) {
            for (int i = 0; i < passwords.Length; i++) {
                if (input == passwords[i]) {
                    passwordCorrect = true;
                    break;
                }
            }

            if (passwordCorrect) {
                Terminal.WriteLine("Password entered correctly!");
                currentScreen = Screen.Win;
            } else {
                Terminal.WriteLine("Wrong password, please try again!");
            }
        }

    }

    private void StartGame() {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        Terminal.WriteLine("Level " + difficulty + " selected.");
        Terminal.WriteLine("Enter password...");
    }

}
