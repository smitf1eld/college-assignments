using UnityEngine;

namespace _Sourse.Scripts.Interfaces
{
    public interface IFadeService
    {
        void FadeIn(CanvasGroup element, float duration);
        void FadeOut(CanvasGroup element, float duration);
    }
}
