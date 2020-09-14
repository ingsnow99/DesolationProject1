using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMove : MonoBehaviour
{
    public List<Transform> resources;
    public Transform startingPos;
    public float range;
    private int currentWaypoint;
    private bool endPath;
    private bool beginMove;
    public bool isCollecting;

    private void Start()
    {
        currentWaypoint = 0;
        endPath = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                resources.Add(hit.transform);
            }
        }

        if (beginMove && !isCollecting)
        { 
            if (Vector3.Distance(gameObject.transform.position, resources[currentWaypoint].position) < range)
            {
                currentWaypoint++;
                if (currentWaypoint >= resources.Count)
                {
                    currentWaypoint = resources.Count - 1;
                    endPath = true;
                }
            }

            if (!endPath)
            {
                gameObject.GetComponent<NavMeshAgent>().SetDestination(resources[currentWaypoint].position);
            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().SetDestination(startingPos.position);
            }
        }

    }

    public void BeginMove()
    {
        //button function
        beginMove = true;
    }
}
