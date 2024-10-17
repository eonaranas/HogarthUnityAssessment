using HogarthAssessmentTest;
using SimpleEventBus_eon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpawner : MonoBehaviour {

    [SerializeField][Range(2f, 100f)] private int _fighterCount;
    public GameObject _fighterPrefab;

	[SerializeField] private GameObject[] _instantiationPoints;

	private List<FighterDummy> _fighterDummies = new List<FighterDummy>();

	#region
	private void OnEnable() {
		SimpleEventBus.StartListening<SimpleEventBusEnum.GAME_EVENTS, FighterDummy>(SimpleEventBusEnum.GAME_EVENTS.ON_PLAYER_DIED, OnFighterDie);
	}

	private void OnDisable() {
		SimpleEventBus.StopListening<SimpleEventBusEnum.GAME_EVENTS, FighterDummy>(SimpleEventBusEnum.GAME_EVENTS.ON_PLAYER_DIED, OnFighterDie);
	}
	private void Start() {
		StartCoroutine(InstantiateWarriors());
	}
	#endregion

	IEnumerator InstantiateWarriors() {
		int instantiatedCount = 0;
		while (instantiatedCount < _fighterCount) {
			GameObject go = Instantiate(_fighterPrefab);
			go.transform.SetParent(transform, true);
			go.transform.position = FixedOverLapSpawnPoints(_instantiationPoints[UnityEngine.Random.Range(0, _instantiationPoints.Length)].transform.position);
			_fighterDummies.Add(go.GetComponentInChildren<FighterDummy>());
			instantiatedCount++;
			go.name = "Fighter " + instantiatedCount;
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));
		}
	}

	private Vector3 FixedOverLapSpawnPoints(Vector3 defPos) {
		Vector3 pos = defPos;
		pos.x += UnityEngine.Random.Range(-3f, 3f);
		pos.y += UnityEngine.Random.Range(-3f, 3f);
		return pos;
	}

	void OnFighterDie(FighterDummy fighterDummy) { 
		_fighterDummies.Remove(fighterDummy);
		if (_fighterDummies.Count == 1) {
			SimpleEventBus.TriggerEvent(SimpleEventBusEnum.UI_EVENTS.ON_WIN, _fighterDummies[0].transform.parent.gameObject.name);
		}
	}
}
