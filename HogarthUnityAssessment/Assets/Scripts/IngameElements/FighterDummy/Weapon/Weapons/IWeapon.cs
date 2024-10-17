using AaronTools;
using UnityEngine;

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