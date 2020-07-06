using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Winarto_21 
{
    public class ProfessionListController : MonoBehaviour
    {
        int order = 0;

        private void Start()
        {
            SetActive();
        }

        public void Control(int i)
        {
            order += i;

            if (order > transform.childCount - 1)
            {
                order = 0;
            }
            else if (order < 0)
            {
                order = transform.childCount - 1;
            }

            SetActive();
        }

        public void SetActive()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            transform.GetChild(order).gameObject.SetActive(true);
        }
    }
}

