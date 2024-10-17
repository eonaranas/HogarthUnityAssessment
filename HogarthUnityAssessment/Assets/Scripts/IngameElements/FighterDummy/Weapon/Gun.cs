using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AaronTools;
using HogarthAssessmentTest;
public class Gun : IWeapon, Bullet.IListener {
	#region IWeapon implementations
	public float AttackSpeed { get; set; }
	public float Damage { get; set; }

	public void Attack(Transform turret, NavMeshAgent target, ObjectPoolLibraryCommon.PoolType poolType = ObjectPoolLibraryCommon.PoolType.BULLET) {
		Bullet bullet = ObjectPoolLibraryCommon.instance.GetObjectPooler(poolType).GiveGameObject().GetComponent<Bullet>();
		bullet.Subscribe(this);
		LeanTween.move(bullet.gameObject, target.transform.position, 5f * Time.deltaTime).setOnComplete(
			() => {
				ObjectPoolLibraryCommon.instance.GetObjectPooler(poolType).ReturnObject(bullet.gameObject);
				bullet.UnSubscribe(this);
			}
		);
	}
	#endregion

	#region Bullet.IListener implementations
	public void OnBulletHit(IDamagable damagable) {
		damagable.TakeDamage(Damage);
	}
	#endregion
}
