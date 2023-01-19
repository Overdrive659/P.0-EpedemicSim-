using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class DefaultPawn : MonoBehaviour
{

    //MOVEMENT SYSTEM
    [SerializeField] Vector3 target;
    [SerializeField] GameObject INFpawn;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = UnityEngine.Random.Range(6f, 12f);
        agent.acceleration = agent.speed;

        agent.SetDestination(PositionGenerator());
        target = agent.destination;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target, transform.position) <= 5)
        {
            target = PositionGenerator();
            agent.SetDestination(target);
        }

        if (transform.tag == "InfectedPawn")
        {
            Instantiate(INFpawn, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private Vector3 PositionGenerator()
    {
        Vector3 RNDPosition = new Vector3(UnityEngine.Random.Range(-62, 63), UnityEngine.Random.Range(-35, 36));

        return RNDPosition;
    }
}
