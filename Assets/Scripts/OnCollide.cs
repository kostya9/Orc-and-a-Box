using UnityEngine;
using System.Collections;

public class OnCollide : MonoBehaviour {
	public GameObject box;
	public GameObject orc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (box.transform.position==orc.transform.position) {
			print ("orc");
			float BoxSize = 1.14f;
			float x = box.transform.localPosition.x;
			float y = box.transform.localPosition.y;
			float z = box.transform.localPosition.z;
			Vector3 newPos = new Vector3(x,y,z);
			if (Input.GetKeyUp ("w")) {
				newPos = new Vector3(x,y+BoxSize,z);
			}
			if (Input.GetKeyUp ("s")){
				newPos = new Vector3(x,y-BoxSize,z);
			}
			
			if (Input.GetKeyUp ("a")){
				newPos = new Vector3(x-BoxSize,y,z);
			}
			if (Input.GetKeyUp ("d")){
				newPos = new Vector3(x+BoxSize,y,z);;
		}
			if(newPos.x<5&&newPos.x>-5&&newPos.y>-5&&newPos.y<5)
				box.transform.position = newPos;
	}
}
}