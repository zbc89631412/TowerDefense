using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    int a = 5;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("a is in Start" + a);
        StartCoroutine(Change());
        Debug.Log("a is after Change" + a);

    }
    IEnumerator Change()
    {
        
        Debug.Log("print first");
        yield return new WaitForSeconds(5.0f);
        a = 0;
        Debug.Log(" after five seconds a is " + a);
        Debug.Log("print after 5 seconds");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
