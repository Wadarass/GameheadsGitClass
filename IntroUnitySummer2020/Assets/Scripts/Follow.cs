using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public float followDistance;
    public float cameraFollowSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        transform.position = targetPosition + followVector;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;
        
        transform.position = Vector3.Lerp(transform.position, cameraTargetPosition, 
            cameraFollowSpeed * Time.deltaTime);
    }

    //Vector3 cameraTargetPosition = CalculateCameraTargetPosition();
    /*
    Vector3 CalculateCameraTargetPosition()
    {
        Vector3 targetPosition = target.transform.position;

        Vector3 followVector = transform.forward * -followDistance;

        Vector3 cameraTargetPosition = targetPosition + followVector;

        return cameraTargetPosition;
    }*/
}
