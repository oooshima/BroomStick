using UnityEngine;
using System.Collections;

public class WebcamCapture : MonoBehaviour {

	//このクラスをウェブカメラの映像をテクスチャとして貼り付けるオブジェクトに適用する
	GameObject refObj;
	public ScoreText scoreText;
	private WebCamTexture webcamtex;

	// Use this for initialization
	void Start()
	{
		refObj = GameObject.Find("Canvas/Text");
		webcamtex = new WebCamTexture();   //コンストラクタ

		Renderer _renderer = GetComponent<Renderer>();  //Planeオブジェクトのレンダラ
		_renderer.material.mainTexture = webcamtex;    //mainTextureにWebCamTextureを指定
		webcamtex.Play();  //ウェブカムを作動させる
		refObj.GetComponent<ScoreText>().score = "x=30,y=20";
	}

}
	

