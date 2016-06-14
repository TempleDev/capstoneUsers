
//    __                     __
//   /  /___________________ \  \
//  /  / |   ____    ____   | \  \
// /  /  |___|   |   |   |__|  \  \
///  /           |   |          \  \
//\  \           |   |          /  /
// \  \          |   |         /  /
//  \  \      _  |   |  _     /  /
//   \__\    | |_|   |_| |   /__/
//           |___________|   
//This code was collected and complied for the use oF the Temple University 
//Capstone 2 teams and the CE Systems Development team.
//    Authors: Kyler Love, Robert Zahorchak, Armond Smith
//    Project Title: TempleLDAPEntry
//    Description: This is a LDAP object class to use with the LDAP login entries
//   

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempleUser
{
    /// <summary>
    /// Class to create an LDAP User.  Also, due to the lack of Faculty Web service calls, this will be the primary object for
    /// Faculty Login
    /// </summary>
    public class LDAPuser
    {
        public string templeEduID;
        public string uID;
        public string cn;
        public string givenName;
        public string sn;
        public string eduPersonAffiliation;
        public string eduPersonPrimaryAffiliation;
        public string mail;
        public string title;
    }

    /// <summary>
    /// Class for identifying Term
    /// </summary>
    public class Term
    {
        public string termCode;
        public string termName;
        public string startDate;
        public string endDate;
        public string registrationStartDate;
        public string registrationEndDate;
    }

    /// <summary>
    /// Student Object 
    /// </summary>
    public class StudentObj
    {
        public string firstName { get; set; }
        public string middleInit { get; set; }
        public string lastName { get; set; }
        public string tuid { get; set; }
        public string email { get; set; }
        public string school { get; set; }
        public string major1 { get; set; }
        public string major2 { get; set; }

        public StudentObj() { }

        //Big ol' constructor
        public StudentObj(string firstName, string middleInit, string lastName, string tuid, string email, string school, string major1, string major2)
        {
            this.firstName = firstName;
            this.middleInit = middleInit;
            this.lastName = lastName;
            this.tuid = tuid;
            this.email = email;
            this.school = school;
            this.major1 = major1;
            this.major2 = major2;
        }
    }

    /// <summary>
    /// Class to hold College Info
    /// </summary>
    public class College
    {
        public string collegeName;
        public string collegeCode;
    }


    //    __                     __
    //   /  /___________________ \  \
    //  /  / |   ____    ____   | \  \
    // /  /  |___|   |   |   |__|  \  \
    ///  /           |   |          \  \
    //\  \           |   |          /  /
    // \  \          |   |         /  /
    //  \  \      _  |   |  _     /  /
    //   \__\    | |_|   |_| |   /__/
    //           |___________|   
    //This code was collected and complied for the use oF the Temple University 
    //Capstone 2 teams and the CE Systems Development team.
    //    Authors: Kyler Love, Robert Zahorchak, 
    // This is a helper class for Web Service requests
    //----------------------------------------------------------------------------------------------------
    // Example of Use
    //
    //      LDAPuser result = WebService.getLDAPEntryByAccessnet("tue71468");
    //     or
    //      LDAPuser result = WebService.getLDAPEntryByTUID("915006167");
    //
    // The 'result' variable will contain all info listed in the Web Services document on BB
    //----------------------------------------------------------------------------------------------------
    // Get the user's listed email address:
    //
    //      string emailAddress = result.mail;
    //----------------------------------------------------------------------------------------------------
    //
    /// <summary>
    /// This is a helper class for Web Service requests
    /// </summary>
    public static class WebService
        {
            private static string webServiceUsername = WSInfo.webServiceUsername;
            private static string webServicePassword = WSInfo.webServicePassword;

            /// <summary>
            /// Creates a LDAPuser (Person Object) when passing a TUID
            /// </summary>
            /// <param name="tuID">TUID</param>
            /// <returns>LDAPuser</returns>
            public static LDAPuser getLDAPEntryByTUID(string tuID)
            {
                // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
                WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
                WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
                results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUID", tuID);
                WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

                // Check if request was successful
                if (resultEntry.result == null) // Success
                {
                    // Create our TempleLDAPEntry object to be returned
                    LDAPuser personLDAPEntry = new LDAPuser();
                    personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
                    personLDAPEntry.uID = resultEntry.uid;
                    personLDAPEntry.cn = resultEntry.cn;
                    personLDAPEntry.givenName = resultEntry.givenName;
                    personLDAPEntry.sn = resultEntry.sn;
                    personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
                    personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
                    personLDAPEntry.mail = resultEntry.mail;
                    personLDAPEntry.title = resultEntry.title;
                    return personLDAPEntry;
                }
                else // Something went wrong..
                {
                    return null;
                }
            }

            /// <summary>
            /// Takes in an accessnet and returns an LDAPuser (Person Object) based on that AccessnetID
            /// </summary>
            /// <param name="accessnetID"></param>
            /// <returns>LDAPuser</returns>
            public static LDAPuser getLDAPEntryByAccessnet(string accessnetID)
            {
                // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
                WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
                WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
                results = ldapProxy.Search(webServiceUsername, webServicePassword, "uid", accessnetID);
                WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

                // Check if request was successful
                if (resultEntry.result == null) // Success
                {
                    // Create our TempleLDAPEntry object to be returned
                    LDAPuser personLDAPEntry = new LDAPuser();
                    personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
                    personLDAPEntry.uID = resultEntry.uid;
                    personLDAPEntry.cn = resultEntry.cn;
                    personLDAPEntry.givenName = resultEntry.givenName;
                    personLDAPEntry.sn = resultEntry.sn;
                    personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
                    personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
                    personLDAPEntry.mail = resultEntry.mail;
                    personLDAPEntry.title = resultEntry.title;
                    return personLDAPEntry;
                }
                else // Something went wrong..
                {
                    return null;
                }
            }

            /// <summary>
            /// Takes in an Email and returns a LDAP Object(Person Object) of that User
            /// </summary>
            /// <param name="emailAlias"></param>
            /// <returns>LDAPuser</returns>
            public static LDAPuser getLDAPEntryByEmailAlias(string emailAlias)
            {
                // Split the email address and get the contents before the @
                string[] splitEmailAlias = emailAlias.Split('@');
                string templeEduTUNA = splitEmailAlias[0];

                // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
                WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
                WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
                results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUNA", templeEduTUNA);
                WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

                // Check if request was successful
                if (resultEntry.result == null) // Success
                {
                    // Create our TempleLDAPEntry object to be returned
                    LDAPuser personLDAPEntry = new LDAPuser();
                    personLDAPEntry.templeEduID = resultEntry.templeEduTUID;
                    personLDAPEntry.uID = resultEntry.uid;
                    personLDAPEntry.cn = resultEntry.cn;
                    personLDAPEntry.givenName = resultEntry.givenName;
                    personLDAPEntry.sn = resultEntry.sn;
                    personLDAPEntry.eduPersonAffiliation = resultEntry.eduPersonAffiliation;
                    personLDAPEntry.eduPersonPrimaryAffiliation = resultEntry.eduPersonPrimaryAffiliation;
                    personLDAPEntry.mail = resultEntry.mail;
                    personLDAPEntry.title = resultEntry.title;
                    return personLDAPEntry;
                }
                else // Something went wrong..
                {
                    return null;
                }
            }

            /// <summary>
            /// Gets the Current Term of the Current Date
            /// </summary>
            /// <returns>Term Object</returns>
            public static Term getCurrentTerm()
            {
                WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
                WS_StudentSearch.Result results = new WS_StudentSearch.Result();
                results = studentProxy.GetCurrentTerm(webServiceUsername, webServicePassword);

                // Check if request was successful
                if (results.Status == "OK") // Success
                {
                    Term returnTerm = new Term();
                    WS_StudentSearch.Term[] t = results.Terms;
                    returnTerm.termCode = t[0].code;
                    returnTerm.termName = t[0].name;
                    returnTerm.startDate = t[0].startDate;
                    returnTerm.endDate = t[0].endDate;

                    return returnTerm;
                }
                else // Something went wrong...
                {
                    return null;

                }
            }

            /// <summary>
            /// Takes in a Terms Code and returns the Term Object associated with it
            /// </summary>
            /// <param name="termCode"></param>
            /// <returns>Term Object</returns>
            public static Term getTermByTermCode(string termCode)
            {
                WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
                WS_StudentSearch.Result results = new WS_StudentSearch.Result();
                results = studentProxy.GetTermByTermCode(webServiceUsername, webServicePassword, termCode);

                // Check if request was successful
                if (results.Status == "OK") // Success
                {
                    Term returnTerm = new Term();
                    WS_StudentSearch.Term[] t = results.Terms;
                    returnTerm.termCode = t[0].code;
                    returnTerm.termName = t[0].name;
                    returnTerm.startDate = DateTime.Parse(t[0].startDate).ToShortDateString().ToString();
                    returnTerm.endDate = DateTime.Parse(t[0].endDate).ToShortDateString().ToString();
                    return returnTerm;
                }
                else // Something went wrong...
                {
                    return null;

                }
            }

            /// <summary>
            /// Takes in a Date and returns the Term it is in
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            public static Term GetTermByDate(string date)
            {
                WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
                WS_StudentSearch.Result results = new WS_StudentSearch.Result();
                results = studentProxy.GetTermByDate(webServiceUsername, webServicePassword, date);

                // Check if request was successful
                if (results.Status == "OK") // Success
                {
                    Term returnTerm = new Term();
                    WS_StudentSearch.Term[] t = results.Terms;
                    returnTerm.termCode = t[0].code;
                    returnTerm.termName = t[0].name;
                    returnTerm.startDate = t[0].startDate;
                    returnTerm.endDate = t[0].endDate;

                    return returnTerm;
                }
                else // Something went wrong...
                {
                    return null;

                }
            }

            /// <summary>
            /// Returns an array of all colleges
            /// </summary>
            /// <returns></returns>
            public static College[] getAllColleges()
            {
                try
                {
                    WS_ProgramsAndDegrees.ProgramsAndDegrees programsProxy = new WS_ProgramsAndDegrees.ProgramsAndDegrees();
                    WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[] results = new WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[30];
                    results = programsProxy.GetAllColleges(webServiceUsername, webServicePassword);

                    College[] colleges = new College[results.Length];

                    for (int i = 0; i < results.Length; i++)
                    {
                        College c = new College();
                        c.collegeName = results[i].college.ToString();
                        c.collegeCode = results[i].collegeCode.ToString();
                        colleges[i] = c;
                    }

                    return colleges;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            /// <summary>
            /// Takes in a College Code and returns a Name Identified by that Code
            /// </summary>
            /// <param name="collegeCode"></param>
            /// <returns></returns>
            public static string getCollegeNameByCollegeCode(string collegeCode)
            {
                try
                {
                    WS_ProgramsAndDegrees.ProgramsAndDegrees programsProxy = new WS_ProgramsAndDegrees.ProgramsAndDegrees();
                    WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[] results = new WS_ProgramsAndDegrees.ProgramsAndDegreesEntry[30];
                    results = programsProxy.GetAllColleges(webServiceUsername, webServicePassword);

                    foreach (WS_ProgramsAndDegrees.ProgramsAndDegreesEntry entry in results)
                    {
                        if (entry.collegeCode.Equals(collegeCode))
                        {
                            return entry.college;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }

                return null;
            }

            /// <summary>
            /// takes in a TUID and creates a StudentObj with Full name, Email, TUID, Major, and College Code
            /// </summary>
            /// <param name="TUID"></param>
            /// <returns></returns>
            public static StudentObj getStudentInfo(string TUID)
            {
                //////// Get LDAP Info
                StudentObj student = new StudentObj();
                TempleLDAPEntry entry = getLDAPEntryByTUID(TUID);

                if (entry != null)
                {
                    String[] name = entry.cn.Split(null); // splits 'cn' into first, middle, last

                    if (name.Length == 2) // No middle initial
                    {
                        student.firstName = name[0];
                        student.middleInit = "";
                        student.lastName = name[1];
                    }
                    else if (name.Length == 3) // Has middle initial
                    {
                        student.firstName = name[0];
                        student.middleInit = name[1];
                        student.lastName = name[2];
                    }
                    else if (name.Length == 4) // Special case for people with 4 part names
                    {
                        student.firstName = name[0];
                        student.middleInit = name[1] + " " + name[2];
                        student.lastName = name[3];
                    }

                    student.email = entry.mail;
                    student.tuid = entry.templeEduID;

                    //////// Get Academic Info
                    WS_StudentSearch.WS_Student studentProxy = new WS_StudentSearch.WS_Student();
                    WS_StudentSearch.Result results = new WS_StudentSearch.Result();
                    results = studentProxy.GetAcademicInfoByTUID(webServiceUsername, webServicePassword, TUID);

                    // Check if request was successful
                    if (results.Status == "OK") // Success
                    {
                        WS_StudentSearch.Student[] s = results.Students;
                        student.major1 = s[0].major1;
                        student.major2 = s[0].major2;
                        student.school = s[0].collegeCode;

                    }
                    else // Something went wrong...
                    {
                        return null;
                    }
                }

                return student;
            }

            /// <summary>
            /// takes in a faculty TUID and returns a string of the title(ie. Employee, Faculty) they hold
            /// </summary>
            /// <param name="TUID"></param>
            /// <returns>String</returns>
            public static String getFacultyTitleByTUID(string TUID)
            {
                // Create the WebService proxy, send the search request and receive the TempleLDAPEntry object
                WS_LDAPSearch.LDAP_Search ldapProxy = new WS_LDAPSearch.LDAP_Search();
                WS_LDAPSearch.TempleLDAPEntry[] results = new WS_LDAPSearch.TempleLDAPEntry[1];
                results = ldapProxy.Search(webServiceUsername, webServicePassword, "templeEduTUID", TUID);
                WS_LDAPSearch.TempleLDAPEntry resultEntry = results[0];

                // Check if request was successful
                if (resultEntry.result == null) // Success
                {
                    string[] affiliations = resultEntry.eduPersonAffiliation.Split(',');
                    foreach (string s in affiliations)
                    {
                        if (s.Equals("faculty"))
                        {
                            return resultEntry.title;
                        }
                    }

                    return null;
                }
                else // Something went wrong..
                {
                    return null;
                }
            }


        }

    
}
