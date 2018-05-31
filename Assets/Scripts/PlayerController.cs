using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	public float speed = 5.0f;
	private AudioSource sound;
	private AudioSource sound2;
	public AudioClip wave;
	public AudioClip wind;
	public AudioClip hit;
	public AudioClip heal;
	private bool soundflag = true;
	// Use this for initialization
	void Start () {
		Debug.Log (GameManager.point);
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound = audioSources[0];
		sound2 = audioSources[1];
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Z)) {
			speed -= 5.0f;
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			speed += 5.0f;
		}


		//スペースキーが押されたら向いてる方向へ進む
		if (GameManager.startflag == true) {
				this.transform.position += transform.TransformDirection (Vector3.forward) * speed * Time.deltaTime;
				//Debug.Log (transform.TransformDirection (Vector3.forward));
			}
		if (soundflag == true) {
			sound.clip = wind;
			sound.Play ();
			soundflag = false;
		}
		if (GameManager.time <= 0) {
			StartCoroutine (ChangeScene ());
		}

	}

	//ゲームプレイモード時にEnemyタグのオブジェクトに衝突したらマイナス１
	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Enemy") {
				sound2.clip = hit;
				sound2.Play ();
			if (GameManager.nazomode == false) {
				GameManager.point += 10;
				Debug.Log (GameManager.point);
			}
		}
	}

	//ゲームプレイモード時にPointタグのオブジェクトに衝突したらプラス５
	void OnTriggerEnter(Collider other){
		if (GameManager.nazomode == false) {
			if (other.gameObject.tag == "Point") {
				sound2.clip = heal;
				sound2.Play ();
				GameManager.point += 5;
				other.gameObject.SetActive (false);
				Debug.Log (GameManager.point);
			}
		}
		if (other.gameObject.name == "ChangeScene") {
				GameManager.point += 20;
				StartCoroutine (ChangeScene ());
		}
	}

	public IEnumerator ChangeScene(){
		sound2.clip = wave;
		sound2.Play ();
		if (GameManager.nazomode == true) {
			yield return new WaitForSeconds(0.5f);
			SceneManager.LoadScene ("Movie");
		} else {
			GameManager.startflag = false;
			yield return new WaitForSeconds(1.0f);
			SceneManager.LoadScene ("Result");
		}
	}
}
