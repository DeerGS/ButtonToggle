using UnityEngine;
using System.Collections;
using System;

namespace LevelObjects
{
	public class Objective : MonoBehaviour
	{
		public Action OnActivate;
		[SerializeField]
		private Material steppedOn;
		public bool activated = false;

		void OnTriggerEnter(Collider other) 
		{
			if(other.CompareTag("Player"))
			{
				this.GetComponent<MeshRenderer>().material = steppedOn;
				activated = true;
			}
			if(OnActivate != null)
			{
				// Convinient trick to remove references if action should be called just once.
				var evnt = OnActivate;
				evnt();
				OnActivate = null;
			}
		}


	}
}
