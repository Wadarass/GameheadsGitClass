using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;
    public Mesh gizmoMesh;

    private GameObject gemObject;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();    
    }

    public void Spawn()
    {
        if (gemObject == null)
        {
            gemObject = GameObject.Instantiate(gemPrefab, transform.position, Quaternion.identity);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawMesh(gizmoMesh, transform.position, Quaternion.Euler(90.0f, 0.0f, 0.0f)); 
    }
}
