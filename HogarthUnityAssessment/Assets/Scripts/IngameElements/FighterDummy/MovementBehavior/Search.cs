using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class Search : IWalkable {
		private NavMeshAgent _agent;
		float _walkingDistance;

		#region IWalkableImplementation

		public void Initialize(NavMeshAgent agent = null, float walkRadius = 0f, NavMeshAgent target = null) {
			_agent = agent;
			_walkingDistance = walkRadius;
			agent.transform.GetComponent<MonoBehaviour>().StartCoroutine(Walk());
		}
		public IEnumerator Walk() {
			GoToRandomPosition();
			do {
				if (_agent.remainingDistance <= 0) {
					GoToRandomPosition();
				} else {
					yield return 0;
				}
				yield return 0;
			} while (_agent != null);

			void GoToRandomPosition() => _agent.destination = Random.insideUnitSphere * _walkingDistance;
		}
		#endregion
	}
}
