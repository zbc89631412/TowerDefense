using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanbingEffect : MonoBehaviour
{

    public Transform BonePosition;
    public Transform BoneRotation;
    [HideInInspector]
    public GameObject[] effect_1;
    [HideInInspector]
    public GameObject[] effect_2;

    public GameObject[] effectPrefab_1;
    public GameObject[] effectPrefab_2;
    GameObject[] InstantiateEffect(GameObject[] effectPrefab)
    {
        int len = effectPrefab.Length;
        GameObject[] effect = new GameObject[len];
        for (int i = 0; i < len; i++)
        {
            effect[i] = Instantiate(effectPrefab[i], BonePosition.position, BoneRotation.rotation);
        }
        return effect;
    }
    public void PlayEffect1()
    {
        //Debug.Log("Play");
        effect_1 = InstantiateEffect(effectPrefab_1);
        //DestroyArrow(effect_1[effect_1.Length - 1]);
    }
    public void PlayEffect2()
    {
        effect_2 = InstantiateEffect(effectPrefab_2);
        DestroyArrow(effect_2[effect_2.Length - 1]);
    }
    void DestroyArrow(GameObject effect)
    {
        GameObject arrowRoot = effect.transform.Find("TransformMotion").gameObject;
        
        if (arrowRoot.transform.Find("Arrow").gameObject != null)
        {
            GameObject arrow = arrowRoot.transform.Find("Arrow").gameObject;
            Destroy(arrow);
        }

        
    }
}
