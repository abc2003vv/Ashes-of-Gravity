using UnityEngine;
using ScriptableObjects.BossMinotaur;
namespace  ScriptableObjects.BossMinotaur
{
[CreateAssetMenu(fileName = "BossSO", menuName = "ScriptableObjects/BossSO")]
public class BossSO : ScriptableObject
{
    [SerializeField] private DataBoss _dataBoss;
    public DataBoss dataBoss => _dataBoss;
} 
}