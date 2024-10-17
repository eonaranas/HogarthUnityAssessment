using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class Search : Command, IWalkable {
		private NavMeshAgent _agent;
		float _walkingDistance;

		#region IWalkableImplementation

		public Search(NavMeshAgent agent = null, float walkRadius = 0f, NavMeshAgent target = null) {
			_agent = agent;
			_walkingDistance = walkRadius;
			_agent.isStopped = false;
		}
		public IEnumerator Walk() {
			_agent.destination = Random.insideUnitSphere * _walkingDistance;
			yield return 0;
		}
		#endregion

		#region Command implementation
		public override bool IsFinished { get => _agent.remainingDistance <= 0.5f; }

		public override void Execute() {
			_agent.transform.GetComponent<MonoBehaviour>().StartCoroutine(Walk());
		}
		#endregion
	}
}
