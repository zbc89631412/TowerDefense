using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform target;
    public float sensitivityMouse = 2.0f;
    private float mouseX = 0.0f;
    private float mouseY = 0.0f;
    public float mouseSpeed = 5.0f;
    private float mouseScroll = 0.0f;
    private float minY = 5.0f;
    private float maxY = 180.0f;
    public float distance = 2.0f;//观察距离

    public float damping = 2.0f; //相机移动速度

    public float maxFov = 90.0f;
    public float minFov = 15.0f;
    public float sensitivityScroll = 10.0f;

    public float x;
    public float y;

    public GameObject GameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    Transform GetTarget()
    {
        CharacterSpawner spawner = GameController.GetComponent<CharacterSpawner>();
        GameObject character = spawner.GetCharacter();
        target = character.transform;
        return target;
    }
    private void LateUpdate()
    {
        GetTarget();
        Quaternion mRotation;
        Vector3 mPosition;
        //Vector3 offset = transform.position - target.position;
        //transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * damping);
        
                mouseX += Input.GetAxis("Horizontal") * sensitivityMouse;
                mouseY -= Input.GetAxis("Vertical") * sensitivityMouse;

                mouseY = ClampAngle(mouseY, minY, maxY);

                mRotation = Quaternion.Euler(mouseY, mouseX, 0);
                mPosition = mRotation * new Vector3(0.0f, 2.0f, -distance) + target.position;

                transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * damping);
                transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * damping);
            
        
           
        
        /*else
        {
            //Vector3 offset = transform.position - target.position;
            //transform.position = Vector3.Lerp(transform.position, target.position+offset, Time.deltaTime * damping);
             mRotation = Quaternion.LookRotation(target.position);
             mPosition =  mRotation * new Vector3(0.0f, 2.0f, -distance) + target.position;
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * damping);
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * damping);
        }*/
            mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            float fov = Camera.main.fieldOfView;
            fov += mouseScroll * sensitivityScroll;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;

    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
