using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;

namespace autolayout
{
    public class SwipingController : UICollectionViewController
    {
        Page[] pages = {
            new Page("bear", "Join use today in our fun and games!", "Are you ready for loads and loads of fun? Don't wait any longer! We hope to see you in our stores soon."),
            new Page("heart", "Subscribe and get coupons on our daily events", "Get notified of the savings immediately when we announce them of our website. make sure to also give us any feedback you have."),
            new Page("leaf", "VIP members special services", "we do the honors to serve you Cooooolll!")
        };
        //readonly string[] imageNames = { "bear", "heart", "leaf" };

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


    }
}
