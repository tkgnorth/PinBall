using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;
	public int Score = 0;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
	private GameObject gamescoreText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");

		this.gamescoreText = GameObject.Find("GameScoreText");

	}
	
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameOverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}

		this.gamescoreText.GetComponent<Text> ().text = "Score:" + Score;




	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "SmallStarTag") {
			Score += 15;
		} else if (other.gameObject.tag == "LargeStarTag") {
			Score += 45;
		} else if (other.gameObject.tag == "SmallCloudTag") {
			Score += 75;
		} else if (other.gameObject.tag == "LargeCloudTag") {
			Score += 100;
		}

	}

}
