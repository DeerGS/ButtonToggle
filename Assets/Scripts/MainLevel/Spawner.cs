using UnityEngine;
using System.Collections;

namespace LevelObjects
{
	public class Spawner : MonoBehaviour
	{
		// Note for future investigation. Setting Renderer bounds size to private variable in Awake
		// funtion doesn't work for some reason. Works as local variable though...
		// Not the best approach - I add a lot of overhead with constant GetComponent method call.

		public MonoBehaviour Spawn(MonoBehaviour obj)
		{
			var spawnBounds = this.GetComponent<Renderer>().bounds.size;
			var newObj = GameObject.Instantiate(obj);
			var newPos = new Vector3(this.transform.position.x + Random.Range(-spawnBounds.x/2f,spawnBounds.x/2f),
			                         this.transform.position.y,
			                         this.transform.position.z + Random.Range(-spawnBounds.z/2f,spawnBounds.z/2f));
			newObj.transform.position = newPos;
			return newObj;
		}
	}
}
