using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    internal sealed class ScreenCaptureEditorWindow : EditorWindow
    {
        [MenuItem( "Window/Kogane/Screen Capture", priority = 1615224119 )]
        private static void Open()
        {
            var window = GetWindow<ScreenCaptureEditorWindow>( "Screen Capture" );
            window.minSize = new Vector2( window.minSize.x, 16 );
        }

        private void OnGUI()
        {
            if ( GUILayout.Button( "Capture Screenshot (Transparent)", GUILayout.ExpandHeight( true ) ) )
            {
                ScreenCapture.CaptureScreenshot( true );
            }

            if ( GUILayout.Button( "Capture Screenshot", GUILayout.ExpandHeight( true ) ) )
            {
                ScreenCapture.CaptureScreenshot( false );
            }
        }
    }
}