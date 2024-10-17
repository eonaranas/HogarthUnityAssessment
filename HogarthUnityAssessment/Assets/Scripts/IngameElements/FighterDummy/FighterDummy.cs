using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class FighterDummy : MonoBehaviour, IDamagable {

		[SerializeField]
		private NavMeshAgent _agent;
		IWalkable _walkableBehaviour = new Search();

		IWeapon _weapon = new Gun();
		[SerializeField]
		private LineOfSight _lineOfSight;

		[SerializeField]
		public Transform _turret;

		#region mono
		private void OnEnable() => _lineOfSight.OnEnemyOnSight += OnEneymyOnSight;
		private void OnDisable() => _lineOfSight.OnEnemyOnSight -= OnEneymyOnSight;
		private void Start() => _walkableBehaviour.Initialize(_agent, 10f);
		#endregion

		#region LineOfSight Listener
		void OnEneymyOnSight(NavMeshAgent targetAgent) {
			_walkableBehaviour = new StopWalking();
			_walkableBehaviour.Initialize(_agent);

			_weapon.Attack(_turret, targetAgent);
		}
		#endregion

		#region IDamagable implementations
		public float HP { get; set; } = 10f;
		public void Die() {
			
		}
		#endregion
	}
}