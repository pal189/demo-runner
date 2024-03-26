using System.Collections.Generic;
using _Project.Scripts.Buffs;
using _Project.Scripts.Buffs.Creators;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Collectables
{
    /// <summary>
    /// Collectable with multiple buff creators. It will create that buffs when collected.
    /// </summary>
    public class BuffCollectable : Collectable
    {
        public List<BuffCreator> BuffCreators;
        
        private BuffFactory _factory;

        [Inject]
        public void Construct(BuffFactory factory) =>
            _factory = factory;
        
        public override void OnTriggerEnter(Collider other)
        {
            foreach (var creator in BuffCreators)
            {
                creator.Create(_factory);
            }

            base.OnTriggerEnter(other);
        }
    }
}