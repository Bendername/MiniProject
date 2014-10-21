using UnityEngine;
using System.Collections;

public class GameStates : MonoBehaviour {


    public void StartGame()
    {
        Application.LoadLevel("mainScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
