using UnityEngine;
using System.Collections.Generic;

namespace LevelObjects
{
	public class Pool : MonoBehaviour
	{
		readonly List<GameObject> available = new List<GameObject>();
		readonly List<GameObject> inUse = new List<GameObject>();
		Transform trans;

		void Awake()
		{
			trans = transform;
			
			for(int i = 0; i < trans.childCount; i++)
			{
				GameObject go = trans.GetChild(i).gameObject;
				go.SetActive(false);
				available.Add(go);                
			}
		}
		
		public virtual GameObject Get()
		{
			GameObject obj = null;
			if(available.Count != 0)
			{
				obj = available[0];
				inUse.Add(obj);
				available.RemoveAt(0);
				obj.SetActive(true);
			} else
			{
				Debug.LogError("There is no available object");
				return null;
			}
			return obj;
		}
		
		public virtual void Release(GameObject entity)
		{
			entity.SetActive(false);
			entity.transform.parent = trans;
			available.Add(entity);
			inUse.Remove(entity);
		}
		
		public void ReInitialize()
		{
			foreach(var obj in inUse)
			{
				Release(obj);
			}
		}
		
	}
}