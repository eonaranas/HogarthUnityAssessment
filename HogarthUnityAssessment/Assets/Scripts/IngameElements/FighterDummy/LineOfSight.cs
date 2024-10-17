using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class LineOfSight : MonoBehaviour {
		public Action<NavMeshAgent> OnEnemyOnSight;

		private void OnTriggerEnter(Collider other) {
			NavMeshAgent targetAgent = other.GetComponent<NavMeshAgent>();
			if (targetAgent != null) {
				OnEnemyOnSight?.Invoke(targetAgent);
			}
		}
	}
}