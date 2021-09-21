using UnityEngine.UI;

namespace Core
{
    public static class Extensions
    {
        public static void SetTransparency(this Image image, float transparency)
        {
            if (image == null) return;
            
            var alpha = image.color;
            alpha.a = transparency;
            image.color = alpha;
        }
    }
}