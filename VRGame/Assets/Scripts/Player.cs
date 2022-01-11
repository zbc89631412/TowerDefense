using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public int maxHealth=100;
    public int currentHealth ;
    public Animator animator;
    public Healthbar healthBar; 
    public Text curHealthText;
    public Text maxHealthText;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       healthBar.SetMaxHealth(maxHealth);
       maxHealthText.text = maxHealth.ToString();
       enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
       healthBar.SetHealth(currentHealth);
       curHealthText.text = currentHealth.ToString();

        if(currentHealth<=0){
             GetComponent<Gun>().isDead = true;         
             Invoke("Death",5.0f);
            
        }
    }
    void Death(){
         
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     void OnTriggerEnter(Collider collider){
         if(collider.gameObject.name == "exit")
         {
             print("exit!!!");
             Invoke("Death",10.0f);

         }

    

         
     }
}
