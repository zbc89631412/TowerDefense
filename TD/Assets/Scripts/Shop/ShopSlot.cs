using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSlot : MonoBehaviour
{
    public GameObject[] intruductionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetHealthTextActive()
    {
        intruductionText[(int)Introduction.health].SetActive(true);
        intruductionText[(int)Introduction.shield].SetActive(false);
        intruductionText[(int)Introduction.speed].SetActive(false);
        intruductionText[(int)Introduction.attack].SetActive(false);
    }

    public void SetShieldTextActive()
    {
        intruductionText[(int)Introduction.health].SetActive(false);
        intruductionText[(int)Introduction.shield].SetActive(true);
        intruductionText[(int)Introduction.speed].SetActive(false);
        intruductionText[(int)Introduction.attack].SetActive(false);
    }

    public void SetSpeedTextActive()
    {
        intruductionText[(int)Introduction.health].SetActive(false);
        intruductionText[(int)Introduction.shield].SetActive(false);
        intruductionText[(int)Introduction.speed].SetActive(true);
        intruductionText[(int)Introduction.attack].SetActive(false);
    }

    public void SetAttackTextActive()
    {
        intruductionText[(int)Introduction.health].SetActive(false);
        intruductionText[(int)Introduction.shield].SetActive(false);
        intruductionText[(int)Introduction.speed].SetActive(false);
        intruductionText[(int)Introduction.attack].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
enum Introduction{
    health,shield,speed,attack
}
