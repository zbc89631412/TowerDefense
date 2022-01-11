using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    //Animator ani;
    public Transform target;
    public static float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //ani = GetComponent<Animator>();
    }
    public void Update()
    {
        agent.speed = speed;
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }
    public void FollowTarget(Interactable interactable)
    {
         
        agent.stoppingDistance = interactable.radius * .8f;
        agent.updateRotation = false;
        target = interactable.transform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
        target = null;
    }

    public void MoveToPoint(Vector3 point)
    {
        //ani.SetInteger("state2", AnimState.RUN);
        agent.SetDestination(point);
    }
}
