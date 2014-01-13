using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace Ex2.FacebookApp.UserControls
{
    public partial class UserViewControl : UserControl
    {
        private User m_User;

        public User User
        {
            get
            {
                return m_User;
            }

            set
            {
                if (m_User != value)
                {
                    m_User = value;
                    updateBinding();
                }
            }
        }

        public UserViewControl()
        {
            InitializeComponent();
        }

        private void linkLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (User != null && !string.IsNullOrEmpty(User.Id))
            {
                Process.Start(linkLinkLabel.Text);
            }
        }

        private void updateBinding()
        {
            if (linkLinkLabel.InvokeRequired)
            {
                linkLinkLabel.Invoke(new Action(() => userBindingSource.DataSource = User));
            }
            else
            {
                userBindingSource.DataSource = User;
            }
        }
    }
}
