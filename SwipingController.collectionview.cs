using System;
using UIKit;
using CoreGraphics;

namespace autolayout
{
    partial class SwipingController
    {
        public SwipingController(UICollectionViewFlowLayout layout) : base(layout)
        {
            CollectionView.Delegate = new CustomViewDelegate();
        }

        class CustomViewDelegate : UICollectionViewDelegateFlowLayout
        {
            public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
            {
                return new CGSize(collectionView.Frame.Width, collectionView.Frame.Height);
            }

            public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
            {
                return 0;
            }
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return pages.Length;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell("cellId", indexPath) as PageCell;
            //cell.BackgroundColor = indexPath.Item % 2 == 0 ? UIColor.Red : UIColor.Green;
            var page = pages[indexPath.Item];
            cell.MyPage = page;
            return cell;
        }

        public override void WillEndDragging(UIScrollView scrollView, CGPoint velocity, ref CGPoint targetContentOffset)
        {
            base.WillEndDragging(scrollView, velocity, ref targetContentOffset);
            var x = targetContentOffset.X;
            Console.WriteLine(x);
            pageControl.CurrentPage = (int)(x / CollectionView.Frame.Width);
        }
    }
}
