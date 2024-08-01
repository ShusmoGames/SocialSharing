using UnityEngine;
using System.IO;
using System;

namespace Shusmo
{
    public partial class ShusmoAPI
    {
        public static class SocialSharing
        {
            private static Action<string> _callback = null;

            public static void Share(string text = null, Texture2D image = null, Action<string> callback = null)
            {
                try
                {
                    if (string.IsNullOrEmpty(text) && image == null)
                    {
#if UNITY_EDITOR
                        Debug.LogError("You trying to share a empty data");
#endif
                        if (callback != null) callback?.Invoke(NativeShare.ShareResult.NotShared.ToString());
                        return;
                    }

                    var _ = new NativeShare();

                    if (!string.IsNullOrEmpty(text)) _.SetText(text);
                    if (image != null) _.AddFile(image);


                    if (callback != null) _callback = callback;

                    _.SetCallback(Callback);
                    _.Share();
                }
                catch (Exception e)
                {
                    if (callback != null) callback?.Invoke(NativeShare.ShareResult.Unknown.ToString());
#if UNITY_EDITOR
                    Debug.LogError(e.Message);
#endif
                    return;
                }
            }

            public static void Share(string text = null, Sprite image = null, Action<string> callback = null) => Share(text, (image) ? image.texture : null, callback);

            private static void Callback(NativeShare.ShareResult result, string shareTarget)
            {
                _callback?.Invoke(result.ToString());
                _callback = null;
            }
        }
    }
}