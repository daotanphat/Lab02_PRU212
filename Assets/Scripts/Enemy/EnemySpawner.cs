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
		float halfWorldHeight = worldHeight / 2;
		spawnMinY = ((spawnMinYPercentage / 100f) * worldHeight) - halfWorldHeight;
		spawnMaxY = ((spawnMaxYPercentage / 100f) * worldHeight) - halfWorldHeight;

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
		FisherYatesShuffle(enemyPool); // shuffle list
	}

	public static void FisherYatesShuffle<T>(IList<T> list)
	{
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = UnityEngine.Random.Range(0, n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
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
		int startIndex = Random.Range(0, enemyPool.Count);

		// Start searching from a random index
		for (int i = startIndex; i < enemyPool.Count; i++)
		{
			if (!enemyPool[i].activeSelf)
			{
				return enemyPool[i];
			}
		}

		// If no enemy is found, search from the beginning up to the random index
		for (int i = 0; i < startIndex; i++)
		{
			if (!enemyPool[i].activeSelf)
			{
				return enemyPool[i];
			}
		}

		// If no inactive enemy is found, return null
		return null;
	}
}
