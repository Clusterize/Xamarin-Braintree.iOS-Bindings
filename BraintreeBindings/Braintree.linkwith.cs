using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("Braintree.a", LinkTarget.ArmV7 | LinkTarget.Simulator, SmartLink = true, ForceLoad = true, Frameworks = "SystemConfiguration Security AudioToolbox PassKit CoreLocation AVFoundation CoreMedia Foundation MessageUI MobileCoreServices UIKit", LinkerFlags = "-lc++ -ObjC")]