using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public Transform[] resources;

    // Update is called once per frame
    void Update()
    {

    }

    public void Patrol()
    {
        for (int i = 0; i < resources.Length; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, resources[i].position) == 0)
            {
                gameObject.GetComponent<NavMeshAgent>().SetDestination(resources[i+1].position);
            }
        }
    }
}
