using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    // GameObject[] characterPrefab;
    public GameObject[] characterPrefab;
    GameObject character;
    public Transform characterTran;
    public Transform camera;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        //characterPrefab=CharacterCreation.instance.characterPrefabs;
        //character = GameObject.Instantiate(characterPrefab[CharacterCreation.instance.characterIndex], characterTran.position, Quaternion.identity);
        character = GameObject.Instantiate(characterPrefab[CharacterCreation.instance.characterIndex], characterTran.position, Quaternion.identity);
        character.transform.parent = parent.transform;
    }

    void SetCemara()
    {
        PlayerController playerController = character.GetComponent<PlayerController>();
        playerController.SetCamera(camera);
    }

    public GameObject GetCharacter()
    {
        //Debug.Log("return character" + character.name);
        return character;
    }
    // Update is called once per frame
    void Update()
    {
        //SetCemara();
        //PlayerMove playerMove = character.GetComponent<PlayerMove>();
       // playerMove.Move();
    }
}
