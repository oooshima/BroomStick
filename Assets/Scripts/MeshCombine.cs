﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombine : MonoBehaviour
{

	//適当なマテリアルをセットするようにしておく
	public Material targetMaterial;
	public GameObject target;

	void Start()
	{
		Component[] meshFilters = GetComponentsInChildren<MeshFilter>();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];

		targetMaterial = target.transform.gameObject.GetComponent<Renderer> ().material;

		int i = 0;
		while (i < meshFilters.Length)
		{
			combine[i].mesh = ((MeshFilter)meshFilters[i]).sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			meshFilters[i].gameObject.SetActive(false);
			i++;
		}

		print(combine.Length);

		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.SetActive(true);

		//マテリアルを再設定
		target.transform.gameObject.GetComponent<Renderer>().material = targetMaterial;
	}
}