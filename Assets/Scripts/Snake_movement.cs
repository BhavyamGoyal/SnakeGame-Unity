using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_movement : MonoBehaviour {

	public int Length=1;
	public int curspeed=2;
	public int rotationspeed=50;
	TrailRenderer snakeTail;
	make_snake makeSnake;
	public GameObject snake_tail;
	int move=0;
	// Use this for initialization
	void Start () {
		makeSnake = snake_tail.GetComponent<make_snake> ();

		
		
	}

	
	// Update is called once per frame
	void Update () {
		if(move!=0){
			gameObject.transform.Rotate (Vector3.forward * rotationspeed * Time.deltaTime * move);
		
	}
		gameObject.transform.Translate(gameObject.transform.up * curspeed * Time.smoothDeltaTime, Space.World);
}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="food")
		{
			Destroy (other.gameObject, .3f);
			makeSnake.snake_length = makeSnake.snake_length + 15;

		}
	}
	public void move_button(int a){
		move = a;
	}
	public void restart(){
		Application.LoadLevel("snake_game");
	}
}