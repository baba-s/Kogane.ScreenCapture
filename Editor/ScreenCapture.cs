using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kogane.Internal
{
    internal static class ScreenCapture
    {
        public static void CaptureScreenshot( bool isTransparent )
        {
            var setting       = ScreenCaptureSetting.instance;
            var directoryName = setting.DirectoryName;
            var path          = $"{directoryName}/{DateTime.Now.ToString( setting.FileNameFormat )}.png";

            if ( !Directory.Exists( directoryName ) )
            {
                Directory.CreateDirectory( directoryName );
            }

            var camera        = Camera.main;
            var width         = camera.pixelWidth;
            var height        = camera.pixelHeight;
            var renderTexture = new RenderTexture( width, height, 32 );
            var texture2D     = new Texture2D( width, height, isTransparent ? TextureFormat.ARGB32 : TextureFormat.RGB24, false );

            camera.targetTexture = renderTexture;
            camera.Render();
            RenderTexture.active = renderTexture;
            texture2D.ReadPixels( new Rect( 0, 0, width, height ), 0, 0 );
            texture2D.Apply();
            RenderTexture.active = null;
            camera.targetTexture = null;
            Object.DestroyImmediate( renderTexture );
            File.WriteAllBytes( path, texture2D.EncodeToPNG() );
        }
    }
}