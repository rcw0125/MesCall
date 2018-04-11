namespace MesCall
{
    using System.Configuration;

    public class MESIFDataConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("MESIFDatas", IsDefaultCollection=true)]
        public MESIFDataConfigElementCollection MESIFDatas
        {
            get
            {
                return (MESIFDataConfigElementCollection) base["MESIFDatas"];
            }
        }
    }
}

