using UnityEngine;

/// <summary>
/// This class makes it easy to find and show a window that prompts the player to upgrade to the full version of the game.
/// </summary>

public class UIUpgradeWindow : MonoBehaviour
{
	/// <summary>
	/// Reference to the panel that acts as the upgrade window.
	/// </summary>

	public UIPanel panel;

	static UIPanel mPanel;

	void Awake () { mPanel = panel; }
	void OnDestroy () { mPanel = null; }

	static public void Show () { if (mPanel != null) UIWindow.Show(mPanel); }
	static public void Hide () { if (mPanel != null) UIWindow.Hide(mPanel); }
}
