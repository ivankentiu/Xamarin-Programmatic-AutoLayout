﻿using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;

namespace autolayout
{
    public partial class SwipingController : UICollectionViewController
    {
        private UIButton previousButton, nextButton;
        private UIPageControl pageControl;

        Page[] pages = {
            new Page {ImageName = "bear", HeaderText = "Join use today in our fun and games!", BodyText ="Are you ready for loads and loads of fun? Don't wait any longer! We hope to see you in our stores soon."},
            new Page {ImageName = "heart", HeaderText = "Subscribe and get coupons on our daily events", BodyText = "Get notified of the savings immediately when we announce them of our website. make sure to also give us any feedback you have." },
            new Page {ImageName = "leaf", HeaderText = "VIP members special services", BodyText = "we do the honors to serve you Cooooolll!" }
        };

        private void SetupBottomControls()
        {
            previousButton = UIButton.FromType(UIButtonType.System);
            ButtonSetup(previousButton, UIColor.Gray, "PREV");

            nextButton = UIButton.FromType(UIButtonType.System);
            ButtonSetup(nextButton, UIColorExtensions.mainPink, "Next");

            pageControl = new UIPageControl()
            {
                CurrentPage = 0,
                Pages = pages.Length,
                CurrentPageIndicatorTintColor = UIColorExtensions.mainPink,
                PageIndicatorTintColor = new UIColor(red: 249f / 255f, green: 207f / 255f, blue: 224f / 255f, alpha: 1f),
            };

            var bottomControlsStackView = new UIStackView(new UIView[] { previousButton, pageControl, nextButton })
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.FillEqually,
                Axis = UILayoutConstraintAxis.Horizontal
            };

            previousButton.TouchUpInside += (sender, e) =>
            {
                var nextIndex = (int)Math.Max(pageControl.CurrentPage - 1, 0);
                MovePage(nextIndex);
            };

            nextButton.TouchUpInside += (sender, e) =>
            {
                var nextIndex = (int)Math.Min(pageControl.CurrentPage + 1, pages.Length - 1);
                MovePage(nextIndex);
            };

            CollectionView.AddSubview(bottomControlsStackView);

            // shorter way instead of setting them 1 by 1
            NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[] {
                //previousButton.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor),
                bottomControlsStackView.BottomAnchor.ConstraintEqualTo(CollectionView.SafeAreaLayoutGuide.BottomAnchor),
                bottomControlsStackView.LeadingAnchor.ConstraintEqualTo(CollectionView.SafeAreaLayoutGuide.LeadingAnchor),
                bottomControlsStackView.TrailingAnchor.ConstraintEqualTo(CollectionView.SafeAreaLayoutGuide.TrailingAnchor),
                bottomControlsStackView.HeightAnchor.ConstraintEqualTo(50)
            });
        }

        private void ButtonSetup(UIButton button, UIColor color, string text)
        {
            button.TitleLabel.Font = UIFont.BoldSystemFontOfSize(14);
            button.SetTitleColor(color, UIControlState.Normal);
            button.SetTitle(text, UIControlState.Normal);
            button.TranslatesAutoresizingMaskIntoConstraints = false;

        }

        private void MovePage(int nextIndex)
        {
            var indexPath = NSIndexPath.FromRowSection(nextIndex, 0);
            pageControl.CurrentPage = nextIndex;
            CollectionView.ScrollToItem(indexPath, UICollectionViewScrollPosition.CenteredHorizontally, true);
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SetupBottomControls();

            CollectionView.BackgroundColor = UIColor.White;
            CollectionView.RegisterClassForCell(typeof(PageCell), "cellId");
            CollectionView.PagingEnabled = true;
        }
       
    }
}
