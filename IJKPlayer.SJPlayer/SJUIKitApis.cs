using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace IJKPlayer.SJPlayer
{
    /*
    // @protocol SJUIKitTextMakerProtocol <SJUTAttributesProtocol>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    #1#
    [Protocol]
    interface SJUIKitTextMakerProtocol : SJUTAttributesProtocol
    {
        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) append;
        [Abstract]
        [Export("append", ArgumentSemantic.Copy)]
        Func<NSString, SJUTAttributesProtocol> Append();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(__attribute__((noescape)) SJUTAppendImageHandler _Nonnull) appendImage;
        [Abstract]
        [Export("appendImage", ArgumentSemantic.Copy)]
        Func<SJUTAppendImageHandler, SJUTAttributesProtocol> AppendImage();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSAttributedString * _Nonnull) appendText;
        [Abstract]
        [Export("appendText", ArgumentSemantic.Copy)]
        Func<NSAttributedString, SJUTAttributesProtocol> AppendText();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSRange) update;
        [Abstract]
        [Export("update", ArgumentSemantic.Copy)]
        Func<NSRange, SJUTAttributesProtocol> Update();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) regex;
        [Abstract]
        [Export("regex", ArgumentSemantic.Copy)]
        Func<NSString, SJUTRegexHandlerProtocol> Regex();

        // @required @property (readonly, copy, nonatomic) id<SJUTRangeHandlerProtocol>  _Nonnull (^ _Nonnull)(NSRange) range;
        [Abstract]
        [Export("range", ArgumentSemantic.Copy)]
        Func<NSRange, SJUTRangeHandlerProtocol> Range();
    }
    
    // common argument actions
    delegate void BoolArgumentAction(bool arg0);
    delegate void NSArrayNSValueArgumentAction(NSArray<NSValue> arg0);
    delegate void NSShaowArgumentAction(NSShadow arg0);
    delegate void SJUTStrokeArgumentAction(SJUTStroke arg0);
    delegate void SJUTDecorationArgumentAction(SJUTDecoration arg0);
    delegate void SJUIKitTextMakerProtocolArgumentAction(SJUIKitTextMakerProtocol arg0);
    delegate void SJUTAttributesProtocolArgumentAction(SJUTAttributesProtocol arg0);
    delegate void NSMutableAttributedStringNSTextCheckingResultArgumentsAction(NSMutableAttributedString arg0, NSTextCheckingResult arg1);
    delegate void SJAttributesRangeOperatorArgumentAction(SJAttributesRangeOperator arg0);
    delegate void SJAttributeWorkerArgumentAction(SJAttributeWorker arg0);

    // typedef void (^SJUTAppendImageHandler)(id<SJUTImageAttachment> _Nonnull);
    delegate void SJUTAppendImageHandler(SJUTImageAttachment arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTFontAttribute)(UIFont * _Nonnull);
    delegate SJUTAttributesProtocol SJUTFontAttribute(UIFont arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTColorAttribute)(UIColor * _Nonnull);
    delegate SJUTAttributesProtocol SJUTColorAttribute(UIColor arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTKernAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTKernAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTShadowAttribute)(void (^ _Nonnull)(NSShadow * _Nonnull));
    delegate SJUTAttributesProtocol SJUTShadowAttribute(NSShaowArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTStrokeAttribute)(void (^ _Nonnull)(id<SJUTStroke> _Nonnull));
    delegate SJUTAttributesProtocol SJUTStrokeAttribute(SJUTStrokeArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTDecorationAttribute)(void (^ _Nonnull)(id<SJUTDecoration> _Nonnull));
    delegate SJUTAttributesProtocol SJUTDecorationAttribute(SJUTDecorationArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTBaseLineOffsetAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTBaseLineOffsetAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineSpacingAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTLineSpacingAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTParagraphSpacingAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTParagraphSpacingAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTAlignmentAttribute)(NSTextAlignment);
    delegate SJUTAttributesProtocol SJUTAlignmentAttribute(UITextAlignment arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTFirstLineHeadIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTFirstLineHeadIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTHeadIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTHeadIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTTailIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTTailIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineBreakModeAttribute)(NSLineBreakMode);
    delegate SJUTAttributesProtocol SJUTLineBreakModeAttribute(UILineBreakMode arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTMinimumLineHeightAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTMinimumLineHeightAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTMaximumLineHeightAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTMaximumLineHeightAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTBaseWritingDirectionAttribute)(NSWritingDirection);
    delegate SJUTAttributesProtocol SJUTBaseWritingDirectionAttribute(NSWritingDirection arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineHeightMultipleAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTLineHeightMultipleAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTParagraphSpacingBeforeAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTParagraphSpacingBeforeAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTHyphenationFactorAttribute)(float);
    delegate SJUTAttributesProtocol SJUTHyphenationFactorAttribute(float arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTTabStopsAttribute)(NSArray<NSTextTab *> * _Nonnull);
    delegate SJUTAttributesProtocol SJUTTabStopsAttribute(NSTextTab[] arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTDefaultTabIntervalAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTDefaultTabIntervalAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTAllowsDefaultTighteningForTruncationAttribute)(BOOL);
    delegate SJUTAttributesProtocol SJUTAllowsDefaultTighteningForTruncationAttribute(bool arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineBreakStrategyAttribute)(NSLineBreakStrategy);
    delegate SJUTAttributesProtocol SJUTLineBreakStrategyAttribute(NSLineBreakStrategy arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTSetAttribute)(id _Nullable, NSString * _Nonnull);
    delegate SJUTAttributesProtocol SJUTSetAttribute(NSObject arg0, string arg1);

    // @protocol SJUTAttributesProtocol
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface SJUTAttributesProtocol
    {
        // @required @property (readonly, copy, nonatomic) SJUTFontAttribute _Nonnull font;
        [Abstract]
        [Export("font", ArgumentSemantic.Copy)]
        SJUTFontAttribute Font();

        // @required @property (readonly, copy, nonatomic) SJUTColorAttribute _Nonnull textColor;
        [Abstract]
        [Export("textColor", ArgumentSemantic.Copy)]
        SJUTColorAttribute TextColor();

        // @required @property (readonly, copy, nonatomic) SJUTColorAttribute _Nonnull backgroundColor;
        [Abstract]
        [Export("backgroundColor", ArgumentSemantic.Copy)]
        SJUTColorAttribute BackgroundColor();

        // @required @property (readonly, copy, nonatomic) SJUTKernAttribute _Nonnull kern;
        [Abstract]
        [Export("kern", ArgumentSemantic.Copy)]
        SJUTKernAttribute Kern();

        // @required @property (readonly, copy, nonatomic) SJUTShadowAttribute _Nonnull shadow;
        [Abstract]
        [Export("shadow", ArgumentSemantic.Copy)]
        SJUTShadowAttribute Shadow();

        // @required @property (readonly, copy, nonatomic) SJUTStrokeAttribute _Nonnull stroke;
        [Abstract]
        [Export("stroke", ArgumentSemantic.Copy)]
        SJUTStrokeAttribute Stroke();

        // @required @property (readonly, copy, nonatomic) SJUTDecorationAttribute _Nonnull underLine;
        [Abstract]
        [Export("underLine", ArgumentSemantic.Copy)]
        SJUTDecorationAttribute UnderLine();

        // @required @property (readonly, copy, nonatomic) SJUTDecorationAttribute _Nonnull strikethrough;
        [Abstract]
        [Export("strikethrough", ArgumentSemantic.Copy)]
        SJUTDecorationAttribute Strikethrough();

        // @required @property (readonly, copy, nonatomic) SJUTBaseLineOffsetAttribute _Nonnull baseLineOffset;
        [Abstract]
        [Export("baseLineOffset", ArgumentSemantic.Copy)]
        SJUTBaseLineOffsetAttribute BaseLineOffset();

        // @required @property (readonly, copy, nonatomic) SJUTLineSpacingAttribute _Nonnull lineSpacing;
        [Abstract]
        [Export("lineSpacing", ArgumentSemantic.Copy)]
        SJUTLineSpacingAttribute LineSpacing();

        // @required @property (readonly, copy, nonatomic) SJUTParagraphSpacingAttribute _Nonnull paragraphSpacing;
        [Abstract]
        [Export("paragraphSpacing", ArgumentSemantic.Copy)]
        SJUTParagraphSpacingAttribute ParagraphSpacing();

        // @required @property (readonly, copy, nonatomic) SJUTAlignmentAttribute _Nonnull alignment;
        [Abstract]
        [Export("alignment", ArgumentSemantic.Copy)]
        SJUTAlignmentAttribute Alignment();

        // @required @property (readonly, copy, nonatomic) SJUTFirstLineHeadIndentAttribute _Nonnull firstLineHeadIndent;
        [Abstract]
        [Export("firstLineHeadIndent", ArgumentSemantic.Copy)]
        SJUTFirstLineHeadIndentAttribute FirstLineHeadIndent();

        // @required @property (readonly, copy, nonatomic) SJUTHeadIndentAttribute _Nonnull headIndent;
        [Abstract]
        [Export("headIndent", ArgumentSemantic.Copy)]
        SJUTHeadIndentAttribute HeadIndent();

        // @required @property (readonly, copy, nonatomic) SJUTTailIndentAttribute _Nonnull tailIndent;
        [Abstract]
        [Export("tailIndent", ArgumentSemantic.Copy)]
        SJUTTailIndentAttribute TailIndent();

        // @required @property (readonly, copy, nonatomic) SJUTLineBreakModeAttribute _Nonnull lineBreakMode;
        [Abstract]
        [Export("lineBreakMode", ArgumentSemantic.Copy)]
        SJUTLineBreakModeAttribute LineBreakMode();

        // @required @property (readonly, copy, nonatomic) SJUTMinimumLineHeightAttribute _Nonnull minimumLineHeight;
        [Abstract]
        [Export("minimumLineHeight", ArgumentSemantic.Copy)]
        SJUTMinimumLineHeightAttribute MinimumLineHeight();

        // @required @property (readonly, copy, nonatomic) SJUTMaximumLineHeightAttribute _Nonnull maximumLineHeight;
        [Abstract]
        [Export("maximumLineHeight", ArgumentSemantic.Copy)]
        SJUTMaximumLineHeightAttribute MaximumLineHeight();

        // @required @property (readonly, copy, nonatomic) SJUTBaseWritingDirectionAttribute _Nonnull baseWritingDirection;
        [Abstract]
        [Export("baseWritingDirection", ArgumentSemantic.Copy)]
        SJUTBaseWritingDirectionAttribute BaseWritingDirection();

        // @required @property (readonly, copy, nonatomic) SJUTLineHeightMultipleAttribute _Nonnull lineHeightMultiple;
        [Abstract]
        [Export("lineHeightMultiple", ArgumentSemantic.Copy)]
        SJUTLineHeightMultipleAttribute LineHeightMultiple();

        // @required @property (readonly, copy, nonatomic) SJUTParagraphSpacingBeforeAttribute _Nonnull paragraphSpacingBefore;
        [Abstract]
        [Export("paragraphSpacingBefore", ArgumentSemantic.Copy)]
        SJUTParagraphSpacingBeforeAttribute ParagraphSpacingBefore();

        // @required @property (readonly, copy, nonatomic) SJUTHyphenationFactorAttribute _Nonnull hyphenationFactor;
        [Abstract]
        [Export("hyphenationFactor", ArgumentSemantic.Copy)]
        SJUTHyphenationFactorAttribute HyphenationFactor();

        // @required @property (readonly, copy, nonatomic) SJUTTabStopsAttribute _Nonnull tabStops;
        [Abstract]
        [Export("tabStops", ArgumentSemantic.Copy)]
        SJUTTabStopsAttribute TabStops();

        // @required @property (readonly, copy, nonatomic) SJUTDefaultTabIntervalAttribute _Nonnull defaultTabInterval;
        [Abstract]
        [Export("defaultTabInterval", ArgumentSemantic.Copy)]
        SJUTDefaultTabIntervalAttribute DefaultTabInterval();

        // @required @property (readonly, copy, nonatomic) API_AVAILABLE(ios(9.0)) SJUTAllowsDefaultTighteningForTruncationAttribute allowsDefaultTighteningForTruncation __attribute__((availability(ios, introduced=9.0)));
        //[iOS(9, 0)]
        [Abstract]
        [Export("allowsDefaultTighteningForTruncation", ArgumentSemantic.Copy)]
        SJUTAllowsDefaultTighteningForTruncationAttribute AllowsDefaultTighteningForTruncation();

        // @required @property (readonly, copy, nonatomic) API_AVAILABLE(ios(9.0)) SJUTLineBreakStrategyAttribute lineBreakStrategy __attribute__((availability(ios, introduced=9.0)));
        //[iOS(9, 0)]
        [Abstract]
        [Export("lineBreakStrategy", ArgumentSemantic.Copy)]
        SJUTLineBreakStrategyAttribute LineBreakStrategy();

        // @required @property (readonly, copy, nonatomic) SJUTSetAttribute _Nonnull set;
        [Abstract]
        [Export("set", ArgumentSemantic.Copy)]
        SJUTSetAttribute Set();
    }

    // @protocol SJUTRangeHandlerProtocol
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface SJUTRangeHandlerProtocol
    {
        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(id<SJUTAttributesProtocol> _Nonnull)) update;
        [Abstract]
        [Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocolArgumentAction> Update();

        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(id<SJUIKitTextMakerProtocol> _Nonnull)) replaceWithText;
        [Abstract]
        [Export("replaceWithText", ArgumentSemantic.Copy)]
        Action<SJUIKitTextMakerProtocolArgumentAction> ReplaceWithText();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) replaceWithString;
        [Abstract]
        [Export("replaceWithString", ArgumentSemantic.Copy)]
        Func<NSString, SJUTAttributesProtocol> ReplaceWithString();
    }

    // @protocol SJUTRegexHandlerProtocol <SJUTRangeHandlerProtocol>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface SJUTRegexHandlerProtocol : SJUTRangeHandlerProtocol
    {
        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(NSMutableAttributedString * _Nonnull, NSTextCheckingResult * _Nonnull)) handler;
        [Abstract]
        [Export("handler", ArgumentSemantic.Copy)]
        Action<NSMutableAttributedStringNSTextCheckingResultArgumentsAction> Handler();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSRegularExpressionOptions) regularExpressionOptions;
        [Abstract]
        [Export("regularExpressionOptions", ArgumentSemantic.Copy)]
        Func<NSRegularExpressionOptions, SJUTRegexHandlerProtocol> RegularExpressionOptions();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSMatchingOptions) matchingOptions;
        [Abstract]
        [Export("matchingOptions", ArgumentSemantic.Copy)]
        Func<NSMatchingOptions, SJUTRegexHandlerProtocol> MatchingOptions();
    }

    // @protocol SJUTStroke
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface ISJUTStroke
    {
        // @required @property (nonatomic, strong) UIColor * _Nullable color;
        [Abstract]
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @required @property (nonatomic) float width;
        [Abstract]
        [Export("width")]
        float Width { get; set; }
    }

    // @protocol SJUTDecoration
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface ISJUTDecoration
    {
        // @required @property (nonatomic, strong) UIColor * _Nullable color;
        [Abstract]
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @required @property (nonatomic) NSUnderlineStyle style;
        [Abstract]
        [Export("style", ArgumentSemantic.Assign)]
        NSUnderlineStyle Style { get; set; }
    }

    // @protocol SJUTImageAttachment <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJUTImageAttachment
    {
        // @required @property (nonatomic, strong) UIImage * _Nullable image;
        [Abstract]
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @required @property (nonatomic) SJUTVerticalAlignment alignment;
        [Abstract]
        [Export("alignment", ArgumentSemantic.Assign)]
        SJUTVerticalAlignment Alignment { get; set; }

        // @required @property (nonatomic) CGRect bounds;
        [Abstract]
        [Export("bounds", ArgumentSemantic.Assign)]
        CGRect Bounds { get; set; }
    }

    // @interface SJMake (NSAttributedString)
    [Category]
    [BaseType(typeof(NSAttributedString))]
    interface NSAttributedString_SJMake
    {
        // +(instancetype _Nonnull)sj_UIKitText:(void (^ _Nonnull)(id<SJUIKitTextMakerProtocol> _Nonnull))block;
        [Static]
        [Export("sj_UIKitText:")]
        NSAttributedString Sj_UIKitText(SJUIKitTextMakerProtocolArgumentAction block);

        // -(CGSize)sj_textSize;
        [Export("sj_textSize")]
        //[Verify(MethodToProperty)]
        CGSize Sj_textSize();

        // -(CGSize)sj_textSizeForRange:(NSRange)range;
        [Export("sj_textSizeForRange:")]
        CGSize Sj_textSizeForRange(NSRange range);

        // -(CGSize)sj_textSizeForPreferredMaxLayoutWidth:(CGFloat)width;
        [Export("sj_textSizeForPreferredMaxLayoutWidth:")]
        CGSize Sj_textSizeForPreferredMaxLayoutWidth(nfloat width);

        // -(CGSize)sj_textSizeForPreferredMaxLayoutHeight:(CGFloat)height;
        [Export("sj_textSizeForPreferredMaxLayoutHeight:")]
        CGSize Sj_textSizeForPreferredMaxLayoutHeight(nfloat height);
    }

    // @interface SJStrokeAttribute : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJStrokeAttribute : INSMutableCopying
    {
        // @property (nonatomic) double value;
        [Export("value")]
        double Value { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // +(instancetype _Nonnull)strokeWithValue:(double)value color:(UIColor * _Nonnull)color;
        [Static]
        [Export("strokeWithValue:color:")]
        SJStrokeAttribute StrokeWithValue(double value, UIColor color);

        // -(instancetype _Nonnull)initWithValue:(double)value color:(UIColor * _Nonnull)color;
        [Export("initWithValue:color:")]
        NativeHandle Constructor(double value, UIColor color);
    }

    // @interface SJUnderlineAttribute : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJUnderlineAttribute : INSMutableCopying
    {
        // @property (nonatomic) NSUnderlineStyle value;
        [Export("value", ArgumentSemantic.Assign)]
        NSUnderlineStyle Value { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // +(instancetype _Nonnull)underLineWithStyle:(NSUnderlineStyle)value color:(UIColor * _Nonnull)color;
        [Static]
        [Export("underLineWithStyle:color:")]
        SJUnderlineAttribute UnderLineWithStyle(NSUnderlineStyle value, UIColor color);

        // -(instancetype _Nonnull)initWithStyle:(NSUnderlineStyle)value color:(UIColor * _Nonnull)color;
        [Export("initWithStyle:color:")]
        NativeHandle Constructor(NSUnderlineStyle value, UIColor color);
    }

    // @interface SJAttributesRecorder : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJAttributesRecorder : INSMutableCopying
    {
        // @property (nonatomic) NSRange range;
        [Export("range", ArgumentSemantic.Assign)]
        NSRange Range { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable font;
        [NullAllowed, Export("font", ArgumentSemantic.Strong)]
        UIFont Font { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic) double expansion;
        [Export("expansion")]
        double Expansion { get; set; }

        // @property (nonatomic, strong) NSShadow * _Nullable shadow;
        [NullAllowed, Export("shadow", ArgumentSemantic.Strong)]
        NSShadow Shadow { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) SJUnderlineAttribute * _Nullable underLine;
        [NullAllowed, Export("underLine", ArgumentSemantic.Strong)]
        SJUnderlineAttribute UnderLine { get; set; }

        // @property (nonatomic, strong) SJUnderlineAttribute * _Nullable strikethrough;
        [NullAllowed, Export("strikethrough", ArgumentSemantic.Strong)]
        SJUnderlineAttribute Strikethrough { get; set; }

        // @property (nonatomic, strong) SJStrokeAttribute * _Nullable stroke;
        [NullAllowed, Export("stroke", ArgumentSemantic.Strong)]
        SJStrokeAttribute Stroke { get; set; }

        // @property (nonatomic) double obliqueness;
        [Export("obliqueness")]
        double Obliqueness { get; set; }

        // @property (nonatomic) double letterSpacing;
        [Export("letterSpacing")]
        double LetterSpacing { get; set; }

        // @property (nonatomic) double offset;
        [Export("offset")]
        double Offset { get; set; }

        // @property (nonatomic) BOOL link;
        [Export("link")]
        bool Link { get; set; }

        // @property (nonatomic, strong, null_resettable) NSMutableParagraphStyle * _Null_unspecified paragraphStyleM;
        [NullAllowed, Export("paragraphStyleM", ArgumentSemantic.Strong)]
        NSMutableParagraphStyle ParagraphStyleM { get; set; }

        // @property (nonatomic) double lineSpacing;
        [Export("lineSpacing")]
        double LineSpacing { get; set; }

        // @property (nonatomic) double paragraphSpacing;
        [Export("paragraphSpacing")]
        double ParagraphSpacing { get; set; }

        // @property (nonatomic) double paragraphSpacingBefore;
        [Export("paragraphSpacingBefore")]
        double ParagraphSpacingBefore { get; set; }

        // @property (nonatomic) double firstLineHeadIndent;
        [Export("firstLineHeadIndent")]
        double FirstLineHeadIndent { get; set; }

        // @property (nonatomic) double headIndent;
        [Export("headIndent")]
        double HeadIndent { get; set; }

        // @property (nonatomic) double tailIndent;
        [Export("tailIndent")]
        double TailIndent { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable alignment;
        [NullAllowed, Export("alignment", ArgumentSemantic.Strong)]
        NSNumber Alignment { get; set; }

        // @property (nonatomic) NSLineBreakMode lineBreakMode;
        [Export("lineBreakMode", ArgumentSemantic.Assign)]
        UILineBreakMode LineBreakMode { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJAttributesRecorder * _Nonnull) propertyDidChangeExeBlock;
        [NullAllowed, Export("propertyDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJAttributesRecorder> PropertyDidChangeExeBlock { get; set; }
    }

    // @interface SJAttributesRangeOperator : NSObject
    [BaseType(typeof(NSObject))]
    interface SJAttributesRangeOperator
    {
        // -(instancetype _Nonnull)initWithRange:(NSRange)range target:(NSMutableAttributedString * _Nonnull)attrStr;
        [Export("initWithRange:target:")]
        NativeHandle Constructor(NSRange range, NSMutableAttributedString attrStr);

        // -(instancetype _Nonnull)initWithRecorder:(SJAttributesRecorder * _Nonnull)recorder target:(NSMutableAttributedString * _Nonnull)attrStr;
        [Export("initWithRecorder:target:")]
        NativeHandle Constructor(SJAttributesRecorder recorder, NSMutableAttributedString attrStr);
    }

    // @interface SJAttributeWorker : SJAttributesRangeOperator
    [BaseType(typeof(SJAttributesRangeOperator))]
    interface SJAttributeWorker
    {
        // @property (readonly, nonatomic) NSRange range;
        [Export("range")]
        NSRange Range();

        // @property (readonly, nonatomic) NSMutableAttributedString * _Nonnull workInProcess;
        [Export("workInProcess")]
        NSMutableAttributedString WorkInProcess();

        // -(NSMutableAttributedString * _Nonnull)endTask;
        [Export("endTask")]
        //[Verify(MethodToProperty)]
        NSMutableAttributedString EndTask();

        // -(NSMutableAttributedString * _Nonnull)endTaskAndComplete:(void (^ _Nonnull)(SJAttributeWorker * _Nonnull))block;
        [Export("endTaskAndComplete:")]
        NSMutableAttributedString EndTaskAndComplete(SJAttributeWorkerArgumentAction block);

        // @property (nonatomic, strong, null_resettable) UIFont * _Null_unspecified defaultFont;
        [NullAllowed, Export("defaultFont", ArgumentSemantic.Strong)]
        UIFont DefaultFont { get; set; }

        // @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified defaultTextColor;
        [NullAllowed, Export("defaultTextColor", ArgumentSemantic.Strong)]
        UIColor DefaultTextColor { get; set; }

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSRange, void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) rangeEdit;
        [Export("rangeEdit", ArgumentSemantic.Copy)]
        Func<NSRange, SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> RangeEdit();

        // @property (readonly, copy, nonatomic) NSAttributedString * _Nonnull (^ _Nonnull)(NSRange) subAttrStr;
        [Export("subAttrStr", ArgumentSemantic.Copy)]
        Func<NSRange, NSAttributedString> SubAttrStr();

        // @property (readonly, nonatomic) NSInteger length;
        [Export("length")]
        nint Length();
    }

    // @interface Regexp (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Regexp
    {
        // @property (readwrite, nonatomic) NSRegularExpressionOptions regexpOptions;
        [Export("regexpOptions")]
        NSRegularExpressionOptions GetRegexpOptions();

        [Export("setregexpOptions:")]
        void SetRegexpOptions(NSRegularExpressionOptions options);

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) regexp;
        [Export("regexp", ArgumentSemantic.Copy)]
        Func<NSString, SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> Regexp();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, void (^ _Nonnull)(NSArray<NSValue *> * _Nonnull), BOOL) regexp_r;
        [Export("regexp_r", ArgumentSemantic.Copy)]
        Func<NSString, NSArrayNSValueArgumentAction, bool, SJAttributeWorker> Regexp_r();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSString * _Nonnull, id _Nonnull, ...) regexp_replace;
        [Export("regexp_replace", ArgumentSemantic.Copy)]
        Action<NSString, NSObject, IntPtr> Regexp_replace();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSString * _Nonnull, SJAttributeRegexpInsertPosition, id _Nonnull, ...) regexp_insert;
        [Export("regexp_insert", ArgumentSemantic.Copy)]
        Action<NSString, SJAttributeRegexpInsertPosition, NSObject, IntPtr> Regexp_insert();
    }

    // @interface Size (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Size
    {
        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(void) size;
        [Export("size", ArgumentSemantic.Copy)]
        Func<CGSize> Size();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(NSRange) sizeByRange;
        [Export("sizeByRange", ArgumentSemantic.Copy)]
        Func<NSRange, CGSize> SizeByRange();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(double) sizeByWidth;
        [Export("sizeByWidth", ArgumentSemantic.Copy)]
        Func<double, CGSize> SizeByWidth();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(double) sizeByHeight;
        [Export("sizeByHeight", ArgumentSemantic.Copy)]
        Func<double, CGSize> SizeByHeight();
    }

    // @interface Insert (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Insert
    {
        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(id _Nonnull, ...) append;
        [Export("append", ArgumentSemantic.Copy)]
        Func<NSObject, IntPtr, SJAttributesRangeOperator> Append();

        // @property (readonly, nonatomic) NSRange lastInsertedRange;
        [Export("lastInsertedRange")]
        NSRange LastInsertedRange();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) lastInserted;
        [Export("lastInserted", ArgumentSemantic.Copy)]
        Func<SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> LastInserted();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSAttributedStringKey _Nonnull, id _Nonnull, NSRange) add;
        [Export("add", ArgumentSemantic.Copy)]
        Func<NSString, NSObject, NSRange, SJAttributeWorker> Add();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, NSInteger) insertText;
        [Export("insertText", ArgumentSemantic.Copy)]
        Func<NSString, nint, SJAttributeWorker> InsertText();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(UIImage * _Nonnull, NSInteger, CGPoint, CGSize) insertImage;
        [Export("insertImage", ArgumentSemantic.Copy)]
        Func<UIImage, nint, CGPoint, CGSize, SJAttributeWorker> InsertImage();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSAttributedString * _Nonnull, NSInteger) insertAttrStr;
        [Export("insertAttrStr", ArgumentSemantic.Copy)]
        Func<NSAttributedString, nint, SJAttributeWorker> InsertAttrStr();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(id _Nonnull, NSInteger, ...) insert;
        [Export("insert", ArgumentSemantic.Copy)]
        Func<NSObject, nint, IntPtr, SJAttributeWorker> Insert();
    }

    // @interface Replace (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Replace
    {
        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange, id _Nonnull, ...) replace;
        [Export("replace", ArgumentSemantic.Copy)]
        Action<NSRange, NSObject, IntPtr> Replace();
    }

    // @interface Delete (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Delete
    {
        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange) removeText;
        [Export("removeText", ArgumentSemantic.Copy)]
        Action<NSRange> RemoveText();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSAttributedStringKey _Nonnull, NSRange) removeAttribute;
        [Export("removeAttribute", ArgumentSemantic.Copy)]
        Action<NSString, NSRange> RemoveAttribute();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange) removeAttributes;
        [Export("removeAttributes", ArgumentSemantic.Copy)]
        Action<NSRange> RemoveAttributes();
    }

    // @interface Property (SJAttributesRangeOperator)
    [Category]
    [BaseType(typeof(SJAttributesRangeOperator))]
    interface SJAttributesRangeOperator_Property
    {
        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIFont * _Nonnull) font;
        [Export("font", ArgumentSemantic.Copy)]
        Func<UIFont, SJAttributesRangeOperator> Font();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull) textColor;
        [Export("textColor", ArgumentSemantic.Copy)]
        Func<UIColor, SJAttributesRangeOperator> TextColor();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) expansion;
        [Export("expansion", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Expansion();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(CGSize, CGFloat, UIColor * _Nonnull) shadow;
        [Export("shadow", ArgumentSemantic.Copy)]
        Func<CGSize, nfloat, UIColor, SJAttributesRangeOperator> Shadow();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull) backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Copy)]
        Func<UIColor, SJAttributesRangeOperator> BackgroundColor();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSUnderlineStyle, UIColor * _Nonnull) underLine;
        [Export("underLine", ArgumentSemantic.Copy)]
        Func<NSUnderlineStyle, UIColor, SJAttributesRangeOperator> UnderLine();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSUnderlineStyle, UIColor * _Nonnull) strikethrough;
        [Export("strikethrough", ArgumentSemantic.Copy)]
        Func<NSUnderlineStyle, UIColor, SJAttributesRangeOperator> Strikethrough();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull, double) stroke;
        [Export("stroke", ArgumentSemantic.Copy)]
        Func<UIColor, double, SJAttributesRangeOperator> Stroke();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) obliqueness;
        [Export("obliqueness", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Obliqueness();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) letterSpacing;
        [Export("letterSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> LetterSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) offset;
        [Export("offset", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Offset();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(void) isLink;
        [Export("isLink", ArgumentSemantic.Copy)]
        Func<SJAttributesRangeOperator> IsLink();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSParagraphStyle * _Nonnull) paragraphStyle;
        [Export("paragraphStyle", ArgumentSemantic.Copy)]
        Func<NSParagraphStyle, SJAttributesRangeOperator> ParagraphStyle();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) lineSpacing;
        [Export("lineSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> LineSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) paragraphSpacing;
        [Export("paragraphSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> ParagraphSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) paragraphSpacingBefore;
        [Export("paragraphSpacingBefore", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> ParagraphSpacingBefore();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) firstLineHeadIndent;
        [Export("firstLineHeadIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> FirstLineHeadIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) headIndent;
        [Export("headIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> HeadIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) tailIndent;
        [Export("tailIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> TailIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSTextAlignment) alignment;
        [Export("alignment", ArgumentSemantic.Copy)]
        Func<UITextAlignment, SJAttributesRangeOperator> Alignment();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSLineBreakMode) lineBreakMode;
        [Export("lineBreakMode", ArgumentSemantic.Copy)]
        Func<UILineBreakMode, SJAttributesRangeOperator> LineBreakMode();
    }

    // @interface SJUTStroke : NSObject <SJUTStroke>
    [BaseType(typeof(NSObject))]
    interface SJUTStroke : ISJUTStroke
    {
        // @property (nonatomic, strong) UIColor * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @property (nonatomic) float width;
        [Export("width")]
        float Width { get; set; }
    }

    // @interface SJUTDecoration : NSObject <SJUTDecoration>
    [BaseType(typeof(NSObject))]
    interface SJUTDecoration : ISJUTDecoration
    {
        // @property (nonatomic, strong) UIColor * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @property (nonatomic) NSUnderlineStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        NSUnderlineStyle Style { get; set; }
    }

    // @interface SJUTImageAttachment : NSObject <SJUTImageAttachment>
    [BaseType(typeof(NSObject))]
    interface SJUTImageAttachment : ISJUTImageAttachment
    {
        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic) CGRect bounds;
        [Export("bounds", ArgumentSemantic.Assign)]
        CGRect Bounds { get; set; }

        // @property (nonatomic) SJUTVerticalAlignment alignment;
        [Export("alignment", ArgumentSemantic.Assign)]
        SJUTVerticalAlignment Alignment { get; set; }
    }

    // @interface SJUTReplace : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTReplace
    {
        // @property (nonatomic, strong) NSString * _Nullable fromString;
        [NullAllowed, Export("fromString", ArgumentSemantic.Strong)]
        string FromString { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) block;
        [NullAllowed, Export("block", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction Block { get; set; }
    }

    // @interface SJUTRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRecorder
    {
        // -(void)setValue:(id _Nullable)value forAttributeKey:(NSString * _Nonnull)key;
        [Export("setValue:forAttributeKey:")]
        void SetValue(NSObject value, string key);

        // -(void)setValuesForAttributeKeysWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)keyedValues;
        [Export("setValuesForAttributeKeysWithDictionary:")]
        void SetValuesForAttributeKeysWithDictionary(NSDictionary<NSString, NSObject> keyedValues);

        // -(NSDictionary<NSAttributedStringKey,id> * _Nonnull)textAttributes;
        [Export("textAttributes")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> TextAttributes();

        // -(NSParagraphStyle * _Nonnull)paragraphAttributesForStyle:(NSParagraphStyle * _Nullable)style;
        [Export("paragraphAttributesForStyle:")]
        NSParagraphStyle ParagraphAttributesForStyle(NSParagraphStyle style);

        // -(NSDictionary<NSAttributedStringKey,id> * _Nonnull)customAttributes;
        [Export("customAttributes")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> CustomAttributes();

        // -(void)setValuesForCommonRecorder:(SJUTRecorder * _Nonnull)common;
        [Export("setValuesForCommonRecorder:")]
        void SetValuesForCommonRecorder(SJUTRecorder common);

        // -(void)setValuesForAttributedString:(NSAttributedString * _Nonnull)attributedString;
        [Export("setValuesForAttributedString:")]
        void SetValuesForAttributedString(NSAttributedString attributedString);
    }

    // @interface SJUTAttributes : NSObject <SJUTAttributesProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTAttributes : SJUTAttributesProtocol
    {
        // @property (readonly, nonatomic, strong) SJUTRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRecorder Recorder();
    }

    // @interface SJUIKitTextMaker : SJUTAttributes <SJUIKitTextMakerProtocol>
    [BaseType(typeof(SJUTAttributes))]
    interface SJUIKitTextMaker : SJUIKitTextMakerProtocol
    {
        // -(NSMutableAttributedString * _Nonnull)install;
        [Export("install")]
        //[Verify(MethodToProperty)]
        NSMutableAttributedString Install();
    }

    // @interface SJUTRangeHandler : NSObject <SJUTRangeHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTRangeHandler : SJUTRangeHandlerProtocol
    {
        // -(instancetype _Nonnull)initWithRange:(NSRange)range;
        [Export("initWithRange:")]
        NativeHandle Constructor(NSRange range);

        // @property (readonly, nonatomic, strong) SJUTRangeRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRangeRecorder Recorder();
    }

    // @interface SJUTRangeRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRangeRecorder
    {
        // @property (nonatomic) NSRange range;
        [Export("range", ArgumentSemantic.Assign)]
        NSRange Range { get; set; }

        // @property (nonatomic, strong) id<SJUTAttributesProtocol> _Nullable utOfReplaceWithString;
        [NullAllowed, Export("utOfReplaceWithString", ArgumentSemantic.Strong)]
        SJUTAttributesProtocol UtOfReplaceWithString { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) replaceWithText;
        [NullAllowed, Export("replaceWithText", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction ReplaceWithText { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUTAttributesProtocol> _Nonnull) update;
        [NullAllowed, Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocol> Update { get; set; }
    }

    // @interface SJUTRegexHandler : NSObject <SJUTRegexHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTRegexHandler : SJUTRegexHandlerProtocol
    {
        // -(instancetype _Nonnull)initWithRegex:(NSString * _Nonnull)regex;
        [Export("initWithRegex:")]
        NativeHandle Constructor(string regex);

        // @property (readonly, nonatomic, strong) SJUTRegexRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRegexRecorder Recorder();
    }

    // @interface SJUTRegexRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRegexRecorder
    {
        // @property (nonatomic) NSRegularExpressionOptions regularExpressionOptions;
        [Export("regularExpressionOptions", ArgumentSemantic.Assign)]
        NSRegularExpressionOptions RegularExpressionOptions { get; set; }

        // @property (nonatomic) NSMatchingOptions matchingOptions;
        [Export("matchingOptions", ArgumentSemantic.Assign)]
        NSMatchingOptions MatchingOptions { get; set; }

        // @property (nonatomic, strong) id<SJUTAttributesProtocol> _Nullable utOfReplaceWithString;
        [NullAllowed, Export("utOfReplaceWithString", ArgumentSemantic.Strong)]
        SJUTAttributesProtocol UtOfReplaceWithString { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable regex;
        [NullAllowed, Export("regex")]
        string Regex { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) replaceWithText;
        [NullAllowed, Export("replaceWithText", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction ReplaceWithText { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUTAttributesProtocol> _Nonnull) update;
        [NullAllowed, Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocol> Update { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSMutableAttributedString * _Nonnull, NSTextCheckingResult * _Nonnull) handler;
        [NullAllowed, Export("handler", ArgumentSemantic.Copy)]
        Action<NSMutableAttributedString, NSTextCheckingResult> Handler { get; set; }
    }

    // typedef void (^SJDeallockCallbackTask)(id _Nonnull);
    delegate void SJDeallockCallbackTask(NSObject arg0);

    // typedef void (^SJKVOObservedChangeHandler)(id _Nonnull, NSDictionary<NSKeyValueChangeKey,id> * _Nullable);
    delegate void SJKVOObservedChangeHandler(NSObject arg0, NSDictionary<NSString, NSObject> arg1);

    // @interface SJKVOHelper (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJKVOHelper
    {
        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath;
        [Export("sj_addObserver:forKeyPath:")]
        void Sj_addObserver(NSObject observer, string keyPath);

        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath context:(void * _Nullable)context;
        [Export("sj_addObserver:forKeyPath:context:")]
        unsafe void Sj_addObserver(NSObject observer, string keyPath, NSObject context);

        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath options:(NSKeyValueObservingOptions)options context:(void * _Nullable)context;
        [Export("sj_addObserver:forKeyPath:options:context:")]
        unsafe void Sj_addObserver(NSObject observer, string keyPath, NSKeyValueObservingOptions options, NSObject context);
    }

    // @interface SJNotificationHelper (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJNotificationHelper
    {
        // -(void)sj_observeWithNotification:(NSNotificationName _Nonnull)notification target:(id _Nullable)sender usingBlock:(void (^ _Nonnull)(id _Nonnull, NSNotification * _Nonnull))block;
        [Export("sj_observeWithNotification:target:usingBlock:")]
        void Sj_observeWithNotification(string notification, NSObject sender, Action<NSObject, NSNotification> block);

        // -(void)sj_observeWithNotification:(NSNotificationName _Nonnull)notification target:(id _Nullable)sender queue:(NSOperationQueue * _Nullable)queue usingBlock:(void (^ _Nonnull)(id _Nonnull, NSNotification * _Nonnull))block;
        [Export("sj_observeWithNotification:target:queue:usingBlock:")]
        void Sj_observeWithNotification(string notification, NSObject sender, NSOperationQueue queue, Action<NSObject, NSNotification> block);
    }

    // @interface SJDeallocCallback (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJDeallocCallback
    {
        // -(void)sj_addDeallocCallbackTask:(SJDeallockCallbackTask _Nonnull)callback;
        [Export("sj_addDeallocCallbackTask:")]
        void Sj_addDeallocCallbackTask(SJDeallockCallbackTask callback);
    }

    // @interface SJPresentationQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPresentationQueue
    {
        // +(void)enqueueToPresent:(UIView<SJPresentViewProtocol> * _Nonnull)presentView sourceView:(UIView * _Nonnull)sourceView;
        [Static]
        [Export("enqueueToPresent:sourceView:")]
        void EnqueueToPresent(SJPresentViewProtocol presentView, UIView sourceView);
    }

    // @protocol SJPresentViewProtocol <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJPresentViewProtocol
    {
        // @required @property (readonly, nonatomic) SJPresentationPriority priority;
        [Abstract]
        [Export("priority")]
        SJPresentationPriority Priority();

        // @required -(void)showInSourceView:(UIView * _Nonnull)source dismissedCallback:(void (^ _Nonnull)(void))callback;
        [Abstract]
        [Export("showInSourceView:dismissedCallback:")]
        void DismissedCallback(UIView source, Action callback);
    }

    // audit-objc-generics: @interface SJQueue<__covariant ObjectType> : NSObject
    [BaseType(typeof(NSObject))]
    interface SJQueue
    {
        // +(instancetype _Nonnull)queue;
        [Static]
        [Export("queue")]
        SJQueue Queue();

        // @property (readonly, nonatomic) NSInteger size;
        [Export("size")]
        nint Size();

        // @property (readonly, nonatomic, strong) ObjectType _Nullable firstObject;
        [NullAllowed, Export("firstObject", ArgumentSemantic.Strong)]
        NSObject FirstObject();

        // @property (readonly, nonatomic, strong) ObjectType _Nullable lastObject;
        [NullAllowed, Export("lastObject", ArgumentSemantic.Strong)]
        NSObject LastObject();

        // -(void)enqueue:(ObjectType _Nonnull)obj;
        [Export("enqueue:")]
        void Enqueue(NSObject obj);

        // -(ObjectType _Nullable)dequeue;
        [NullAllowed, Export("dequeue")]
        //[Verify(MethodToProperty)]
        NSObject Dequeue();

        // -(void)empty;
        [Export("empty")]
        void Empty();
    }

    // audit-objc-generics: @interface SJSafeQueue<__covariant ObjectType> : SJQueue
    [BaseType(typeof(SJQueue))]
    interface SJSafeQueue
    {
    }

    // typedef void (^SJRunLoopTaskHandler)();
    delegate void SJRunLoopTaskHandler();

    // @interface SJRunLoopTaskQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJRunLoopTaskQueue
    {
        // @property (readonly, copy, nonatomic, class) SJRunLoopTaskQueue * _Nonnull (^ _Nonnull)(NSString * _Nonnull) queue;
        [Static]
        [Export("queue", ArgumentSemantic.Copy)]
        Func<NSString, SJRunLoopTaskQueue> Queue();

        // @property (readonly, copy, nonatomic, class) SJRunLoopTaskQueue * _Nonnull main;
        [Static]
        [Export("main", ArgumentSemantic.Copy)]
        SJRunLoopTaskQueue Main();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(NSString * _Nonnull) destroy;
        [Static]
        [Export("destroy", ArgumentSemantic.Copy)]
        Action<NSString> Destroy();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(NSUInteger) delay;
        [Export("delay", ArgumentSemantic.Copy)]
        Func<nuint, SJRunLoopTaskQueue> Delay();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(CFRunLoopRef _Nonnull, CFRunLoopMode _Nonnull) update;
        [Export("update", ArgumentSemantic.Copy)]
        unsafe Func<CFRunLoop, NSString, SJRunLoopTaskQueue> Update();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(SJRunLoopTaskHandler _Nonnull) enqueue;
        [Export("enqueue", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskHandler, SJRunLoopTaskQueue> Enqueue();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(void) dequeue;
        [Export("dequeue", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskQueue> Dequeue();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(void) empty;
        [Export("empty", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskQueue> Empty();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(void) destroy;
        //[Export("destroy", ArgumentSemantic.Copy)]
        //Action Destroy();

        // @property (readonly, nonatomic, strong) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name();

        // @property (readonly, nonatomic) NSInteger count;
        [Export("count")]
        nint Count();
    }

    // typedef void (^SJTaskHandler)();
    delegate void SJTaskHandler();

    // @interface SJTaskQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJTaskQueue
    {
        // @property (readonly, copy, nonatomic, class) SJTaskQueue * _Nonnull (^ _Nonnull)(NSString * _Nonnull) queue;
        [Static]
        [Export("queue", ArgumentSemantic.Copy)]
        Func<NSString, SJTaskQueue> Queue();

        // @property (readonly, copy, nonatomic, class) SJTaskQueue * _Nonnull main;
        [Static]
        [Export("main", ArgumentSemantic.Copy)]
        SJTaskQueue Main();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(NSString * _Nonnull) destroy;
        [Static]
        [Export("destroy", ArgumentSemantic.Copy)]
        Action<NSString> Destroy();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(NSTimeInterval) delay;
        [Export("delay", ArgumentSemantic.Copy)]
        Func<double, SJTaskQueue> Delay();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(SJTaskHandler _Nonnull) enqueue;
        [Export("enqueue", ArgumentSemantic.Copy)]
        Func<SJTaskHandler, SJTaskQueue> Enqueue();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(void) dequeue;
        [Export("dequeue", ArgumentSemantic.Copy)]
        Func<SJTaskQueue> Dequeue();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(void) empty;
        [Export("empty", ArgumentSemantic.Copy)]
        Func<SJTaskQueue> Empty();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(void) destroy;
        //[Export("destroy", ArgumentSemantic.Copy)]
        //Action Destroy();

        // @property (readonly, nonatomic, strong) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name();

        // @property (readonly, nonatomic) NSInteger count;
        [Export("count")]
        nint Count();
    }

    // @interface SJSQLiteColumnInfo : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SJSQLiteColumnInfo : INSCopying
    {
        // @property (copy, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable type;
        [NullAllowed, Export("type")]
        string Type { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable constraints;
        [NullAllowed, Export("constraints")]
        string Constraints { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable property;
        [NullAllowed, Export("property")]
        string Property { get; set; }

        // @property (nonatomic) BOOL isModelArray;
        [Export("isModelArray")]
        bool IsModelArray { get; set; }

        // @property (nonatomic) BOOL isJsonString;
        [Export("isJsonString")]
        bool IsJsonString { get; set; }

        // @property (nonatomic) BOOL isPrimaryKey;
        [Export("isPrimaryKey")]
        bool IsPrimaryKey { get; set; }

        // @property (nonatomic) BOOL isAutoincrement;
        [Export("isAutoincrement")]
        bool IsAutoincrement { get; set; }
    }

    // @interface SJSQLiteTableInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLiteTableInfo : ObjCRuntime.INativeObject
    {
        // +(instancetype _Nullable)tableInfoWithClass:(Class<SJSQLiteTableModelProtocol> _Nonnull)cls;
        [Static]
        [Export("tableInfoWithClass:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo TableInfoWithClass(SJSQLiteTableModelProtocol cls);

        // @property (readonly, nonatomic) Class _Nonnull cls;
        [Export("cls")]
        Class Cls();

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name();

        // @property (readonly, copy, nonatomic) NSString * _Nonnull primaryKey;
        [Export("primaryKey")]
        string PrimaryKey();

        // @property (readonly, copy, nonatomic) NSArray<SJSQLiteColumnInfo *> * _Nullable columns;
        [NullAllowed, Export("columns", ArgumentSemantic.Copy)]
        SJSQLiteColumnInfo[] Columns();

        // @property (readonly, copy, nonatomic) NSDictionary<SJSQLiteColumnInfo *,SJSQLiteTableInfo *> * _Nullable columnAssociatedTableInfos;
        [NullAllowed, Export("columnAssociatedTableInfos", ArgumentSemantic.Copy)]
        NSDictionary<SJSQLiteColumnInfo, SJSQLiteTableInfo> ColumnAssociatedTableInfos();

        // @property (readonly, copy, nonatomic) NSSet<Class> * _Nonnull allClasses;
        [Export("allClasses", ArgumentSemantic.Copy)]
        NSSet<Class> AllClasses();

        // -(SJSQLiteColumnInfo * _Nullable)columnInfoForProperty:(NSString * _Nonnull)key;
        [Export("columnInfoForProperty:")]
        //[return: NullAllowed]
        SJSQLiteColumnInfo ColumnInfoForProperty(string key);

        // -(SJSQLiteColumnInfo * _Nullable)columnInfoForColumnName:(NSString * _Nonnull)key;
        [Export("columnInfoForColumnName:")]
        //[return: NullAllowed]
        SJSQLiteColumnInfo ColumnInfoForColumnName(string key);
    }

    // @interface SJSQLiteTableInfoExtended (SJSQLiteColumnInfo)
    [Category]
    [BaseType(typeof(SJSQLiteColumnInfo))]
    interface SJSQLiteColumnInfo_SJSQLiteTableInfoExtended
    {
        // @property (readonly, nonatomic, strong) SJSQLiteTableInfo * _Nullable associatedTableInfo;
        [NullAllowed, Export("associatedTableInfo", ArgumentSemantic.Strong)]
        SJSQLiteTableInfo AssociatedTableInfo();
    }

    // @interface SJSQLiteObjectInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLiteObjectInfo
    {
        // +(instancetype _Nullable)objectInfoWithObject:(id _Nonnull)obj tableInfo:(SJSQLiteTableInfo * _Nonnull)tableInfo;
        [Static]
        [Export("objectInfoWithObject:tableInfo:")]
        //[return: NullAllowed]
        SJSQLiteObjectInfo ObjectInfoWithObject(NSObject obj, SJSQLiteTableInfo tableInfo);

        // @property (readonly, nonatomic, strong) id _Nonnull obj;
        [Export("obj", ArgumentSemantic.Strong)]
        NSObject Obj();

        // @property (readonly, nonatomic, strong) SJSQLiteTableInfo * _Nonnull table;
        [Export("table", ArgumentSemantic.Strong)]
        SJSQLiteTableInfo Table();

        // @property (readonly, nonatomic, strong) SJSQLiteColumnInfo * _Nonnull primaryKeyColumnInfo;
        [Export("primaryKeyColumnInfo", ArgumentSemantic.Strong)]
        SJSQLiteColumnInfo PrimaryKeyColumnInfo();

        // @property (readonly, copy, nonatomic) NSArray<SJSQLiteColumnInfo *> * _Nullable autoincrementColumns;
        [NullAllowed, Export("autoincrementColumns", ArgumentSemantic.Copy)]
        SJSQLiteColumnInfo[] AutoincrementColumns();
    }

    // @interface SJSQLiteObjectInfoExtended (SJSQLiteColumnInfo)
    [Category]
    [BaseType(typeof(SJSQLiteColumnInfo))]
    interface SJSQLiteColumnInfo_SJSQLiteObjectInfoExtended
    {
        // @property (readonly, nonatomic, strong) NSArray<SJSQLiteObjectInfo *> * _Nullable associatedObjectInfos;
        [NullAllowed, Export("associatedObjectInfos", ArgumentSemantic.Strong)]
        SJSQLiteObjectInfo[] AssociatedObjectInfos();
    }

    // @interface SJSQLite3CoreExtended (NSMutableString)
    [Category]
    [BaseType(typeof(NSMutableString))]
    interface NSMutableString_SJSQLite3CoreExtended
    {
        // -(void)sjsql_deleteSuffix:(NSString * _Nonnull)str;
        [Export("sjsql_deleteSuffix:")]
        void Sjsql_deleteSuffix(string str);
    }

    // @protocol SJSQLiteTableModelProtocol <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJSQLiteTableModelProtocol : ObjCRuntime.INativeObject
    {
        // @required +(NSString * _Nullable)sql_primaryKey;
        [Static, Abstract]
        [NullAllowed, Export("sql_primaryKey")]
        //[Verify(MethodToProperty)]
        string Sql_primaryKey();

        // @optional +(NSArray<NSString *> * _Nullable)sql_autoincrementlist;
        [Static]
        [NullAllowed, Export("sql_autoincrementlist")]
        //[Verify(MethodToProperty)]
        string[] Sql_autoincrementlist();

        // @optional +(NSDictionary<NSString *,Class> * _Nullable)sql_arrayPropertyGenericClass;
        [Static]
        [NullAllowed, Export("sql_arrayPropertyGenericClass")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, Class> Sql_arrayPropertyGenericClass();

        // @optional +(NSDictionary<NSString *,NSString *> * _Nullable)sql_customKeyMapper;
        [Static]
        [NullAllowed, Export("sql_customKeyMapper")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> Sql_customKeyMapper();

        // @optional +(NSArray<NSString *> * _Nullable)sql_uniquelist;
        [Static]
        [NullAllowed, Export("sql_uniquelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_uniquelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_whitelist;
        [Static]
        [NullAllowed, Export("sql_whitelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_whitelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_blacklist;
        [Static]
        [NullAllowed, Export("sql_blacklist")]
        //[Verify(MethodToProperty)]
        string[] Sql_blacklist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_notnulllist;
        [Static]
        [NullAllowed, Export("sql_notnulllist")]
        //[Verify(MethodToProperty)]
        string[] Sql_notnulllist();

        // @optional +(NSString * _Nullable)sql_tableName;
        [Static]
        [NullAllowed, Export("sql_tableName")]
        //[Verify(MethodToProperty)]
        string Sql_tableName();
    }

    // @interface SJSQLite3 : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3 Shared();

        // -(instancetype _Nullable)initWithDatabasePath:(NSString * _Nonnull)dbPath __attribute__((objc_designated_initializer));
        [Export("initWithDatabasePath:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string dbPath);

        // -(BOOL)save:(id _Nonnull)object error:(NSError * _Nullable * _Nullable)error;
        [Export("save:error:")]
        bool Save(NSObject @object, out NSError error);

        // -(BOOL)saveObjects:(NSArray * _Nonnull)objectArray error:(NSError * _Nullable * _Nullable)error;
        [Export("saveObjects:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool SaveObjects(NSObject[] objectArray, out NSError error);

        // -(BOOL)update:(id _Nonnull)object forKeys:(NSArray<NSString *> * _Nonnull)properties error:(NSError * _Nullable * _Nullable)error;
        [Export("update:forKeys:error:")]
        bool Update(NSObject @object, string[] properties, out NSError error);

        // -(BOOL)update:(id _Nonnull)object forKey:(NSString * _Nonnull)property error:(NSError * _Nullable * _Nullable)error;
        [Export("update:forKey:error:")]
        bool Update(NSObject @object, string property, out NSError error);

        // -(BOOL)updateObjects:(NSArray * _Nonnull)objectArray forKeys:(NSArray<NSString *> * _Nonnull)properties error:(NSError * _Nullable * _Nullable)error;
        [Export("updateObjects:forKeys:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool UpdateObjects(NSObject[] objectArray, string[] properties, out NSError error);

        // -(id _Nullable)objectForClass:(Class _Nonnull)cls primaryKeyValue:(id _Nonnull)value error:(NSError * _Nullable * _Nullable)error;
        [Export("objectForClass:primaryKeyValue:error:")]
        //[return: NullAllowed]
        NSObject ObjectForClass(Class cls, NSObject value, out NSError error);

        // -(BOOL)removeAllObjectsForClass:(Class _Nonnull)cls error:(NSError * _Nullable * _Nullable)error;
        [Export("removeAllObjectsForClass:error:")]
        bool RemoveAllObjectsForClass(Class cls, out NSError error);

        // -(BOOL)removeObjectsForClass:(Class _Nonnull)cls primaryKeyValues:(NSArray<id> * _Nonnull)values error:(NSError * _Nullable * _Nullable)error;
        [Export("removeObjectsForClass:primaryKeyValues:error:")]
        bool RemoveObjectsForClass(Class cls, NSObject[] values, out NSError error);

        // -(BOOL)removeObjectForClass:(Class _Nonnull)cls primaryKeyValue:(id _Nonnull)value error:(NSError * _Nullable * _Nullable)error;
        [Export("removeObjectForClass:primaryKeyValue:error:")]
        bool RemoveObjectForClass(Class cls, NSObject value, out NSError error);
    }

    // @interface FoundationExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_FoundationExtended
    {
        // -(BOOL)save:(id _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("save:forKey:error:")]
        bool Save(NSObject value, string key, out NSError error);

        // -(BOOL)setValue:(id _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setValue:forKey:error:")]
        bool SetValue(NSObject value, string key, out NSError error);

        // -(BOOL)setDictionary:(NSDictionary * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setDictionary:forKey:error:")]
        bool SetDictionary(NSDictionary value, string key, out NSError error);

        // -(BOOL)setArray:(NSArray * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setArray:forKey:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool SetArray(NSObject[] value, string key, out NSError error);

        // -(BOOL)setString:(NSString * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setString:forKey:error:")]
        bool SetString(string value, string key, out NSError error);

        // -(BOOL)setURL:(NSURL * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setURL:forKey:error:")]
        bool SetURL(NSUrl value, string key, out NSError error);

        // -(BOOL)setInteger:(NSInteger)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setInteger:forKey:error:")]
        bool SetInteger(nint value, string key, out NSError error);

        // -(BOOL)setDouble:(double)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setDouble:forKey:error:")]
        bool SetDouble(double value, string key, out NSError error);

        // -(BOOL)setFloat:(float)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setFloat:forKey:error:")]
        bool SetFloat(float value, string key, out NSError error);

        // -(BOOL)setBool:(BOOL)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setBool:forKey:error:")]
        bool SetBool(bool value, string key, out NSError error);

        // -(BOOL)removeValueForKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("removeValueForKey:error:")]
        bool RemoveValueForKey(string key, out NSError error);

        // -(id _Nullable)objectForKey:(NSString * _Nonnull)key objectClass:(Class _Nonnull)cls;
        [Export("objectForKey:objectClass:")]
        //[return: NullAllowed]
        NSObject ObjectForKey(string key, Class cls);

        // -(NSString * _Nullable)jsonStringForKey:(NSString * _Nonnull)key;
        [Export("jsonStringForKey:")]
        //[return: NullAllowed]
        string JsonStringForKey(string key);

        // -(NSDictionary * _Nullable)dictionaryForKey:(NSString * _Nonnull)key;
        [Export("dictionaryForKey:")]
        //[return: NullAllowed]
        NSDictionary DictionaryForKey(string key);

        // -(NSArray * _Nullable)arrayForKey:(NSString * _Nonnull)key;
        [Export("arrayForKey:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ArrayForKey(string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key;
        [Export("stringForKey:")]
        //[return: NullAllowed]
        string StringForKey(string key);

        // -(NSURL * _Nullable)URLForKey:(NSString * _Nonnull)key;
        [Export("URLForKey:")]
        //[return: NullAllowed]
        NSUrl URLForKey(string key);

        // -(NSInteger)integerForKey:(NSString * _Nonnull)key;
        [Export("integerForKey:")]
        nint IntegerForKey(string key);

        // -(double)doubleForKey:(NSString * _Nonnull)key;
        [Export("doubleForKey:")]
        double DoubleForKey(string key);

        // -(float)floatForKey:(NSString * _Nonnull)key;
        [Export("floatForKey:")]
        float FloatForKey(string key);

        // -(BOOL)boolForKey:(NSString * _Nonnull)key;
        [Export("boolForKey:")]
        bool BoolForKey(string key);
    }

    // @interface SJSQLite3TableClassCache : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3TableClassCache
    {
        // -(BOOL)containsClass:(Class _Nonnull)cls;
        [Export("containsClass:")]
        bool ContainsClass(Class cls);

        // -(void)addClass:(Class _Nonnull)cls;
        [Export("addClass:")]
        void AddClass(Class cls);

        // -(void)addClasses:(NSSet<Class> * _Nonnull)set;
        [Export("addClasses:")]
        void AddClasses(NSSet<Class> set);

        // -(void)removeClass:(Class _Nonnull)cls;
        [Export("removeClass:")]
        void RemoveClass(Class cls);

        // -(void)removeClasses:(NSSet<Class> * _Nonnull)set;
        [Export("removeClasses:")]
        void RemoveClasses(NSSet<Class> set);
    }

    // @interface Core (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_Core
    {
        // -(NSArray<SJSQLite3RowData *> * _Nullable)exec:(NSString * _Nonnull)sql error:(NSError * _Nullable * _Nullable)error;
        [Export("exec:error:")]
        //[return: NullAllowed]
        NSDictionary[] Exec(string sql, out NSError error);

        // -(NSArray<SJSQLite3RowData *> * _Nullable)execInTransaction:(NSString * _Nonnull)sql error:(NSError * _Nullable * _Nullable)error;
        [Export("execInTransaction:error:")]
        //[return: NullAllowed]
        NSDictionary[] ExecInTransaction(string sql, out NSError error);

        // -(void)execInTransaction:(BOOL (^ _Nonnull)(SJSQLite3 * _Nonnull))block;
        [Export("execInTransaction:")]
        void ExecInTransaction(Func<SJSQLite3, bool> block);

        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls rowDatas:(NSArray<SJSQLite3RowData *> * _Nonnull)rowDatas error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:rowDatas:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, NSDictionary[] rowDatas, out NSError error);

        // -(SJSQLiteTableInfo * _Nullable)tableInfoForClass:(Class _Nonnull)cls error:(NSError * _Nullable * _Nullable)error;
        [Export("tableInfoForClass:error:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo TableInfoForClass(Class cls, out NSError error);

        // -(SJSQLiteObjectInfo * _Nullable)objectInfoWithObject:(id _Nonnull)object error:(NSError * _Nullable * _Nullable)error;
        [Export("objectInfoWithObject:error:")]
        //[return: NullAllowed]
        SJSQLiteObjectInfo ObjectInfoWithObject(NSObject @object, out NSError error);

        // -(BOOL)containsTableForClass:(Class _Nonnull)cls;
        [Export("containsTableForClass:")]
        bool ContainsTableForClass(Class cls);
    }

    // @interface SJSQLite3Condition : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3Condition
    {
        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column relatedBy:(SJSQLite3Relation)relation value:(id _Nonnull)value;
        [Static]
        [Export("conditionWithColumn:relatedBy:value:")]
        SJSQLite3Condition ConditionWithColumn(string column, SJSQLite3Relation relation, NSObject value);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column value:(id _Nonnull)value;
        [Static]
        [Export("conditionWithColumn:value:")]
        SJSQLite3Condition ConditionWithColumn(string column, NSObject value);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column in:(NSArray * _Nonnull)values;
        [Static]
        [Export("conditionWithColumn:in:")]
        //[Verify(StronglyTypedNSArray)]
        SJSQLite3Condition ConditionWithColumn(string column, NSObject[] values);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column notIn:(NSArray * _Nonnull)values;
        [Static]
        [Export("conditionWithColumn:notIn:")]
        //[Verify(StronglyTypedNSArray)]
        SJSQLite3Condition ConditionWithColumnNotIn(string column, NSObject[] values);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column between:(id _Nonnull)start and:(id _Nonnull)end;
        [Static]
        [Export("conditionWithColumn:between:and:")]
        SJSQLite3Condition ConditionWithColumnBetween(string column, NSObject start, NSObject end);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column like:(NSString * _Nonnull)like;
        [Static]
        [Export("conditionWithColumn:like:")]
        SJSQLite3Condition ConditionWithColumnLike(string column, string like);

        // +(instancetype _Nonnull)conditionWithIsNullColumn:(NSString * _Nonnull)column;
        [Static]
        [Export("conditionWithIsNullColumn:")]
        SJSQLite3Condition ConditionWithIsNullColumn(string column);

        // -(instancetype _Nonnull)initWithCondition:(NSString * _Nonnull)condition;
        [Export("initWithCondition:")]
        NativeHandle Constructor(string condition);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull condition;
        [Export("condition")]
        string Condition();
    }

    // @interface SJSQLite3ColumnOrder : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3ColumnOrder
    {
        // +(instancetype _Nonnull)orderWithColumn:(NSString * _Nonnull)column ascending:(BOOL)ascending;
        [Static]
        [Export("orderWithColumn:ascending:")]
        SJSQLite3ColumnOrder OrderWithColumn(string column, bool ascending);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull order;
        [Export("order")]
        string Order();
    }

    // @interface QueryObjectsExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_QueryObjectsExtended
    {
        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:conditions:orderBy:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, out NSError error);

        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:conditions:orderBy:range:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range, out NSError error);

        // -(NSUInteger)countOfObjectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions error:(NSError * _Nullable * _Nullable)error;
        [Export("countOfObjectsForClass:conditions:error:")]
        nuint CountOfObjectsForClass(Class cls, SJSQLite3Condition[] conditions, out NSError error);
    }

    // @interface QueryDataExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_QueryDataExtended
    {
        // -(NSArray<NSDictionary *> * _Nullable)queryDataForClass:(Class _Nonnull)cls resultColumns:(NSArray<NSString *> * _Nullable)columns conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders error:(NSError * _Nullable * _Nullable)error;
        [Export("queryDataForClass:resultColumns:conditions:orderBy:error:")]
        //[return: NullAllowed]
        NSDictionary[] QueryDataForClass(Class cls, string[] columns, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, out NSError error);

        // -(NSArray<NSDictionary *> * _Nullable)queryDataForClass:(Class _Nonnull)cls resultColumns:(NSArray<NSString *> * _Nullable)columns conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range error:(NSError * _Nullable * _Nullable)error;
        [Export("queryDataForClass:resultColumns:conditions:orderBy:range:error:")]
        //[return: NullAllowed]
        NSDictionary[] QueryDataForClass(Class cls, string[] columns, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range, out NSError error);
    }

    // @interface RemoveExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_RemoveExtended
    {
        // -(BOOL)removeAllObjectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions error:(NSError * _Nullable * _Nullable)error;
        [Export("removeAllObjectsForClass:conditions:error:")]
        bool RemoveAllObjectsForClass(Class cls, SJSQLite3Condition[] conditions, out NSError error);
    }

    // @interface TableExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_TableExtended
    {
        // -(BOOL)containsColumn:(NSString * _Nonnull)column inTableForClass:(Class _Nonnull)cls;
        [Export("containsColumn:inTableForClass:")]
        bool ContainsColumn(string column, Class cls);
    }

    // @interface SJSQLite3Logger : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3Logger
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3Logger Shared();

        // @property (getter = isEnabledConsoleLog, nonatomic) BOOL enabledConsoleLog;
        [Export("enabledConsoleLog")]
        bool EnabledConsoleLog { [Bind("isEnabledConsoleLog")] get; set; }

        // -(void)addLog:(NSString * _Nonnull)format, ... __attribute__((format(NSString, 1, 2)));
        [Internal]
        [Export("addLog:", IsVariadic = true)]
        void AddLog(string format, IntPtr varArgs);
    }

    // @interface SJSQLite3TableInfoCache : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3TableInfoCache
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3TableInfoCache Shared();

        // -(SJSQLiteTableInfo * _Nullable)getTableInfoForClass:(Class _Nonnull)cls;
        [Export("getTableInfoForClass:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo GetTableInfoForClass(Class cls);
    }

    // @interface SJSQLiteTableModelConstraints : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLiteTableModelConstraints
    {
        // -(instancetype _Nonnull)initWithClass:(Class<SJSQLiteTableModelProtocol> _Nonnull)cls __attribute__((objc_designated_initializer));
        [Export("initWithClass:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SJSQLiteTableModelProtocol cls);

        // @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull objc_sysProperties;
        [Export("objc_sysProperties", ArgumentSemantic.Strong)]
        string[] Objc_sysProperties();

        // @property (nonatomic, strong) NSString * _Nullable sql_primaryKey;
        [NullAllowed, Export("sql_primaryKey", ArgumentSemantic.Strong)]
        string Sql_primaryKey { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_autoincrementlist;
        [NullAllowed, Export("sql_autoincrementlist", ArgumentSemantic.Strong)]
        string[] Sql_autoincrementlist { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,Class<SJSQLiteTableModelProtocol>> * _Nullable sql_arrayPropertyGenericClass;
        [NullAllowed, Export("sql_arrayPropertyGenericClass", ArgumentSemantic.Strong)]
        NSDictionary<NSString, SJSQLiteTableModelProtocol> Sql_arrayPropertyGenericClass { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nullable sql_customKeyMapper;
        [NullAllowed, Export("sql_customKeyMapper", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Sql_customKeyMapper { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_uniquelist;
        [NullAllowed, Export("sql_uniquelist", ArgumentSemantic.Strong)]
        string[] Sql_uniquelist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_whitelist;
        [NullAllowed, Export("sql_whitelist", ArgumentSemantic.Strong)]
        string[] Sql_whitelist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_blacklist;
        [NullAllowed, Export("sql_blacklist", ArgumentSemantic.Strong)]
        string[] Sql_blacklist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_notnulllist;
        [NullAllowed, Export("sql_notnulllist", ArgumentSemantic.Strong)]
        string[] Sql_notnulllist { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable sql_tableName;
        [NullAllowed, Export("sql_tableName", ArgumentSemantic.Strong)]
        string Sql_tableName { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double SJUIKitVersionNumber;
        [Field("SJUIKitVersionNumber", "__Internal")]
        double SJUIKitVersionNumber { get; }

        // extern const unsigned char[] SJUIKitVersionString;
        [Field("SJUIKitVersionString", "__Internal")]
        NSString SJUIKitVersionString { get; }
    }
    */
}
