using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController: MonoBehaviour
{
   
   
    public Transform followedCamera;

   
 
    public void SetCamera(Transform camera)
    {
        followedCamera = camera;
    }
   
    Camera cam;
    PlayerMotor motor;
    public void Start()
    {
       // Debug.Log("Start");
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
       
    }

    
    public void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                
                motor.MoveToPoint(hit.point);
                RemoveFocus();
                
            }
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,100))
            {
               // Debug.Log("right mouse hit");            
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                  //  Debug.Log("interactable is not null");
                    SetFocus(interactable);
                }
                
            }

        }

        
    }
    public Interactable focus;
    void SetFocus(Interactable newFocus)
    {
        if (newFocus!=focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget(newFocus);

        }
        newFocus.OnFocused(transform);

        
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
   
}
