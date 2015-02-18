using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace BraintreeBindings
{
	[BaseType (typeof (NSObject))]
	interface Braintree
	{
		[Static, Export ("braintreeWithClientToken:")]
		Braintree Create (string clientToken);

		[Export ("dropInViewControllerWithDelegate:")]
		BTDropInViewController CreateDropInViewController (BTDropInViewControllerDelegate dropInDelegate);
	}

	[BaseType (typeof (UIViewController))]
	interface BTDropInViewController
	{
		[Wrap ("WeakDelegate")]
		BTDropInViewControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		[Export ("summaryTitle")]
		string SummaryTitle { get; set; }

		[Export ("summaryDescription")]
		string SummaryDescription { get; set; }

		[Export ("displayAmount")]
		string DisplayAmount { get; set; }

		[Export ("callToActionText")]
		string CallToActionText { get; set; }

		[Export ("shouldHideCallToAction")]
		bool ShouldHideCallToAction { get; set; }

		[Export ("paymentMethods")]
		BTPaymentMethod[] PaymentMethods { get; set; }

		[Export ("fetchPaymentMethods")]
		void FetchPaymentMethods ();
	}

	[Model, Protocol, BaseType (typeof (NSObject))]
	interface BTDropInViewControllerDelegate
	{
		[Abstract, Export ("dropInViewController:didSucceedWithPaymentMethod:")]
		void OnSuccess (BTDropInViewController controller, BTPaymentMethod paymentMethod);

		[Abstract, Export ("dropInViewControllerDidCancel:")]
		void OnCanceled (BTDropInViewController controller);
	}

	[BaseType (typeof (NSObject))]
	interface BTPaymentMethod
	{
		[Export ("nonce")]
		string Nonce { get; }
	}
}