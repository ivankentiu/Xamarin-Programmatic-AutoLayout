using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace autolayout
{
    public class SwipingController : UICollectionViewController
    {
        public SwipingController(UICollectionViewFlowLayout layout) : base(layout)
        {
            this.CollectionView.Delegate = new CustomViewDelegate();
        }

        class CustomViewDelegate : UICollectionViewDelegateFlowLayout
        {
            public override CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
            {
                return new CGSize(collectionView.Frame.Width, collectionView.Frame.Height);
            }

            public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
            {
                return 0;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(PageCell), "cellId");
            CollectionView.PagingEnabled = true;

        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 4;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell("cellId", indexPath) as PageCell;
            //cell.BackgroundColor = indexPath.Item % 2 == 0 ? UIColor.Red : UIColor.Green;
            return cell;
        }


    }
}
