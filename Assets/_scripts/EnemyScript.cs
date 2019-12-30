using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{

    public GameObject player;
    private NavMeshAgent enemyAgent;

    public void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        enemyAgent.SetDestination(player.transform.position);


    }



}
