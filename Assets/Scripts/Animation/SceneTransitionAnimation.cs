﻿using DG.Tweening;
using Loaders;
using UnityEngine;
using Zenject;

namespace Animation
{
    public class SceneTransitionAnimation : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private SceneTransitionAnimation _instance;
        private ScenesLoader _scenesLoader;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [Inject]
        private void Construct(ScenesLoader scenesLoader)
        {
            _scenesLoader = scenesLoader;
        }
        
        private void OnEnable()
        {
            _scenesLoader.OnSceneLoaded += DoFadeOut;
        }
        
        private void OnDisable()
        {
            _scenesLoader.OnSceneLoaded -= DoFadeOut;
        }
        
        public void DoFadeIn()
        {
            spriteRenderer.DOFade(1f, 1f);
        }
        
        private void DoFadeOut()
        {
            spriteRenderer.DOFade(0f, 1f);
        }
    }
}