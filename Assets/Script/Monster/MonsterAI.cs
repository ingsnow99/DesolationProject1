using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [Header("Monster Stats")]
    public float monsterHP;
    public float monsterSpeed;
    public float attackRange;
    public float approachRange;
    public float chaseRange;
    [Range(0, 360)]
    public float fieldOfView;

    [Header("Target")]
    public GameObject monsterTarget;

    [Header("Waypoints")]
    public GameObject[] monsterWaypoints;

    private float currentHP;
    private float currentSpeed;
    private bool atWaypoint;
    private Vector3 dir;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = monsterHP;
        currentSpeed = monsterSpeed;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void ChaseTarget()
    {
        //play chase animation
        agent.speed = monsterSpeed;
        gameObject.transform.LookAt(monsterTarget.transform);
        agent.SetDestination(monsterTarget.transform.position);
    }

    public void AttackTarget()
    {
        //play attack animation
    }

    public void ApproachTarget()
    {
        //play walk animation
        agent.speed = monsterSpeed / 2;
        gameObject.transform.LookAt(monsterTarget.transform);
        agent.SetDestination(monsterTarget.transform.position);
    }

    public bool FindWaypoint()
    {
        if (monsterWaypoints.Length == 0 && !agent.isStopped)
        {
            return false;
        }

        foreach (GameObject point in monsterWaypoints) {
            if (GetDistance(point) != 0)
            {
                atWaypoint = false;
            }
            else
            {
                atWaypoint = true;
                break;
            }
        }

        if (!atWaypoint)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MoveToWayPoint()
    {
        Vector3 closestPoint = monsterWaypoints[0].transform.position;
        float lastDist = Vector3.Distance(monsterWaypoints[0].transform.position, gameObject.transform.position);

        foreach (GameObject point in monsterWaypoints)
        {
            float currentDist = Vector3.Distance(point.transform.position, gameObject.transform.position);
            if (lastDist > currentDist)
            {
                closestPoint = point.transform.position;
            }
        }

        //play walk animation
        agent.SetDestination(closestPoint);
    }

    public void Idle()
    {
        //play idle animation
        agent.isStopped = true;
        StartCoroutine(Resume());

    }

    IEnumerator Resume()
    {
        yield return new WaitForSeconds(2.0f);
        agent.isStopped = false;
    }

    public bool CheckApproachRange()
    {
        if (GetDistance(monsterTarget) > attackRange && GetDistance(monsterTarget) <= approachRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckAttackRange()
    {
        if (GetDistance(monsterTarget) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckChaseRange()
    {
        if (GetDistance(monsterTarget) > approachRange && GetDistance(monsterTarget) <= chaseRange)
        {
            if (GetViewAngle(monsterTarget) <= fieldOfView)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool CheckIdle()
    {
        foreach(GameObject point in monsterWaypoints)
        {
            if(GetDistance(point) == 0)
            {
                return true;
            }
        }
        return false;
    }

    public float GetDistance(GameObject target)
    {
        return Vector3.Distance(gameObject.transform.position, target.transform.position);
    }

    public float GetViewAngle(GameObject target)
    {
        dir = target.transform.position - monsterTarget.transform.position;
        dir.y = 0;
        return Vector3.Angle(dir, gameObject.transform.forward);
    }

}
