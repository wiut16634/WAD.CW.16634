using WAD.CW._16634.Repositories;

namespace WAD.CW._16634.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
        // 16634 Implemnting Observer

        private readonly List<IOptionObserver> _observers = new List<IOptionObserver>();

        public void Attach(IOptionObserver observer) => _observers.Add(observer);
        public void Detach(IOptionObserver observer) => _observers.Remove(observer);

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.ValidateOption(this);
            }
        }

        public void UpdateTitle(string newTitle)
        {
            OptionText = newTitle;
            Notify(); // Notify observers for validation
        }
    }
}
