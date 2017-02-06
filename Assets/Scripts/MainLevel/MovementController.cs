using UnityEngine;
using System.Collections;

namespace Player
{
	public class MovementController : MonoBehaviour
	{
		[Range(1,5)] [SerializeField]
		private float speed;

		private Transform playerTransform = null;
		void Awake()
		{
			playerTransform = this.gameObject.transform;
		}

		void Update()
		{
			bool moving = Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f;
			if(moving)
				playerTransform.position = new Vector3(playerTransform.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime),
				                                       playerTransform.position.y,
				                                       playerTransform.position.z+ (Input.GetAxis("Vertical") * speed * Time.deltaTime));
		}
	}
}
