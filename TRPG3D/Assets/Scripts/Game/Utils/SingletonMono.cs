using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
  /// <summary>
  /// MonoBehaviourを継承したシングルトン
  /// </summary>
  public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
  {

    /// <summary>
    /// インスタンス
    /// </summary>
    private static volatile T instance;

    /// <summary>
    /// 同期オブジェクト
    /// </summary>
    private static object syncObj = new object();

    /// <summary>
    /// インスタンスのgetter/setter
    /// </summary>
    public static T I
    {
      get
      {
        // アプリ終了時に，再度インスタンスの呼び出しがある場合に，オブジェクトを生成することを防ぐ
        if (m_ApplicationIsQuitting)
        {
          return null;
        }
        // インスタンスがない場合に探す
        if (instance == null)
        {
          instance = FindObjectOfType<T>() as T;

          // 複数のインスタンスがあった場合
          if (FindObjectsOfType<T>().Length > 1)
          {
            return instance;
          }

          // Findで見つからなかった場合、新しくオブジェクトを生成
          if (instance == null)
          {
            // 同時にインスタンス生成を呼ばないためにlockする
            lock (syncObj)
            {
              GameObject singleton = new GameObject();
#if UNITY_EDITOR
              // シングルトンオブジェクトだと分かりやすいように名前を設定
              singleton.name = typeof(T).ToString() + " (singleton)";
#endif
              instance = singleton.AddComponent<T>();
              // シーン変更時に破棄させない
              DontDestroyOnLoad(singleton);
            }
          }

        }
        return instance;
      }
      // インスタンスをnull化するときに使うのでprivateに
      private set
      {
        instance = value;
      }
    }

    /// <summary>
    /// アプリが終了しているかどうか
    /// </summary>
    static bool m_ApplicationIsQuitting = false;

    void OnApplicationQuit()
    {
      m_ApplicationIsQuitting = true;
    }

    void OnDestroy()
    {
      instance = null;
    }

    // コンストラクタをprotectedにすることでインスタンスを生成出来なくする
    protected SingletonMono() { }
  }
}
