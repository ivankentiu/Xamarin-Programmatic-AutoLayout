using System;
using Foundation;
using CoreGraphics;
using UIKit;

namespace autolayout
{
    partial class SwipingController
    {

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);

            coordinator.AnimateAlongsideTransition((context) =>
            {
                Layout.InvalidateLayout();

                if (pageControl.CurrentPage == 0)
                {
                    CollectionView.ContentOffset = new CGPoint(0, 0);
                }
                else
                {
                    var indexPath = NSIndexPath.FromItemSection(pageControl.CurrentPage, 0);
                    CollectionView.ScrollToItem(indexPath, UICollectionViewScrollPosition.CenteredHorizontally, true);
                }
            },
            (context) => { });

        }
    }
}
