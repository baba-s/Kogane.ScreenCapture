using UnityEditor;

namespace Kogane.Internal
{
    internal static class ScreenCaptureMenuItem
    {
        [MenuItem( "Kogane/スクリーンショット撮影（背景透過）" )]
        private static void CaptureScreenshotTransparent()
        {
            ScreenCapture.CaptureScreenshot( true );
        }

        [MenuItem( "Kogane/スクリーンショット撮影" )]
        private static void CaptureScreenshot()
        {
            ScreenCapture.CaptureScreenshot( false );
        }
    }
}