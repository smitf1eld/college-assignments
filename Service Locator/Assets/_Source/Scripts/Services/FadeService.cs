using _Sourse.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;

public class FadeService : IFadeService
{
    public void FadeIn(CanvasGroup element, float duration)
    {
        element.DOKill();
        element.alpha = 0;
        element.gameObject.SetActive(true);
        element.DOFade(1, duration);
    }

    public void FadeOut(CanvasGroup element, float duration)
    {
        element.DOKill();
        element.DOFade(0, duration)
            .OnComplete(() => element.gameObject.SetActive(false));
    }
}