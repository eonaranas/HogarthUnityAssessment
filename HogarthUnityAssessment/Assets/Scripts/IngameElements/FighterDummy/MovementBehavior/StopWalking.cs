using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class StopWalking : IWalkable {
		private NavMeshAgent _agent;

		#region IWalkable Implementation
		public void Initialize(NavMeshAgent agent, float walkingDistance = 0, NavMeshAgent target = null) {
			_agent = agent;
			_agent.isStopped = true;
		}
		#endregion
	}
}