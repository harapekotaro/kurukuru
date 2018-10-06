using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koStick2 : MonoBehaviour {

	private GameObject parent;

	void Start()
	{
		 //親オブジェクトを取得
        parent = transform.root.gameObject;
	}


	void OnCollisionEnter2D(Collision2D c)
	{
		// rb2d.velocity = Vector2.zero;
		//tokei = tokei ? false:true;	
		parent.transform.eulerAngles += new Vector3 (0f, 0f, -30f);
	}

}
