# Google Publisher Tag
Google Publisher Tag Control for Universal Windows Platform (UWP)

## Description ##
Due to the lack of an SDK to handle Google Advertising inside an Universal Windows Platform (UWP) app, this library  makes use of [Google Publisher Tag](https://support.google.com/dfp_sb/answer/1649768) by using the HTML and JavaScript [code](https://support.google.com/dfp_premium/answer/1638622) inside a control called <i>TagControl</i>.

## Install ##
To install Google Publisher Tag for UWP, run the following command in the Package Manager Console:  
<pre>PM > Install-Package GooglePublisherTag</pre>


## Code ##

When using Google Publisher Tag, your XAML file should look like this:

	<Page
	    x:Class="GooglePublisherTagSample.MainPage"
	    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
	    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
	    xmlns:local="using:GooglePublisherTagSample"
	    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
	    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
	    xmlns:controls="using:GooglePublisherTag"
	    mc:Ignorable="d">
	
	    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
	        <controls:TagControl x:Name="MyTagControl" Tag="/1234/travel/asia/food" Width="728" Height="90"/>
	    </Grid>
	</Page>
