using UnityEngine;
using System.Collections;

namespace LevelObjects
{
	public class Enemy : MonoBehaviour
	{
		private Pool pool;
		private LevelController controller;
		private GameObject player;

		void Start()
		{
			pool = GameObject.FindObjectOfType<Pool>();
			controller = GameObject.FindObjectOfType<LevelController>();
			player = GameObject.FindGameObjectWithTag("Player");
			StartCoroutine(Shoot());
		}
		
		private float RELOAD_TIME = 4f;

		IEnumerator Shoot()
		{
			while(true)
			{
				yield return new WaitForSeconds(RELOAD_TIME);

				var projectile = pool.Get();
				projectile.transform.position = this.transform.position;
				projectile.transform.LookAt(new Vector3(player.transform.position.x,
				                                        this.transform.position.y,
				                                        player.transform.position.z));
				projectile.GetComponent<Projectile>().Fire(pool, controller);
			}
		}

	}
}
