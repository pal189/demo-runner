using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Effects;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Buffs
{
    public class BuffsController : ITickable
    {
        private readonly Dictionary <IBuffCreator, IBuff> _buffs = new Dictionary<IBuffCreator, IBuff>();

        public void Tick()
        {
            var delta = Time.deltaTime;
            foreach (var buff in _buffs.Values.ToList())
            {
                buff.Tick(delta);
            }
        }

        public void AddBuff(IBuff buff)
        {
            if (_buffs.ContainsKey(buff.IBuffCreator))
            {
                _buffs[buff.IBuffCreator].Activate();
            }
            else
            {
                _buffs.Add(buff.IBuffCreator, buff);
                buff.Activate();
            }
        }

        public void RemoveBuff(IBuff buff)
        {
            _buffs.Remove(buff.IBuffCreator);
        }
    }
}