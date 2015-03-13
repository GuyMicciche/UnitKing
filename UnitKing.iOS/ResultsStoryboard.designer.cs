// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UnitKing.iOS
{
	[Register ("ResultsStoryboard")]
	partial class ResultsStoryboard
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField carbohydrates { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField current { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel suggested { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField target { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (carbohydrates != null) {
				carbohydrates.Dispose ();
				carbohydrates = null;
			}
			if (current != null) {
				current.Dispose ();
				current = null;
			}
			if (suggested != null) {
				suggested.Dispose ();
				suggested = null;
			}
			if (target != null) {
				target.Dispose ();
				target = null;
			}
		}
	}
}
