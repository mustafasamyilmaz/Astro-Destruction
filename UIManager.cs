using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoretext;
    [SerializeField]
    private Image _currentLives;
    [SerializeField]
    private Sprite[] _livesSprite;
    [SerializeField]
    private GameObject _gameOver;
    [SerializeField]
    private Text _restart;
    [SerializeField]
    private Text _backToMenu;
    
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _scoretext.text = "Score " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(_gameManager == null)
        {
            Debug.LogError("gamemanager null");
        }
        
    }

    
    public void UpdateScore(int playerScore)
    {
        _scoretext.text = "Score " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _currentLives.sprite = _livesSprite[currentLives];
        if (currentLives == 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        _gameManager.GameOver();
        StartCoroutine(GameOverFlicker());
        _restart.gameObject.SetActive(true);
        _backToMenu.gameObject.SetActive(true);
    }
    

    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            _gameOver.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOver.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
