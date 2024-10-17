using AaronTools;
using HogarthAssessmentTest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : IBullet {

	#region IBullet implementations
	public float BulletSpeed { get; set; }
	public float Damage { get; set; }
	public float BulletLifeSpan { get; set; }

	public void InitializeStats(BulletData bulletData) {
		BulletSpeed = bulletData.bulletSpeed;
		Damage = bulletData.damage;
		BulletLifeSpan = bulletData.bulletLifeSpan;
	}
	#endregion
}
