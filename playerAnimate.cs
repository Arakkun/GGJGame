using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimate : MonoBehaviour {
	private Animator myAnim;
	public Sprite[] faceDirection;
	public Sprite[] goingDirection;
	public int leftIndex, rightIndex;
	private SpriteRenderer mySprite;
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		mySprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myAnim.GetBool ("goingLeft")) {
			StartCoroutine (Going (leftIndex));
		}
		if (myAnim.GetBool ("goingRight")) {
			StartCoroutine (Going (rightIndex));
		}
	}
	IEnumerator Going(int direction){
		mySprite.sprite = faceDirection [direction];
		yield return new WaitForEndOfFrame ();
		while((myAnim.GetBool ("goingLeft"))||(myAnim.GetBool ("goingRight"))) 	{
			Debug.Log ("moving");
			mySprite.sprite = goingDirection [direction];
			yield return new WaitForEndOfFrame ();}
		mySprite.sprite = faceDirection [direction];
	}
}
