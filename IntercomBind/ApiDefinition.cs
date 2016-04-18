using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;

namespace IntercomBind
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//

	interface GlobalVaribale{
		[Field ("IntercomSDKErrorDomain")]
		string IntercomSDKErrorDomain { get; }
		[Notification]
		[Field ("IntercomWindowWillShowNotification")]
		string IntercomWindowWillShowNotification { get; }
		[Notification]
		[Field ("IntercomWindowDidShowNotification")]
		string IntercomWindowDidShowNotification { get; }
		[Notification]
		[Field ("IntercomWindowWillHideNotification")]
		string IntercomWindowWillHideNotification { get; }
		[Notification]
		[Field ("IntercomWindowDidHideNotification")]
		string IntercomWindowDidHideNotification { get; }
	}

	public delegate void ICMCompletion(NSError error);

	[BaseType (typeof (NSObject))]
	[Model][Protocol]
	interface IntercomSessionListener{
		[Export ("intercomSessionStatusDidChange:")]
		void IntercomSessionStatusDidChange(bool isSessionOpen);
	}

	[BaseType (typeof (NSObject))]
	interface Intercom{
		[Static, Export ("setApiKey:forAppId:")]
		void SetApiKey(string apiKey, string appId);

		[Static, Export ("setApiKey:forAppId:securityOptions:")]
		void SetApiKey(string apiKey, string appId, NSDictionary securityOptions);

		[Static, Export ("beginSessionForUserWithEmail:completion:")]
		void BeginSessionForUserWithEmail(string email, ICMCompletion completion);

		[Static, Export ("beginSessionForUserWithUserId:completion:")]
		void BeginSessionForUserWithUserId(string userId, ICMCompletion completion);

		[Static, Export ("beginSessionForAnonymousUserWithCompletion:")]
		void BeginSessionForAnonymousUserWithCompletion(ICMCompletion completion);

		[Static, Export ("endSession")]
		void EndSession();

		[Static, Export ("updateUserWithAttributes:")]
		void UpdateUserWithAttributes(NSDictionary attributes);

		[Static, Export ("updateUserWithAttributes:completion:")]
		void UpdateUserWithAttributesCompletion(NSDictionary attributes, ICMCompletion completion);

//		[Static, Export ("logEventWithName:__attribute__((deprecated))")]
//		void LogEventWithName__attribute__((deprecated)) (string name, (deprecated ));

		[Static, Export ("logEventWithName:completion:")]
		void LogEventWithNameCompletion(string name, ICMCompletion completion);

		[Static, Export ("logEventWithName:optionalMetaData:completion:")]
		void LogEventWithNameOptionalMetaDataCompletion(string name, NSDictionary metadata, ICMCompletion completion);

		[Static, Export ("presentMessageViewAsConversationList:")]
		void PresentMessageViewAsConversationList(bool showConversationList);

		[Static, Export ("registerForRemoteNotifications")]
		void RegisterForRemoteNotifications();

		[Static, Export ("setPresentationInsetOverScreen:")]
		void SetPresentationInsetOverScreen(UIEdgeInsets presentationInset);

		[Static, Export ("setPresentationMode:")]
		void SetPresentationMode(ICMPresentationMode presentationMode);

		[Static, Export ("setBaseColor:")]
		void SetBaseColor(UIColor color);

		[Static, Export ("checkForUnreadMessages")]
		void CheckForUnreadMessages();

//		[Static, Export ("hideConversations:__attribute__((deprecated))")]
//		void HideConversations__attribute__((deprecated))(bool hide, (deprecated ));

		[Static, Export ("hideNotifications:")]
		void HideNotifications(bool hide);

		[Static, Export ("enableLogging")]
		void EnableLogging();

		[Static, Export ("setSessionListener:")]
		void setSessionListener(IntercomSessionListener sessionListener);
	}
}

