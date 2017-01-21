using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour {
	public float[] levelThresholds;
	public Transform[] spawnPoint;
	public GameObject[] wave;
	public MicrophoneReader linkedMic;
	float timer=0;
	public float waitTime=0.2f;
	// Use this for initialization
	void Start () {
		timer = waitTime + 1;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer>waitTime) {
			float volume = linkedMic.volume;
			for (int i = 0; i < levelThresholds.Length; i++) {
				if (volume < levelThresholds [i]) {
					timer = 0;
					int random = Random.Range (0, spawnPoint.Length);
					if (wave [i] != null)
					if(i<levelThresholds.Length-1) Instantiate (wave [i],spawnPoint[random].position,spawnPoint[random].rotation);
					else Instantiate (wave [i],spawnPoint[spawnPoint.Length/2].position,spawnPoint[spawnPoint.Length/2].rotation);
					break;
				}
			}
		}
	}
}
