using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace autolayout
{
    public class PageCell : UICollectionViewCell
    {
        UIView topImageContainerView;
        public UIImageView bearImageView;
        public UITextView descriptionTextView;

        private Page _myPage;
        public Page MyPage
        {
            get { return _myPage; }
            set
            {
                _myPage = value;
                bearImageView.Image = UIImage.FromBundle(_myPage.imageName);

                var attributedText = new NSMutableAttributedString(
                    _myPage.headerText,
                    font: UIFont.BoldSystemFontOfSize(18)
                );

                var subtitleAttributedText = new NSAttributedString(
                    String.Format("\n\n\n{0}", _myPage.bodyText),
                    font: UIFont.BoldSystemFontOfSize(13),
                    foregroundColor: UIColor.Gray
                );

                attributedText.Append(subtitleAttributedText);
                descriptionTextView.AttributedText = attributedText;
                descriptionTextView.TextAlignment = UITextAlignment.Center;
            }
        }


        [Export("initWithFrame:")]
        public PageCell(CGRect frame) : base(frame)
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

            AddSubview(descriptionTextView);
            AddSubview(topImageContainerView);
            topImageContainerView.AddSubview(bearImageView);
            SetupLayout();
        }

        private void SetupLayout()
        {
            // better to use leading and trailing - aware if whether the language is left to right or vise versa (arabic)
            topImageContainerView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            //topImageContainerView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            //topImageContainerView.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            topImageContainerView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
            topImageContainerView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
            topImageContainerView.HeightAnchor.ConstraintEqualTo(HeightAnchor, 0.5f).Active = true;

            //imageView.Frame = new CGRect(0, 0, 50, 50);
            bearImageView.CenterXAnchor.ConstraintEqualTo(topImageContainerView.CenterXAnchor).Active = true;
            bearImageView.CenterYAnchor.ConstraintEqualTo(topImageContainerView.CenterYAnchor).Active = true;
            bearImageView.HeightAnchor.ConstraintEqualTo(topImageContainerView.HeightAnchor, 0.5f).Active = true;
            //bearImageView.TopAnchor.ConstraintEqualTo(View.TopAnchor, 100).Active = true;
            //bearImageView.WidthAnchor.ConstraintEqualTo(200).Active = true;
            //bearImageView.HeightAnchor.ConstraintEqualTo(200).Active = true;

            descriptionTextView.TopAnchor.ConstraintEqualTo(topImageContainerView.BottomAnchor).Active = true;
            descriptionTextView.LeftAnchor.ConstraintEqualTo(LeftAnchor, 24).Active = true;
            descriptionTextView.RightAnchor.ConstraintEqualTo(RightAnchor, -24).Active = true;
            descriptionTextView.BottomAnchor.ConstraintEqualTo(BottomAnchor, 0).Active = true;
        }
    }
}
