using AaronTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public interface IWeapon {
		float AttackSpeed { get; set; }
		float Range { get; set; }
		ObjectPoolLibraryCommon.PoolType PoolType { get; set; }
		void Attack(Transform turret);
		void StopAttack();
		void InitializeStats(WeaponData weaponData);
	}
}