using UnityEngine;
public class DataEnemyCrab
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _ameAttack;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _checkNearPlayerRadius;
    [SerializeField] private RuntimeAnimatorController _animatorController;

    public float MaxHealth => _maxHealth;
    public float DameAttack => _ameAttack;
    public float MoveSpeed => _moveSpeed;
    public float CheckNearPlayerRadius => _checkNearPlayerRadius;
    public RuntimeAnimatorController AnimatorController => _animatorController;
}
