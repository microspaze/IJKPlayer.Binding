//
//  UIScrollView+SJRefreshAdd.h
//  SJObjective-CTool_Example
//
//  Created by 畅三江 on 2016/5/28.
//  Copyright © 2018年 changsanjiang@gmail.com. All rights reserved.
//

#import <UIKit/UIKit.h>

/** 刷新控件的状态 */
typedef NS_ENUM(NSInteger, SJWrapRefreshState) {
    /** 普通闲置状态 */
    SJWrapRefreshStateIdle = 1,
    /** 松开就可以进行刷新的状态 */
    SJWrapRefreshStatePulling,
    /** 正在刷新中的状态 */
    SJWrapRefreshStateRefreshing,
    /** 即将刷新的状态 */
    SJWrapRefreshStateWillRefresh,
    /** 所有数据加载完毕，没有更多的数据了 */
    SJWrapRefreshStateNoMoreData
};

/// 此size用于标记请求不需要pageSize
/// 当不需要页码大小时, 可以传入此size
extern char const SJRefreshingNonePageSize;
@class SJRefreshConfig, SJPlaceholderView, SJRefreshOptions;

NS_ASSUME_NONNULL_BEGIN
@interface UIScrollView (SJSetupRefresh)
@property (nonatomic, readonly) SJWrapRefreshState sj_headerRefreshState;
@property (nonatomic, readonly) SJWrapRefreshState sj_footerRefreshState;

@property (nonatomic, readonly) NSInteger sj_beginPageNum;
@property (nonatomic, readonly) NSInteger sj_pageSize;
@property (nonatomic, readonly) NSInteger sj_pageNum;   // current PageNum

- (void)sj_setupRefreshingWithOptions:(SJRefreshOptions *)options;

- (void)sj_endRefreshing;
- (void)sj_endRefreshingWithItemCount:(NSUInteger)itemCount;

///

- (void)sj_exeHeaderRefreshing;
- (void)sj_exeHeaderRefreshingAnimated:(BOOL)animated;
- (void)sj_exeFooterRefreshing;

- (void)sj_resetState;

#pragma mark - deprecated

- (void)sj_setupRefreshingWithRefreshingBlock:(void(^)(__kindof UIScrollView *scrollView, NSInteger requestPageNum))refreshingBlock;
- (void)sj_setupRefreshingWithPageSize:(short)pageSize beginPageNum:(NSInteger)beginPageNum refreshingBlock:(void(^)(__kindof UIScrollView *scrollView, NSInteger requestPageNum))refreshingBlock;
- (void)sj_setupFooterRefreshingWithPageSize:(short)pageSize beginPageNum:(NSInteger)beginPageNum refreshingBlock:(void(^)(__kindof UIScrollView *scrollView, NSInteger requestPageNum))refreshingBlock;
@end

@interface SJRefreshOptions : NSObject
- (instancetype)initWithBeginPageNum:(NSInteger)beginPageNum pageSize:(short)pageSize disabledHeaderRefreshing:(BOOL)isDisabledHeaderRefreshing disabledFooterRefreshing:(BOOL)isDisabledFooterRefreshing refreshingExecuteBlock:(void(^)(__kindof UIScrollView *scrollView, NSInteger pageNum))refreshingExecuteBlock;
@property (nonatomic) NSInteger beginPageNum;
@property (nonatomic) short pageSize;
@property (nonatomic, getter=isDisabledHeaderRefreshing) BOOL disabledHeaderRefreshing;
@property (nonatomic, getter=isDisabledFooterRefreshing) BOOL disabledFooterRefreshing;
@property (nonatomic, copy, nullable) void(^refreshingExecuteBlock)(__kindof UIScrollView *scrollView, NSInteger pageNum);
@end

@interface UIScrollView (SJRefreshUIConfig)
@property (class, nonatomic, strong, readonly) SJRefreshConfig *sj_commonConfig;
@property (nonatomic, strong, readonly) SJRefreshConfig *sj_refreshConfig;
- (void)sj_updateRefreshConfig;
@end

@interface SJRefreshConfig : NSObject
@property (nonatomic, strong, nullable) UIColor *textColor;
@property (nonatomic, strong, nullable) UIFont *font;
@property (nonatomic, strong, nullable) UIImage *gifImage_header;
@property (nonatomic, strong, nullable) UIImage *gifImage_footer;
@property (nonatomic) CGFloat ignoredTopEdgeInset;
@property (nonatomic) CGFloat ignoredBottomEdgeInset;
@end

@interface UIScrollView (SJPlaceholder)
@property (nonatomic, strong, readonly) SJPlaceholderView  *sj_placeholderView;
@end

@interface SJPlaceholderView : UIControl
@property (nonatomic, strong, readonly) UILabel *label;
@property (nonatomic) UIEdgeInsets insets;
@property (nonatomic, copy, nullable) void(^clickedBackgroundExeBlock)(SJPlaceholderView *view);
@end
NS_ASSUME_NONNULL_END
