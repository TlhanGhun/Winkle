using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;

namespace Winkle
{
    public class VersionCheck
    {
        private string winkleVersion = "0.2";
        private XmlDocument WinkleResponse = new XmlDocument();
        public string errorCode = "";
        public string versionToUse = "CurrentStableVersion";
        public bool showWindowIfUpdateAvailable = true;
        private string applicatenName = "";
        private string updateInfoUrl = "";
        private List<DescriptionOfChanges> changeLog = new List<DescriptionOfChanges>();


        public VersionCheck(string appName, string updateUrl)
        {
            applicatenName = appName;
            updateInfoUrl = updateUrl;

        }

        public UpdateInfo checkForUpdate(Version version, bool includeBetaVersions)
        {
            return _doUpdateCheck(version, includeBetaVersions);
        }

        public UpdateInfo checkForUpdate(System.Reflection.Assembly assembly, bool includeBetaVersions) 
        {
                Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return _doUpdateCheck(v, includeBetaVersions);
        }

        public UpdateInfo checkForUpdate(int currentMajorVersion, int currentMinorVersion, int currentBuild, int currentRevision, bool includeBetaVersions) 
        {
            Version currentVersion = new Version(currentMajorVersion, currentMinorVersion, currentBuild, currentRevision);
            return _doUpdateCheck(currentVersion, includeBetaVersions);
        }

        private UpdateInfo _doUpdateCheck(Version currentVersion, bool includeBetaVersions) {
            UpdateInfo returnCode = new UpdateInfo();
            WinkleResponse = getUpdateFile(updateInfoUrl);
            if (WinkleResponse == null)
            {
                returnCode.errorCode = 1;
                returnCode.updateInfoRetrievalSuccessfull = false;
                returnCode.errorTitle = "Retrieval of update information failed";
                returnCode.errorDescription = "Cannot download the update file description from " + updateInfoUrl;
                return returnCode;
            }

            Version newestAvailableVersion = currentVersion;
            bool updateAvailable = false;

            getChangeLog(false,currentVersion);
            changeLog.Sort();
            changeLog.Reverse();
            if(changeLog.Count > 0) 
            {
                newestAvailableVersion = changeLog[0].version;
            }

            if (includeBetaVersions)
            {
                getChangeLog(true, newestAvailableVersion);
            }

            changeLog.Sort();
            changeLog.Reverse();
            if (changeLog.Count > 0)
            {
                newestAvailableVersion = changeLog[0].version;
                updateAvailable = true;
            }

            if (updateAvailable)
            {
                returnCode.updateAvailable = true;
                returnCode.updateInfoRetrievalSuccessfull = true;
                returnCode.version = newestAvailableVersion;
                returnCode.prettyName = changeLog[0].prettyName;
                
                returnCode.manualDownloadUrl = new System.Uri(getDownloadLinkUrl(includeBetaVersions));

                if(showWindowIfUpdateAvailable) {
                    Winkle.UpdateNotification myUpdateNotification = new UpdateNotification();
                    
                    myUpdateNotification.setDownloadLink(returnCode.manualDownloadUrl.ToString());
                    string myDescription = "";
                    
                    
                    foreach (DescriptionOfChanges myChanges in changeLog) {
                            myDescription += myChanges.getFormattedVersionString() + "\n";
                            myDescription += myChanges.updateDescription;
                            myDescription += "\n============================================\n";
                    }
                    myUpdateNotification.setVersion(applicatenName, newestAvailableVersion.ToString());
                    myUpdateNotification.setShortDescription(applicatenName,newestAvailableVersion.ToString(),currentVersion); 
                    myUpdateNotification.setDescription(myDescription);
                    myUpdateNotification.Show();
                }

                return returnCode;
            }

            returnCode.updateInfoRetrievalSuccessfull = true;
            return returnCode;
        }

        private int getLatestMajorVersion(bool includeBetaVersion)
        {
            return getSingleVersionNumber("Major", includeBetaVersion);
        }

        private int getVersion(XmlNode currentNode, string type)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(currentNode[type].InnerText);
            }
            finally
            {
               
            }
            return number;
        }

        private string getPrettyName(XmlNode currentNode)
        {
            string prettyName = "";
            try
            {
                prettyName = currentNode["PrettyName"].InnerText;
            }
            finally
            {

            }
            return prettyName;
        }

        private int getLatestMinorVersion(bool includeBetaVersion)
        {
            return getSingleVersionNumber("Minor", includeBetaVersion);
        }

        private int getLatestBuild(bool includeBetaVersion)
        {
            return getSingleVersionNumber("Build", includeBetaVersion);
        }

        private int getLatestRevision(bool includeBetaVersion)
        {
            return getSingleVersionNumber("Revision", includeBetaVersion);
        }

        private int getSingleVersionNumber(string partOfNumber, bool includeBetaVersion)
        {
            string stringForNumber = WinkleResponse.SelectNodes("Winkle/StableVersions/StableVersion/" + partOfNumber).Item(0).InnerText;
            int returnCode = 0;
            try
            {
                returnCode = Convert.ToInt32(stringForNumber);
            }
            catch (Exception e)
            {
                errorCode = "Error parsing update file - cannot parse " + partOfNumber + " version: " + e.Message;
            }
            return returnCode;
        }

        private string getDownloadLinkUrl(bool includeBetaVersion)
        {
            return WinkleResponse.SelectNodes("Winkle/StableVersions/StableVersion/UpdateFileUrl").Item(0).InnerText;
        }


        private string getUpdateDescription(bool includeBetaVersion)
        {
            return WinkleResponse.SelectNodes("Winkle/StableVersions/StableVersion/NewInThisVersion").Item(0).InnerText;
        }

        private void getChangeLog(bool includeBeta, Version minVersion) {
            try
            {
                XmlNodeList allChanges;
                if (!includeBeta)
                {
                    try 
                    {
                        allChanges = WinkleResponse.SelectNodes("Winkle/StableVersions/StableVersion");
                    }
                    catch
                    {
                        allChanges = null;
                    }
                }
                else
                {
                    try
                    {
                        allChanges = WinkleResponse.SelectNodes("Winkle/BetaVersions/BetaVersion");
                    }
                    catch
                    {
                        allChanges = null;
                    }
                }

                if (allChanges == null)
                {
                    return;
                }
                foreach (XmlNode thisChange in allChanges)
                {
                    try
                    {
                        Version localVersion = new Version(getVersion(thisChange, "Major"), getVersion(thisChange, "Minor"), getVersion(thisChange, "Build"), getVersion(thisChange, "Revision"));

                        if (localVersion < minVersion)
                        {
                            continue;
                        }

                        DescriptionOfChanges thisVersion = new DescriptionOfChanges();
                        thisVersion.updateDescription = thisChange["NewInThisVersion"].InnerText;
                        thisVersion.version = localVersion;
                        thisVersion.prettyName = getPrettyName(thisChange);
                        changeLog.Add(thisVersion);
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private XmlDocument getUpdateFile(string updateUrl)
        {
            XmlDocument Winkle_XMLdoc = null;
            if(updateUrl.StartsWith("file",true,System.Globalization.CultureInfo.CurrentCulture)) {
                FileWebRequest Winkle_Request;
                FileWebResponse Winkle_Response = null;
                
                try
                {
                    Winkle_Request = (FileWebRequest)WebRequest.Create(string.Format(updateUrl));
                    //Winkle_Request.UserAgent = @"Winkle automatic update system " + winkleVersion;
                    Winkle_Response = (FileWebResponse)Winkle_Request.GetResponse();
                    Winkle_XMLdoc = new XmlDocument();
                    Winkle_XMLdoc.Load(Winkle_Response.GetResponseStream());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (Winkle_Response != null)
                {
                    Winkle_Response.Close();
                }
            }
            else 
            {
                   HttpWebRequest Winkle_Request;
                   HttpWebResponse Winkle_Response = null;
                    
                    try
                    {
                        Winkle_Request = (HttpWebRequest)WebRequest.Create(string.Format(updateUrl));
                        Winkle_Request.UserAgent = @"Winkle automatic update system " + winkleVersion;
                        Winkle_Response = (HttpWebResponse)Winkle_Request.GetResponse();
                        Winkle_XMLdoc = new XmlDocument();
                        Winkle_XMLdoc.Load(Winkle_Response.GetResponseStream());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (Winkle_Response != null)
                    {
                        Winkle_Response.Close();
                    }
                }
        
            return Winkle_XMLdoc;
        }
    }
}
