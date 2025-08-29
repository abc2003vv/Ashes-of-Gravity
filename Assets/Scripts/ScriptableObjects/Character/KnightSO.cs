using ScriptableObjects.Character;
using UnityEngine;
namespace ScriptableObjects.Knight
{
    [CreateAssetMenu(fileName = "KnightSO", menuName = "ScriptableObjects/KnightSO")]
    public class KnightSO : ScriptableObject
    {
        [SerializeField] private DataKnight _KnightSO;
        public DataKnight dataKnight => _KnightSO;
    }
}