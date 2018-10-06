using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyaStick : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Stickの回転速度
	public float rspeed = 2;
	// Stickの回転速度
	public float speed = 3;
	// Stickの回転方向
	public bool tokei = false;
	//子Stick
	public GameObject kostick;
	//ぶつかり真偽
	private bool butukariOn = false;

	void Start(){
		// Rigidbody2Dを取得
		rb2d = GetComponent<Rigidbody2D>();
	}

	// 棒操作
	void StickControler()
	{
		// tokeiの真偽によって回転方向を変える
		if (tokei){
			transform.eulerAngles += new Vector3 (0,0,1 * rspeed);
		}
		else{
			transform.eulerAngles += new Vector3 (0,0,-1 * rspeed);
		}
		
		//入力を取得
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		//方向を決定
		Vector2 direction = new Vector2(x, y).normalized;

		//移動
		rb2d.velocity = direction * speed;
	}

	// ぶつかりモーション
	void Butukari()
	{
		// ぶつかり空間(子stick)を作成
		GameObject g = (GameObject)Instantiate (kostick, transform.position, Quaternion.identity);

		//
		g.transform.parent = transform;

		// 少し待つ
		// yield return new WaitForSeconds (0.2f);

		rb2d.velocity = Vector3.zero;

		// ぶつかり空間削除
		Destroy (g);

		butukariOn = false;
	}

	// Update is called once per frame
	void Update () {
		if (butukariOn)	
		Butukari();

		else
		StickControler();
	}

		void OnCollisionEnter2D(Collision2D c)
	{
		// rb2d.velocity = Vector2.zero;
		//tokei = tokei ? false:true;	
		// parent.transform.eulerAngles += new Vector3 (0f, 0f, -30f);
		butukariOn = true;
	}
}