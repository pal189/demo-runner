﻿using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Collectables
{
    public class Spin : MonoBehaviour
    {
        private Tween _tween;

        private void Awake()
        {
            _tween = transform.DORotate(new Vector3(0, 0, 360), 1f)
                .SetLoops(-1, LoopType.Incremental)
                .OnKill(() => _tween = null);
        }

        private void OnDestroy() => 
            _tween.Kill();
    }
}