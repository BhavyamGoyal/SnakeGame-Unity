using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_generator : MonoBehaviour {

	Vector3 posToGenerate;
    public GameObject Food;
	float time=0f;
	float interval=3.0f;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
		Instantiate (Food, new Vector3 (-22, -20, 0), new Quaternion (0, 0, 0, 0));
		Instantiate (Food, new Vector3 (-14, 7, 0), new Quaternion (0, 0, 0, 0));
		Instantiate (Food, new Vector3 (10, -12, 0), new Quaternion (0, 0, 0, 0));
		Instantiate (Food, new Vector3 (-2, 14, 0), new Quaternion (0, 0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (time > interval) {
			time = 0;
			Random rnd = new Random();
			posToGenerate=new Vector3(Random.Range(-120.0f, 120.0f), Random.Range(-120.0f, 120.0f),0);
			Instantiate (Food, posToGenerate, new Quaternion (0, 0, 0, 0));
		}
		time = time + Time.deltaTime;
		
	}
}
