using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataControl", menuName = "ScriptableObjects/DataControl")]
public class DataControl : ScriptableObject
{
    [Header("Stats")]
    public string characterName;
    public float moveSpeed;
    public float maxHealth;
    public float jumpForce;
    public float damage;


    [Header("Visual")]
    public List<GameManager> characterPrefab;
    public RuntimeAnimatorController animatorController;
}
