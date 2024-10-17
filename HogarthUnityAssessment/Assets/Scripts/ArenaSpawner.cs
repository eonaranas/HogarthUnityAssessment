using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpawner : MonoBehaviour {

    [SerializeField][Range(2f, 100f)] private int _fighterCount;
    public GameObject _fighterPrefab;

	public GameObject[] instantiationPoints;

	private void Start() {
		StartCoroutine(InstantiateWarriors());
	}

	IEnumerator InstantiateWarriors() {
		int instantiatedCount = 0;
		while (instantiatedCount < _fighterCount) {
			GameObject go = Instantiate(_fighterPrefab);
			go.transform.SetParent(transform, true);
			go.transform.position = instantiationPoints[UnityEngine.Random.Range(0, instantiationPoints.Length)].transform.position;
			instantiatedCount++;
			go.name = "Fighter " + instantiatedCount;
			yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 1.5f));
		}
	}
}
