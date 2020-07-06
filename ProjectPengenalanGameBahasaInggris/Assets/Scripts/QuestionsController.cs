#pragma warning disable CS0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Winarto_21 
{
    public class QuestionsController : MonoBehaviour
    {
        [System.Serializable]
        public class Questions
        {
            [Header("Question")]
            public Sprite question;
            public string questionText;

            [Header("Answers")]
            public string selectionA;
            public string selectionB, selectionC, selectionD;

            [Header("Answers Key")]
            public bool a;
            public bool b, c, d;
        }

        public static int randomValue;
        public static int score;
        public static int answerQuestions;

        public static bool gameOver = false;

        private TMP_Text questionText, textA, textB, textC, textD, scoreValueText;

        private Image questionImage;

        [SerializeField]
        private GameManager gameManager;

        public List<Questions> collectionOfQuestions;

        private void Start()
        {
            gameManager.ResetGame();

            randomValue = Random.Range(0, collectionOfQuestions.Count);

            questionImage = GameObject.Find("QuestionImage").GetComponent<Image>();
            questionText = GameObject.Find("QuestionText").GetComponent<TMP_Text>();

            textA = GameObject.Find("TextA").GetComponent<TMP_Text>();
            textB = GameObject.Find("TextB").GetComponent<TMP_Text>();
            textC = GameObject.Find("TextC").GetComponent<TMP_Text>();
            textD = GameObject.Find("TextD").GetComponent<TMP_Text>();

            scoreValueText = GameObject.Find("TextScoreValue").GetComponent<TMP_Text>();
        }

        private void Update()
        {
            scoreValueText.text = score.ToString();

            questionImage.sprite = collectionOfQuestions[randomValue].question;
            questionImage.SetNativeSize();

            questionText.text = collectionOfQuestions[randomValue].questionText;

            textA.text = collectionOfQuestions[randomValue].selectionA;
            textB.text = collectionOfQuestions[randomValue].selectionB;
            textC.text = collectionOfQuestions[randomValue].selectionC;
            textD.text = collectionOfQuestions[randomValue].selectionD;

            if (answerQuestions == 8)
            {
                gameOver = true;
            }
        }
    }
} 

