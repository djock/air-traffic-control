using UnityEngine;

public class UIWindowButton : MonoBehaviour
{
	public enum Action
	{
		Show,
		Hide,
		GoBack,
	}

	public UIPanel window;
	public Action action = Action.Hide;
	public bool requiresFullVersion = false;
	public bool eraseHistory = false;

	void Start ()
	{
		UIPanel panel = NGUITools.FindInParents<UIPanel>(gameObject);

		if (panel != null)
		{
			UIWindow.Add(panel);
		}
	}

	void OnClick ()
	{
		if (requiresFullVersion )
		{
			UIUpgradeWindow.Show();
			return;
		}

		switch (action)
		{
			case Action.Show:
			{
				if (window != null)
				{
					if (eraseHistory) UIWindow.Close();
					UIWindow.Show(window);
				}
			}
			break;

			case Action.Hide:
			UIWindow.Close();
			break;

			case Action.GoBack:
			UIWindow.GoBack();
			break;
		}
	}
}
