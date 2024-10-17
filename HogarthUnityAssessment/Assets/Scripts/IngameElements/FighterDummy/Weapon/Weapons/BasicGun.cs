using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AaronTools;
using HogarthAssessmentTest;
public class BasicGun : IWeapon {

	#region IWeapon implementations
	public float AttackSpeed { get; set; }
	public float Range { get; set; }
	public ObjectPoolLibraryCommon.PoolType PoolType { get; set; }

	public void Attack(Transform turret) {
		BulletObject bullet = ObjectPoolLibraryCommon.instance.GetObjectPooler(PoolType).GiveGameObject().GetComponent<BulletObject>();
		bullet.Shooter = turret.GetComponentInParent<FighterDummy>().transform;
		bullet.transform.position = turret.position;
		bullet.transform.forward = turret.forward;
		bullet.OnBulletHit += ReturnBulletToPool;
		bullet.MoveToTarget(ReturnBulletToPool);
		void ReturnBulletToPool() {
			bullet.OnBulletHit -= ReturnBulletToPool;
			ObjectPoolLibraryCommon.instance.GetObjectPooler(PoolType).ReturnObject(bullet.gameObject);
		}
	}

	public void InitializeStats(WeaponData weaponData) {
		AttackSpeed = weaponData.attackSpeed;
		Range = weaponData.range;
		PoolType = weaponData.poolType;
	}
	#endregion
}
