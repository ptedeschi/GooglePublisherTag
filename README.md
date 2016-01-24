# Google Publisher Tag
Google Publisher Tag Control for Universal Windows Platform (UWP)

## Description ##
Due to the lack of an SDK to handle Google Advertising inside an Universal Windows Platform (UWP) app, this library  makes use of [Google Publisher Tag](https://support.google.com/dfp_sb/answer/1649768) by using the HTML and JavaScript [code](https://support.google.com/dfp_premium/answer/1638622) inside a control called <i>TagControl</i>.

## Install ##
To install Google Publisher Tag for UWP, run the following command in the Package Manager Console:  
<pre>PM > Install-Package GooglePublisherTag</pre>


## Code ##

Inside your XAML page, add inside <i>Page</i> statement:

    xmlns:controls="using:GooglePublisherTag

Put the control in the place you need:

    <controls:TagControl x:Name="tagControl" />

Now, at XAML page code behind, indicates to load the desired ad unit

    this.tagControl.Load("YOUR-AD-UNIT", 320, 50);