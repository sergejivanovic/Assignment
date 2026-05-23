using System.Windows.Media;

namespace Assignment.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public Brush Color
        {
            get
            {
                if (Priority == 1)
                {
                    return Brushes.Red;
                }

                if (Priority == 2)
                {
                    return Brushes.Yellow;
                }

                return Brushes.Green;
            }
        }
    }
}
