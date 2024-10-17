using HogarthAssessmentTest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AaronTools;
public class BulletObject : MonoBehaviour {

	public Action OnBulletHit;
	[SerializeField] private BulletData bulletData;
	IBullet _bullet;

	public Transform Shooter { private get; set; }
	#region mono
	private void Awake() {
		_bullet = new BasicBullet();
		_bullet.InitializeStats(bulletData);
	}
	private void OnTriggerEnter(Collider other) {
		FighterDummy fighterDummy = other.GetComponent<FighterDummy>();
		if (fighterDummy is IDamagable damageable && Shooter != fighterDummy.transform) {
			damageable.TakeDamage(_bullet.Damage);
			OnBulletHit?.Invoke();
			Debug.Log(fighterDummy.ToString() + " take damage: " + _bullet.Damage);
		}
	}
	#endregion

	public void MoveToTarget(Action onDone = null) {
		StartCoroutine(Move(onDone));
	}

	IEnumerator Move(Action onDone = null) {
		Debug.Log(gameObject.name + " Speed: " + _bullet.BulletSpeed);
		float currentTimer = 0f;
		while (currentTimer < _bullet.BulletLifeSpan) {
			currentTimer += Time.deltaTime;
			yield return 0;
			transform.position += transform.forward * _bullet.BulletSpeed * Time.deltaTime;
		}
		onDone?.Invoke();
	}
}