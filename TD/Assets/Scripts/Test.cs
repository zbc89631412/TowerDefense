using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void GetKey()
    {
        float v = Input.GetAxis("Horizontal");
        Debug.Log("v is "+v);
        animator.SetFloat("speedPercent", v);

    }

    // Update is called once per frame
    void Update()
    {
        GetKey();
    }
}
