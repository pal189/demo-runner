using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public interface IFactory
    {
        GameObject CreateHero(Vector3 at);
        GameObject CreatePlatform(Vector3 at);
    }
}