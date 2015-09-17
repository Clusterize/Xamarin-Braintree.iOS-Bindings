using ObjCRuntime;

[assembly: LinkWith ("Braintree.a", LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator | LinkTarget.Simulator64, SmartLink = true, ForceLoad = true, Frameworks = "SystemConfiguration Security AudioToolbox PassKit CoreLocation AVFoundation CoreMedia Foundation MessageUI MobileCoreServices UIKit", LinkerFlags = "-lc++ -ObjC")]