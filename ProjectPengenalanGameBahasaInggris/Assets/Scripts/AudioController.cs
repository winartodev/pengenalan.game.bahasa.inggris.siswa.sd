using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Winarto_21 
{
	public class AudioController : MonoBehaviour
	{
		Music music;

		public Button musicBtn;

		public Sprite musicOn, musicOff;

		private void Start()
		{
			music = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
			UpdateIcon();
		}

		public void PausedMusic()
		{
			music.ToggleSound();
			UpdateIcon();
		}

		public void UpdateIcon()
		{
			if (PlayerPrefs.GetInt("Muted", 0) == 0)
			{
				music.IsPaused(true);
				musicBtn.GetComponent<Image>().sprite = musicOff;
			}
			else
			{
				music.IsPaused(false);
				musicBtn.GetComponent<Image>().sprite = musicOn;
			}
		}
	}
}

