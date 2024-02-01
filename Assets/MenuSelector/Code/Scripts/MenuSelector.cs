using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelector : MonoBehaviour
{
    public void AdventureText()
    {
        SceneManager.LoadScene("MainMenuAdventureText");
    }

    public void AirHockey()
    {
        SceneManager.LoadScene("MainMenuAirHockey");
    }

    public void TopGun()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameSuika()
    {
        SceneManager.LoadScene("GameSuika");
    }

    public void Pacman()
    {
        SceneManager.LoadScene("GamePacman");
    }

    public void Tetris()
    {
        SceneManager.LoadScene("GameTetris");
    }



}
