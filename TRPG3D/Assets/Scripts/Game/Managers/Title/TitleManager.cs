using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

namespace Game
{
	/// <summary>
	/// タイトル画面
	/// </summary>
	public class TitleManager : SingletonMono<TitleManager>
	{
		/// <summary>
		/// マッチルームを作成するボタンを押された
		/// </summary>
        public void OnClickMakeRoomButton()
		{
			GameManager.I.ChangeState(GameState.Lobby, new GameManager.GameStateLobbyParam(true));
		}

		/// <summary>
		/// マッチルームを探して入るボタンを押された
		/// </summary>
		public void OnClickEnterRoomButton()
		{
			GameManager.I.ChangeState(GameState.Lobby, new GameManager.GameStateLobbyParam(false));
		}

		/// <summary>
		/// フィールドを作るボタンを押された
		/// </summary>
		public void OnClickCreateFieldButton()
		{
			GameManager.I.ChangeState(GameState.CreateField);
		}

		/// <summary>
		/// ネットワークテストを開く
		/// </summary>
		public void OnClickTestButton()
		{
			GameManager.I.ChangeState(GameState.TestNetwork);
		}
    }
}