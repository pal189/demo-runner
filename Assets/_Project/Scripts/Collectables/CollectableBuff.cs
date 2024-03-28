using System.Collections.Generic;
using _Project.Scripts.Buffs;
using _Project.Scripts.Buffs.Creators;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Collectables
{
    /// <summary>
    /// Buff behavior for Collectables. It has a collection of buff creators which will create buffs on collision with player.
    /// </summary>
    public class CollectableBuff : MonoBehaviour
    {
        public List<BuffCreator> BuffCreators;
        
        private BuffFactory _factory;

        [Inject]
        public void Construct(BuffFactory factory) =>
            _factory = factory;
        
        public void OnTriggerEnter(Collider other)
        {
            foreach (var creator in BuffCreators)
            {
                creator.Create(_factory);
            }
        }
    }
}