
using System;
using System.Drawing;

using Foundation;
using UIKit;
using UnitKing.Core;

namespace UnitKing.iOS
{
    public partial class ResultsStoryboard : UIViewController
    {
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public ResultsStoryboard(IntPtr handle)
            : base(handle)
        {
            Calculation.Weight = 195;
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NSNotificationCenter.DefaultCenter.AddObserver(UITextField.TextFieldTextDidChangeNotification, TextChangedEvent);
        }

        private void TextChangedEvent(NSNotification notification)
        {
            int num = 0;
            UITextField field = (UITextField)notification.Object;

            if (notification.Object == current)
            {
                if (int.TryParse(current.Text.ToString(), out num))
                {
                    Calculation.Actual = num;
                }
            }
            else if (notification.Object == target)
            {
                if (int.TryParse(target.Text.ToString(), out num))
                {
                    Calculation.Target = num;
                }
            }
            else if (notification.Object == carbohydrates)
            {
                if (int.TryParse(carbohydrates.Text.ToString(), out num))
                {
                    Calculation.Carbohydrates = num;
                }
            }

            DisplaySuggestedUnits();
        }
        
        private void DisplaySuggestedUnits()
        {
            suggested.Text = "Suggested Units:  " + Calculation.TotalMealtimeDose + " units";
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}