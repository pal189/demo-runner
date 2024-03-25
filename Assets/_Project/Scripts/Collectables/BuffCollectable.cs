using System.Collections.Generic;
using _Project.Scripts.Buffs;
using _Project.Scripts.Effects;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Collectables
{
    public class BuffCollectable : Collectable
    {
        public List<IBuffCreator> BuffCreators;
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