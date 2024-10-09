using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour
{
	[SerializeField] float speedX;
	Renderer renderer;
	// Start is called before the first frame update
	void Start()
	{
		renderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{
		var offset = new Vector2(Time.time * speedX, 0);
		renderer.material.mainTextureOffset = offset;
	}
}
