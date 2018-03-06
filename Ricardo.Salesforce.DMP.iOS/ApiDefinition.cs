namespace Ricardo.Salesforce.DMP.iOS
{
    using Foundation;
    using ObjCRuntime;

    // @protocol KruxConsentCallback
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface KruxConsentCallback
    {
        // @required -(void)handleConsentGetResponse:(id)consentGetResponse;
        [Abstract]
        [Export("handleConsentGetResponse:")]
        void HandleConsentGetResponse(NSObject consentGetResponse);

        // @required -(void)handleConsentGetError:(id)consentGetError;
        [Abstract]
        [Export("handleConsentGetError:")]
        void HandleConsentGetError(NSObject consentGetError);

        // @required -(void)handleConsentSetResponse:(id)consentSetResponse;
        [Abstract]
        [Export("handleConsentSetResponse:")]
        void HandleConsentSetResponse(NSObject consentSetResponse);

        // @required -(void)handleConsentSetError:(id)consentSetError;
        [Abstract]
        [Export("handleConsentSetError:")]
        void HandleConsentSetError(NSObject consentSetError);
    }

    // @protocol KruxTrackerController <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IKruxTrackerController
    {
        // @required -(void)trackPageView:(NSString *)section pageAttributes:(NSDictionary *)pageAttributes userAttributes:(NSDictionary *)userAttributes;
        [Abstract]
        [Export("trackPageView:pageAttributes:userAttributes:")]
        void TrackPageView(string section, NSDictionary pageAttributes, NSDictionary userAttributes);

        // @required -(void)trackPageView:(NSString *)section attributes:(NSDictionary *)attributes;
        [Abstract]
        [Export("trackPageView:attributes:")]
        void TrackPageView(string section, NSDictionary attributes);

        // @required -(BOOL)fireEvent:(NSString *)eventUid eventAttributes:(NSDictionary *)eventAttributes withError:(NSError **)error;
        [Abstract]
        [Export("fireEvent:eventAttributes:withError:")]
        bool FireEvent(string eventUid, NSDictionary eventAttributes, out NSError error);

        // @required -(void)trackTransactionWithAttributes:(NSDictionary *)transactionAttributes;
        [Abstract]
        [Export("trackTransactionWithAttributes:")]
        void TrackTransactionWithAttributes(NSDictionary transactionAttributes);

        // @required -(void)consentSetRequest:(NSDictionary *)consentSetAttributes;
        [Abstract]
        [Export("consentSetRequest:")]
        void ConsentSetRequest(NSDictionary consentSetAttributes);

        // @required -(void)consentGetRequest:(NSDictionary *)consentGetAttributes;
        [Abstract]
        [Export("consentGetRequest:")]
        void ConsentGetRequest(NSDictionary consentGetAttributes);
    }

    // @interface KruxTracker : NSObject <KruxTrackerController>
    [BaseType(typeof(NSObject))]
    interface KruxTracker : IKruxTrackerController
    {
        // @property (readwrite) BOOL debug;
        [Export("debug")]
        bool Debug { get; set; }

        // @property (readwrite) BOOL dryRun;
        [Export("dryRun")]
        bool DryRun { get; set; }

        // @property (readonly, strong) NSString * configId;
        [Export("configId", ArgumentSemantic.Strong)]
        string ConfigId { get; }

        // @property (readwrite, strong) NSString * configHost;
        [Export("configHost", ArgumentSemantic.Strong)]
        string ConfigHost { get; set; }

        // @property (readwrite, strong) NSString * jslogHost;
        [Export("jslogHost", ArgumentSemantic.Strong)]
        string JslogHost { get; set; }

        // @property (readwrite, strong) NSObject<KruxConsentCallback> * consentCallback;
        [Export("consentCallback", ArgumentSemantic.Strong)]
        KruxConsentCallback ConsentCallback { get; set; }

        // +(instancetype)sharedEventTrackerWithConfigId:(NSString *)configId debugFlag:(BOOL)debug dryRunFlag:(BOOL)dryRun;
        [Static]
        [Export("sharedEventTrackerWithConfigId:debugFlag:dryRunFlag:")]
        KruxTracker SharedEventTrackerWithConfigId(string configId, bool debug, bool dryRun);

        // +(instancetype)sharedEventTrackerWithConfigId:(NSString *)confId debugFlag:(BOOL)debugFlag dryRunFlag:(BOOL)dryRunFlag configHost:(NSString *)configHost jslogHost:(NSString *)jslogHost;
        [Static]
        [Export("sharedEventTrackerWithConfigId:debugFlag:dryRunFlag:configHost:jslogHost:")]
        KruxTracker SharedEventTrackerWithConfigId(string confId, bool debugFlag, bool dryRunFlag, string configHost, string jslogHost);

        // +(instancetype)sharedEventTrackerWithConfigId:(NSString *)configId debugFlag:(BOOL)debug dryRunFlag:(BOOL)dryRun consentCallback:(NSObject<KruxConsentCallback> *)consentCallback;
        [Static]
        [Export("sharedEventTrackerWithConfigId:debugFlag:dryRunFlag:consentCallback:")]
        KruxTracker SharedEventTrackerWithConfigId(string configId, bool debug, bool dryRun, KruxConsentCallback consentCallback);

        // +(instancetype)sharedEventTrackerWithConfigId:(NSString *)confId debugFlag:(BOOL)debugFlag dryRunFlag:(BOOL)dryRunFlag configHost:(NSString *)configHost jslogHost:(NSString *)jslogHost consentCallback:(NSObject<KruxConsentCallback> *)consentCallback;
        [Static]
        [Export("sharedEventTrackerWithConfigId:debugFlag:dryRunFlag:configHost:jslogHost:consentCallback:")]
        KruxTracker SharedEventTrackerWithConfigId(string confId, bool debugFlag, bool dryRunFlag, string configHost, string jslogHost, KruxConsentCallback consentCallback);

        // +(NSString *)getKruxSDKVersionNo;
        [Static]
        [Export("getKruxSDKVersionNo")]
        string KruxSDKVersionNo { get; }

        // -(NSArray *)getSegments;
        [Export("getSegments")]
        NSObject[] Segments { get; }

        // -(void)startScheduler;
        [Export("startScheduler")]
        void StartScheduler();

        // -(void)stopScheduler;
        [Export("stopScheduler")]
        void StopScheduler();
    }

}
