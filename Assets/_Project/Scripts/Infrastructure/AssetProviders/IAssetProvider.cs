using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetProviders
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}