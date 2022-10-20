using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PawnController : MonoBehaviour
{
    // incase in default state run normal code
    // when state changes do the same but have more code 
    // 
    public bool hasInfection = false;
    public bool hasMask = false;
    public float susVariable = 0;



    //MOVEMENT SYSTEM
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("WalkTarget").transform;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.updateUpAxis = false;

        agent.speed = Random.Range(6f, 12f);
        agent.acceleration = agent.speed;

        susVariable = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        if (hasInfection)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("A pawn entered Infection Area");
    }
}
