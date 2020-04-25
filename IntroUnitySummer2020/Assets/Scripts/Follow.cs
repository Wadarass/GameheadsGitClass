using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followDistance;
    public Vector3 followOffset;
    public float cameraFollowSpeed = 0.1f;
    public float cameraRotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        transform.position = targetPosition + followVector + followOffset;

        transform.rotation = Quaternion.LookRotation(target.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector + followOffset;

        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, 
            cameraFollowSpeed * Time.deltaTime);
        
        //Which way is the capsule facing - target.transform.forward
        Vector3 targetForward = target.transform.forward;

        //Taking the camera direction and slowly rotating towards the capsule forward
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetForward,
            cameraRotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    //Vector3 cameraTargetPosition = CalculateCameraTargetPosition();
    /*
    Vector3 CalculateCameraTargetPositionAndRotation()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;

        return cameraTargetPosition;
    }*/
}
