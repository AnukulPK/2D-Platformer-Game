using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button buttonLobby;
    public GameObject LevelSelection;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        buttonLobby.onClick.AddListener(ActivateLevelSelection);
    }
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }

    public void ReloadLevel()
    {
        Debug.Log("Player Died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ActivateLevelSelection()
    {
        LevelSelection.SetActive(true);
    }
}
