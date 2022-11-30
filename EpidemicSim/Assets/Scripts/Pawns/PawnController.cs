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
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = Random.Range(6f, 12f);
        agent.acceleration = agent.speed;

        susVariable = Random.Range(0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
       if(col.gameObject.tag == "Pawn")
        {
            int chance = Random.Range(0, 100);

            if(chance > 50)
            {
                col.gameObject.tag = this.tag;
            }
        }
        
    }

}
