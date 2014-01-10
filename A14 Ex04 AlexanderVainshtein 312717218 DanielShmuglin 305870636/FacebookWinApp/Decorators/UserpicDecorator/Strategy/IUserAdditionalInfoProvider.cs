// -----------------------------------------------------------------------
// <copyright file="IUserAdditionalInfoProvider.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Ex2.FacebookApp.Decorators.UserpicDecorator.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using FacebookWrapper.ObjectModel;

    public interface IUserAdditionalInfoProvider
    {
        void PaintAdditionalInfo(Graphics i_Graphics, User i_User);
    }
}
