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

    Vector3 CalculateCameraTargetPosition()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector + followOffset;

        return cameraTargetPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = CalculateCameraTargetPosition();

        transform.rotation = Quaternion.LookRotation(target.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraTargetPosition = CalculateCameraTargetPosition();

        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, 
            cameraFollowSpeed * Time.deltaTime);
        
        //Which way is the capsule facing - target.transform.forward
        Vector3 targetForward = target.transform.forward;

        //Taking the camera direction and slowly rotating towards the capsule forward
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetForward,
            cameraRotationSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
