using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HogarthAssessmentTest {
	public interface IDamagable {
		float HP { get; set; }
		public void TakeDamage(float amount) => Mathf.Clamp(HP -= amount, 0, 10);
		void Die();
	}
}