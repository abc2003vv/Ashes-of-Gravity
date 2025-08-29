using System;
using UnityEngine;
namespace ScriptableObjects.BossMinotaur
{
    [Serializable]
    public class DataBoss
    {
        [SerializeField] private float _Runspeed;
        [SerializeField] private float _walkingSpeed;
        [SerializeField] private float _walkingDistance;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackDamage;
        [SerializeField] private float _checkPlayerRadius;
        [SerializeField] private float _checkNearPlayerRadius;
        [SerializeField] private RuntimeAnimatorController _animatorController;
        [SerializeField] private AudioClip _attackSound;
        [SerializeField] private AudioClip _jumpSound;
        [SerializeField] private AudioClip _landSound;
        [SerializeField] private AudioClip _hurtSound;
        [SerializeField] private AudioClip _deathSound;
        [SerializeField] private int _maxHealth;

        public float Runspeed => _Runspeed;
        public float walkingSpeed => _walkingSpeed;
        public float walkingDistance => _walkingDistance;
        public float attackRange => _attackRange;
        public float attackDamage => _attackDamage;
        public float checkPlayerRadius => _checkPlayerRadius;
        public float checkNearPlayerRadius => _checkNearPlayerRadius;
        public RuntimeAnimatorController animatorController => _animatorController;
        public AudioClip attackSound => _attackSound;
        public AudioClip jumpSound => _jumpSound;
        public AudioClip landSound => _landSound;
        public AudioClip hurtSound => _hurtSound;
        public AudioClip deathSound => _deathSound;
        public int maxHealth => _maxHealth;

    }
}