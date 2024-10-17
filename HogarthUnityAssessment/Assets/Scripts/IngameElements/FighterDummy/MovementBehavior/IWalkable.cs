using System.Collections;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public interface IWalkable {
		IEnumerator Walk() { yield return 0; }
	}
}