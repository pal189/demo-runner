using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName, Action onLoaded = null);
    }

    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                return;
            }

            await SceneManager
                .LoadSceneAsync(sceneName)
                .ToUniTask()
                .ContinueWith(() => onLoaded?.Invoke());
        }
    }
}