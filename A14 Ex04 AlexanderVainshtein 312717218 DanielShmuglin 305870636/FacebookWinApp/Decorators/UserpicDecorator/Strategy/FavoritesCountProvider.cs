// -----------------------------------------------------------------------
// <copyright file="FavoritesCountProvider.cs" company="">
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
    using Ex2.FacebookApp.Model;

    public class FavoritesCountProvider : IUserAdditionalInfoProvider
    {
        public FavoritesManager FavoritesManager { get; set; }

        public void PaintAdditionalInfo(Graphics i_Graphics, User i_User)
        {
            if (i_User == null || FavoritesManager == null)
            {
                return;
            }

            var numberOfFavoritePosts = FavoritesManager.GetFavoritePosts().Count(post => post.From != null && post.From.Id == i_User.Id);

            i_Graphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(new Point(0, 0), new Size(20, 20)));
            i_Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(new Point(0, 0), new Size(20, 20)));
            i_Graphics.DrawString(numberOfFavoritePosts.ToString(), new Font("Arial", 8, FontStyle.Bold), System.Drawing.Brushes.DarkBlue, new Point(2, 3));
        }
    }
}
