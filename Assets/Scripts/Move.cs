using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public GameObject Orc;
	private Rigidbody2D rb;
	public float topEnd;
	public float botEnd;
	public float leftEnd;
	public float rightEnd;
	public Vector2 newPos;
	public Vector2 oldPos;
	private float BoxSize;

	// Use this for initialization
	void Start () {
		BoxSize=1.01f;
	rb = Orc.GetComponent<Rigidbody2D> ();
		oldPos = Orc.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = Orc.transform.position;
		if (rb.velocity != Vector2.zero) {
			if (pos.x < (newPos + oldPos + new Vector2(0.001f,0.001f)).x && pos.x > (newPos + oldPos - new Vector2(0.001f,0.001f)).x &&
			    pos.y < (newPos + oldPos + new Vector2(0.001f,0.001f)).y && pos.y > (newPos + oldPos - new Vector2(0.001f,0.001f)).y) {
				oldPos = pos;
				rb.velocity = Vector2.zero;
				rb.angularVelocity = 0;

			}
		} 
		else if (rb.velocity == Vector2.zero) {
//		if ((oldPos + newPos) == pos) {
//			rb.MovePosition (new Vector3 (0, 0, 0));
//			print ("b");
//		}
				if (Input.GetKey ("w")) {
					newPos = new Vector2 (0, BoxSize);

					MoveOrc (newPos, pos);

				}
				if (Input.GetKey ("s")) {
					newPos = new Vector2 (0, -BoxSize);
					MoveOrc (newPos, pos);
				}
		
				if (Input.GetKey ("a")) {
					newPos = new Vector2 (-BoxSize, 0);
					MoveOrc (newPos, pos);
				}
				if (Input.GetKey ("d")) {
					newPos = new Vector2 (BoxSize, 0);
					MoveOrc (newPos, pos);
				}

			}
		}
	void MoveOrc(Vector3 addPos, Vector3 pos)
	{
		if (
			(addPos + pos).x < rightEnd && (addPos + pos).x > leftEnd && (addPos + pos).y > botEnd && (addPos + pos).y < topEnd 
			) {
			//Orc.transform.position +=newPos;
			rb.MovePosition(pos + addPos*Time.fixedDeltaTime);
		}
	}

}
