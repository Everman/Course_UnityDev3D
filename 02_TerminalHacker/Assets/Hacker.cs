using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen = Screen.MainMenu;

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
        if (input == "menu") {
            StartMainMenu();
        } else if (input == "007") {
            Terminal.WriteLine("Welcome Mr.Bond! Please choose a level...");
        } else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        } else {

        }
    }

    private void RunMainMenu(string input) {
        if (input == "menu") { // We can always go back to main menu
            StartMainMenu();
        } else if (input == "1") {
            currentScreen = Screen.Password;
            StartGame();
        } else if (input == "2") {
            currentScreen = Screen.Password;
            StartGame();
        } else if (input == "3") {
            currentScreen = Screen.Password;
            StartGame();
        } else {
            Terminal.WriteLine("Invalid input. Choose 1 , 2, or 3!");
        }
    }

    private void StartGame() {
        Terminal.WriteLine("Level " + currentScreen + " selected.");
    }
}
