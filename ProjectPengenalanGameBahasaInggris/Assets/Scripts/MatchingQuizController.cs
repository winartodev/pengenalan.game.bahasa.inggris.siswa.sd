#pragma warning disable CS0649
#pragma warning disable CS0414
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Winarto_21 
{
    public class MatchingQuizController : MonoBehaviour
    {
		[SerializeField]
		private Sprite bgImages;

		[SerializeField]
		private TMP_Text countDownTimerText;

		[SerializeField]
		private GameObject gameOver, mainGame;

		public List<GameObject> stars;

		float currentTime = 0f;
		float startTime = 60f;
		float finalTime; 

		public Sprite[] puzzle;

		public List<Sprite> gamePuzzles = new List<Sprite>();

		public List<Button> btns = new List<Button>();

		private bool firstGuest, secondGuest;

		private int countGuesses;
		private int countCorrectGuesses;
		private int gameGuesses;

		private int firstGuessIndex, secondGuessIndex;

		private string firstGuessPuzzle, secondGuessPuzzle;

		private void Awake()
		{
			puzzle = Resources.LoadAll<Sprite>("8966");
		}

		private void Start()
		{
			GetButtons();
			AddListener();
			AddGamePuzzle();
			shuffle(gamePuzzles);
			gameGuesses = gamePuzzles.Count / 2;

			currentTime = startTime;
		}

		void GetButtons()
		{
			GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

			for (int i = 0; i < objects.Length; i++)
			{
				btns.Add(objects[i].GetComponent<Button>());
				btns[i].image.sprite = bgImages;
			}
		}

		void AddGamePuzzle()
		{
			int looper = btns.Count;
			int index = 0;

			for (int i = 0; i < looper; i++)
			{
				if (index == looper / 2)
				{
					index = 0;
				}

				gamePuzzles.Add(puzzle[index]);
				index++;
			}
		}

		void Update()
		{
			startTime -= 1 * Time.deltaTime;
			countDownTimerText.text = startTime.ToString("0");
			if (startTime <= 0)
			{
				GameOver();
			}
		}

		void AddListener()
		{
			foreach (Button btn in btns)
			{
				btn.onClick.AddListener(() => PickPuzzle());
			}
		}

		public void PickPuzzle()
		{
			string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

			if (!firstGuest)
			{

				firstGuest = true;

				firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

				firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

				btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];

			}
			else if (!secondGuest)
			{

				secondGuest = true;

				secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

				secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

				btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

				countGuesses++;

				StartCoroutine(CheckIfThePuzzlesMatch());
			}
		}

		IEnumerator CheckIfThePuzzlesMatch()
		{
			yield return new WaitForSeconds(.5f);

			if (firstGuessPuzzle == secondGuessPuzzle)
			{
				yield return new WaitForSeconds(.25f);

				btns[firstGuessIndex].interactable = false;
				btns[secondGuessIndex].interactable = false;

				btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
				btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

				CheckIfTheGameIsFinished();
			}
			else
			{
				yield return new WaitForSeconds(.25f);

				btns[firstGuessIndex].image.sprite = bgImages;
				btns[secondGuessIndex].image.sprite = bgImages;
			}

			yield return new WaitForSeconds(.25f);

			firstGuest = secondGuest = false;
		}

		void CheckIfTheGameIsFinished()
		{
			countCorrectGuesses++;

			if (countCorrectGuesses == gameGuesses)
			{
				GameOver();
			}
		}

		void shuffle(List<Sprite> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				Sprite temp = list[i];
				int randomIndex = Random.Range(i, list.Count);
				list[i] = list[randomIndex];
				list[randomIndex] = temp;
			}
		}

		void GameOver() 
		{
			PlayerPrefs.SetInt("finalTime", (int)startTime);
			finalTime = PlayerPrefs.GetInt("finalTime", (int)startTime);
			gameOver.SetActive(true);
			mainGame.SetActive(false);
			GetStars();
		}

		void GetStars() 
		{
			if (finalTime < 20)
			{
				stars[0].SetActive(false);
				stars[1].SetActive(false);
				stars[2].SetActive(false);
			}
			else if (finalTime >= 20 && finalTime < 30)
			{
				stars[0].SetActive(true);
				stars[1].SetActive(false);
				stars[2].SetActive(false);
			}
			else if (finalTime >= 30 && finalTime < 45)
			{
				stars[0].SetActive(true);
				stars[1].SetActive(true);
				stars[2].SetActive(false);
			}
			else if (finalTime >= 45 && finalTime < 60)
			{
				stars[0].SetActive(true);
				stars[1].SetActive(true);
				stars[2].SetActive(true);
			}
		}
	}
}

