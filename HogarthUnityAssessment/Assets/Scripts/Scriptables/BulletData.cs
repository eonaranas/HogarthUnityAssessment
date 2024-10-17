using UnityEngine;
using AaronTools;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData", order = 1)]
public class BulletData : ScriptableObject {
	public float bulletSpeed;
	public float damage;
	public float bulletLifeSpan;
}