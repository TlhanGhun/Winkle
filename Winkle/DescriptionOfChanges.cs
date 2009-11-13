using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winkle
{
    public class DescriptionOfChanges : IComparable<DescriptionOfChanges>
    {
        public bool isBeta = false;

        public Version version;
        public string prettyName = "";
        public string updateName = "";
        public string updateDescription = "";

        public void setVersion(int major, int minor, int build, int revision)
        {
            version = new Version(major, minor, build, revision);
        }

        public string getFormattedVersionString()
        {
            if(version == null) {
                return "Not definded";
            }
            if(prettyName != "") {
                return prettyName + " (" + version.ToString() + ")";
            }
            else
            {
                return version.ToString();
            }
        }


        public int CompareTo(DescriptionOfChanges obj)
        {
            return this.version.CompareTo(obj.version);
        }

    }


}
