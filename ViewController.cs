using System;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace autolayout
{

    public static class UIColorExtensions
    {
        public static UIColor mainPink = new UIColor(red: 232f / 255f, green: 68f / 255f, blue: 133f / 255f, alpha: 1f);
    }

    public class ViewController : UIViewController
    {
        UIView topImageContainerView;
        UIImageView bearImageView;
        UITextView descriptionTextView;
        UIButton previousButton, nextButton;
        UIPageControl pageControl;

        public ViewController()
        {
            topImageContainerView = new UIView()
            {
                //BackgroundColor = UIColor.Blue,
                Frame = new CGRect(0, 0, 100, 100),
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            bearImageView = new UIImageView()
            {
                Image = UIImage.FromBundle("bear"),
                TranslatesAutoresizingMaskIntoConstraints = false,
                ContentMode = UIViewContentMode.ScaleAspectFit
            };


            var attributedText = new NSMutableAttributedString(
                "Join us today in our fun and games!",
                font: UIFont.BoldSystemFontOfSize(18)
            );

            var subtitleAttributedText = new NSAttributedString(
                "\n\n\nAre you ready for loads and loads of fun? Don't wait any longer! We hope to see you in our stores soon.",
                font: UIFont.BoldSystemFontOfSize(13),
                foregroundColor: UIColor.Gray
            );

            attributedText.Append(subtitleAttributedText);

            descriptionTextView = new UITextView()
            {
                //Text = "Join us today in our fun and games!",
                //Font = UIFont.BoldSystemFontOfSize(18),
                AttributedText = attributedText,
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextAlignment = UITextAlignment.Center,
                Editable = false,
                ScrollEnabled = false
            };

            previousButton = UIButton.FromType(UIButtonType.System);
            previousButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(14);
            previousButton.SetTitleColor(UIColor.Gray, UIControlState.Normal);
            previousButton.SetTitle("PREV", UIControlState.Normal);
            previousButton.TranslatesAutoresizingMaskIntoConstraints = false;

            nextButton = UIButton.FromType(UIButtonType.System);
            nextButton.TitleLabel.Font = UIFont.BoldSystemFontOfSize(14);
            nextButton.SetTitleColor(UIColorExtensions.mainPink, UIControlState.Normal);
            nextButton.SetTitle("NEXT", UIControlState.Normal);
            nextButton.TranslatesAutoresizingMaskIntoConstraints = false;

            pageControl = new UIPageControl()
            {
                CurrentPage = 0,
                Pages = 4,
                CurrentPageIndicatorTintColor = UIColorExtensions.mainPink,
                PageIndicatorTintColor = new UIColor(red: 249f / 255f, green: 207f / 255f, blue: 224f / 255f, alpha: 1f)
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            View.AddSubview(descriptionTextView);
            View.AddSubview(topImageContainerView);
            topImageContainerView.AddSubview(bearImageView);
            SetupBottomControls();
            SetupLayout();
        }

        private void SetupBottomControls()
        {
            var bottomControlsStackView = new UIStackView(new UIView[] { previousButton, pageControl, nextButton })
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Distribution = UIStackViewDistribution.FillEqually,
                Axis = UILayoutConstraintAxis.Horizontal
            };

            View.AddSubview(bottomControlsStackView);

            // shorter way instead of setting them 1 by 1
            NSLayoutConstraint.ActivateConstraints(new NSLayoutConstraint[] {
                //previousButton.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor),
                bottomControlsStackView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor),
                bottomControlsStackView.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor),
                bottomControlsStackView.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor),
                bottomControlsStackView.HeightAnchor.ConstraintEqualTo(50)
            });
        }

        private void SetupLayout()
        {
            // better to use leading and trailing - aware if whether the language is left to right or vise versa (arabic)
            topImageContainerView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            //topImageContainerView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            //topImageContainerView.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            topImageContainerView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            topImageContainerView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            topImageContainerView.HeightAnchor.ConstraintEqualTo(View.HeightAnchor, 0.5f).Active = true;

            //imageView.Frame = new CGRect(0, 0, 50, 50);
            bearImageView.CenterXAnchor.ConstraintEqualTo(topImageContainerView.CenterXAnchor).Active = true;
            bearImageView.CenterYAnchor.ConstraintEqualTo(topImageContainerView.CenterYAnchor).Active = true;
            bearImageView.HeightAnchor.ConstraintEqualTo(topImageContainerView.HeightAnchor, 0.5f).Active = true;
            //bearImageView.TopAnchor.ConstraintEqualTo(View.TopAnchor, 100).Active = true;
            //bearImageView.WidthAnchor.ConstraintEqualTo(200).Active = true;
            //bearImageView.HeightAnchor.ConstraintEqualTo(200).Active = true;

            descriptionTextView.TopAnchor.ConstraintEqualTo(topImageContainerView.BottomAnchor).Active = true;
            descriptionTextView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 24).Active = true;
            descriptionTextView.RightAnchor.ConstraintEqualTo(View.RightAnchor, -24).Active = true;
            descriptionTextView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, 0).Active = true;
        }


    }
}
