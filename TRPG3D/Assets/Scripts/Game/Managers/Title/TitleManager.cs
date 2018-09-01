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
        public void OnClickMakeRoomButton()
		{

		}

		public void OnClickEnterRoomButton()
		{
			
		}

		public void OnClickTestButton()
		{
			GameManager.I.ChangeState(GameState.TestNetwork);
		}
    }
}