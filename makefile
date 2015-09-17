XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=./XCodeProject
PROJECT=$(PROJECT_ROOT)/BraintreeApp.xcworkspace
TARGET=BraintreeApp
OUTPUT=./BraintreeBindings

all: Braintree.a libPayPalMobile.a

Build-i386:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphonesimulator -derivedDataPath $(PROJECT_ROOT)/build/386 -configuration Release clean build

Braintree-i386.a: Build-i386
	-mv $(PROJECT_ROOT)/build/386/Build/Products/Release-iphonesimulator/libBraintree.a $@

Build-armv7:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphoneos -derivedDataPath $(PROJECT_ROOT)/build/v7 -arch armv7 -configuration Release clean build 

Braintree-armv7.a: Build-armv7
	-mv $(PROJECT_ROOT)/build/v7/Build/Products/Release-iphoneos/libBraintree.a $@

Build-arm64:
	$(XBUILD) -workspace $(PROJECT) -scheme $(TARGET) -sdk iphoneos -derivedDataPath $(PROJECT_ROOT)/build/64 -arch arm64 -configuration Release clean build 

Braintree-arm64.a: Build-arm64
	-mv $(PROJECT_ROOT)/build/64/Build/Products/Release-iphoneos/libBraintree.a $@

Braintree.a: Braintree-i386.a Braintree-armv7.a Braintree-arm64.a
	xcrun -sdk iphoneos lipo -create -output $(OUTPUT)/$@ $^
	-rm -f $^
    
libPayPalMobile.a:
	-cp $(PROJECT_ROOT)/Pods/Braintree/Braintree/PayPal/mSDK/libPayPalMobile-BT.a $(OUTPUT)/$@

clean:
	-rm -f *.a *.dll $(OUTPUT)/*.a