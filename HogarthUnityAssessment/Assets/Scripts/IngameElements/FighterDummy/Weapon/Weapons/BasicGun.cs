using System.Collections;
using UnityEngine;
using AaronTools;
using HogarthAssessmentTest;
using UnityEngine.UIElements;
public class BasicGun : IWeapon {

	#region IWeapon implementations
	public float AttackSpeed { get; set; }
	public float Range { get; set; }
	public ObjectPoolLibraryCommon.PoolType PoolType { get; set; }

	bool _doAttack;
	public void Attack(Transform turret) {
		_doAttack = true;
		turret.GetComponentInParent<FighterDummy>().StartCoroutine(LoopAttack(turret));
	}

	void SpawnBullets(Transform turret) {
		BulletObject bullet = ObjectPoolLibraryCommon.instance.GetObjectPooler(PoolType).GiveGameObject().GetComponent<BulletObject>();
		bullet.Shooter = turret.GetComponentInParent<FighterDummy>().transform;
		bullet.transform.position = turret.position;
		bullet.transform.forward = turret.forward;
		bullet.OnBulletHit += ReturnBulletToPool;
		bullet.MoveToTarget(Range, ReturnBulletToPool);
		void ReturnBulletToPool() {
			bullet.OnBulletHit -= ReturnBulletToPool;
			ObjectPoolLibraryCommon.instance.GetObjectPooler(PoolType).ReturnObject(bullet.gameObject);
		}
	}

	IEnumerator LoopAttack(Transform turret) {
		while (_doAttack) {
			SpawnBullets(turret);
			yield return new WaitForSeconds(AttackSpeed);
		}
	}

	public void StopAttack() {
		_doAttack = false;
	}

	public void InitializeStats(WeaponData weaponData) {
		AttackSpeed = weaponData.attackSpeed;
		Range = weaponData.range;
		PoolType = weaponData.poolType;
	}
	#endregion
}
