using System;
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
    public bool hasVaccine = false;
    public bool hasMask = false;
    public float susVariable = 0;
    


    //MOVEMENT SYSTEM
    [SerializeField] Vector3 target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = UnityEngine.Random.Range(6f, 12f);
        agent.acceleration = agent.speed;

        susVariable = UnityEngine.Random.Range(0f, 1f);

        agent.SetDestination(PositionGenerator());
        target = agent.destination;
        Debug.Log("FIRST DEST." + target);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target, transform.position) <= 5)
        {
            Debug.Log("Has Reached Target");
            target = PositionGenerator();
            agent.SetDestination(target);
            Debug.Log("NEW DEST." + target);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Pawn")
        {
            int chance = UnityEngine.Random.Range(0, 101);

            if(chance > 99)
            {
                col.gameObject.tag = this.tag;
            }
        }
        
    }

    private Vector3 PositionGenerator()
    {
        Vector3 RNDPosition = new Vector3(UnityEngine.Random.Range(-374, 374), UnityEngine.Random.Range(-366, 372));

        return RNDPosition;
    }

}
