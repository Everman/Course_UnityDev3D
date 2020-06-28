using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private string greeting = "";
    private bool nameProvided = false;
    private enum Screen { MainMenu, Password, Win };
    private Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        EnterName();
    }

    private void EnterName() {
        Terminal.WriteLine("Hello! Please write your name: ");
    }

    void StartMainMenu(string greeting) {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("1 Easy:   Neighbors");
        Terminal.WriteLine("2 Medium: Work");
        Terminal.WriteLine("3 Hard:   Pentagon");
        Terminal.WriteLine("Press 1,2, or 3 to continue...");
        Terminal.WriteLine("");
        currentScreen = Screen.MainMenu;
    }

    void OnUserInput(string input) {
        if (nameProvided) {
            if (input == "1") {
                currentScreen = Screen.Password;
                StartGame();
            } else if (input == "2") {
                currentScreen = Screen.Password;
                StartGame();
            } else if (input == "3") {
                currentScreen = Screen.Password;
                StartGame();
            } else if (input == "menu") {
                StartMainMenu(greeting);
            } else if (input == "007") {
                Terminal.WriteLine("Welcome Mr.Bond! Please choose a level...");
            } else {
                Terminal.WriteLine("Invalid input. Choose 1 , 2, or 3!");
            }
        } else {
            nameProvided = true;
            greeting = "Welcome " + input;
            StartMainMenu(greeting);
        }
    }

    private void StartGame() {
        Terminal.WriteLine("Level " + currentScreen + " selected.");
    }
}
