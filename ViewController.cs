using System;
using CoreGraphics;
using UIKit;

namespace autolayout
{
    public class ViewController : UIViewController
    {
        UIImageView bearImageView;
        UITextView descriptionTextView;

        internal ViewController()
        {
            bearImageView = new UIImageView()
            {
                Image = UIImage.FromBundle("bear"),
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            descriptionTextView = new UITextView()
            {
                Text = "Join us today in our fun and games!",
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.BoldSystemFontOfSize(18),
                TextAlignment = UITextAlignment.Center,
                Editable = false,
                ScrollEnabled = false
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White; 

            View.AddSubview(bearImageView);
            View.AddSubview(descriptionTextView);
            SetupLayout();
        }

        private void SetupLayout()
        {
            //imageView.Frame = new CGRect(0, 0, 50, 50);
            bearImageView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            //imageView.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            bearImageView.TopAnchor.ConstraintEqualTo(View.TopAnchor, 100).Active = true;
            bearImageView.WidthAnchor.ConstraintEqualTo(200).Active = true;
            bearImageView.HeightAnchor.ConstraintEqualTo(200).Active = true;

            descriptionTextView.TopAnchor.ConstraintEqualTo(bearImageView.BottomAnchor, 120).Active = true;
            descriptionTextView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            descriptionTextView.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            descriptionTextView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor, 0).Active = true;
        }


    }
}
