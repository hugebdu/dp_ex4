// -----------------------------------------------------------------------
// <copyright file="OnlineStatusProvider.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex2.FacebookApp.Decorators.UserpicDecorator.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using FacebookWrapper.ObjectModel;

    public class OnlineStatusProvider : IUserAdditionalInfoProvider
    {
        private readonly Color m_ActiveColor = Color.FromArgb(165, 250, 115);
        private readonly Color m_IdleColor = Color.Brown;
        private readonly Color m_OfflineColor = Color.Gray;
        private readonly Color m_UnknownColor = Color.Silver;
        
        public void PaintAdditionalInfo(Graphics i_Graphics, User i_User)
        {
            if (i_User == null)
            {
                return;
            }

            var onlineStatus = i_User.OnlineStatus;
            
            // DEMO Logic - use random online status as the user's OnlineStatus property is not being updated
            onlineStatus = getDemoOnlineStatus();

            Color color;
            if (onlineStatus.HasValue)
            {
                switch (onlineStatus.Value)
                {
                    case User.eOnlineStatus.active:
                        color = m_ActiveColor;
                        break;
                    case User.eOnlineStatus.idle:
                        color = m_IdleColor;
                        break;
                    case User.eOnlineStatus.offline:
                        color = m_OfflineColor;
                        break;
                    case User.eOnlineStatus.unknown:
                        color = m_UnknownColor;
                        break;
                    default:
                        color = m_UnknownColor;
                        break;
                }
            }
            else
            {
                color = m_UnknownColor;
            }

            using (Brush brush = new SolidBrush(color))
            {
                i_Graphics.FillEllipse(brush, new Rectangle(new Point(1, 1), new Size(10, 10)));
                i_Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(new Point(1, 1), new Size(10, 10)));
            }
        }

        private User.eOnlineStatus? getDemoOnlineStatus()
        {
            var number = DateTime.Now.Millisecond;
            if (number % 4 == 0)
            {
                return User.eOnlineStatus.active;
            }
            else if (number % 4 == 1)
            {
                return User.eOnlineStatus.offline;
            }
            else if (number % 4 == 2)
            {
                return User.eOnlineStatus.idle;
            }
            else 
            {
                return User.eOnlineStatus.unknown;
            }
        }
    }
}
