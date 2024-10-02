using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float minSpeed;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float lifeTime;
	float width, speed, time;

	// Start is called before the first frame update
	void Start()
	{
		float gOWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
		width = Camera.main.orthographicSize * Camera.main.aspect - gOWidth;
		speed = Random.Range(minSpeed, maxSpeed);
		time = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x > -width)
		{
			transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}
		else
		{
			this.gameObject.SetActive(false);
		}

		time += Time.deltaTime;

		if (time > lifeTime)
		{
			this.gameObject.SetActive(false);
		}
	}
}
