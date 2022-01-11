using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
       
        instance = this;
       
    }
    #endregion
    //public GameObject characterSpawner;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    { 
          
    }
    
    // Update is called once per frame
    void Update()
    {
     
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
