using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllower2D : MonoBehaviour {

	private Transform target;

	public float boundsLeft = 0.0f;
	public float boundsRight = 0.0f;
	public float boundsTop = 0.0f;
	public float boundsBottom = 0.0f;

	public Vector2 movementFromBase = new Vector2 (0.0f, 0.0f);
	public Vector2 baseLocation = new Vector2(0.0f, 0.0f);

	public float[] layerSpeeds;
	public GameObject[] layers;


	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player").transform;

		baseLocation = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

		var newX = Mathf.Clamp(target.position.x, boundsLeft, boundsRight);

		var newY = baseLocation.y;
		if(target.position.y > 0.23f)
			newY = Mathf.Clamp(target.position.y - (0.23f + 2.5975f), boundsBottom, boundsTop);

		transform.position = new Vector3 (newX, newY, transform.position.z);

		movementFromBase = new Vector2 (transform.position.x - baseLocation.x, transform.position.y - baseLocation.y);

		if (layers.Length > 0) {
			int i = 0;

			foreach (GameObject layer in layers) {
				var material = layer.GetComponent<Renderer> ().material;

				material.SetTextureOffset ("_MainTex", new Vector2 (movementFromBase.x * 0.015f * layerSpeeds[i], 0.0f));
				++i;
			}

		}

	}
}
