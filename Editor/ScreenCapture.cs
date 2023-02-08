using System;
using System.IO;
using UnityEditor;

namespace Kogane.Internal
{
    internal static class ScreenCapture
    {
        public static void CaptureScreenshot()
        {
            var setting       = ScreenCaptureSetting.instance;
            var directoryName = setting.DirectoryName;
            var path          = $"{directoryName}/{DateTime.Now.ToString( setting.FileNameFormat )}.png";

            if ( !Directory.Exists( directoryName ) )
            {
                Directory.CreateDirectory( directoryName );
            }

            var type = typeof( EditorWindow ).Assembly.GetType( "UnityEditor.GameView" );
            EditorWindow.FocusWindowIfItsOpen( type );

            UnityEngine.ScreenCapture.CaptureScreenshot( path );

            // var width   = Screen.width;
            // var height  = Screen.height;
            // var texture = new Texture2D( width, height, TextureFormat.ARGB32, false );
            //
            // texture.ReadPixels( new Rect( 0, 0, width, height ), 0, 0 );
            // texture.Apply();
            //
            // var bytes = texture.EncodeToPNG();
            //
            // UnityEngine.Object.DestroyImmediate( texture );
            //
            // File.WriteAllBytes( path, bytes );
        }
    }
}