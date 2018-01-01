using System;
using Foundation;

namespace autolayout
{
    public struct Page
    {
        public String imageName;
        public String headerText;
        public String bodyText;

        public Page(string _imageName, string _headerText, string _bodyText)
        {
            imageName = _imageName;
            headerText = _headerText;
            bodyText = _bodyText;
        }
    }
}
