using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Trigger : MonoBehaviour
{
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        
        // Invoke("Escape",10.0f);
//        print(collider.gameObject.name);
         if(collider.gameObject.name == "exit")
         {
             print("exit!!!");
             //Invoke("Escape",10.0f);
             GetComponent<Enemy>().loadScene = true;
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

         }

    }
    void Escape(){
         
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
