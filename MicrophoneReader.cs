using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneReader : MonoBehaviour {
	public AudioSource receiver;
	public string device=null;
	public int sampleWindow;
	public float volume;
	// Use this for initialization
	void Start () {
		foreach (string s in Microphone.devices)
			Debug.Log (s);
		if (device == "")
			device = Microphone.devices [0];
		Debug.Log ("set "+device);
		receiver.clip = Microphone.Start (device, true, 990, 44100);
	}

	// Update is called once per frame
	void Update () {
		volume = MicVolume ();
	}
	float MicVolume(){
		float max = 0; 
		float[] values = new float[sampleWindow];
		int position = Microphone.GetPosition (null) - (sampleWindow + 1);
		if (position < 0)
			return volume;
		receiver.clip.GetData(values,position);
		foreach (float p in values) {
			if (max < Mathf.Abs(p))
				max = Mathf.Abs(p);
		}
		return max;
	}
	void OnDisable(){
		StopMic ();
	}
	void OnDestroy(){
		StopMic ();
	}
	void StopMic(){
		Microphone.End (device);
	}
}
