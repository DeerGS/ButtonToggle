using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace LevelObjects
{
	public class LevelController : MonoBehaviour
	{
		[SerializeField]
		private Spawner spawner;

		private int hitPoints;
		public int HitPoints
		{
			get
			{
				return hitPoints;
			}
			set
			{
				hitPoints = value;
				Debug.Log("LevelController HitPoints: Remaining: " + hitPoints.ToString());
			}
		}
		private int DEFAULT_HIT_POINTS_NUM = 5;

		void Awake()
		{
			if(spawner == null)
			{
				spawner = GameObject.FindObjectOfType<Spawner>();
			}
			HitPoints = DEFAULT_HIT_POINTS_NUM;
		}

		[SerializeField]
		private Objective objectivePrefab;
		[SerializeField] [Range(1,10)]
		private int objectiveCount;
		private List<Objective> objectiveList = new List<Objective>();

		[SerializeField]
		private Enemy enemyPrefab;

		void Start()
		{
			for(int i = 0; i < objectiveCount; i++)
			{
				var obj = (Objective)spawner.Spawn(objectivePrefab);
				objectiveList.Add(obj);
				obj.OnActivate += VictoryCheck;
			}
			StartCoroutine(SpawnEnemy());
		}

		void VictoryCheck()
		{
			bool victory = true;
			foreach(var obj in objectiveList)
			{
				if(!obj.activated)
					victory = false;
			}
			if(victory)
			{
				Debug.Log("Victory");
				Application.LoadLevel(0);
			}
		}

		[SerializeField] 
		private float maxEnemySpawnTime;

		IEnumerator SpawnEnemy()
		{
			while(true)
			{
				yield return new WaitForSeconds(UnityEngine.Random.Range(1f,maxEnemySpawnTime));
				spawner.Spawn(enemyPrefab);
			}
		}

		public static Action OnLoseHitPoints;
		public void RemoveHitPoint()
		{
			HitPoints--;
			if(OnLoseHitPoints != null)
				OnLoseHitPoints();
			if(HitPoints <= 0)
				Lose();
		}

		void Lose()
		{
			Debug.Log("Lose!");
			Application.LoadLevel(0);
		}

	}

}