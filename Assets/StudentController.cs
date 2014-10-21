using UnityEngine;
using System.Collections;

public class StudentController : MonoBehaviour {
    public int auditory;
    private NavMeshAgent nma;
	// Use this for initialization
	void Start () {
        nma = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] auditories = GameObject.FindGameObjectsWithTag("Auditory");
        Vector3 target = Vector3.zero;
        for (int i = 0; i < auditories.Length; i++)
        {
            if (auditory == auditories[i].GetComponent<Auditory>().number) { target = auditories[i].transform.position; break; }
        }
        nma.SetDestination(target);
	
	}
}
