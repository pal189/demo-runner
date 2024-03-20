using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public interface IFactory
    {
        GameObject CreatePlatform(Vector3 at);
    }
}