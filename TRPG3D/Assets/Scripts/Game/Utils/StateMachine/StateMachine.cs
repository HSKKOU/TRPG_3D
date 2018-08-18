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

    public void ChangeState(State<T> state)
    {
      if (m_CurrentState != null) { m_CurrentState.Exit(); }
      m_CurrentState = state;
      m_CurrentState.Enter();
    }

    public void Update()
    {
      if (m_CurrentState != null) { m_CurrentState.Execute(); }
    }
  }

}
