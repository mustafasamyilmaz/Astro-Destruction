using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1); // 1 = CurrentGameScene
        }

        else if(Input.GetKeyDown(KeyCode.J) && _isGameOver == true)
        {
            SceneManager.LoadScene(0); // 0 = MainMenu
        }
    }

    public void GameOver() 
    {
        _isGameOver = true;
    }
}
