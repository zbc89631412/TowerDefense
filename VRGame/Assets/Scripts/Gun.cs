using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Gun : MonoBehaviour {

    public GameObject end, start; // The gun start and end point
    public GameObject[] gun;
    public Animator animator;
    
    public GameObject spine;
    public GameObject handMag;
    public GameObject gunMag;
    public GameObject bulletHole;
    public GameObject muzzleFlash;
    public GameObject shotSound;
    public GameObject enemy;
    float gunShotTime = 0.1f;
    float gunReloadTime = 1.0f;
    Quaternion previousRotation;
    public float health = 100;
    public bool isDead;
    int flag = 0;

    public Text magBullets;
    public Text remainingBullets;

    int magBulletsVal = 30;
    int remainingBulletsVal = 90;
    int magSize = 30;
    public GameObject headMesh;
    public static bool leftHanded { get; private set; }
    
    // Use this for initialization
    void Start() {
        headMesh.GetComponent<SkinnedMeshRenderer>().enabled = false; // Hiding player character head to avoid bugs :)
        enemy = GameObject.FindWithTag("Enemy");
       // print(enemy);
    }

    // Update is called once per frame
    void Update() {
        
        // Cool down times
        if (gunShotTime >= 0.0f)
        {
            gunShotTime -= Time.deltaTime;
        }
        if (gunReloadTime >= 0.0f)
        {
            gunReloadTime -= Time.deltaTime;
        }
      

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && gunShotTime <= 0 && gunReloadTime <= 0.0f && magBulletsVal > 0 && !isDead)
        { 
            enemy.GetComponent<Enemy>().isBeingShooted=true;
            shotDetection(); // Should be completed

            addEffects(); // Should be completed

            animator.SetBool("fire", true);
            gunShotTime = 0.5f;
            
            // Instantiating the muzzle prefab and shot sound
            
            magBulletsVal = magBulletsVal - 1;
            if (magBulletsVal <= 0 && remainingBulletsVal > 0)
            {
                animator.SetBool("reloadAfterFire", true);
                gunReloadTime = 2.5f;
                Invoke("reloaded", 2.5f);
            }
        }
        else
        {
            animator.SetBool("fire", false);
        }
       
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.R)) && gunReloadTime <= 0.0f && gunShotTime <= 0.1f && remainingBulletsVal > 0 && magBulletsVal < magSize && !isDead )
        {
            animator.SetBool("reload", true);
            gunReloadTime = 2.5f;
            Invoke("reloaded", 2.0f);
        }
        else
        {
            animator.SetBool("reload", false);
        }
         if((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Q))){
            animator.SetBool("swap", true);
            Invoke("Swap",2.0f);
        }
        updateText();
       
    }

   public void Swap(){
       gun[flag].SetActive(false);
            flag = (flag+1)%2;
            gun[flag].SetActive(true);
   }

    public void Being_shot(float damage) // getting hit from enemy
    {
        
    }

    public void ReloadEvent(int eventNumber) // appearing and disappearing the handMag and gunMag
    {
        if(eventNumber==1)
        {
            handMag.GetComponent<SkinnedMeshRenderer>().enabled = true;
            gunMag.GetComponent<SkinnedMeshRenderer>().enabled = false;
             print("reload event");
        }
        else if(eventNumber==2){
            handMag.GetComponent<SkinnedMeshRenderer>().enabled = false;
            gunMag.GetComponent<SkinnedMeshRenderer>().enabled = true;
            print("reload event");
        }
       //print("reload event");
    }

    void reloaded()
    {
        int newMagBulletsVal = Mathf.Min(remainingBulletsVal + magBulletsVal, magSize);
        int addedBullets = newMagBulletsVal - magBulletsVal;
        magBulletsVal = newMagBulletsVal;
        remainingBulletsVal = Mathf.Max(0, remainingBulletsVal - addedBullets);
        animator.SetBool("reloadAfterFire", false);
    }

    void updateText()
    {
        magBullets.text = magBulletsVal.ToString() ;
        remainingBullets.text = remainingBulletsVal.ToString();
    }

    void shotDetection() // Detecting the object which player shot 
    {
        float enemy_distance = Vector3.Distance(transform.position, enemy.transform.position);
        RaycastHit rayHit;
        int layerMask = 1<<8;
        layerMask = ~layerMask;
        if(Physics.Raycast(end.transform.position,(end.transform.position-start.transform.position).normalized,out rayHit,100.0f,layerMask))
        {
            GameObject bulletHoleObject = Instantiate(bulletHole,rayHit.point+rayHit.collider.transform.up*0.01f,rayHit.collider.transform.rotation);
            Destroy(bulletHoleObject,2.0f);
            print("shot at "+rayHit.collider.tag);

            
                print("enemy dead");
                rayHit.collider.GetComponent<Animator>().SetBool("enemy_dead", true);
                rayHit.collider.GetComponent<Enemy>().isDead = true;
                rayHit.collider.GetComponent<Enemy>().Death();
                
            
        }
       
    }

    void addEffects() // Adding muzzle flash, shoot sound and bullet hole on the wall
    {
        
        GameObject muzzleFlashObject = Instantiate(muzzleFlash,end.transform.position,end.transform.rotation);
        muzzleFlashObject.GetComponent<ParticleSystem>().Play();
        Destroy(muzzleFlashObject,1.0f);
        Destroy((GameObject) Instantiate(shotSound,transform.position,transform.rotation),1.0f);
        
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "ammo"){
            print("reach ammo crater");
            magBulletsVal += 10;
        }
    }

}
