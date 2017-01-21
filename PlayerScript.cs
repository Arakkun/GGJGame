using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public int currentPos=1; // posizione corrente. PUBBLICA PER DEBUG
	public int startingPos=1; // posizione iniziale
	public float easing; //durata movimento del personaggio in s
	public Transform[] positions; // posizione delle colonne in cui muoversi
	private Transform myTransform; // trasform dell'oggetto
	public bool moving = false;
	public KeyCode leftKey, centerKey, rightKey; // tasti movimento
	// Use this for initialization
	void Start () {
		myTransform = GetComponent<Transform> (); 
		currentPos = startingPos;
		myTransform.position = new Vector3 (positions [startingPos].position.x, myTransform.position.y, myTransform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (!moving) {
			if (Input.GetKeyDown (rightKey)) {
				if (currentPos > 0) {
					int nextPos = currentPos - 1;
					StartCoroutine (MoveTo (currentPos, nextPos));
					currentPos--;
				}
			}
			if (Input.GetKeyDown (leftKey)) {
				if (currentPos < positions.Length - 1) {
					int nextPos = currentPos + 1;
					StartCoroutine (MoveTo (currentPos, nextPos));
					currentPos++;
				}
			}
			if (Input.GetKeyDown (centerKey)) {
				//UNIMPLEMENTED
			}
		}
	}
	IEnumerator MoveTo(int startPos, int endPos){
		if ((startPos < 0) || (startPos > positions.Length) || (endPos < 0) || (endPos > positions.Length))
			yield break;
		moving = true;
		for (float timer = 0; timer < easing; timer+=Time.deltaTime) {
			Debug.Log ("moving from " + startPos + " to " + endPos);
			Debug.Log (Mathf.Lerp(positions[startPos].position.x,positions[endPos].position.x,timer/easing));
			myTransform.position = new Vector3 (Mathf.Lerp(positions[startPos].position.x,positions[endPos].position.x,timer/easing) , myTransform.position.y, myTransform.position.z);
			yield return new WaitForEndOfFrame ();
			myTransform.position = new Vector3 (positions[endPos].position.x, myTransform.position.y, myTransform.position.z);
		}
		moving = false;
	}
}
