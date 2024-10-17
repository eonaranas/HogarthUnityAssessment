using AaronTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public interface IBullet {
		float BulletSpeed { get; set; }
		float Damage { get; set; }
		float BulletLifeSpan {get; set; }
		void InitializeStats(BulletData bulletData);
	}
}