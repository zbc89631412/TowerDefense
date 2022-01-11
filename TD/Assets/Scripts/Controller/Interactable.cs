using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 5;
    public Transform interactionTrans;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;

   
    public virtual void Interact()
    {
        //Debug.Log("Interaction with " + transform.name);
    }

    void Update()
    {
        if (isFocus&&!hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTrans.position);
            if (distance < radius)
            {
               // Debug.Log("Interaction");
                Interact();
                hasInteracted = true;
            }
        }
        
    }
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;

    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTrans == null)
        {
            interactionTrans = transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionTrans.position, radius);
    }
}
