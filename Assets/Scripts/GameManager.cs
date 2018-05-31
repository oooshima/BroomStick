using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static int point = 0; //ゲームプレイモードにおける得点の値
	public static bool nazomode = true; //true時謎解き用モード　false時ゲームプレイモード
	public static bool startflag = false; //trueになるとゲームスタート
	public GameObject[] Points; //Pointタグオブジェクトの配列
	public GameObject Plane;
	public static float time = 50.0f;
	public Text Timetext;
	public Text Scoretext;
	public GameObject particle;
	Vector3 firstpos; //Playerの初期位置


	// Use this for initialization
	void Start () {
		//firstpos = GameObject.Find("Player").transform.position;
		Points = GameObject.FindGameObjectsWithTag("Point");
			foreach (GameObject Point in Points) {
				Point.SetActive (false);//Pointオブジェクトなし
			}

			Debug.Log ("謎用");
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log (nazomode);

		//Sを押したらPlaneが消える
		if (WebCamController.flag == 1) {
			Debug.Log ("aaa");
			Plane.gameObject.transform.position = new Vector3 (-631f, -100f, 912f);
		}

		if (Input.GetKeyDown (KeyCode.T)) {
			SceneManager.LoadScene("Movie");
		}

		//Spaceキーを押したらゲームスタート
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (startflag == false) {
				startflag = true;
			} else {
				startflag = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			startflag = false;
			//Plane.SetActive (true);
			nazomode = true;
			WebCamController.flag = 0;
			WebCamController.flag2 = 0;
			//現在のシーン番号を取得
			int sceneIndex = SceneManager.GetActiveScene().buildIndex;
			//現在のシーンを再読み込みする
			SceneManager.LoadScene(sceneIndex);

		}

		//Pを押したらゲームプレイモード
		if (Input.GetKeyDown (KeyCode.P)) {
			point = 0;
			nazomode = false;
			startflag = false;
			time = 50.0f;
			foreach(GameObject Point in Points) {
				Point.SetActive(true);//Pointオブジェクト設置
			}
			Debug.Log("ゲーム用");
		}
		//Nを押したら謎解き用モード
		if (Input.GetKeyDown (KeyCode.N)) {
			nazomode = true;
			startflag = false;
			Timetext.gameObject.SetActive (false);
			foreach(GameObject Point in Points) {
				Point.SetActive(false);//Pointオブジェクトなし
			}
			Debug.Log("謎用");
		}
		//ゲームプレイモードの時UI
		if (nazomode == false) {
			Timetext.gameObject.SetActive (true);
			Scoretext.gameObject.SetActive (true);
			particle.SetActive (false);
			if (startflag == true) {
				time -= Time.deltaTime;
				Timetext.GetComponent<Text> ().text = "TIME:"+((int)time).ToString ();
				Scoretext.GetComponent<Text> ().text = "SCORE:"+((int)point).ToString ();
				Debug.Log (time);
				if (time < 11f) {
					Timetext.color = new Color (238f / 255f, 37f / 255f, 37f / 255f);
				}
			}
		}
	}
}
