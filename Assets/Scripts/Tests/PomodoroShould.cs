using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class PomodoroShould
    {
        private Pomodoro _pomodoro;
        private ITimer _timer;

        [SetUp]
        public void Setup()
        {
            _timer = Substitute.For<ITimer>();
            _pomodoro = new Pomodoro(_timer);
        }

        [Test]
        public void HaveADefaultTimeAtCreation()
        {
            Assert.AreEqual(25, _pomodoro.GetDuration());
        }

        [Test]
        [TestCase(13)]
        [TestCase(22)]
        public void BeAbleToDefineDurationAtCreation(int minutes)
        {
            _pomodoro = new Pomodoro(_timer, minutes);
            
            Assert.AreEqual(minutes, _pomodoro.GetDuration());
        }

        [Test]
        public void StartInStandBy()
        {
            Assert.IsTrue(_pomodoro.IsStandBy());
        }

        [Test]
        public void StartCountingDownWhenInitiated()
        {
            _pomodoro.Initiate();
            Assert.IsFalse(_pomodoro.IsStandBy());
        }

        [Test]
        public void NotBeAbleToFinishIfItWasNotInitiated()
        {
            Assert.IsFalse(_pomodoro.IsAbleToFinish());
        }

        [Test]
        public void BeAbleToFinishWhenInitiated()
        {
            _pomodoro.Initiate();
            Assert.IsTrue(_pomodoro.IsAbleToFinish());
        }

        [Test]
        public void FinishWhenTimeIsOver()
        {
            _pomodoro.EndTimer();
            Assert.IsTrue(_pomodoro.IsFinished());
        }
        
        [Test]
        public void NotStartAsInterrupted()
        {
            Assert.IsFalse(_pomodoro.IsInterrupted());
        }

        [Test]
        public void BeInterruptible()
        {
            _pomodoro.Interrupt();
            Assert.IsTrue(_pomodoro.IsInterrupted());
        }

        [Test]
        public void BeAbleToShowInterruptionTime()
        {
            _pomodoro.Interrupt();
            _timer.GetInterruptionTimeInString().Returns("01:03");
            Assert.AreEqual("01:03", _pomodoro.GetInterruptionTime());
        }

        [Test]
        public void NotBeNullifiedAtStart()
        {
            Assert.IsFalse(_pomodoro.IsNullified());
        }

        [Test]
        public void BeNullifiedIfInterrupted()
        {
            _pomodoro.Interrupt();
            Assert.IsTrue(_pomodoro.IsNullified());
        }
    }
}
