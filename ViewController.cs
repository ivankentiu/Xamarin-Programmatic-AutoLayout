using System;
using CoreGraphics;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace autolayout
{
    public class ViewController : UIViewController
    {
        UIView topImageContainerView;
        UIImageView bearImageView;
        UITextView descriptionTextView;

        internal ViewController()
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


        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            View.AddSubview(descriptionTextView);
            View.AddSubview(topImageContainerView);
            topImageContainerView.AddSubview(bearImageView);
            SetupLayout();
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
