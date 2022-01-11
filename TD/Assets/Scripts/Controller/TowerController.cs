using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public int[] damageValue;
    public float speed = 10000;
    public float attackRadius;
    Transform target;
    public Transform spawnPosition;
    public Transform shootPos;
    public GameObject startParticlePrefab;
    //public GameObject[] particlePrefabs;
    GameObject startParticle;
    bool hasParticle = false;
    TowerStatus myStat;
    public int difference;
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= attackRadius)
        {
            if(!hasParticle)
            {
                startParticle = Instantiate(startParticlePrefab, spawnPosition.position,Quaternion.identity,spawnPosition);
                hasParticle = true;
                CharacterStats targetStat = target.GetComponent<CharacterStats>();
                if (targetStat != null)
                {
                    Attack(targetStat);
                }

            }
             
        }
        else
        {
            if (hasParticle)
            {
                Destroy(startParticle);
                hasParticle = false;
            }
        }

    }

    void Attack(CharacterStats targetStat)
    {
        myStat = GetComponent<TowerStatus>();
        int health = myStat.currentHealth;
        Debug.Log("currentHealth" + health);
        Debug.Log("difference" + difference);
        if (health <= 0)
            return;
        int index = health / difference;
        Debug.Log("index " + index);
        //Debug.Log("particle length " + particlePrefabs.Length);
        int length = Shoot.instance.GetAmount();
        if (index ==length)
        {
            // particle = Instantiate(particlePrefabs[index-1], spawnPosition.position, Quaternion.identity, spawnPosition);
            Shoot.instance.ShootBullet(target, shootPos, index-1);
            myStat.damage.SetValue(damageValue[index - 1]);
        }
        else
        {
            //particle = Instantiate(particlePrefabs[index], spawnPosition.position, Quaternion.identity, spawnPosition);
            Shoot.instance.ShootBullet(target, shootPos, index);
            myStat.damage.SetValue(damageValue[index]);
        }
        
       
        targetStat.TakeDamage(myStat.damage.GetValue());

    }


}
