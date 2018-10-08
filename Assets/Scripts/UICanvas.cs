using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour {

	public GameObject maru;
	private GameObject player;
	private Stick stickScript;
	List<GameObject> hpBar;

	// Use this for initialization
	void Start () {
		
		int h = stickScript.hp;
		for(int i = 0; i < h; i++)
		{
			GameObject hpicon = (GameObject)Instantiate(maru, new Vector3 (35f, 35f + i*53f, 0f), Quaternion.identity);
			hpicon.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
