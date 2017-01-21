using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public int currentPos=1; // posizione corrente. PUBBLICA PER DEBUG
	public int startingPos=1; // posizione iniziale
	public float easing; //durata movimento del personaggio in s
	public Transform[] positions; // posizione delle colonne in cui muoversi
	public float jumpHeight;
	private Transform myTransform; // trasform dell'oggetto
	public bool moving = false;
	public KeyCode leftKey, centerKey, rightKey; // tasti movimento
	public bool mouseKeys;
	public Animator myAnim;
	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform> (); 
		currentPos = startingPos;
		myTransform.position = new Vector3 (positions [startingPos].position.x, myTransform.position.y, myTransform.position.z);
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) {
			
			if ((Input.GetKeyDown (rightKey))||((Input.GetMouseButtonDown(0))&&(mouseKeys))) {
				if (currentPos > 0) {
					Debug.Log ("checked");
					myAnim.SetBool ("goingRight", true);
					int nextPos = currentPos - 1;
					StartCoroutine (MoveTo (currentPos, nextPos));
					currentPos--;
				}
			}
			if ((Input.GetKeyDown (leftKey))||((Input.GetMouseButtonDown(1))&&(mouseKeys))) {
				if (currentPos < positions.Length - 1) {
					myAnim.SetBool ("goingLeft", true);
					int nextPos = currentPos + 1;
					StartCoroutine (MoveTo (currentPos, nextPos));
					currentPos++;
				}
			}
			if ((Input.GetKeyDown (centerKey))||((Input.GetMouseButtonDown(2))&&(mouseKeys))) {
				StartCoroutine (Jump ());
				//UNIMPLEMENTED
			}
		}
	}
	IEnumerator MoveTo(int startPos, int endPos){
		if ((startPos < 0) || (startPos > positions.Length) || (endPos < 0) || (endPos > positions.Length))
			yield break;
		moving = true;
		for (float timer = 0; timer < easing; timer+=Time.deltaTime) {
			Debug.Log ("going from " + startPos + " to " + endPos);
			Debug.Log (Mathf.Lerp(positions[startPos].position.x,positions[endPos].position.x,timer/easing));
			myTransform.position = new Vector3 (Mathf.Lerp(positions[startPos].position.x,positions[endPos].position.x,timer/easing) , myTransform.position.y, myTransform.position.z);
			yield return new WaitForEndOfFrame ();
			}
		myTransform.position = new Vector3 (positions[endPos].position.x, myTransform.position.y, myTransform.position.z);
		myAnim.SetBool ("goingRight", false);
		myAnim.SetBool ("goingLeft", false);
		moving = false;
	}
	IEnumerator Jump(){
		moving = true;
		Debug.Log ("jump!");
		for (float timer = 0; timer < easing; timer+=Time.deltaTime) {
			Debug.Log (Mathf.Lerp(positions[currentPos].position.y,positions[currentPos].position.y+jumpHeight,timer/easing));
			myTransform.position = new Vector3 (positions[currentPos].position.x,Mathf.Lerp(positions[currentPos].position.y,positions[currentPos].position.y+jumpHeight,2*timer/easing), myTransform.position.z);
			yield return new WaitForEndOfFrame ();
		}
		for (float timer = 0; timer < easing; timer+=Time.deltaTime) {
			Debug.Log (Mathf.Lerp(positions[currentPos].position.y+jumpHeight,positions[currentPos].position.y,timer/easing));
			myTransform.position = new Vector3 (positions[currentPos].position.x,Mathf.Lerp(positions[currentPos].position.y+jumpHeight,positions[currentPos].position.y,2*timer/easing), myTransform.position.z);
			yield return new WaitForEndOfFrame ();
		}
		myTransform.position = new Vector3 (positions[currentPos].position.x,positions[currentPos].position.y, myTransform.position.z);
		moving = false;
	}
}
