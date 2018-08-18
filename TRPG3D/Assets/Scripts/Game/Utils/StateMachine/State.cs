namespace Utils.StateMachine
{

  public class State<T>
  {
    // このステートを利用するインスタンス
    protected T m_Owner;

    public State(T owner)
    {
      this.m_Owner = owner;
    }

    // このステートに遷移する時に一度だけ呼ばれる
    public virtual void Enter() { /* do nothing */ }

    // このステートである間、毎フレーム呼ばれる
    public virtual void Execute() { /* do nothing */ }

    // このステートから他のステートに遷移するときに一度だけ呼ばれる
    public virtual void Exit() { /* do nothing */ }
  }

}
