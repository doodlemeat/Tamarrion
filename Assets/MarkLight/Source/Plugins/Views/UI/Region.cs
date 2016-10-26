#region Using Statements
using MarkLight.ValueConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
#endregion

namespace MarkLight.Views.UI
{
    /// <summary>
    /// Region view.
    /// </summary>
    /// <d>View used primarily to section off a region of space in order to spacially arrange child views.</d>
    [HideInPresenter]
    public class Region : UIView
    {
		[ChangeHandler ("LayoutChanged")]
		public _bool Flex;

		[ChangeHandler ("LayoutChanged")]
		public _string FlexDirection;

		public override void SetDefaultValues () {
			base.SetDefaultValues ();

			Flex.DirectValue = false;
			FlexDirection.DirectValue = "Row";
		}

		public override void ChildLayoutChanged () {
			base.ChildLayoutChanged ();
			//QueueChangeHandler ("LayoutChanged");
		}

		public override void Initialize () {
			base.Initialize ();
		}

		public override void LayoutChanged () {
			if(!Flex.Value) { return; } 

			var children = new List<UIView> ();
			var ActualPixelHeight = ActualHeight;
			
			this.ForEachChild<Region> (x => {
				children.Add (x);
			}, false);

			// Height of all flex children that which FlexGrow = false
			float TotalFlexChildHeight = 0;

			// Number of FlexGrow flex items
			int NumberOfFlexGrowItems = 0;
			 
			children.ForEach (child => {
				float TotalChildHeight = 0;
				child.ForEachChild<UIView> (x => {
					TotalChildHeight += x.ActualHeight;
				}, false);

				if (! child.FlexGrow ) {
					TotalFlexChildHeight += TotalChildHeight;
				} else {
					++NumberOfFlexGrowItems;
				}

				child.Height.DirectValue = ElementSize.FromPixels (TotalChildHeight);
				child.RectTransformChanged ();
			});

			if ( NumberOfFlexGrowItems > 0) {
				float FlexGrowHeight = 0;
				if ( TotalFlexChildHeight > 0 ) {
					FlexGrowHeight = (ActualPixelHeight - TotalFlexChildHeight) / NumberOfFlexGrowItems;
				} else {
					FlexGrowHeight = ActualPixelHeight / NumberOfFlexGrowItems;
				}
				children.ForEach (child => {
					if ( child.FlexGrow ) {
						Debug.Log (FlexGrowHeight);
						child.Height.DirectValue = ElementSize.FromPixels (FlexGrowHeight);
						child.RectTransformChanged ();
					}
				});
			}
		}	
	}
}
