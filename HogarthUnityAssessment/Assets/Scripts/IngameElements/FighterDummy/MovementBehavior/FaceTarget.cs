using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class FaceTarget : Command, IWalkable  {
		private NavMeshAgent _agent;
		private NavMeshAgent _target;

		bool _isDone = false;
		#region IWalkable Implementation
		public FaceTarget(NavMeshAgent agent = null, float walkRadius = 0f, NavMeshAgent target = null) {
			_isDone = false;
			_agent = agent;
			_agent.isStopped = true;
			_target = target;
		}

		public IEnumerator Walk() {
			Quaternion targetRotation;
			float str;
			float strength = 5f;
			float rotateTimer = 3f;
			float timer = 0f; ;
			while (timer <= rotateTimer) {
				timer += Time.deltaTime;
				targetRotation = Quaternion.LookRotation(_target.transform.position - _agent.transform.position);
				str = Mathf.Min(strength * Time.deltaTime, 1);
				_agent.transform.rotation = Quaternion.Lerp(_agent.transform.rotation, targetRotation, str);
				yield return 0;
			}
			_isDone = true;
		}
		#endregion

		#region Command implementation
		public override bool IsFinished { get => _isDone; }

		public override void Execute() {
			_agent.transform.GetComponent<MonoBehaviour>().StartCoroutine(Walk());
		}
		#endregion
	}
}