using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

namespace Net
{
    public class MatchMaker : MonoBehaviour
    {
        [SerializeField]
        private string m_TitleSceneName;

        [SerializeField]
        private Text m_Text;

        public void Start()
        {
            NetworkManager.singleton.StartMatchMaker();
            FindInternetMatch("");
        }

#region マッチ作成
        public void CreateInternetMatch()
        {
            m_Text.text = "Create Match...";

            var matchName = "";
            uint matchSize = 5;                //マッチのプレイヤーの最大人数
            var matchAdvertise = true;         //NetworkMatch.ListMatchesで帰ってくるList<MatchInfoSnapshot>に、このマッチを含めるかどうか
            var matchPassword = "";            //マッチのパスワード
            var publicClientAddress = "";      //クライアントがインターネット経由で直接接続するためのネットワークアドレス
            var privateClientAddress = "";     //クライアントが LAN 経由で直接接続するためのネットワークアドレス
            var eloScoreForMatch = 0;          //いわゆるスキルレート。全クライアントが0だとランダムになる
            var requestDomain = 0;             //クライアントバージョンを区別するための番号

            NetworkManager.singleton.matchMaker.CreateMatch(matchName, matchSize, matchAdvertise, matchPassword, publicClientAddress, privateClientAddress, eloScoreForMatch, requestDomain, OnInternetMatchCreate);
        }

        private void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                MatchInfo hostInfo = matchInfo;
                NetworkServer.Listen(hostInfo, 9000);

                NetworkManager.singleton.StartHost(hostInfo);
            }
            else
            {
                m_Text.text = "Create match failed";
                // SceneManager.LoadScene(m_TitleSceneName);
            }
        }
#endregion

        public void FindInternetMatch(string matchName)
        {
            var startPageNumber = 0;                         //リストし始めるページ
            var resultPageSize = 10;                         //callbackに渡すリストのマッチの最大数
            var matchNameFilter = matchName;                 //*<matchNameFilter>*に該当するマッチが検索される
            var filterOutPrivateMatchesFromResults = true;   //プライベートマッチを検索結果に含めるかどうか
            var eloScoreTarget = 0;                          //検索するときのスキルレート
            var requestDomain = 0;                           //クライアントバージョンを区別するための番号

            m_Text.text = "Searching Match...";

            NetworkManager.singleton.matchMaker.ListMatches(startPageNumber, resultPageSize, matchNameFilter, filterOutPrivateMatchesFromResults, eloScoreTarget, requestDomain, OnJoinInternetMatch);
        }

        private void OnJoinInternetMatch(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
        {
            if (success)
            {
                if (matches.Count == 0)
                {
                    CreateInternetMatch();
                }
                else
                {
                    m_Text.text = "Join Match";
                    var earliestCreatedMatch = matches.Find(v => v.currentSize != v.maxSize);
                    NetworkManager.singleton.matchMaker.JoinMatch(earliestCreatedMatch.networkId, "", "", "", 0, 0, OnConnectMatch);
                }
            }
            else
            {
                m_Text.text = "Couldn't connect to match maker";
                // SceneManager.LoadScene(m_TitleSceneName);
            }
        }

        private void OnConnectMatch(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                MatchInfo hostInfo = matchInfo;
                NetworkManager.singleton.StartClient(hostInfo);
            }
            else
            {
                CreateInternetMatch();
            }
        }


        private void OnDestroy()
        {

        }
    }
}