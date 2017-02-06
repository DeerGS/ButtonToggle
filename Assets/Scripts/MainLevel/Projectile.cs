using UnityEngine;
using System.Collections;

namespace LevelObjects
{
	public class Projectile : MonoBehaviour
	{
		private bool fired = false;
		private Pool pool;
		private LevelController controller;

		public void Fire(Pool inPool, LevelController inController)
		{
			fired = true;
			pool = inPool;
			controller = inController;
			StartCoroutine(Fly());
		}

		[SerializeField] [Range(1f,10f)]
		private float speed;

		IEnumerator Fly()
		{
			while(fired)
			{
				yield return new WaitForFixedUpdate();
				this.transform.position += transform.forward * speed * Time.fixedDeltaTime;
			}
		}

		void OnTriggerEnter(Collider other) 
		{
			if(other.CompareTag("Player"))
				controller.RemoveHitPoint();
			if(other.CompareTag("Wall"))
			{
				fired = false;
				pool.Release(this.gameObject);

			}

		}
	}
}
