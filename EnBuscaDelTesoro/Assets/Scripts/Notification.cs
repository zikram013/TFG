namespace NotificationCenter
{
    public class Notification
    {
        private readonly object m_sender;
        private readonly object m_message;

        public Notification(object p_sender, object p_message)
        {
            m_sender = p_sender;
            m_message = p_message;
        }

        public object Sender
        {
            get { return m_sender; }
        }

        public object Message
        {
            get { return m_message; }
        }
        public static Notification Empty
        {
            get
            {
                return new Notification(null,null);
            }
        }
    }
}
