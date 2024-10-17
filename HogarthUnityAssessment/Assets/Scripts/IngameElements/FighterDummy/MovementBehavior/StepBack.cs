using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class StepBack : Command, IWalkable {
		private NavMeshAgent _agent;

		bool _isDone;
		#region IWalkable Implementation
		public StepBack(NavMeshAgent agent = null, float walkRadius = 0f, NavMeshAgent target = null) {
			_isDone = false;
			_agent = agent;
			_agent.isStopped = true;
		}

		public IEnumerator Walk() {
			float stepBackTime = UnityEngine.Random.Range(1f, 2f);
			float timer = 0f;
			while (timer < stepBackTime) {
				timer += Time.deltaTime;
				_agent.transform.position += (_agent.transform.forward * -1f) * 2.5f * Time.deltaTime;
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