// -----------------------------------------------------------------------
// <copyright file="UserPictureBox.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex2.FacebookApp.Decorators.UserpicDecorator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Drawing;
    using System.Windows.Forms;
    using FacebookWrapper.ObjectModel;
    using Ex2.FacebookApp.Decorators.UserpicDecorator.Strategy;

    class UserPictureBox : PictureBox
    {
        public IUserAdditionalInfoProvider AdditionalInfoProvider { get; set; }

        private User m_User;

        public User User
        {
            get
            {
                return m_User;
            }

            set
            {
                if (value != m_User)
                {
                    m_User = value;
                    Utils.UpdateImage(this, m_User == null ? null : m_User.ImageNormal);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (AdditionalInfoProvider != null)
            {
                AdditionalInfoProvider.PaintAdditionalInfo(pe.Graphics, m_User);
            }
        }
    }
}
