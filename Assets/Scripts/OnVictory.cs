using UnityEngine;
using System.Collections;

public class OnVictory : MonoBehaviour {
	public GameObject Box;
	public GameObject Point;
	public GameObject Panel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Approximately (Box.transform.position.x, Point.transform.position.x) && Mathf.Approximately (Box.transform.position.y, Point.transform.position.y))
			Panel.SetActive (true);
	}
}
