   M S B A M L   `   `   `  ????  	Kursovaya    Kursovaya.MenuBuhgalter   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $??18(?5   	      MaterialDesignFont#???   6     ? 
ResizeMode$  NoResize=?6I    ? WindowStartupLocation$ CenterScreen=?5   	    ? WindowStyle$
 None=?6.    ? AllowsTransparency . 
?????? $	??675??5	      $	??875??6'   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??1.22* ?6   .+?5   
   ?? ???#07BF96 ?? Padding$ 30q?6&    ?? CornerRadius$ 	25 0 0 25??63   $??	0,0,264,0q?6L   ?? 5   
   ???#ffffff$ 	0 10 10 0??6&   $??2??6?   $??	112,0,0,0q?6S   #  MaterialDesignThemes.Wpf.Card  5   
   .??5      ?? $	??Top=?6   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ 
PrimaryMid=?69    * &MaterialDesignNavigationRailTabControl#??[ 6j   $??
0,0,-462,0q?6?   .@?5      ?? $
??auto??6   ??5      ?? 5      $
??auto??6&   $
??auto??63   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon  $??24??67   $??24??6B   $??Center=?6N      Kind$ 
Airballoon=?6k   ?? 5      $??Center=?6(   $#??Экспорт отчетов??6E   $
??Wrap=?6\   $??94??6p   	 ?? TextAlignment$	 Center=?6{   5      .??5      ? .+?5        -   5        $ Close=?5   2   $	??Top=?6?   $??20??6W   $??20??6b   $??Right=?6n   $??	0 13 14 0q?6?   
 J? Opacity$	
 0.3Q?6?   6?     5      -   5        $ ArrowLeftBoldBoxOutline=?5   2   $	??Top=?6Q   $??20??6i   $??20??6t   $??Right=?6?   $??	0,13,34,0q?6?   $	
 0.3Q?6?   6?   5      5      ?? 5      $??88??6   ??5       ?? 5!      $
??auto??6&   $
??auto??64   .+?5"        $??24??67   $??24??6E   $??Center=?6S   $ Account=?6r   ?? 5#      $??Center=?6)   $??Профиль??6I   5$      .??5&      ? .+?5'        -   5        $ Close=?5'   2   $	??Top=?6?   $??20??6W   $??20??6b   $??Right=?6n   $??	0 13 14 0q?6?   $	
 0.3Q?6?   6?     5(      -   5        $ ArrowLeftBoldBoxOutline=?5(   2   $	??Top=?6Q   $??20??6i   $??20??6t   $??Right=?6?   $??	0,13,34,0q?6?   $	
 0.3Q?6?   6?   ?? 5)      $??Center=?6%   $??
64,43,34,0q?6@   $	??572??6T   .+?5*      ?? -   5         ??Name$ fam_sotr??5*   &   $??	0 0 0 1.5q?68   ???#C5C8CC)  #MaterialDesignThemes.Wpf.HintAssist   FloatingOffset$ 0,-20&?6j      Hint$ Фамилия??6?   $??Петров??6?    % !MaterialDesignFloatingHintTextBox#??[ 6?   ?? 5+      -   5        $??im_sotr??5+   &   $??	0 0 0 1.5q?65   ???#C5C8CC$ 0,-18&?6g   $ Имя??6?   $??Петр??6?   #??[ 6?   ?? 5,      -   5        $??	otch_sotr??5,   '   $??	0 0 0 1.5q?68   ???#C5C8CC$ 0,-18&?6j   $ Отчество??6?   $??Сергеевич??6?   #??[ 6?   (  "System.Windows.Controls.DatePicker  5-      -   5        $??	date_sotr??5-   *   $??	0 0 0 1.5q?6;   ???#C5C8CC$ Дата рождения??6n   $ 0,-18&?6?      Text$ 
05.05.1975??6?   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#??[ 6  ?? 5.      -	   5        $??tel_sotr??5.   '    ?? 	MaxLength$ 12??67   $??	0 0 0 1.5q?6F   ???#C5C8CC$ 0,-18&?6x   $! Номер телефона??6?   $??+79997892345??6?   #??[ 6?   ?? 5/      -
   5        $??	mail_sotr??5/   &   $??	0 0 0 1.5q?67   ???#C5C8CC$ 0,-18&?6i   $ E-mail??6?   $??petrov123@mail.ru??6?   #??[ 6?   ?? 50      -   5        $??log_sotr??50   '   $??	0 0 0 1.5q?67   ???#C5C8CC$ 0,-18&?6i   $ 
Логин??6?   $??John.Doe_am??6?   #??[ 6?   G? 51      -   5        $??passwd_sotr??51   +   $??	0 0 0 1.5q?6>   ???#C5C8CC$ 0,-18&?6p   $ Пароль??6?    G? Password$ 
1234567890??6?    ) %MaterialDesignFloatingHintPasswordBox#??[ 6?   ?? 52      -   5        $??Сохранить??52   %   ???#05B790???#ffffff$??18(?6c   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 22??6q   $??45??6?   $??186,100,227,0q?6?   6?   53      54      55      56      57      58      59      