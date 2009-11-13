using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winkle
{
    public class UpdateInfo
    {
        public bool updateInfoRetrievalSuccessfull = false;
        public bool updateIsBeta = false;

        public bool updateAvailable = false;

        public Version version;
        public string prettyName = "";

        public List<DescriptionOfChanges> changeLog;
        public System.Uri manualDownloadUrl;

        public int errorCode = 0;
        public string errorTitle = "";
        public string errorDescription = "";

    }
}
