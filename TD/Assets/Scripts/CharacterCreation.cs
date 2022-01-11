using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    #region Singleton
    public static CharacterCreation instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject[] characterPrefabs;
    GameObject[] characterGameObjects;
    [HideInInspector]
    public int characterIndex = 0;
    int characterAmount;
    //public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        characterAmount = characterPrefabs.Length;
        characterGameObjects = new GameObject[characterAmount];
        for(int i = 0; i < characterAmount; i++)
        {
            characterGameObjects[i] = Instantiate(characterPrefabs[i],transform.position ,transform.rotation,transform);
        }
        ShowCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowCharacter()
    {
        characterGameObjects[characterIndex].SetActive(true);
        for(int i = 0; i < characterAmount; i++)
        {
            if (i != characterIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonDown()
    {
        characterIndex++;
        characterIndex %= characterAmount;
        //Debug.Log("index is " + characterIndex);
        ShowCharacter();
    }

    public void OnPrevButtonDown()
    {
        
        if (characterIndex == 0)
        {
            characterIndex = characterAmount - 1;
        }
        else
            characterIndex--;
        //Debug.Log("index is " + characterIndex);
        ShowCharacter();
    }
}
