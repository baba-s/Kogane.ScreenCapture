using UnityEditor;

namespace Kogane.Internal
{
    internal static class ScreenCaptureMenuItem
    {
        [MenuItem( "Kogane/スクリーンショット撮影" )]
        private static void CaptureScreenshot()
        {
            ScreenCapture.CaptureScreenshot();
        }
    }
}