using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIAnimationTypes
{ 
    Move,
    Scale,
    ScaleX,
    ScaleY,
    Fade
}
namespace Winarto_21 
{
    public class AnimationController : MonoBehaviour
    {
        public GameObject objectToAnimate;

        public UIAnimationTypes animationType;
        public LeanTweenType easeType;
        public float duration;
        public float delay;

        public bool loop;
        public bool pingpong;

        public bool startPositionOffset;
        public Vector3 from;
        public Vector3 to;

        public LTDescr _tweenObject;

        public bool showOnEnable;
        public bool workOnDisable;

        public void OnEnable()
        {
            if (showOnEnable)
            {
                Show();
            }
        }

        public void Show()
        {
            HandleTween();
        }

        public void HandleTween()
        {
            if (objectToAnimate == null)
            {
                objectToAnimate = gameObject;
            }

            switch (animationType)
            {
                case UIAnimationTypes.Fade:
                    Fade();
                    break;
                case UIAnimationTypes.Move:
                    MoveAbsolute();
                    break;
                case UIAnimationTypes.Scale:
                    Scale();
                    break;
                case UIAnimationTypes.ScaleX:
                    Scale();
                    break;
                case UIAnimationTypes.ScaleY:
                    Scale();
                    break;
            }

            _tweenObject.setDelay(delay);
            _tweenObject.setEase(easeType);

            if (loop)
            {
                _tweenObject.loopCount = int.MaxValue;
            }
            if (pingpong)
            {
                _tweenObject.setLoopPingPong();
            }
        }

        public void Fade()
        {
            if (gameObject.GetComponent<CanvasGroup>() == null)
            {
                gameObject.AddComponent<CanvasGroup>();
            }

            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
            }

            _tweenObject = LeanTween.alphaCanvas(objectToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
        }

        public void MoveAbsolute()
        {
            objectToAnimate.GetComponent<RectTransform>().anchoredPosition = from;

            _tweenObject = LeanTween.move(objectToAnimate.GetComponent<RectTransform>(), to, duration);
        }

        public void Scale()
        {
            if (startPositionOffset)
            {
                objectToAnimate.GetComponent<RectTransform>().localScale = from;
            }

            _tweenObject = LeanTween.scale(objectToAnimate, to, duration);
        }

        void SwapDirection()
        {
            var temp = from;
            from = to;
            to = temp;
        }

        public void Disable()
        {
            SwapDirection();

            HandleTween();

            _tweenObject.setOnComplete(() => {

                SwapDirection();

                gameObject.SetActive(false);
            });
        }

        public void Disable(Action onCompleteAction)
        {
            SwapDirection();
        }


    }
}
