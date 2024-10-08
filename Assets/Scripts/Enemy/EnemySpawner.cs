using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] float spawnMinYPercentage;
	[SerializeField] float spawnMaxYPercentage;
	[SerializeField] float spawnTime;
	[SerializeField] List<GameObject> enemies;
	[SerializeField] List<float> ratios;
	[SerializeField] int poolSize;
	List<GameObject> enemyPool;
	float timer;
	float spawnX;
	float spawnMinY, spawnMaxY;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		enemyPool = new List<GameObject>();

		// calculate spawn height based on camera height
		float worldHeight = Camera.main.orthographicSize * 2;
		spawnMinY = (spawnMinYPercentage / 100f) / worldHeight;
		spawnMaxY = (spawnMaxYPercentage / 100f) / worldHeight;

		// calculate width camera
		float cameraWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
		spawnX = cameraWidth / 2;

		int ratio1 = (int)(ratios[0] * poolSize); // ratio appear of first enemy
		for (int i = 0; i < ratio1; i++)
		{
			GameObject newEnemy = Instantiate(enemies[0]);
			newEnemy.SetActive(false);
			enemyPool.Add(newEnemy);
		}
		for (int i = ratio1; i < poolSize; i++)
		{
			GameObject newEnemy = Instantiate(enemies[1]);
			newEnemy.SetActive(false);
			enemyPool.Add(newEnemy);
		}
		enemyPool = ShuffleList(enemyPool); // shuffle list
	}

	List<GameObject> ShuffleList(List<GameObject> list)
	{
		var random = new System.Random();
		return list.OrderBy(item => random.Next()).ToList();
	}

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer > spawnTime)
		{
			GameObject newEnemy = GetFreeEnemy();
			if (newEnemy != null)
			{
				newEnemy.SetActive(true);
				newEnemy.transform.position = new Vector3(spawnX, Random.Range(spawnMinY, spawnMaxY), transform.position.z);
				timer = 0;
			}
		}
	}

	private GameObject GetFreeEnemy()
	{
		foreach (var enemy in enemyPool)
		{
			if (enemy.activeSelf == false)
			{
				return enemy;
			}
		}
		return null;
	}
}
