using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InfectedPawn : MonoBehaviour
{
    [SerializeField] protected int coughChance;
    [SerializeField] protected int sneezeChance;
    [SerializeField] private GameObject EmotePrefab;
    [SerializeField] private GameObject CloudPrefab;

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

        agent.SetDestination(PositionGenerator());
        target = agent.destination;

        StartCoroutine(SpreadSystem());
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target, transform.position) <= 5)
        {
            target = PositionGenerator();
            agent.SetDestination(target);
        }
    }
    private Vector3 PositionGenerator()
    {
        Vector3 RNDPosition = new Vector3(UnityEngine.Random.Range(-62, 63), UnityEngine.Random.Range(-35, 36));

        return RNDPosition;
    }

    IEnumerator SpreadSystem()
    {
        while (true)
        {
            coughChance = UnityEngine.Random.Range(1, 101);
            sneezeChance = UnityEngine.Random.Range(1, 101);

            if (coughChance > 60)
            {
                Cough();
            }
            if (sneezeChance > 80)
            {
                Sneeze();
            }

            yield return new WaitForSeconds(3f);
        }
    }

    void Cough()
    {
        ShowText("*Coughs!*");
        GameObject AerosolCloud = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        return;
    }

    void Sneeze()
    {
        ShowText("*Sneezes!*");
        GameObject AerosolCloud = Instantiate(CloudPrefab, transform.position, Quaternion.identity);
        return;
    }

    void ShowText(string text)
    {
        if (EmotePrefab)
        {
            GameObject prefab = Instantiate(EmotePrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pawn")
        {
            int chance = UnityEngine.Random.Range(0, 101);

            if (chance > 90)
            {
                col.gameObject.tag = this.tag;
            }
        }

    }
}
