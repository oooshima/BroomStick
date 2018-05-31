using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieScript : MonoBehaviour {
	bool flag1 = false;
	bool flag2 = false;
	bool flag3 = false;
	bool flag4 = false;
	public GameObject canvas;
	public GameObject canvas2;
	public GameObject canvas3;
	public GameObject particle;
	public GameObject Text;
	public GameObject Text2;
	private Image image;
	private Text text;
	public AudioClip wind;
	public AudioClip system;
	public AudioClip space;
	public AudioClip moya;
	private AudioSource sound01;
	private AudioSource sound02;
	private AudioSource sound03;
	// Use this for initialization
	void Start () {
		image = canvas2.gameObject.GetComponent<Image>();
		//text = Text.gameObject.GetComponent<TextMesh> ();
		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound01 = audioSources[0];
		sound02 = audioSources[1];
		sound03 = audioSources[2];
		StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("Main");
		}

		if(flag1 == true){
			var color = image.color;//取得したimageのcolorを取得
			color.a -= 0.04f;//ラーのアルファ値(透明度合)を徐々に減らす
			image.color = color;//取得したImageに適応させる
		}
		if(flag2 == true){
			var color = image.color;//取得したimageのcolorを取得
			color.a += 0.03f;
			image.color = color;//取得したImageに適応させる
		}
		if (flag3 == true) {
			if (Text.gameObject.GetComponent<TextMesh> ().color.a < 200f) {
				var color = Text.gameObject.GetComponent<TextMesh> ().color;//取得したimageのcolorを取得
				color.a += 0.01f;
				Text.gameObject.GetComponent<TextMesh> ().color = color;//取得したImageに適応させる
			}
		}
		if (flag4 == true) {
			if (Text2.gameObject.GetComponent<TextMesh> ().color.a < 200f) {
			var color = Text2.gameObject.GetComponent<TextMesh> ().color;//取得したimageのcolorを取得					
			color.a += 0.01f;
			Text2.gameObject.GetComponent<TextMesh> ().color = color;//取得したImageに適応させる
				}

		}
	}


	public IEnumerator Move(){
			yield return new WaitForSeconds(2.5f);
			flag1 = true;
			yield return new WaitForSeconds(5.0f);
			flag1 = false;
			iTween.MoveTo (particle, iTween.Hash ("y", -80f, "z", -50f, "islocal", true, "time", 15.0f));
			sound03.clip = moya;
			sound03.loop = true;
			sound03.Play ();
			yield return new WaitForSeconds(5.0f);
			particle.SetActive (false);
			iTween.MoveTo (this.gameObject, iTween.Hash ("x", -1.88f, "y", -6.0f, "z", -0.71f, "islocal", true, "time", 8.0f));
			if (sound03.volume > 0) {
				sound03.volume =- 0.05f;
			}
			sound01.clip = wind;
			sound01.Play ();
			yield return new WaitForSeconds(3.0f);
			iTween.RotateTo (this.gameObject, iTween.Hash ("y", 199f,  "islocal", true, "time", 5.0f));
			yield return new WaitForSeconds(0.5f);
			flag3 =true;
			yield return new WaitForSeconds(4.0f);
			sound02.clip = space;
			sound02.Play ();
			iTween.MoveTo (this.gameObject, iTween.Hash ("x", 0.21f, "y", -7.1f, "z", -1.77f, "islocal", true, "time", 3.0f));
			iTween.RotateTo (this.gameObject, iTween.Hash ("y", 182.15f,  "islocal", true, "time", 5.0f));
			yield return new WaitForSeconds(1.5f);
			iTween.MoveTo (this.gameObject, iTween.Hash ("x", 0.21f, "y", -7.1f, "z", -23.5f, "islocal", true, "time", 20.0f));
			iTween.RotateTo (this.gameObject, iTween.Hash ("x", -16f,"y", 162f,  "islocal", true, "time", 4.0f));
			yield return new WaitForSeconds(2.0f);
			iTween.RotateTo (this.gameObject, iTween.Hash ("x", -16f,"y", 209f,  "islocal", true, "time", 4.0f));
			yield return new WaitForSeconds(2.5f);
			iTween.RotateTo (this.gameObject, iTween.Hash ("x", -5.7f,"y", 182.15f,  "islocal", true, "time", 3.0f));
			yield return new WaitForSeconds(1.5f);
			iTween.MoveTo (this.gameObject, iTween.Hash ("x", 9.53f, "y", -8.32f, "z", -29.94f, "islocal", true, "time", 15.0f));
			iTween.RotateTo (this.gameObject, iTween.Hash ("x", -5.7f,"y", 90.29f, "islocal", true, "time", 15.0f));
			flag4 = true;
			yield return new WaitForSeconds(8.0f);	
			sound01.clip = system;
			sound01.Play ();
			canvas3.SetActive (true);
			yield return new WaitForSeconds(7.0f);
			canvas3.SetActive (false);
			sound01.Play ();
			canvas.SetActive (true);
			yield return new WaitForSeconds(2.0f);
			flag2 = true;
			canvas.SetActive (false);
			iTween.RotateTo (this.gameObject, iTween.Hash ("x", 34.5f, "islocal", true, "time", 10.0f));
			flag1 = false;
	}
}