using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils.StateMachine
{

  /// <summary>
  /// StateMachineを実装するクラスの基底クラス
  /// </summary>
  public abstract class AStatefulObject<T, TEnum> : MonoBehaviour where T : class where TEnum : System.IConvertible
  {

    /// <summary>
    /// 所持しているStateのList
    /// </summary>
    protected List<State<T>> m_StateList = new List<State<T>>();

    protected StateMachine<T> m_StateMachine;

    /// <summary>
    /// 現在のState
    /// </summary>
    [SerializeField]
    protected TEnum m_CurrentState;

    /// <summary>
    /// Stateの切り替え
    /// </summary>
    public virtual void ChangeState(TEnum state)
    {
      if (m_StateMachine == null) { return; }
      m_CurrentState = state;
      //Debug.Log ("Change State to " + currentState.ToString() + ": " + typeof(T).ToString());
      m_StateMachine.ChangeState(m_StateList[state.ToInt32(null)]);
    }

    /// <summary>
    /// 現在のStateの確認
    /// </summary>
    public virtual bool IsCurrentState(TEnum state)
    {
      if (m_StateMachine == null) { return false; }
      return m_StateMachine.CurrentState == m_StateList[state.ToInt32(null)];
    }

    protected virtual void Update()
    {
      if (m_StateMachine != null)
      {
        m_StateMachine.Update();
      }
    }


    /// <summary>
    /// StateMachineを積んだclassは必ずInitializeメソッドを実装する。
    /// </summary>
    public virtual void Initialize()
    {
      this.m_StateMachine = new StateMachine<T>();
    }
  }
}
