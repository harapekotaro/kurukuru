using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Stickの回転速度
	public float rspeed = 2;
	// Stickの回転速度
	public float speed = 3;
	// Stickの回転方向
	private bool tokei = true;

	void Start(){
		// Rigidbody2Dを取得
		rb2d = GetComponent<Rigidbody2D>();
	}
	// Update is called once per frame
	void Update () {
		// tokeiの真偽によって回転方向を変える
		if (tokei){
			transform.eulerAngles += new Vector3 (0,0,2);
		}
		else{
			transform.eulerAngles += new Vector3 (0,0,-2);
		}
		
		//入力を取得
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		//方向を決定
		Vector2 direction = new Vector2(x, y).normalized;

		//移動
		rb2d.velocity = direction * speed;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		tokei = tokei ? false:true;	
	}
}
