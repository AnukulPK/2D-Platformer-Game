﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    public GameObject LevelSelection;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///if (collision.gameObject.CompareTag("Player"))
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Level is over
            Debug.Log("Level Finished by the player!");
            LevelManager.Instance.MarkCurrentLevelComplete();
            ActivateLevelSelection();
        }
    }

    private void ActivateLevelSelection()
    {
        LevelSelection.SetActive(true);
    }
}
