# capstoneUsers

<p>This project contains a .cs file with many helpful classes and methods in order to communicate with Temple's Web Services</p>
Contact the Authors @ [ElGrandeQueso@temple.edu](http://tumail.temple.edu)</br>
or<br/>
@ [gandalf.the.grey@temple.edu](http://tumail.temple.edu)</br>
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
This is a simple class to give you organization for objects holding just the collegeName and collegeCode <br/>
[Back to Class List](#classes)<br/>

###WebService
<p>This static Class holds many helpful functions that are already built to interact with the web services provided to you.  below are a list of methods that can be called</p>
<ul>
<li>getLDAPEntryByTUID(string templeID)</li>
<p>this method takes in a Temple users ID (91xxxxxxx) and returns an LDAPuser object with all known properties</p>
<li>getLDAPEntryByAccessnet(string accessnet)</li>
<p>this method takes in a Temple users AccessNet and returns an LDAPuser object with all known properties</p>
<li>getLDAPEntryByEmailAlias(string email)</li>
<p>this method takes in an email address and returns the LDAPuser object with all known properties</p>
<li>getCurrentTerm()</li>
<p>this method returns the current term that we are in</p>
<li>getTermByTermCode(string termCode)</li>
<p>this method takes in a termCode and returns a Term object associated with it</p>
<li>GetTermByDate(string date)</li>
<p>this method takes in a date (string) and returns a Term object associated with it</p>
<li>getAllColleges()</li>
<p>returns an array of all colleges as College Objects</p>
<li>getCollegeNameByCollegeCode(string CollegeCode)</li>
<p>this method takes in a CollegeCode and returns a string of CollegeName</p>
<li>getStudentInfo(string TUID)</li>
<p>this method takes in a Temple users ID (91xxxxxxx) and returns a student object with all known properties</p>
<li>getFacultyTitleByTUID(string TUID)</li>
<p>this method takes in a Temple users ID (91xxxxxxx) and returns a string of the title of that faculty member</p>
</ul>
[Back to Class List](#classes)<br/>

