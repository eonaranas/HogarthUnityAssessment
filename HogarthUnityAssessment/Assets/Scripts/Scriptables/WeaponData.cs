using AaronTools;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject {
	public float attackSpeed;
	public float range;
	public ObjectPoolLibraryCommon.PoolType poolType;
}