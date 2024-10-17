using UnityEngine;
using SimpleEventBus_eon;
using TMPro;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour {
    public GameObject goWinUI;
	public TextMeshProUGUI txtWinner;
	private void OnEnable() {
		SimpleEventBus.StartListening<SimpleEventBusEnum.UI_EVENTS, string>(SimpleEventBusEnum.UI_EVENTS.ON_WIN, ShowWinUI);
	}

	private void OnDisable() {
		SimpleEventBus.StopListening<SimpleEventBusEnum.UI_EVENTS, string>(SimpleEventBusEnum.UI_EVENTS.ON_WIN, ShowWinUI);
	}

	void ShowWinUI(string winningName) {
		goWinUI.SetActive(true);
		txtWinner.text = $"Winner: {winningName}";
	}

	public void RestartLevel() {
		SceneManager.LoadScene(0);
	}
	public void Quit() {
		Application.Quit();
	}
}
