using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class LineOfSight : MonoBehaviour {

		private Action<NavMeshAgent> onEnemyOnSight;
		private Action<NavMeshAgent> onEnemyOffSight;

		public interface IListener { 
			void OnEnemyOnSight(NavMeshAgent agent);
			void OnEnemyOffSight(NavMeshAgent agent);
		}

		#region mono
		private void OnTriggerEnter(Collider other) {
			NavMeshAgent _currentTarget = other.GetComponent<NavMeshAgent>();
			if (_currentTarget != null) {
				onEnemyOnSight?.Invoke(_currentTarget);
			}
		}

		private void OnTriggerExit(Collider other) {
			NavMeshAgent _currentTarget = other.GetComponent<NavMeshAgent>();
			if (_currentTarget != null) {
				onEnemyOffSight?.Invoke(_currentTarget);
				_currentTarget = null;
			}
		}
		#endregion mono

		#region sub/unsub
		public void Subscribe(IListener listener) {
			onEnemyOnSight += listener.OnEnemyOnSight;
			onEnemyOffSight += listener.OnEnemyOffSight;
		}
		public void Unsubscribe(IListener listener) {
			onEnemyOnSight -= listener.OnEnemyOnSight;
			onEnemyOffSight -= listener.OnEnemyOffSight;
		}
		#endregion
	}
}