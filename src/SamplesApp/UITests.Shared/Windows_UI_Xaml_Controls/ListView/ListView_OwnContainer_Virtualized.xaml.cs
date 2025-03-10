﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UITests.Shared.Windows_UI_Xaml_Controls
{
	[SampleControlInfo("ListView", nameof(ListView_OwnContainer_Virtualized), description: SampleDescription)]
	public sealed partial class ListView_OwnContainer_Virtualized : UserControl
	{
		private const string SampleDescription = "This sample uses custom items and virtualization associated with it. " +
			"Scrolling through the list should work properly.";

		public ListView_OwnContainer_Virtualized()
		{
			this.InitializeComponent();
		}
	}
}
