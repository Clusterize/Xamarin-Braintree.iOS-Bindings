using ObjCRuntime;

[assembly: LinkWith ("Braintree.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, SmartLink = true, ForceLoad = true, Frameworks = "Accelerate SystemConfiguration Security AudioToolbox CoreLocation AVFoundation CoreMedia Foundation MessageUI MobileCoreServices UIKit", WeakFrameworks="PassKit", LinkerFlags = "-lc++ -ObjC")]