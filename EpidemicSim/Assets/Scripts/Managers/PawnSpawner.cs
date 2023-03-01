using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PawnSpawner : MonoBehaviour
{
    [SerializeField] VarManager VarManager;

    [SerializeField] GameObject Pawn;
    [SerializeField] GameObject InfPawn;
    [SerializeField] GameObject VaxPawn;

    private int? totPawns;
    private int? defPawns;
    private int? infPawns;
    private int? vaxPawns;

    private void Awake()
    {
        VarManager = GameObject.Find("GameManager").GetComponent<VarManager>();

        totPawns = VarManager.totalPawns;

        defPawns = VarManager.uninfectedPawnAmount;
        infPawns = VarManager.infectedPawnAmount;
        vaxPawns = VarManager.vaccinatedPawnAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(defPawns != null && defPawns != 0 )
        {
            for (int i = 0; i <= defPawns; i++)
            {
                int x = UnityEngine.Random.Range(-300, 301);
                int y = UnityEngine.Random.Range(-300, 301);

                GameObject D_Pawn = Instantiate(Pawn, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        if(infPawns != null && infPawns != 0 )
        {
            for (int i = 0; i <= infPawns; i++)
            {
                int x = UnityEngine.Random.Range(-300, 301);
                int y = UnityEngine.Random.Range(-300, 301);

                GameObject I_Pawn = Instantiate(InfPawn, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        if (vaxPawns != null && vaxPawns != 0)
        {
            for (int i = 0; i <= vaxPawns; i++)
            {
                int x = UnityEngine.Random.Range(-300, 301);
                int y = UnityEngine.Random.Range(-300, 301);

                GameObject V_Pawn = Instantiate(VaxPawn, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        Debug.Log("---PAWN SPAWNER HAS FULLY EXECUTED SPAWNING SEQUENCE---");
        Debug.Log("TOTAL PAWNS SPAWNED:" + totPawns);
        Debug.Log("Default Pawns:" + defPawns);
        Debug.Log("Infected Pawns:" + infPawns);
        Debug.Log("Vaccinated Pawns:" + vaxPawns);
        Debug.Log("---REMOVING SELF---");
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(this);
    }

    private void OnDestroy()
    {
        Debug.Log("---PAWN SPAWNER HAS FULLY EXECUTED SPAWNING SEQUENCE---");
        Debug.Log("TOTAL PAWNS SPAWNED:" + totPawns);
        Debug.Log("Default Pawns:" + defPawns);
        Debug.Log("Infected Pawns:" + infPawns);
        Debug.Log("Vaccinated Pawns:" + vaxPawns);
        Debug.Log("---REMOVING SELF---");
    }
}
