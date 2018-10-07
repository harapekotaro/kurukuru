using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

	private Rigidbody2D rb2d;
	private SpriteRenderer spriter;

	// Stickの回転速度
	public float rspeed = 2;
	// Stickの回転速度
	public float speed = 3;
	// Stickの回転方向
	public bool tokei = false;
	//ぶつかった判定
	private bool butukari = false;
	// 積算時間を収納
	private float timeElapsed;
	private Vector2 direction;
	

	void Start(){
		// Rigidbody2Dを取得
		rb2d = GetComponent<Rigidbody2D>();
		// SpriteRendererの取得
		spriter = gameObject.GetComponent<SpriteRenderer> ();
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
		// timeElapsedが設定した時間を越えるとぶつかりモードを終了する
		if(timeElapsed >= 0.7f) 
		{
			rb2d.angularVelocity = 0f;
			timeElapsed = 0.0f;
			butukari = false;
			spriter.color =  new Color(28f,207f,151f,0.7f);
		}
	}

	void FixedUpdate () {
		// 移動
		rb2d.velocity = direction * speed;

		//ダメージを受けた時の処理
		if(butukari){
			float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
			spriter.color =  new Color(28f,207f,151f,level);
		}
	}


	// Update is called once per frame
	void Update () {
		// 入力を検出
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		//方向を決定
		direction = new Vector2(x, y).normalized;

		// ぶつかったときにぶつかりモードにはいる
		if (butukari){
			ButukariMode();				
		}
		else{
			StickRotator();
		}
	}

	void OnCollisionStay2D(Collision2D c)
	{
			butukari = true;
	}
}