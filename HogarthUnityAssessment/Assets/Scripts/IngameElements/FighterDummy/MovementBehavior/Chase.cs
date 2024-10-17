using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace HogarthAssessmentTest {
	public class Chase : IWalkable {
		private NavMeshAgent _agent;
		private NavMeshAgent _target;
		#region IWalkable Implementation
		public void Initialize(NavMeshAgent agent = null, float walkingDistance = 0, NavMeshAgent target = null) {
			_agent = agent;
			_target = target;
			agent.transform.parent.GetComponent<MonoBehaviour>().StartCoroutine(Walk());
		}

		public IEnumerator Walk() {
			while (_agent != null) {
				if (Vector3.Distance(_agent.transform.position, _target.transform.position) >= 5f) {
					_agent.destination = _target.transform.position;
					yield return 0;
				} else {
					_agent.updateRotation = true;
					_agent.isStopped = true;
					yield return 0;
				}
			}
		}
		#endregion IWalkable Implementation
	}
}