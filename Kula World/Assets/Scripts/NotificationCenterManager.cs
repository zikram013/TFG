using System;
using System.Collections;
using System.Collections.Generic;

namespace NotificationCenter
{
    public class NotificationCenterManager
    {
        private static NotificationCenterManager m_instance;
        private readonly Hashtable m_hashtable;

        private NotificationCenterManager()
        {
            m_hashtable=new Hashtable();
        }
        /// <summary>
        /// Singelton Instance
        /// </summary>
        public static NotificationCenterManager Instance
        {
            get { return m_instance ?? (m_instance = new NotificationCenterManager()); }
        }
        /// <summary>
        /// Adds an entry to the receiver’s dispatch table with an observer, a notification Delegate and notification name.
        /// </summary>
        /// <param name="p_notificationDelegate">Delegate  that specifies the message the receiver sends notificationObserver to notify it of the notification posting</param>
        /// <param name="p_notificationName">The name of the notification for which to register the observer; that is, only notifications with this name are delivered to the observer</param>
        public void AddObserver(NotificationDelegate p_notificationDelegate, string p_notificationName)
        {
            if (string.IsNullOrEmpty(p_notificationName))
            {
                throw new ArgumentNullException(@"p_notificationDelegate");

            }
            if ( p_notificationDelegate==null)
            {
                throw new ArgumentNullException("p_notificationDelegate");
                
            }
            var delegatesCollection = (List<NotificationDelegate>)m_hashtable[p_notificationName];
            if(delegatesCollection==null)
            {
                delegatesCollection=new List<NotificationDelegate> ();
                m_hashtable.Add(p_notificationName, delegatesCollection);
            }
           delegatesCollection.Add(p_notificationDelegate);
    
        }
        /// <summary>
        /// Removes matching entries from the receiver’s dispatch table.
        /// </summary>
        /// <param name="p_notificationDelegate">Delegate  that specifies the message the receiver sends notificationObserver to notify it of the notification posting</param>
        /// <param name="p_notificationName">The name of the notification for which to register the observer; that is, only notifications with this name are delivered to the observer</param>
        public void RemoveObserver(NotificationDelegate p_notificationDelegate, string p_notificationName)
        {
            if (string.IsNullOrEmpty(p_notificationName))
            {
                throw new ArgumentNullException(@"p_notificationName");

            }
            if (p_notificationDelegate == null)
            {
                throw new ArgumentNullException("p_notificationDelegate");

            }
            var delegatesCollection = (List<NotificationDelegate>)m_hashtable[p_notificationName];
            if (delegatesCollection!=null)
            {
                delegatesCollection.Remove(p_notificationDelegate);
            }
        }
        /// <summary>
        /// Creates a notification with a given name and sender and posts it to the receiver.
        /// </summary>
        /// <param name="p_notificationName">The name of the notification for which to register the observer; that is, only notifications with this name are delivered to the observer.</param>
        /// <param name="p_notification">The notification includinf the sender and a message.</param>
        public void PostNotification(string p_notificationName, Notification p_notification)
        {
            if (string.IsNullOrEmpty(p_notificationName))
            {
                throw new ArgumentNullException(@"p_notificationName");

            }
            if (p_notification == null)
            {
                throw new ArgumentNullException("p_notification");

            }
            var delegatesCollection = (List<NotificationDelegate>)m_hashtable[p_notificationName];
            if (delegatesCollection != null)
            {
                foreach (var notificationDelegate in delegatesCollection)
                {
                    notificationDelegate(p_notification);
                }

            }

        }
        /// <summary>
        /// Creates a notification with a given name and sender and posts it to the receiver with Empty notification.
        /// </summary>
        /// <param name="p_notificationName">The name of the notification for which to register the observer; that is, only notifications with this name are delivered to the observer.</param>
        public void PostNotification(string p_notificationName)
        {
            if (string.IsNullOrEmpty(p_notificationName))
            {
                throw new ArgumentNullException(@"p_notificationName");

            }
            
            var delegatesCollection = (List<NotificationDelegate>)m_hashtable[p_notificationName];
            if (delegatesCollection != null)
            {
                foreach (var notificationDelegate in delegatesCollection)
                {
                    try
                    {
                        notificationDelegate(Notification.Empty);
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Error fire Notification.");
                    }
                   
                }

            }

        }

        public delegate void NotificationDelegate(Notification p_notification);
    }
}
