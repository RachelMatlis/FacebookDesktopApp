<!DOCTYPE html>
<html>
<head>
 
# Facebook desktop application using Facebook SDK and FbGraphApiWrapper

<p>The purpose of the project is to study and practice work with API, design patterns, object oriented programming and multi-threading programming.</p>

<p>Facebook desktop application is a winForms application that communicates with Facebook and provides basic features like
post new status, change profile/cover picture, displays active user profile data (full name, posts, profile/cover picturs, birthday date, etc..) 
and displays user lists like frinds, events, check-ins, etc...</p>

<p>In addition the appliction includes two unique features which is described below.</p>

 # Unique Features Description:
  
<h3>1. Find friends by Check-in tags: </h3>
<p>The user get the ability to discover which of his friends has visited a particular location and get essential information.</p>

<p>The feature displays a sorted check-ins list by location name of all the user’s friends.
The user can select a check-in from the list or search manually for a specific check-in.
After specified check-in name (picked from the list  or searched manually) a list of friends that checked-in in this particular location will appear. 
The user is able to select any friend from the list to get more information about the check- in such as: Date, description and photos that shared by the selected friend.</p>

<h3>2. Show most liked pictures: </h3>
The feature reveals to the user up to 6 pictures that received the highest number of likes out of all the pictures that the user has ever uploaded to Facebook.
In addition, the user can select one of the pictures and update it as a new profile picture or cover picture.

 
 # Implemented design patterns: 
 <p>Class Adapter, Singleton, Proxy, Iterator, Strategy and Template Method.</p>
 
<h3>Example of Singleton usage: </h3>
The pattern is activated during the log-in operation.<br>
Singleton is used in order to create <b>one instance</b> of the variable: 

``` 
User m_loggedInUser 
``` 
which contains data about the current logged-in user.
Singleton is necessary here since only one user is logged-in to the application, therefore  only one instance is required , additionally this instance has to live  until the end of the program.

 # Technologies used : 
  
  <ul>
  <li>.NET Framework 4</li>
  <li>C# 3</li>
  <li>FacebookAPI</li>
  <li>WinForms</li>
  <li>Visual Studio 2015</li>
</ul>

 # Usage: 
 
<ol>
  <li>Create an application-account on https://developers.facebook.com/apps</li>
  <li>Tea</li>
  <li>Milk</li>
</ol> 

</body>
</html>





