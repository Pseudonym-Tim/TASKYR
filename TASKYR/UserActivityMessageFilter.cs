using System;
using System.Windows.Forms;

namespace TASKYR
{
    public class UserActivityMessageFilter : IMessageFilter
    {
        private readonly Action onUserActivity;

        public UserActivityMessageFilter(Action onUserActivity)
        {
            this.onUserActivity = onUserActivity;
        }

        public bool PreFilterMessage(ref Message m)
        {
            // Capture mouse and keyboard messages, jesus fucking christ...
            // This is extremely cursed, use a HashSet instead or something!
            if(m.Msg == 0x100 || m.Msg == 0x101 || m.Msg == 0x102 || // Keyboard messages
                m.Msg == 0x200 || m.Msg == 0x201 || m.Msg == 0x202 || // Mouse messages
                m.Msg == 0x203 || m.Msg == 0x204 || m.Msg == 0x205)
            {
                onUserActivity?.Invoke();
            }

            return false; // Allow other handlers to handle the message
        }
    }

}
