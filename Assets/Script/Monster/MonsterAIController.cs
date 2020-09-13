using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAIController : MonoBehaviour
{
    public BTSelector aiController;
    public BTSelector patrolState;
    public BTSelector attackState;

    public FindWaypoint findWaypointTask;
    public Idle idleTask;
    public Chase chaseState;
    public ApproachDrone approachDroneTask;
    public Attack attackTask;

    private MonsterAI monster;

    private void Awake()
    {
        monster = gameObject.GetComponent<MonsterAI>();
    }
    private void Start()
    {
        findWaypointTask = new FindWaypoint(monster, monster.FindWaypoint);
        idleTask = new Idle(monster, monster.CheckIdle);
        chaseState = new Chase(monster, monster.CheckChaseRange);
        approachDroneTask = new ApproachDrone(monster, monster.CheckApproachRange);
        attackTask = new Attack(monster.CheckAttackRange);

        patrolState = new BTSelector(new List<INode> { findWaypointTask, idleTask });
        attackState = new BTSelector(new List<INode> { approachDroneTask, attackTask});
        aiController = new BTSelector(new List<INode> { attackState, chaseState, patrolState });
    }

    private void Update()
    {
        aiController.Evaluate();
    }
}
