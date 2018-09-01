using UnityEngine;

namespace Utils.StateMachine
{

  public class StateMachine<T>
  {
    private State<T> m_CurrentState;

    public StateMachine() { m_CurrentState = null; }

    public State<T> CurrentState
    {
      get { return m_CurrentState; }
    }

    public void ChangeState(State<T> state, object parameter)
    {
      if (m_CurrentState != null) { m_CurrentState.Exit(); }
      m_CurrentState = state;
      bool isValidParam = m_CurrentState.SetParameter(parameter);

      if (isValidParam)
      {
        m_CurrentState.Enter();
      }
      else
      {
#if UNITY_EDITOR
        Debug.LogErrorFormat("[StateMachine] 異なるParameterをセットしようとしています。 遷移先ステート: {0}, Paraneter： {1}", state, parameter);
#endif
      }
    }

    public void Update()
    {
      if (m_CurrentState != null) { m_CurrentState.Execute(); }
    }
  }

}
