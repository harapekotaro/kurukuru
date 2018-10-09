using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour {

	public GameObject maru;
	public GameObject player;
	private Stick stickScript;

	private int h;
	private List<GameObject> hpBar;

	// Use this for initialization
	void Start () {
		stickScript = player.GetComponent<Stick>();
		h = stickScript.hp;
		hpBar = new List<GameObject>();
		for(int i = 0; i < h; i++)
		{
			GameObject hpicon = (GameObject)Instantiate(maru, new Vector3 (35f, 35f + i*53f, 0f), Quaternion.identity);
			hpicon.transform.SetParent(transform);
			hpBar.Add(hpicon);
		}
		
	}

	 public void Damage()
	{
		hpBar[h-1].SetActive (false);

		h--;
	}
}