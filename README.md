# Social Sharing

This Unity project provides functionality to share text or image or both using a device native share.
It supports both mobile iOS and Android platforms for scanning and generating QR codes.

## Features

- Share Text.
- Share Images.
- Share Text and Images.
- Get a callback with the result.

## Setup
In Unity Package Manager use this URL `https://github.com/ShusmoGames/SocialSharing.git`

## Example of Using

```csharp
using Shusmo;

private string text;
private Sprite image; //Can be Sprite or Texture2D.

/// <summary>
/// Add what you want to share.
/// </summary>
ShusmoAPI.SocialSharing.Share(text, image, ShowResult);

private void ShowResult(string result) => Debug.Log(result);
```
