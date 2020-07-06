using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Winarto_21 
{
    public class RandomSelection : MonoBehaviour
    {
        private void Start()
        {
            Random_Selection();
        }

        public void Random_Selection()
        {
            Vector3[] buttonPos = new Vector3[transform.childCount];

            bool[] installed = new bool[transform.childCount];

            for (int i = 0; i < buttonPos.Length; i++)
            {
                buttonPos[i] = transform.GetChild(i).transform.position;

                installed[i] = false;
            }

            for (int i = 0; i < buttonPos.Length; i++)
            {
                bool reset = true;

                while (reset)
                {
                    int randomPos = Random.Range(0, transform.childCount);

                    if (!installed[randomPos])
                    {
                        transform.GetChild(i).transform.position = buttonPos[randomPos];

                        installed[randomPos] = true;

                        reset = false;
                    }
                    else
                    {
                        reset = true;
                    }
                }
            }
        }
    }
}

