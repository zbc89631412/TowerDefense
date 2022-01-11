// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class Enemy : MonoBehaviour
// {
//     public GameObject end, start; // The gun start and end point
//     public GameObject enemy;
//     public Animator animator;
//     UnityEngine.AI.NavMeshAgent agent;
//     public Transform[] targets;
//      public int minRange = 3;
//     public int maxRange = 5;
//     float speed = 2;
//     float delta = 0.5f;
//     public Transform origin;
//     public GameObject handMag;
//     public GameObject gunMag;
//     int flag=0 ;
//     bool firt_time = true;
//     public GameObject player;
//     public float stoppingDistance = 10;
//     public bool isDead = false;
//     public GameObject bulletHole;
//     public GameObject muzzleFlash;
//     public GameObject shotSound;
//     private int playerHealth;
//     float gunReloadTime = 1.0f;
//         float gunShotTime = 0.1f;
//        public bool isBeingShooted=false;
//         Transform enemyPosition;
//         Transform gunPosition;
//         public GameObject gun;
//         public bool loadScene = false;
       
//     // Start is called before the first frame update
//     void Start()
//     {
//         agent=GetComponent<UnityEngine.AI.NavMeshAgent>();
       
//         //origin = transform.position;
//         player = GameObject.Find("Player");

//     }
    
//     // Update is called once per frame
//     void Update()
//     {
//         if(isDead){
//             //print("enemy is dead");
//         }
//     RaycastHit rayHit;
//         // if(isDead){
//         //     Invoke("Death",4.0f);
//         // }
//         playerHealth = player.GetComponent<Player>().currentHealth;
//     if(loadScene)
//     {print("loadScence");print(loadScene);
//         animator.SetBool("enemy_idle",true);

//     }
//     if(!isDead&&playerHealth>0&&!loadScene)    
//     {
   
         
//        //Invoke("Reload",3.0f);
//       // transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targets[2].transform.position- transform.position),Time.deltaTime*0.1f);
//        //transform.position = (targets[2].position-transform.position)*Time.deltaTime;
//       //float dist_player = Vector3.Distance(transform.position, player.transform.position);
//     if (gunShotTime >= 0.1f)
//             {
//                 gunShotTime -= Time.deltaTime;
//                 //animator.SetBool("enemy_fire", false);
//             }
//         if(detect_player()){
            
//             float distance = Vector3.Distance(player.transform.position, transform.position);
         
//             if(distance>stoppingDistance){
//                 //print("chasing");
//                 FaceTarget();
//                 //animator.SetFloat("enemy_speed",2);
//                 //agent.SetDestination(player.transform.position);
//                 animator.SetBool("enemy_walk",true);
//                 animator.SetBool("enemy_idle",false);
//                  //animator.SetBool("enemy_fire", false);

//             } 
//                if (distance <= stoppingDistance&& gunShotTime <0.1f)
//                 {
                     
//                     gunShotTime = 0.8f;
//                    FaceTarget();
//                     animator.SetBool("enemy_fire", true);
//                     animator.SetBool("enemy_idle",true);
//                    // animator.SetBool("enemy_walk",false);
//                       // make sure face the target
//                     Attack();
//                    // print("in firing distance");
//                 }
//                 //print("out of firing distance");
//             if(distance <= stoppingDistance&& gunShotTime >=0.1)
//             {
//                 animator.SetBool("enemy_fire", false);
//                 animator.SetBool("enemy_walk",true);
//                 //animator.SetBool("enemy_idle",true);
//                 FaceTarget();
//                 agent.SetDestination(player.transform.position);
//             }
             
      

                
//         }
//       // flag = 0;
//     if(!detect_player())
//     {
//          if(!JudgeDistance(flag)){
//               Roaming(flag);
//             // print(flag);
//           }
//           else{
//               flag = (flag+1)%targets.Length;
//           }
//     }
         
//     }
    
      
//     }

   
       
    
//     public void Death(){
//        Invoke("SeperateGun",3.0f);
//     //    gun.GetComponent<Rigidbody>().isKinematic = false;
//     //      gun.transform.SetParent(transform);
//     //      gun.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//         //Destroy(enemy);
//     }

//     public void SeperateGun(){
//          gun.GetComponent<Rigidbody>().isKinematic = false;
//          gun.transform.SetParent(this.transform);
//          gun.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//     }

//     void FaceTarget()
//     {
//         //print("face target");
//         transform.LookAt(player.transform.position);
//         Vector3 direction = (player.transform.position - transform.position).normalized;
//         Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//         transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2.0f);
//     }
//     //
//     void Attack(){
//             shotDetection(); // Should be completed

//             addEffects(); // Should be completed

           
        
//             //animator.SetBool("fire", true);
//             //gunShotTime = 0.5f;

//     }
//     void shotDetection() // Detecting the object which player shot 
//     {
//         RaycastHit rayHit;
//         int layerMask = 1<<8;
//         layerMask = ~layerMask;
//          float randomAngle = Random.Range(-10, 10);
//         Vector3 axis = new Vector3(1, 1, 0);
//         var rotation = Quaternion.AngleAxis(randomAngle, axis);
// //        print(randomAngle);
//         if(Physics.Raycast(end.transform.position,rotation*(end.transform.position-start.transform.position).normalized,out rayHit,100.0f))
//         {
//             GameObject bulletHoleObject = Instantiate(bulletHole,rayHit.point+rayHit.collider.transform.up*0.01f,rayHit.collider.transform.rotation);
//             Destroy(bulletHoleObject,2.0f);
//             if(rayHit.collider.tag=="Player"){
//                 player.GetComponent<Player>().currentHealth -= 20 ;
//             }
// //            print(rayHit.collider.tag);
//         }
       
//     }

//     void addEffects() // Adding muzzle flash, shoot sound and bullet hole on the wall
//     {
        
//         GameObject muzzleFlashObject = Instantiate(muzzleFlash,end.transform.position,end.transform.rotation);
//         muzzleFlashObject.GetComponent<ParticleSystem>().Play();
//         Destroy(muzzleFlashObject,1.0f);
//         Destroy((GameObject) Instantiate(shotSound,transform.position,transform.rotation),1.0f);
        
//     }
//     bool JudgeDistance(int i){
//            if(transform.position.x > targets[i].position.x -  delta 
//             && transform.position.x < targets[i].position.x +  delta 
//             && transform.position.z > targets[i].position.z - delta&&
//                 transform.position.z < targets[i].position.z + delta)
//         {
//             return true;
//         }
//         return false;
        
//     }
//     void Roaming(int i)
//     {
//         transform.LookAt(targets[i].position);
//        　transform.Translate(Vector3.forward*Time.deltaTime*speed);
//     }
//      Vector3 GetDir()
//     {
        
//         return targets[0].position-transform.position;
//     }
//     void Reload()
//     {
//         //transform.rotation =Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(targets[1].transform.position - transform.position),Time.deltaTime*0.1f);

//         animator.SetBool("reload_bool",true);
//     }
//     public void EnemyReload(int eventNumber) // appearing and disappearing the handMag and gunMag
//     {
//         if(eventNumber==1)
//         {
//             handMag.GetComponent<SkinnedMeshRenderer>().enabled = true;
//             gunMag.GetComponent<SkinnedMeshRenderer>().enabled = false;
//              //print("reload event");
//         }
//         else if(eventNumber==2){
//             handMag.GetComponent<SkinnedMeshRenderer>().enabled = false;
//             gunMag.GetComponent<SkinnedMeshRenderer>().enabled = true;
//             //print("reload event");
//         }
//        //print("reload event");
//     }
//     bool detect_player()
//     {
//         float dist_player = Vector3.Distance(transform.position, player.transform.position);
//         //float player_direction = player.transform.position;
//         float angle_with_player = Vector3.Angle(player.transform.position,transform.forward);
//         //print(dist_player);
//         //)
//         //print("distance is "+dist_player);
//         //print("angle is "+angle_with_player);
//         if (dist_player<30&&System.Math.Abs(angle_with_player)<60)  
//         {
            
//            // print("detect player");
//              return true;
//         }
//         return false;
           
//     }

//     // void OnTriggerEnter(Collider collider){
//     //      if(collider.gameObject.name == "Player"){
//     //          print("enemy dead");
//     //             enemy.GetComponent<Animator>().SetBool("enemy_dead", true);
//     //             enemy.GetComponent<Enemy>().isDead = true;
//     //             enemy.GetComponent<Enemy>().Death();
//     //      }
//     // }
    
// }
