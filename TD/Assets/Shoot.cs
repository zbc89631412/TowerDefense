using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    #region Singleton
    public static Shoot instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject[] particlePrefabs;
    public float speed;
    
    public Transform cube;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    public int GetAmount()
    {
        return particlePrefabs.Length;
    }

    public void ShootBullet(Transform target, Transform startPos, int index)
    {
       
        
            Debug.Log("startPos " + startPos.position);
            GameObject particle = Instantiate(particlePrefabs[index], startPos);
            particle.transform.LookAt(target.position);
            Vector3 direction = target.position - particle.transform.position;
            particle.GetComponent<Rigidbody>().AddForce(direction * speed);
        
        //particle.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject particle = Instantiate(particlePrefabs[0],position);
            particle.transform.LookAt(cube.position);
            //Vector3 direction = target.position - particle.transform.position;
            particle.GetComponent<Rigidbody>().AddForce( particle.transform.forward* speed);
        }
    }
}
