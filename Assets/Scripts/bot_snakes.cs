using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot_snakes : MonoBehaviour {

	public int Length=1;
	public int curspeed=2;
	public int rotationspeed=50;
	TrailRenderer snakeTail;
	public GameObject GameOver;
	make_snake makeSnake;
	public GameObject snake_tail;
	int move=0;
	float intervaltocontrol=2;
	public GameObject player;
	float clock=0;

	// Use this for initialization
	void Start () {
		makeSnake = snake_tail.GetComponent<make_snake> ();
		makeSnake.snake_length = Random.Range (25, 100);
		player = GameObject.FindGameObjectWithTag ("Player");

		GameOver.SetActive (false);
		//float size = Random.Range (.5f, 2f);
		//makeSnake.set_Width (size);
		//gameObject.transform.root.localScale = new Vector3 (size, size, 1f);


	}


	// Update is called once per frame
	void Update () {
		clock = clock + Time.deltaTime;
		if (clock > intervaltocontrol) {
			clock = 0;

			float prob = Random.Range (0f, 10f);
			if (prob <= 2) {
				move_left ();
			} else if (prob <= 4) {
				move_right ();
			} else if (prob <= 6) {
				move_straight ();
			} else {
				follow ();
			}
		}

		if (move == -1 || move <= 1 || move==0) {
			if (move != 0) {
				gameObject.transform.Rotate (Vector3.forward * rotationspeed * Time.deltaTime * move);

			}

		} else {
			Vector3 difference = player.transform.position - transform.position;
			float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rotationZ - 90), Time.deltaTime * 3);
		}
		gameObject.transform.Translate (gameObject.transform.up * curspeed * Time.smoothDeltaTime, Space.World);
	}

	public void move_left(){
		move = 1;
		intervaltocontrol = 2;
	}

	public void move_right(){
		move = -1;
		intervaltocontrol = 2;
	}

	public void follow(){
		move = 2;
		intervaltocontrol = 4;
	}
	public void move_straight(){
		move = 0;
		intervaltocontrol = 5;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag=="player_tail")
		{
			GameOver.SetActive (true);
			Time.timeScale = .01f;
		}
	}
}
