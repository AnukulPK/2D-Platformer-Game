using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Level is over
            Debug.Log("Oops, you are dead");
        }
    }
}
