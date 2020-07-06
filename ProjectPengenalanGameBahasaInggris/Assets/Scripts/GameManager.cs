using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Winarto_21 
{
    public class GameManager : MonoBehaviour
    {
        public GameObject gameOverPanel;

        public GameObject mainGame;

        public TMP_Text finalScoreText;

        public List<GameObject> stars;

        private void Update()
        {
            if (QuestionsController.gameOver)
            {
                gameOverPanel.SetActive(true);

                mainGame.SetActive(false);

                finalScoreText.text = "Your Score : " + QuestionsController.score.ToString();

                GetStars();
            }
        }

        private void GetStars()
        {
            if (QuestionsController.score < 100)
            {
                stars[0].SetActive(false);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
            }
            else if (QuestionsController.score >= 200 && QuestionsController.score < 400)
            {
                stars[0].SetActive(true);
                stars[1].SetActive(false);
                stars[2].SetActive(false);
            }
            else if (QuestionsController.score >= 400 && QuestionsController.score < 600)
            {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(false);
            }
            else if (QuestionsController.score >= 600 && QuestionsController.score <= 800)
            {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);
            }
        }

        public void ResetGame()
        {
            QuestionsController.score = 0;
            QuestionsController.answerQuestions = 0;
            QuestionsController.gameOver = false;
            gameOverPanel.SetActive(false);
            mainGame.SetActive(true);
        }
    }
}
