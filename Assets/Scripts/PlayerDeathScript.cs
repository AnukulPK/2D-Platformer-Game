using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathScript : MonoBehaviour
{
    public GameOverController gameOverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Level is over
            /* Debug.Log("Oops, you are dead");
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
            gameOverController.PlayerDied();
            this.enabled = false;
        }
    }
}
