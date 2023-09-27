//
//  SJPageMenuBarInterfaces.h
//  SJPageViewController
//
//  Created by BlueDancer on 2020/2/11.
//  Copyright © 2020 changsanjiang@gmail.com. All rights reserved.
//

#ifndef SJPageMenuBarInterfaces_h
#define SJPageMenuBarInterfaces_h
#import <UIKit/UIKit.h>
@protocol SJPageMenuItemView;

NS_ASSUME_NONNULL_BEGIN
@protocol SJPageMenuItemView <NSObject>
@property (nonatomic, getter=isFocusedMenuItem) BOOL focusedMenuItem;
@property (nonatomic, strong, null_resettable) UIColor *tintColor;
@property (nonatomic) CGFloat transitionProgress;
@end

@protocol SJPageMenuBarScrollIndicator <NSObject>

@end
NS_ASSUME_NONNULL_END
#endif /* SJPageMenuBarInterfaces_h */
