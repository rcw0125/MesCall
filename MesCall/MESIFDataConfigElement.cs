namespace MesCall
{
    using System;
    using System.Configuration;

    public class MESIFDataConfigElement : ConfigurationElement
    {
        public MESIFDataConfigElement()
        {
        }

        public MESIFDataConfigElement(string type)
        {
        }

        public MESIFDataConfigElement(string type, string target, string method)
        {
        }

        [ConfigurationProperty("method", IsRequired=true)]
        public string Method
        {
            get
            {
                return (string) base["method"];
            }
            set
            {
                base["method"] = value;
            }
        }

        [ConfigurationProperty("target", IsRequired=true)]
        public string Target
        {
            get
            {
                return (string) base["target"];
            }
            set
            {
                base["target"] = value;
            }
        }

        [ConfigurationProperty("type", IsKey=true, IsRequired=true), StringValidator(InvalidCharacters="~!@#$%^&*()[]{}/;'\"|\\", MinLength=0, MaxLength=60)]
        public string Type
        {
            get
            {
                return (string) base["type"];
            }
            set
            {
                base["type"] = value;
            }
        }
    }
}

