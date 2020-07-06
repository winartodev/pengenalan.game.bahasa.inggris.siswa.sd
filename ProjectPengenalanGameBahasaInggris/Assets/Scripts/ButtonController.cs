#pragma warning disable CS0649
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Winarto_21 
{
    public class ButtonController : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPanel;

        [SerializeField] private ProfessionListController professionController;

        [SerializeField] private QuestionsController questionsController;

        [SerializeField] private AudioSource myAudio;

        [SerializeField] private RandomSelection randomSelection;

        public void OnClick_ChangeScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void OnClick_EnabledSettingPanel()
        {
            if (settingsPanel)
            {
                settingsPanel.SetActive(true);
            }
            else
            {
                print("Game Object Settings Panel is Not Added");
            }
        }

        public void OnClick_DisableSettingPanel()
        {
            if (settingsPanel)
            {
                settingsPanel.SetActive(false);
            }
            else
            {
                print("Game Object Settings Panel is Not Added");
            }
        }

        public void OnClick_ProfessionListController(int i)
        {
            if (professionController)
            {
                professionController.Control(i);
            }
            else
            {
                print("Add Script ProfessionListController");
            }
        }

        public void OnClick_RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnClick_Exit()
        {
            Application.Quit();
        }

        [System.Obsolete]
        public void OnClick_CheckAnswer(string answer)
        {
            if (questionsController.collectionOfQuestions[QuestionsController.randomValue].a && answer == "a")
            {
                QuestionsController.score += 100;
            }
            else if (questionsController.collectionOfQuestions[QuestionsController.randomValue].b && answer == "b")
            {
                QuestionsController.score += 100;
            }
            else if (questionsController.collectionOfQuestions[QuestionsController.randomValue].c && answer == "c")
            {
                QuestionsController.score += 100;
            }
            else if (questionsController.collectionOfQuestions[QuestionsController.randomValue].d && answer == "d")
            {
                QuestionsController.score += 100;
            }

            QuestionsController.answerQuestions += 1;

            questionsController.collectionOfQuestions.RemoveAt(QuestionsController.randomValue);

            QuestionsController.randomValue = Random.RandomRange(0, questionsController.collectionOfQuestions.Count);

            randomSelection.Random_Selection();
        }

        public void OnClick_PlaySound(AudioClip audio)
        {
            myAudio = gameObject.GetComponent<AudioSource>();
            myAudio.PlayOneShot(audio);
        }
    }
}

