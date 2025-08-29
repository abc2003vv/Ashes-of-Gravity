using UnityEngine;
namespace ScriptableObjects.CrabEnemy
{
    [CreateAssetMenu(fileName = "CrabsEnemySO", menuName = "ScriptableObjects/CrabsEnemySO")]
    public class CrabsEnemySO : ScriptableObject
    {
        [SerializeField] private DataEnemyCrab _dataEnemyCrab;
        public DataEnemyCrab dataEnemyCrab => _dataEnemyCrab;
    }
}