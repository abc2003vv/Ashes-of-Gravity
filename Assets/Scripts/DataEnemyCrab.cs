using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataControl", menuName = "ScriptableObjects/DataCrabs")]
public class DataEnemyCrab : ScriptableObject
{
    public float maxHealth;
    public float DameAttack;
    public float moveSpeed;
    public float checkNearPlayerRadius;
     public RuntimeAnimatorController animatorController;
}
