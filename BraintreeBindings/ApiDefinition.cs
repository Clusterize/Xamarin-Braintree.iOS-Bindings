using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace BraintreeBindings
{
	delegate void CompletionCallback (string nonce, NSError error);

	[BaseType (typeof (NSObject))]
	interface Braintree
	{
		[Static, Export ("braintreeWithClientToken:")]
		Braintree Create (string clientToken);

		[Export ("dropInViewControllerWithDelegate:")]
		BTDropInViewController CreateDropInViewController (BTDropInViewControllerDelegate dropInDelegate);

		[Export ("tokenizeCard:completion:")]
		[Async]
		void TokenizeCard (BTClientCardTokenizationRequest request, CompletionCallback callback);
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

	[BaseType (typeof (NSObject))]
	interface BTClientCardTokenizationRequest
	{
		[Export ("number")]
		string Number { get; set; }

		[Export ("expirationMonth")]
		string ExpirationMonth { get; set; }

		[Export ("expirationYear")]
		string ExpirationYear { get; set; }

		[Export ("expirationDate")]
		string ExpirationDate { get; set; }

		[Export ("cvv")]
		string CVV { get; set; }

		[Export ("postalCode")]
		string PostalCode { get; set; }

		[Export ("additionalParameters")]
		NSDictionary AdditionalParameters { get; set; }
	}
}