using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

namespace Game
{
	/// <summary>
	/// ロビー画面
	/// </summary>
	public class LobbyManager : SingletonMono<LobbyManager>
	{
		/// <summary>
		/// インゲームのスタートボタンを押された
		/// </summary>
        public void OnClickProceedToInGameButton()
		{
			GameManager.I.ChangeState(GameState.InGame);
		}
    }
}