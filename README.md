# capstoneUsers

<p>This project contains a .cs file with many helpful classes and methods in order to communicate with Temple's Web Services</p>
```
Missing from this project (for obvious security reasons) are:
1)Links for web service calls that you will create 
NOTE:The Names for these web services are hardcoded in the TempleUser.cs page 
if you want them to say something else you will have to rename them
2)WSInfo class where you will store your username and password
```
##Classes
[LDAPuser](#ldapuser)<br/>
[Term](#term)<br/>
[StudentObj](#studentobj)<br/>
[College](#college)<br/>
[WebService](#webservice)<br/>

###LDAPuser
<p>This Class is used as the primary object for users in your system and holds the following properties</p>
<ul>
<li>string templeEduID (accessnet)</li>
<li>string uID (91XXXXXXX)</li>
<li>string cn (common name, first name)</li>
<li>string givenName (full Name)</li>
<li>string sn (Last Name)</li>
<li>string ediPersonAffiliation (unknown)</li>
<li>string eduPersonPrimaryAffiliation (unkown)</li>
<li>string mail (email)</li>
<li>string title (Temple Title)</li>
</ul>


[Back to Class List](#classes)<br/>

###Term
<p>This Class is the object to get Term information holds the following properties</p>
<ul>
<li>string termCode (Temple Given TermCode)</li>
<li>string termName (Name of Term)</li>
<li>string startDate (First Day of Term)</li>
<li>string endDate (Last Day of Term)</li>
<li>string registrationStartDate (Obvious)</li>
<li>string registrationEndDate (We cant help you anymore if you dont know what this is)</li>
</ul>
[Back to Class List](#classes)<br/>

###StudentObj
<p>This Class is used to create a Student object with more "Student" detail than LDAPuser</p>
<ul>
<li>string firstName (duh)</li>
<li>string middleInit (middle initial... not initialize)</li>
<li>string lastName (...)</li>
<li>string tuid (Temple ID number)</li>
<li>string email (EMAIL)</li>
<li>string school (school on record for student)</li>
<li>string major1 (primary major)</li>
<li>string major2 (another if applicable)</li>
</ul>
[Back to Class List](#classes)<br/>

###College
This is a simple class to give you organization for objects holding just the collegeName and collegeCode
[Back to Class List](#classes)<br/>

###WebService
<p>This static Class holds many helpful functions that are already built to interact with the web services provided to you.  below are a list of methods that can be called</p>
<ul>
<li>
```C#
getLDAPEntryByTUID()
```
</li>
<li>
```
getLDAPEntryByTUID()
```
</li>
</ul>
[Back to Class List](#classes)<br/>

