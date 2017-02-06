using UnityEngine;
using System.Collections;

namespace MainMenu
{
	public class Controller : MonoBehaviour
	{
		public void NewGame()
		{
			Application.LoadLevel(1);
		}

		public void Exit()
		{
			Application.Quit();
		}
	}
}
