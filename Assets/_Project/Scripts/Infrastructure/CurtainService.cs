using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public interface ICurtainService
    {
        void Show();
        void Hide();
    }

    public class CurtainService : MonoBehaviour, ICurtainService
    {
        public CanvasGroup CurtainCanvasGroup;

        public void Show()
        {
            gameObject.SetActive(true);
            CurtainCanvasGroup.alpha = 1;
        }

        public void Hide()
        {
            CurtainCanvasGroup.DOFade(0, 1)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}