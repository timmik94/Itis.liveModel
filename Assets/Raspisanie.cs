using UnityEngine;
using System.Collections;

public class Raspisanie : MonoBehaviour {
    public int[,] rasp;
    public int[] grouplist;
    public Vector3[,] parelist;//x=days:y=ours:z=minuts;
    public float speed;
    private int parenow;
    private bool active;
    public int getauditory(int group)
    {
        for (int i = 0; i < grouplist.Length; i++)
        {
            if (group == grouplist[i]) { group = i; break; }
        }
            return rasp[group,parenow];
    }
    private float millis;
    private float ours;
    private float seconds;
    private float minuts;
    private float days;
	// Use this for initialization
	void Start () {
        active = false; 
        parenow = 0;
        days = 0;
        ours = 0;
        minuts = 0;
        seconds = 0;
        millis = 0;
        rasp=new int[1,3];
        parelist = new Vector3[2, 3];
        rasp[0,0] = 1;
        rasp[0,1] = 2;
        rasp[0,2] = 4;
        parelist[0,0] = new Vector3(0, 0, 30);
        parelist[1,0] = new Vector3(0, 2, 0);
        parelist[0,1] = new Vector3(0, 2, 10);
        parelist[1,1] = new Vector3(0, 3, 40);
        parelist[0,2] = new Vector3(0, 3, 50);
        parelist[1,2] = new Vector3(0, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
        millis += Time.deltaTime;
        if (millis >= speed) { seconds += 1; millis = 0; }
        //Debug.Log(parenow);
        if (seconds >= 60) { minuts += 1; seconds = 0; }
        if (minuts >= 60) { ours += 1; minuts = 0; }
        if (ours >= 24) { ours = 0;days+=1; }
        if (days > 5) { days = 0; parenow = 0; }
        if (parelist[1, parenow].x <= days && parelist[1, parenow].y <= ours && parelist[1, parenow].z <= minuts) { parenow += 1; active = false; Debug.Log(parelist[1, parenow].z); }
        if (parelist[0,parenow].x <= days && parelist[0,parenow].y <= ours && parelist[0,parenow].z <= minuts) { active = true; }
        
	}
}
