using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCanvas : MonoBehaviour
{
    #region Singleton
    public static LastCanvas instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public static bool gameIsOver = false;
    public static bool isLost = false;
    public int count = 0;

    public GameObject winText;
    public GameObject failText;
    public GameObject gameOverMenu;
    int playerHealthValue;

    


    // Update is called once per frame
    void Update()
    {
        playerHealthValue = PlayerManager.instance.player.GetComponent<CharacterStats>().currentHealth;
        if (playerHealthValue<=0)
        {
            Invoke("LoadLoseMenu", 2.0f);

        }
        if (count == 3)
        {
            Invoke("LoadWinMenu", 2.0f);
        }
    }

    void LoadLoseMenu()
    {
        gameOverMenu.SetActive(true);
        failText.SetActive(true);
    }

    void LoadWinMenu()
    {
        gameOverMenu.SetActive(true);       
            winText.SetActive(true);     
    }
}
