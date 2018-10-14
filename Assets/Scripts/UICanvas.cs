using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour {

	public GameObject maru;
	public GameObject player;
	private int startHP;
	private int h;
	private List<GameObject> hpBar;
	

	// Use this for initialization
	void Start () {
		startHP = Stick.hp;
		h = startHP;
		hpBar = new List<GameObject>();
		for(int i = 0; i < startHP; i++)
		{
			GameObject hpicon = (GameObject)Instantiate(maru, new Vector3 (35f, 35f + i*53f, 0f), Quaternion.identity);
			hpicon.transform.SetParent(transform);
			hpBar.Add(hpicon);
		}

	}

	public void HPDealer(int num)
	{
		if(num < 0){
			hpBar[h-1].SetActive (false);
			h--;
		}
		else{
			if(h < startHP ){
				hpBar[h].SetActive (true);
				h++;
			}
		}
	}

	// public void Shoukan()
	// {
	// 	Instantiate (player, player.transform.position, player.transform.rotation);
	// 	h = startHP;
	// 	foreach(GameObject i in hpBar)
	// 	{
	// 		i.SetActive (true);
	// 	}
	// }
}