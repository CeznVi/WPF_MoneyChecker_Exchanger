using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MoneyChecker.TabControls
{
    class TabViewControl
    {
        private KeyValuePair<ToggleButton, Page> _tab;

        /* CTOR  */
        public TabViewControl(ToggleButton toggleButton, Page page)
        {
            _tab = new KeyValuePair<ToggleButton, Page>(toggleButton, page);
        }

        public static ToggleButton GetToggleButton(Bitmap bitmap, string text)
        {
            ToggleButton tmp = new ToggleButton();
            WrapPanel wrapPanel = new WrapPanel();

            tmp.Content = wrapPanel;

            wrapPanel.Orientation = Orientation.Vertical;

            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
           
            image.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(), 
                IntPtr.Zero, 
                System.Windows.Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );

            image.Height = 32;
            wrapPanel.Children.Add(image);

            TextBlock textBlock = new TextBlock();
            textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            textBlock.Text = text;

            wrapPanel.Children.Add(textBlock);

            return tmp;
        }

        public KeyValuePair<ToggleButton, Page> Tab { get { return _tab; } }

    }
}
