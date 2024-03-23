using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure
{
    public class SceneLoader
    {
        public async void LoadSceneAsync(string sceneName, Action onLoaded = null)
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