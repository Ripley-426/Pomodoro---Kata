public class Pomodoro
{
    private int _duration;
    private bool _isStandBy = true;
    private bool _isAbleToFinish;
    private bool _isFinished;
    private bool _isInterrupted;
    private ITimer _timer;
    private bool _isNullified;
    public Pomodoro(ITimer timer,int minutes = 25)
    {
        _duration = minutes;
        _timer = timer;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public bool IsStandBy()
    {
        return _isStandBy;
    }

    public void Initiate()
    {
        _isStandBy = false;
        _isAbleToFinish = true;
    }

    public bool IsAbleToFinish()
    {
        return _isAbleToFinish;
    }

    public bool IsFinished()
    {
        return _isFinished;
    }

    public void EndTimer()
    {
        _isFinished = true;
    }

    public bool IsInterrupted()
    {
        return _isInterrupted;
    }

    public void Interrupt()
    {
        _isInterrupted = true;
        _isNullified = true;
    }

    public string GetInterruptionTime()
    {
        return _timer.GetInterruptionTimeInString();
    }

    public bool IsNullified()
    {
        return _isNullified;
    }
}
