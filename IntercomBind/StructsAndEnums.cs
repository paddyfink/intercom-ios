using System;

namespace IntercomBind
{
	public enum ICMPresentationMode : uint{
		ICMPresentationModeBottomLeft = 0,
		ICMPresentationModeBottomRight = 1,
		ICMPresentationModeTopLeft = 2,
		ICMPresentationModeTopRight = 3
	}

	public enum ICMSDKError : uint{
		ICMSDKErrorParameterMissing = 1001,
		ICMSDKErrorCredentialsMissing = 1002,
		ICMSDKErrorUpdateUserError = 1003,
		ICMSDKErrorAppIdMissing = 1004,
	} 
}

