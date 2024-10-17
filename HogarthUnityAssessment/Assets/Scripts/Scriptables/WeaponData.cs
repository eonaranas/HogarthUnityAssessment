using AaronTools;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject {
	[Range(0.1f, 10f)]
	public float attackSpeed;

	[Range(10f, 100f)]
	public float range;

	public ObjectPoolLibraryCommon.PoolType poolType;
}