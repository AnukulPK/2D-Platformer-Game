using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static int health=3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

     void Start()
    {
        RefreshHealthStatus();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for(int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    private void RefreshHealthStatus()
    {
        health=3;
    }
}
