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
	public bool tokei = false;
	//子Stick
	public GameObject kostick;
	//ぶつかった判定
	private bool butukari = false;
	private bool butukari2 = false;

	private float timeElapsed;

	void Start(){
		// Rigidbody2Dを取得
		rb2d = GetComponent<Rigidbody2D>();
	}

	// 棒操作
	void StickControler()
	{	
		//入力を取得
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		//方向を決定
		Vector2 direction = new Vector2(x, y).normalized;

		//移動
		rb2d.velocity = direction * speed;
	}

	// 回転
	void StickRotator()
	{
	// tokeiの真偽によって回転方向を変える
		if (tokei){
			transform.eulerAngles += new Vector3 (0,0,1 * rspeed);
		}
		else{
			transform.eulerAngles += new Vector3 (0,0,-1 * rspeed);
		}
	}

	// ぶつかったときの挙動
	void ButukariMode()
	{
		// ぶつかってからの時間を計測
		timeElapsed += Time.deltaTime;
		// 連続で二回ぶつかると回転が止まる
		if (butukari2){
			rb2d.angularVelocity = 0f;
		}
		else{
			StickRotator();
		}
		// timeElapsedが設定した時間を越えるとぶつかりモードを終了する
		if(timeElapsed >= 0.7f) 
		{
			rb2d.angularVelocity = 0f;
			tokei = tokei ? false:true;
			timeElapsed = 0.0f;
			butukari = false;
			butukari2 = false;
		}
	}

	// Update is called once per frame
	void Update () {
		StickControler();

		// ぶつかったときにぶつかりモードにはいる
		if (butukari){
			ButukariMode();				
		}
		else{
			StickRotator();
		}
	}


	void OnCollisionEnter2D(Collision2D c)
	{
		if (butukari){
			butukari2 = true;
		}
		else{
			tokei = tokei ? false:true;
			butukari = true;
		}
	}
}