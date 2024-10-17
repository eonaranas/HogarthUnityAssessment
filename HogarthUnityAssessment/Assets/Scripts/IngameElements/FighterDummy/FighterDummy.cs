using SimpleEventBus_eon;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HogarthAssessmentTest {
	public class FighterDummy : MonoBehaviour, IDamagable, LineOfSight.IListener {

		[SerializeField] private NavMeshAgent _agent;

		[SerializeField] private WeaponObject _weaponObject;
		[SerializeField] private LineOfSight _lineOfSight;

		[SerializeField] public Transform _turret;

		[SerializeField] CommandControlledBot _commandCenter;

		[SerializeField] AIData _aiData;

		private NavMeshAgent _currentTarget;

		#region mono
		private void OnEnable() => _lineOfSight.Subscribe(this);
		private void OnDisable() => _lineOfSight.Unsubscribe(this);

		private void Start(){
			HP = _aiData.HP;
			StartCoroutine(AILoop());
		}
		#endregion

		#region IDamagable implementations
		public float HP { get; set; } = 10f;
		public void Die() {
			_agent.isStopped = true;
			_commandCenter.StopOperation();
			_currentTarget = null;
			StopCoroutine(AILoop());
			SimpleEventBus.TriggerEvent(SimpleEventBusEnum.GAME_EVENTS.ON_PLAYER_DIED, this);
			gameObject.transform.parent.gameObject.SetActive(false);
		}
		#endregion

		#region LineOfSight implementations
		public void OnEnemyOnSight(NavMeshAgent target) {
            if (_currentTarget == null || !_currentTarget.gameObject.activeInHierarchy) {
				_currentTarget = target;
				_commandCenter.AddCommand(new FaceTarget(agent: _agent, target: _currentTarget), true);
				_weaponObject.Weapon.Attack(_turret);
			}
		}

		public void OnEnemyOffSight(NavMeshAgent target) {
			if (_currentTarget == target) {
				_currentTarget = null;
				_weaponObject.Weapon.StopAttack();
			}
		}
		#endregion

		IEnumerator AILoop() {
			while (gameObject.activeSelf) {
				if (_currentTarget == null) {
					_commandCenter.AddCommand(new Search(_agent, 10f));

				} else {
					if (UnityEngine.Random.Range(0, 100) > 50) {
						_commandCenter.AddCommand(new StepBack(_agent), true);
					}
				}
				if (_currentTarget != null && !_currentTarget.gameObject.activeInHierarchy) {
					_currentTarget = null;
					_weaponObject.Weapon.StopAttack();
				}
				yield return new WaitForSeconds(UnityEngine.Random.Range(_aiData.minSpeedThinking, _aiData.maxSpeedThinking));
			}
		}
	}
}