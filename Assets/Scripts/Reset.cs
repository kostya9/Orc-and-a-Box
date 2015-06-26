using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {
	private Vector3 posOrc;
	private Vector3 posBox;
	public GameObject Orc;
	public GameObject Box;
	// Use this for initialization
	void Start () {
		posBox = Box.transform.position;
		posOrc = Orc.transform.position;
	}

	public void DoReset()
	{
		Debug.Log ("Reset?");
		Application.LoadLevel(Application.loadedLevel);
		Debug.Log ("Reset!");
	}
}
