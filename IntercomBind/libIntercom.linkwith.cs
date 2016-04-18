using System;
using ObjCRuntime;
[assembly: LinkWith ("libIntercom.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64,"-ObjC", Frameworks="UIKit AVFoundation AudioToolbox MobileCoreServices SystemConfiguration ImageIO", SmartLink = true, ForceLoad = true)]
