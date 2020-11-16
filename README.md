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
  <li>Create an application-account on https://developers.facebook.com/apps to get an App ID.</li>
  <li>In Visual Studio add a reference to the .dll files (FbGraphApiWrapper.dll, Facebook.dll).</li>
  <li>Use the static login method<br>
   
 ```
LoginResult result = FacebookWrapper.FBService.Login( AppID, list of permission);
```
providing your AppID and the permissions required from your app's user to display a login form to
your user.<br>
<b>For the list of permission, see this</b> https://developers.facebook.com/docs/facebook-login/permissions.
 </li>
 <li>The return value of the Login method (LoginResult) has a LoggedInUser property
(of type FacebookWrapper.ObjectModel.User) which you should use in order to utilize your user's
data and actions
  <ul>
  <li>Data:<br>
   user.FirstName, user.LastName, user.Birthday, user.RelationshipStatus, etc.
   </li>
  <li>
   Relations to facebook objects:<br>
   user.Friends, user.FriendLists, user.Checkins, user.WallPosts, user.Events, user.Albums,
   user.Pokes, user.Videos, etc.<br>
   friend.FirstName, friend.LastName, friend.Albums, friend.Checkins, etc.<br>
   album.Photos, checkin.Comments, photo.Comments, photo.Tagged, photo.LikedBy, etc.
   </li>
  <li>
   Actions:<br>
   user.PostStatus(), user.PostPhoto(), user.CreateAlbum(), user.CreateFriendList(), etc.<br>
   album.UploadPhoto(), photo.Comment(), photo.Like(), status.Comment(), etc.
   </li>
</ul>
 <br>If the user failed to login or simply closed/canceled the login dialog, the result object will indicate
the error with the ErrorMessage property of the LoginResult object
</li>
<li>
 The return value of the Login method (LoginResult) also has a AccessToken property which holds
the AccessToken your app got in the Login process.<br>
 Use the static 'Connect' method, the AccessToken you got in the Login process, like such:
 
 ```
LoginResult result = FacebookWrapper.FBService.Connect(theAccessToken);
```
result.LoggedInUser will hold the User object with the logged in use data.
</li>
</ol> 

 # Resources:
 
 <ul>
  <li>
   Visit https://developers.facebook.com/docs/reference/api/ to understand more and get all the
   information about the Facebook Graph API.
</li>
  <li>
  Use the https://developers.facebook.com/tools/explorer application to browse data on facebook
  using the Graph API and understanding Jason.
</li>
</ul>

</body>
</html>





