using System;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptableObjects.Character
{
    [Serializable]
    public class DataKnight
    {
        [SerializeField] private string characterName;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float maxHealth;
        [SerializeField] private float jumpForce;
        [SerializeField] private float damage;
        [SerializeField] private RuntimeAnimatorController animatorController;

        public string CharacterName => characterName;
        public float MoveSpeed => moveSpeed;
        public float MaxHealth => maxHealth;
        public float JumpForce => jumpForce;
        public RuntimeAnimatorController AnimatorController => animatorController;
    }
}