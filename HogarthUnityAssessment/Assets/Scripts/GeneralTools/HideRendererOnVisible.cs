using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HideRendererOnVisible : MonoBehaviour {
	private void OnEnable() => GetComponent<Renderer>().enabled = false;
}