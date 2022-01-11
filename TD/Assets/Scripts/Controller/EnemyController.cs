using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public float lookRadius = 3.0f;
    Transform target;
    NavMeshAgent agent;
    public Transform centre;
    public int minRange = 30;
    public int maxRange = 50;
    // Start is called before the first frame update
    CharacterCombat enemyCombat;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //target = PlayerManager.instance.player.transform;
        target = PlayerManager.instance.player.transform;
        enemyCombat = GetComponent<CharacterCombat>();
        centre = GameObject.FindGameObjectWithTag("centre").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
            target = PlayerManager.instance.player.transform;
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                if (targetStats != null)
                {
                    enemyCombat.Attack(targetStats);
                }
                   
                    FaceTarget();// make sure face the target
                }
            }
        else
            agent.SetDestination(transform.position + GetRandomDir() * Random.Range(minRange,maxRange));             
    }

    Vector3 GetRandomDir()
    {
        float x = Random.Range(-1.0f, 1.0f);
        float z = Random.Range(-1.0f, 1.0f);

        return new Vector3(x, z).normalized;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
