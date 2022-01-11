using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemySpawner : MonoBehaviour
{
    public Transform[] towerTreePos;
    public GameObject enemyPrefab;
    //public Transform enemyParent;
    GameObject[] enemies;
    NavMeshAgent[] agents;
    public int minStartPosRange = 10;
    public int maxStartPosRange = 20;
    public int minRoamingRange = 50;
    public int maxRoamingRange = 60;
    public int enemyNum = 12;
    bool hasAgent = false;
    // Start is called before the first frame update
    void Start()
    {     
        CreateEnemies();
       
        //FindEnemies();

    }

    // Update is called once per frame
    void Update()
    {
       
       /* if (!hasAgent)
        {
            SetAgent();
            hasAgent = true;
        }
        GetEnemiesRoaming();*/
    }

    void FindEnemies()
    {
        int count = 0;
      
        
        agents = new NavMeshAgent[enemyNum];
       foreach(Transform child in transform)
        {
            if (child != null)
            {
                agents[count] = child.gameObject.GetComponent<NavMeshAgent>();
                count++;
                Debug.Log("success");
            }
            
        }
    }

    

    void SetAgent()
    {
        agents = gameObject.GetComponentsInChildren<NavMeshAgent>();
    }

    void GetEnemiesRoaming()
    {
        Vector3 destination;
        int towerNum = towerTreePos.Length;
        for(int i = 0; i < enemies.Length; i++)
        {
            destination = GetPosition(towerTreePos[i / towerNum].position,
                minRoamingRange, maxRoamingRange);
            if (i == 0)
            {
               // Debug.Log("destination is " + destination);
            }
            agents[i].SetDestination(destination);

        }
    }

    void CreateEnemies()
    {
        //Debug.Log("Create Enemies");
        int startPosNum = towerTreePos.Length;
        enemies = new GameObject[enemyNum];
        Vector3 enemyStartPos;
        for(int i = 0; i < startPosNum; i++)
        {
            for(int j = 0; j < (int)enemyNum / startPosNum; j++)
            {
                enemyStartPos = GetPosition(towerTreePos[i].position, minStartPosRange, maxStartPosRange);
                enemies[j] = Instantiate(enemyPrefab,enemyStartPos , Quaternion.identity, transform);
            }
        }
    }

    Vector3 GetPosition(Vector3 startPosition, int min, int max)
    {
        return startPosition + GetRandomDir() * Random.Range(min,max);
    }

    Vector3 GetRandomDir()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);
       
        return new Vector3(x, z).normalized;
    }

   
}
