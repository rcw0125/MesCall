namespace MesCall
{
    using System;
    using System.Configuration;
    using System.Reflection;

    public class MESIFDataConfigElementCollection : ConfigurationElementCollection
    {
        public void Add(MESIFDataConfigElement element)
        {
            this.BaseAdd(element);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element, false);
        }

        public void Clear()
        {
            base.BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new MESIFDataConfigElement();
        }

        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new MESIFDataConfigElement(elementName);
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MESIFDataConfigElement) element).Type;
        }

        public int IndexOf(MESIFDataConfigElement element)
        {
            return base.BaseIndexOf(element);
        }

        public void Remove(MESIFDataConfigElement element)
        {
            if (base.BaseIndexOf(element) >= 0)
            {
                base.BaseRemove(element.Type);
            }
        }

        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }

        public string AddElementName
        {
            get
            {
                return base.AddElementName;
            }
            set
            {
                base.AddElementName = value;
            }
        }

        public string ClearElementName
        {
            get
            {
                return base.ClearElementName;
            }
            set
            {
                base.ClearElementName = value;
            }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        public int Count
        {
            get
            {
                return base.Count;
            }
        }

        public MESIFDataConfigElement this[int index]
        {
            get
            {
                return (MESIFDataConfigElement) base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        public MESIFDataConfigElement this[string name]
        {
            get
            {
                return (MESIFDataConfigElement) base.BaseGet(name);
            }
        }

        public string RemoveElementName
        {
            get
            {
                return base.RemoveElementName;
            }
        }
    }
}

