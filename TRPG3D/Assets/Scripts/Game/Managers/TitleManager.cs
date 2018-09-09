using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utils;

namespace Game
{
	/// <summary>
	/// タイトル画面
	/// </summary>
	public class TitleManager : SingletonMono<TitleManager>
	{

#region 定数定義

		/// <summary>
		/// 部屋作成中メッセージ
		/// </summary>
		private const string MAKE_ROOM_TEXT = "ルーム作成中...";

		/// <summary>
		/// マッチメイキング中メッセージ
		/// </summary>
		private const string MATCHING_TEXT = "マッチング中...";

#endregion // 定数定義

		/// <summary>
		/// ロードテキスト
		/// </summary>
		[SerializeField]
		private Text m_LoadingText;

		/// <summary>
		/// ルーム作成情報を入力
		/// </summary>
		[SerializeField]
		private UIRoomInoutLightbox m_MakeRoomInfoInput;

		/// <summary>
		/// ルーム入場情報を入力
		/// </summary>
		[SerializeField]
		private UIRoomInoutLightbox m_EnterRoomInfoInput;



#region MonoBehaviour Message

		private void Awake()
		{
			m_MakeRoomInfoInput.onRequestRoomInfoEvent += MakeRoom;
			m_MakeRoomInfoInput.onCancelEvent += CloseMakeRoomInfoInput;
			m_EnterRoomInfoInput.onRequestRoomInfoEvent += EnterRoom;
			m_EnterRoomInfoInput.onCancelEvent += CloseEnterRoomInfoInput;
		}

		private void Start()
		{
			UIManager.I.onClickFilterEvent += CloseMakeRoomInfoInput;
			UIManager.I.onClickFilterEvent += CloseEnterRoomInfoInput;
		}

		private void OnDestroy()
		{
			m_MakeRoomInfoInput.onRequestRoomInfoEvent -= MakeRoom;
			m_MakeRoomInfoInput.onCancelEvent -= CloseMakeRoomInfoInput;
			m_EnterRoomInfoInput.onRequestRoomInfoEvent -= EnterRoom;
			m_EnterRoomInfoInput.onCancelEvent -= CloseEnterRoomInfoInput;

			if (UIManager.IsValid())
			{
				UIManager.I.onClickFilterEvent -= CloseMakeRoomInfoInput;
				UIManager.I.onClickFilterEvent -= CloseEnterRoomInfoInput;
			}
		}

#endregion // MonoBehaviour Message


#region マッチマイカー

		/// <summary>
		/// ルーム作成
		/// </summary>
		private void MakeRoom(UIRoomInoutLightbox.RoomInfo info)
		{
			m_LoadingText.text = MAKE_ROOM_TEXT;
		}

		/// <summary>
		/// ルーム入場
		/// </summary>
		private void EnterRoom(UIRoomInoutLightbox.RoomInfo info)
		{
			m_LoadingText.text = MATCHING_TEXT;
		}

#endregion // マッチマイカー


#region UI

		/// <summary>
		/// ルームを作成するボタンを押された
		/// </summary>
		public void OnClickMakeRoomButton()
		{
			UIManager.I.ShowFilter(true);
			m_MakeRoomInfoInput.gameObject.SetActive(true);
		}

		/// <summary>
		/// ルームに入るボタンを押された
		/// </summary>
		public void OnClickEnterRoomButton()
		{
			UIManager.I.ShowFilter(true);
			m_EnterRoomInfoInput.gameObject.SetActive(true);
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


		/// <summary>
		/// ルーム作成画面を閉じる
		/// </summary>
		private void CloseMakeRoomInfoInput()
		{
			m_MakeRoomInfoInput.gameObject.SetActive(false);
			UIManager.I.HideFilter();
		}

		/// <summary>
		/// ルーム入場画面を閉じる
		/// </summary>
		private void CloseEnterRoomInfoInput()
		{
			m_EnterRoomInfoInput.gameObject.SetActive(false);
			UIManager.I.HideFilter();
		}

#endregion // UI
    }
}