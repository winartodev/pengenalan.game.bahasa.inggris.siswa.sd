#pragma warning disable CS0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Winarto_21 
{
    public class MatchingQuizAddButtons : MonoBehaviour
    {
		[SerializeField]
		private Transform puzzleFiled;

		[SerializeField]
		private GameObject btn;

		private void Awake()
		{
			for (int i = 0; i < 8; i++)
			{
				GameObject button = Instantiate(btn);
				button.name = "" + i;
				button.transform.SetParent(puzzleFiled, false);
			}
		}
	}
}

