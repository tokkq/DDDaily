   M S B A M L   `   `   `  ????G  CDailyProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:DailyProject.WeekDailyProject.Week  5      '    !DailyProject.Week.WeeklyWritePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:DailyProject.Week     5      -   5          N? 
FontFamily$  Meiryo)?5       N? FontSize$ 18(?5	       N? Title$ WeeklyWritePage??5       J? InputBindings 5      ?? 5   
    ?? Gesture$ Ctrl+S??6    ?? Command 6&   ?? *SaveCommand+.??5      ? ???	#FF323232.+?5   
   ?? .??5      ?? $??10,10,10,10q?6   .+?5      ?? -   5        $??2000/01/01～2000/01/01??5      
???????$??Center=?6L   $??24(?6i   $
??Bold"?6w   $??Meiryo)?6?   6?   ?? 5       J? Opacity$ 0Q?6   $??10??6(   ?? 5      $!??先週の良かったこと??6   
???????6-   ?? 5       ?? TextWrapping$
 Wrap=?6v   
??????????	#FF141414 ?? AcceptsReturn$
 True??6?   $??60??6?   $??5,5,5,5q?6?   ??6   ?? *WeeklyNoteInfo.GoodPoint+	 ?? Mode$	 TwoWay=?
 ?? UpdateSourceTrigger$
 PropertyChanged=?6?   ?? 5      $ 0Q?6   $??10??6(   ?? 5      $!??先週の変えたいこと??6   
???????6-   ?? 5      $
 Wrap=?6x   
??????????	#FF141414$
 True??6?   $??60??6?   $??5,5,5,5q?6?   ??6   ?? *WeeklyNoteInfo.ChangePoint+$	 TwoWay=?$
 PropertyChanged=?6?   ?? 5      $ 0Q?6   $??10??6(   ?? 5      $??今週の目標??6   
???????6)   ?? 5      $
 Wrap=?6s   
??????????	#FF141414$
 True??6?   $??60??6?   $??5,5,5,5q?6?   ??6   ?? *WeeklyNoteInfo.Target+$	 TwoWay=?$
 PropertyChanged=?6?   ?? 5       $ 0Q?6   $??10??6(   5"      5#      5$      5%      