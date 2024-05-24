﻿using System;

using UnityEngine;

using Game.Scriptables;
using Game.Input;
using YG;

namespace Game
{
    class CubeSling : MonoBehaviour
    {
        public event Action<Cube> Detached;

        [SerializeField] private CubeSlingData _data;

        private Cube _cube;
        private Transform _cubeTransform;
        private DragTouchInput _touchInput;

        public AudioSource audioSource;
        public AudioClip audioClip;

        public Menu menu;
        public PauseGame pause;
        public Timer timer;

        public void Update()
        {
            if (!menu.isMenu && !pause.isPaused && !timer.isOver && !YandexGame.isAd)
            {
                _touchInput?.Update();
            }
        }

        public void Attach(Cube cube)
        {
           
                _cube = cube;
                _cubeTransform = cube.transform;
                _cube.EnableKinematic();

                _touchInput = new DragTouchInput(_cubeTransform);
                _touchInput.Drag += OnDragCube;
                _touchInput.EndDrag += OnEndDragCube;
            
        }
        private void Detach()
        {
            
                _touchInput.EndDrag -= OnEndDragCube;
                _touchInput.Drag -= OnDragCube;
                _touchInput = null;

                var cube = _cube;
                _cube = null;

                cube.DisableKinematic();
                cube.Push(Vector3.forward, _data.PushForce);

                Detached?.Invoke(cube);
                audioSource.PlayOneShot(audioClip);
            
        }

        private void OnDragCube(Vector3 position)
        {
           
                var oldPosition = _cubeTransform.position;
                var newPosition = new Vector3(position.x, oldPosition.y, oldPosition.z);

                _cubeTransform.position = newPosition;
            
        }
        private void OnEndDragCube()
        {
            Detach();
        }
    }
}