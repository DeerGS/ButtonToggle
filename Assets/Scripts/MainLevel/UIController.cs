using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LevelObjects;

namespace UI
{
	public class UIController : MonoBehaviour
	{
		[SerializeField]
		private Text hitPointsText;

		private LevelController levelController;

		void Start()
		{
			levelController = GameObject.FindObjectOfType<LevelController>();
			LevelController.OnLoseHitPoints += UpdateHitPointText;
			UpdateHitPointText();
		}

		void UpdateHitPointText()
		{
			hitPointsText.text = levelController.HitPoints.ToString();
		}
	}
}