﻿using Android.Content;
using SkiaSharp.Views.Android;
using Android.Util;
using System;
using Android.Runtime;

namespace SimpleCharts.Droid
{

	public class ChartView : SKCanvasView
	{
		#region Constructors

		public ChartView(Context context) : base(context)
		{
			this.PaintSurface += OnPaintCanvas;
		}

		public ChartView(Context context, IAttributeSet attributes) : base(context, attributes)
		{
			this.PaintSurface += OnPaintCanvas;
		}

		public ChartView(Context context, IAttributeSet attributes, int defStyleAtt) : base(context, attributes, defStyleAtt)
		{
			this.PaintSurface += OnPaintCanvas;
		}

		public ChartView(IntPtr ptr, JniHandleOwnership jni) : base(ptr, jni)
		{
			this.PaintSurface += OnPaintCanvas;
		}

		#endregion

		private Chart chart;

		public Chart Chart
		{
			get => this.chart;
			set
			{

				if (this.chart != null)
					this.chart.DrawInvalidated = null;
				if (this.chart != value)
				{
					this.chart = value;
					this.Invalidate();
					if (this.chart != null)
						this.chart.DrawInvalidated = () => this.Post(Invalidate);
				}
			}
		}

		private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
		{
			if (this.chart != null)
			{
				this.chart.Draw(e.Surface.Canvas, e.Info.Width, e.Info.Height);
			}
		}
	}
}
