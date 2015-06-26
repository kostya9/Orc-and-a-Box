using UnityEngine;
using System.Collections;

public class OnCollide : MonoBehaviour {
	public GameObject Box;
	private Rigidbody2D rb;
	public float topEnd;
	public float botEnd;
	public float leftEnd;
	public float rightEnd;
	public Vector2 newPos;
	public Vector2 oldPos;
	private float BoxSize;
	private Vector2 pos;
	// Use this for initialization
	void Start () {
		BoxSize=1.01f;
		rb = Box.GetComponent<Rigidbody2D> ();
		oldPos = Box.transform.position;
		Debug.Log("Trigger: " + Box.GetComponent<BoxCollider2D>().isTrigger);
	}
	void FixedUpdate()
	{
		pos = Box.transform.position;
		if (rb.velocity != Vector2.zero) {
			if (pos.x < (newPos + oldPos + new Vector2 (0.001f, 0.001f)).x && pos.x > (newPos + oldPos - new Vector2 (0.001f, 0.001f)).x &&
				pos.y < (newPos + oldPos + new Vector2 (0.001f, 0.001f)).y && pos.y > (newPos + oldPos - new Vector2 (0.001f, 0.001f)).y) {
				oldPos = pos;
				rb.velocity = Vector2.zero;
				rb.angularVelocity = 0;
				
			}
		}
	}
	void OnTriggerEnter2D(Collider2D col) {

		pos = Box.transform.position;
		var relativePosition = new Vector2 (col.transform.position.x - Box.transform.position.x, col.transform.position.y - Box.transform.position.y);
		if (relativePosition.x > 0.2f) {
			
			//print ("The object is to the right");
			newPos = new Vector2 (-BoxSize, 0);
			MoveBox (newPos, pos);
			
		} else if(relativePosition.x < -0.2f) {
			
			//print ("The object is to the left");
			newPos = new Vector2 (BoxSize, 0);
			MoveBox (newPos, pos);
			
		}
		
		if (relativePosition.y > 0.2f) {
			
			//print ("The object is above.");
			newPos = new Vector2 (0, -BoxSize);
			MoveBox (newPos, pos);
			
		} else if(relativePosition.y < -0.2f) {
			
			//print ("The object is below.");
			newPos = new Vector2 (0, BoxSize);
			
			MoveBox (newPos, pos);
			
		}

	}

	void MoveBox(Vector3 addPos, Vector3 pos)
	{
		if (
			(addPos + pos).x < rightEnd && (addPos + pos).x > leftEnd && (addPos + pos).y > botEnd && (addPos + pos).y < topEnd 
			) {
			//Box.transform.position +=newPos;
			rb.MovePosition(pos + addPos*Time.fixedDeltaTime*2);
		}
	}
	
}
