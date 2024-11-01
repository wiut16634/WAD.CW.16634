using WAD.CW._16634.Models;

namespace WAD.CW._16634.Repositories
{
    public interface IOptionObserver
    {
        // 16634 Initalizing Observer Design Pattern for validating the options and trigger to duplicate
        void ValidateOption(Option option);
    }
}
