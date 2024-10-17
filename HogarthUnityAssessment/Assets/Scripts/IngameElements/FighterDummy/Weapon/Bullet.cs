using HogarthAssessmentTest;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AaronTools;
public class Bullet : MonoBehaviour {
	
	public Action<IDamagable> OnBulletHit;
	public interface IListener { 
		void OnBulletHit(IDamagable damagable);
	}
	
	private void OnTriggerEnter(Collider other) {
		FighterDummy fighterDummy = other.GetComponent<FighterDummy>();
		if (fighterDummy != null) {
			OnBulletHit?.Invoke((IDamagable)fighterDummy);
		}
	}

	public void Subscribe(IListener listener) {
		OnBulletHit += listener.OnBulletHit;
	}

	public void UnSubscribe(IListener listener) {
		OnBulletHit -= listener.OnBulletHit;
	}
}
