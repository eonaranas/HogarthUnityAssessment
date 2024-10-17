using UnityEngine;
using AaronTools;

[CreateAssetMenu(fileName = "AIData", menuName = "ScriptableObjects/AIData", order = 1)]

public class AIData : ScriptableObject {
	[Range(1f, 10f)] public float minSpeedThinking;

	[Range(1f, 10f)] public float maxSpeedThinking;

	[Range(1f, 10f)] public float HP;
}