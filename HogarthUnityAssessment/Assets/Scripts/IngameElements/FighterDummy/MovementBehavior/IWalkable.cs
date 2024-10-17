using System.Collections;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public interface IWalkable {
		void Initialize(NavMeshAgent agent = null, float walkingDistance = 0f, NavMeshAgent target = null);
		IEnumerator Walk() { yield return 0; }
	}
}