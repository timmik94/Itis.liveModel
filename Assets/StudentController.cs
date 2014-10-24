using UnityEngine;
using System.Collections;

public class StudentController : MonoBehaviour {
    private int auditory;
    private NavMeshAgent nma;
    private Raspisanie rasp; 
    public int group;
	// Use this for initialization
	void Start () {
        nma = gameObject.GetComponent<NavMeshAgent>();
        rasp = GameObject.FindGameObjectWithTag("Raspisanie").GetComponent<Raspisanie>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] auditories = GameObject.FindGameObjectsWithTag("Auditory");
        Vector3 target = Vector3.zero;
        auditory = rasp.getauditory(group);
        for (int i = 0; i < auditories.Length; i++)
        {
            if (auditory == auditories[i].GetComponent<Auditory>().number) { target = auditories[i].transform.position; break; }
        }
        nma.SetDestination(target);
	
	}
}
