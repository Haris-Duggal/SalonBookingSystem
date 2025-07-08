using SalonBookingSystem.Models;

namespace SalonBookingSystem.Services
{
    public class UserStateService
    {
        public User? CurrentUser { get; private set; }

        public event Action? OnChange;

        public void SetUser(User user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void ClearUser()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
