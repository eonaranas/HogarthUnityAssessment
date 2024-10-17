using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class FaceTarget : IWalkable {
		private NavMeshAgent _agent;
		private NavMeshAgent _target;
		#region IWalkable Implementation
		public void Initialize(NavMeshAgent agent, float walkingDistance = 0, NavMeshAgent target = null) {
			_agent = agent;
			_agent.isStopped = true;
			_target = target;
			agent.GetComponent<MonoBehaviour>().StartCoroutine(Walk());
		}

		public IEnumerator Walk() {
			Quaternion targetRotation;
			float str;
			float strength = 1f;
			while (_target != null) {
				targetRotation = Quaternion.LookRotation(_target.transform.position - _agent.transform.position);
				str = Mathf.Min(strength * Time.deltaTime, 1);
				_agent.transform.rotation = Quaternion.Lerp(_agent.transform.rotation, targetRotation, str);
				yield return 0;
			}
			
		}
		#endregion
	}
}