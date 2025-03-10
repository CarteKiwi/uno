﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Uno.UI;

#if __ANDROID__
using View = Android.Views.View;
using Font = Android.Graphics.Typeface;
#elif __IOS__
using UIKit;
using View = UIKit.UIView;
using Color = UIKit.UIColor;
using Font = UIKit.UIFont;
#elif __MACOS__
using AppKit;
using View = AppKit.NSView;
using Color = AppKit.NSColor;
using Font = AppKit.NSFont;
#endif

namespace Windows.UI.Xaml.Controls
{
	/// <summary>
	/// A border layouter, to apply Padding to the border.
	/// </summary>
	public partial class Border
#if !__CROSSRUNTIME__ && !IS_UNIT_TESTS
		: ICustomClippingElement
#endif
	{
		protected override Size MeasureOverride(Size availableSize)
		{
			var padding = Padding;
			var borderThickness = BorderThickness;

			Size measuredSize;
			if (Child is { } child)
			{
				var childSize = new Size(
					availableSize.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right,
					availableSize.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom
				);
				measuredSize = MeasureElement(child, childSize);
			}
			else
			{
				measuredSize = default;
			}

			return new Size(
				measuredSize.Width + padding.Left + padding.Right + borderThickness.Left + borderThickness.Right,
				measuredSize.Height + padding.Top + padding.Bottom + borderThickness.Top + borderThickness.Bottom
			);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			var child = this.FindFirstChild();

			if (child != null)
			{
				var padding = Padding;
				var borderThickness = BorderThickness;

				var finalRect = new Rect(
					padding.Left + borderThickness.Left,
					padding.Top + borderThickness.Top,
					finalSize.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right,
					finalSize.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom
				);

				base.ArrangeElement(child, finalRect);
			}

			return finalSize;
		}
	}
}
