using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] float spawnMinY;
	[SerializeField] float spawnMaxY;
	[SerializeField] float spawnTime;
	[SerializeField] List<GameObject> enemies;
	[SerializeField] int poolSize;
	List<GameObject> enemyPool;
	float timer;
	float numEnemies;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
		numEnemies = enemies.Count;
		enemyPool = new List<GameObject>();
		for (int i = 0; i < poolSize; i++)
		{
			GameObject newEnemy = Instantiate(enemies[(int)Random.Range(0, numEnemies)]);
			newEnemy.SetActive(false);
			enemyPool.Add(newEnemy);
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
				newEnemy.transform.position = new Vector3(transform.position.x, Random.Range(spawnMinY, spawnMaxY), transform.position.z);
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
