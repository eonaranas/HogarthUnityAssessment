using UnityEngine;
using AaronTools;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
public class BulletData : ScriptableObject {
	[Range(3f, 100f)]
	public float bulletSpeed;

	public float damage;

	[Range(3f, 10f)]
	public float bulletLifeSpan;
}