using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Minotaur", menuName = "ScriptableObjects/DataMinotaur")]
public class DataBoss : ScriptableObject
{
    public float Runspeed;
    public float walkingSpeed;
    public float walkingDistance;
    public float attackRange;
    public float attackDamage;
    public float checkPlayerRadius;
    public float checkNearPlayerRadius;
    public RuntimeAnimatorController animatorController;
    public AudioClip attackSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public int maxHealth;
}
