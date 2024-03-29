using System;
using _Project.Scripts.Heroes;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Cameras
{
    public interface ICameraService
    {
        void FollowHero(HeroMove heroMove);
    }

    public class CameraService : IDisposable, ICameraService
    {
        private Camera _camera;
        private HeroMove _heroMove;
        private Transform _transform;
        
        private IDisposable _followHero;
        private IDisposable _updatePosition;

        public CameraService(Camera camera)
        {
            _camera = camera;
            _transform = camera.transform;
        }

        public void FollowHero(HeroMove heroMove)
        {
            _heroMove = heroMove;
            _followHero = _heroMove.IsMoving
                .Subscribe(isMoving =>
                {
                    if (isMoving)
                    {
                        _updatePosition = Observable.EveryLateUpdate()
                            .Subscribe(_ => UpdatePosition());
                    }
                    else
                    {
                        _updatePosition?.Dispose();
                    }
                });
        }

        private void UpdatePosition()
        {
            var oldPosition = _transform.position;
            _transform.position = new Vector3(_heroMove.transform.position.x, oldPosition.y, oldPosition.z);
        }

        public void Dispose()
        {
            _updatePosition?.Dispose();
            _followHero?.Dispose();
        }
    }
}