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
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log ("OutCircle");
		if (col.GetType() == typeof(CircleCollider2D)) 
		{
			rb.velocity = new Vector2(-0.0001f,-0.0001f);
			rb.angularVelocity = 0;
			print("circle");
			Orc.transform.position=oldPos;
		//	newPos=Vector2.zero;

		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos = Orc.transform.position;
		if (rb.velocity != Vector2.zero) {

			if (pos.x < (newPos + oldPos + new Vector2(0.01f,0.01f)).x && pos.x > (newPos + oldPos - new Vector2(0.01f,0.01f)).x &&
			    pos.y < (newPos + oldPos + new Vector2(0.01f,0.01f)).y && pos.y > (newPos + oldPos - new Vector2(0.01f,0.01f)).y) {
				oldPos = pos;
				rb.velocity = Vector2.zero;
				rb.angularVelocity = 0;
				print ("stahp!");

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
		print ("Thinking");
		bool notTheEndOfBack = (addPos + pos).x < rightEnd && (addPos + pos).x > leftEnd && (addPos + pos).y > botEnd && (addPos + pos).y < topEnd;
		if (notTheEndOfBack) 
		{
			print("go!");
			//Orc.transform.position +=newPos;
			rb.MovePosition(pos + addPos*Time.fixedDeltaTime*2);
		}
	}


}
