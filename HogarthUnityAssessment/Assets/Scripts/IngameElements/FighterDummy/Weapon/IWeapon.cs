using AaronTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IWeapon {
	float AttackSpeed { get;set; }
	float Damage {get;set;}
	void Attack(Transform turret, NavMeshAgent target, ObjectPoolLibraryCommon.PoolType poolType = ObjectPoolLibraryCommon.PoolType.BULLET);

}
