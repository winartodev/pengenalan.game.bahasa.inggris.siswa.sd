using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Winarto_21 
{
	public class Music : MonoBehaviour
	{
		private static Music instance;

		AudioSource myAudio;

		void Awake()
		{
			myAudio = GetComponent<AudioSource>();

			if (Music.instance == null)
			{
				Music.instance = this;
				GameObject.DontDestroyOnLoad(this.gameObject);
			}
			else
			{
				Destroy(this.gameObject);
			}
		}

		public void ToggleSound()
		{
			if (PlayerPrefs.GetInt("Muted", 0) == 0)
			{
				PlayerPrefs.SetInt("Muted", 1);
			}
			else
			{
				PlayerPrefs.SetInt("Muted", 0);
			}
		}

		public void IsPaused(bool vol)
		{
			myAudio.mute = vol;
		}
	}
}

